using Desafio.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Entidades.Argumentos.Response
{
    public class PessoaResponse : BaseResponse
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string UF { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
