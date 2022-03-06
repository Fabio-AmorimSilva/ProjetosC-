using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro
{
    public class Usuario
    {

        public string Nome { get; set; }
        public int Cpf { get; set; }
        public int Idade { get; set; }
        public string Cidade { get; set; }

        public override string ToString()
        {
            return $"-- Dados do Usuário --"
                   +$"Nome: {this.Nome} "
                   +$"CPF: {this.Cpf}"
                   +$"Idade: {this.Idade}"
                   +$"Cidade: {this.Cidade}";

        }


    }
}
