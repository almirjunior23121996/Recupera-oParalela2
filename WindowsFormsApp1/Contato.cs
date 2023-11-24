using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Contato
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string DataNascimento { get; set; }
        public string Cargo { get; set; }
        public string Empresa { get; set; }
        public string DataContato { get; set; }
        public string Observacoes { get; set; }

        private void ObterDadosDoFormulario(string Nome, string Telefone, string Email,string Endereco,string DataNascimento,string Cargo,string Empresa,string DataContato,string Observacoes)
        {
           
        }
    }
}
