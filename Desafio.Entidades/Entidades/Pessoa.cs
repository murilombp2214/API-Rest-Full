using Desafio.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio.Entidades.Entidades
{
    public class Pessoa : BaseDB
    {
        [MaxLength(150)]
        public string Nome { get; set; }
        [MaxLength(11)]
        public string CPF { get; set; }
        [MaxLength(2)]
        public string UF { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
