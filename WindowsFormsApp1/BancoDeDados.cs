using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class BancoDeDados
    {
        private string connectionString = ("Data Source=.\\SQLEXPRESS;Initial Catalog=Contatos;User ID=sa;Password=sql2022");

         public void InserirContato(Contato contato)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Contatos VALUES (@Nome, @Telefone, @Email, @Endereco, @DataNascimento, @Cargo, @Empresa, @DataContato, @Observacoes)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", contato.Nome);
                    command.Parameters.AddWithValue("@Telefone", contato.Telefone);
                    command.Parameters.AddWithValue("@Email", contato.Email);
                    command.Parameters.AddWithValue("@Endereco", contato.Endereco);
                    command.Parameters.AddWithValue("@DataNascimento", contato.DataNascimento);
                    command.Parameters.AddWithValue("@Cargo", contato.Cargo);
                    command.Parameters.AddWithValue("@Empresa", contato.Empresa);
                    command.Parameters.AddWithValue("@DataContato", contato.DataContato);
                    command.Parameters.AddWithValue("@Observacoes", contato.Observacoes);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarContato(Contato contato)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Contatos SET Nome = @Nome, Telefone = @Telefone, Email = @Email, Endereco = @Endereco, DataNascimento = @DataNascimento, Cargo = @Cargo, Empresa = @Empresa, DataContato = @DataContato, Observacoes = @Observacoes WHERE ID = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", contato.ID);
                    command.Parameters.AddWithValue("@Nome", contato.Nome);
                    command.Parameters.AddWithValue("@Telefone", contato.Telefone);
                    command.Parameters.AddWithValue("@Email", contato.Email);
                    command.Parameters.AddWithValue("@Endereco", contato.Endereco);
                    command.Parameters.AddWithValue("@DataNascimento", contato.DataNascimento);
                    command.Parameters.AddWithValue("@Cargo", contato.Cargo);
                    command.Parameters.AddWithValue("@Empresa", contato.Empresa);
                    command.Parameters.AddWithValue("@DataContato", contato.DataContato);
                    command.Parameters.AddWithValue("@Observacoes", contato.Observacoes);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void ExcluirContato(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Contatos WHERE ID = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Contato> ConsultarContatos()
        {
            List<Contato> contatos = new List<Contato>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Contatos";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        Contato contato = new Contato
                        {
                            ID = Convert.ToInt32(row["ID"]),
                            Nome = row["Nome"].ToString(),
                            Telefone = row["Telefone"].ToString(),
                            Email = row["Email"].ToString(),
                            Endereco = row["Endereco"].ToString(),
                            DataNascimento = row["DataNascimento"].ToString(),
                            Cargo = row["Cargo"].ToString(),
                            Empresa = row["Empresa"].ToString(),
                            DataContato = row["DataContato"].ToString(),
                            Observacoes = row["Observacoes"].ToString()
                        };

                        contatos.Add(contato);
                    }
                }
            }

            return contatos;
        }

        public List<Contato> PesquisarContatos(string termoPesquisa)
        {
            List<Contato> contatosPesquisados = new List<Contato>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Contatos WHERE Nome LIKE @TermoPesquisa OR Telefone LIKE @TermoPesquisa OR Email LIKE @TermoPesquisa";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@TermoPesquisa", "%" + termoPesquisa + "%");

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        Contato contato = new Contato
                        {
                            ID = Convert.ToInt32(row["ID"]),
                            Nome = row["Nome"].ToString(),
                            Telefone = row["Telefone"].ToString(),
                            Email = row["Email"].ToString(),
                            Endereco = row["Endereco"].ToString(),
                            DataNascimento = row["DataNascimento"].ToString(),
                            Cargo = row["Cargo"].ToString(),
                            Empresa = row["Empresa"].ToString(),
                            DataContato = row["DataContato"].ToString(),
                            Observacoes = row["Observacoes"].ToString()
                        };

                        contatosPesquisados.Add(contato);
                    }
                }
            }

            return contatosPesquisados;
        }
    }
}
