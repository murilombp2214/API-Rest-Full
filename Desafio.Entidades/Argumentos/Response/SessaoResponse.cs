using Desafio.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Entidades.Argumentos.Response
{
    public class SessaoResponse : BaseResponse
    {
        public Guid CodigoPessoa { get; set; }
        public DateTime InicioSessao { get; set; }
    }
}
