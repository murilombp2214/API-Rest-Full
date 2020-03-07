using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Desafio.Entidades.Base
{
    public class BaseDB
    {
        /// <summary>
        /// id do cadastro da entidade atual
        /// </summary>
        [Key]
        public Guid Codigo { get; set; } = Guid.Empty;

        /// <summary>
        /// Indicador se esta ativo ou nãi
        /// </summary>
        public bool Ativo { get; set; } = true;
    }
}
