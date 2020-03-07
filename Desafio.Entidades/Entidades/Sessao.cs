using Desafio.Entidades.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Desafio.Entidades.Entidades
{
    public class Sessao : BaseDB
    {
        public Guid CodigoPessoa { get; set; }

        [ForeignKey("CodigoPessoa")]
        public Pessoa Pessoa { get; set; }
        public DateTime InicioSessao { get; set; }
    }
}
