using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        BancoDeDados bancoDeDados = new BancoDeDados();
        public Form1()
        {
            InitializeComponent();

            var Nome = txtNome.Text;
            var Telefone = txtTelefone.Text;
            var Email = txtEmail.Text;
            var Endereco = txtEndereco.Text;
            var DataDeNascimento = txtDataNascimento.Text;
            var cargo = txtCargo.Text;
            var Empresa = txtEmpresa.Text;
            var DataContato = txtDataContato.Text;
            var Observacoes = txtObservacoes.Text;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            AtualizarListaContatos();
        }
        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (ValidarCamposObrigatorios())
            {
                Contato novoContato = ObterDadosDoFormulario();

                bancoDeDados.InserirContato(novoContato);

                LimparCampos();
                AtualizarListaContatos();
                lblResultado.Text = "Graças a des deu certo"; 
            }
            else
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (listViewContatos.SelectedItems.Count > 0)
            {
                if (ValidarCamposObrigatorios())
                {
                    Contato contatoAtualizado = ObterDadosDoFormulario();
                    contatoAtualizado.ID = Convert.ToInt32(listViewContatos.SelectedItems[0].Tag);

                    bancoDeDados.AtualizarContato(contatoAtualizado);

                    LimparCampos();
                    AtualizarListaContatos();
                }
                else
                {
                    MessageBox.Show(" por favor Preencha todos os campos obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("por favor Selecione um contato para atualizar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (listViewContatos.SelectedItems.Count > 0)
            {
                int idContato = Convert.ToInt32(listViewContatos.SelectedItems[0].Tag);

                bancoDeDados.ExcluirContato(idContato);

                LimparCampos();
                AtualizarListaContatos();
            }
            else
            {
                MessageBox.Show("Selecione um contato para excluir.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string termoPesquisa = txtPesquisa.Text;

            List<Contato> contatosPesquisados = bancoDeDados.PesquisarContatos(termoPesquisa);

            AtualizarListaContatos(contatosPesquisados);
        }

        private void AtualizarListaContatos(List<Contato> contatos = null)
        {
            listViewContatos.Items.Clear();

            List<Contato> contatosAtualizados = contatos ?? bancoDeDados.ConsultarContatos();

            foreach (Contato contato in contatosAtualizados)
            {
                ListViewItem item = new ListViewItem(contato.Nome);
                item.SubItems.Add(contato.Telefone);
                item.SubItems.Add(contato.Email);
                item.SubItems.Add(contato.Endereco);

                listViewContatos.Items.Add(item);
            }
        }



        private void LimparCampos()
        {
            txtNome.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            txtDataNascimento.Clear();
            txtDataNascimento.Clear();
            txtCargo.Clear();
            txtEmpresa.Clear();
            txtDataContato.Clear();
            txtObservacoes.Clear();
        }

        private bool ValidarCamposObrigatorios()
        {
            return !string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtTelefone.Text) && !string.IsNullOrEmpty(txtEmail.Text);
        }

    
    }
}