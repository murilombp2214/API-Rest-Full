using Desafio.Entidades.Base.Auxiliares;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Entidades.Base
{
    public class BaseResponse : BaseEntidade
    {
        /// <summary>
        /// Se verdadeiro o retorno possui erro
        /// </summary>
        public bool Erro { get; set; } = false;

        /// <summary>
        /// Se Erro == True o motivo do erro esta na propiedade alerta
        /// </summary>
        public Alerta Alertas { get; set; } = new Alerta();
    }
}
