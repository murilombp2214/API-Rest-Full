using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Entidades.Base
{
    public class BaseEntidade 
    {
        /// <summary>
        /// Id da sessão da requisição
        /// </summary>
        public Guid CodigoSessao { get; set; } = Guid.Empty;
        /// <summary>
        /// id do cadastro
        /// </summary>
        public Guid Codigo { get; set; } = Guid.Empty;
        /// <summary>
        /// Se a entidade em questão está ativa ou inativa
        /// </summary>
        public bool Ativo { get; set; } = false;

        /// <summary>
        /// Obtem o Json do objeto atual
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
