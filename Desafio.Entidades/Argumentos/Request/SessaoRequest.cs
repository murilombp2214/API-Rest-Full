using Desafio.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Entidades.Argumentos.Request
{
    public class SessaoRequest : BaseRequest
    {
        public Guid CodigoPessoa { get; set; }
        public DateTime InicioSessao { get; set; }
    }
}
