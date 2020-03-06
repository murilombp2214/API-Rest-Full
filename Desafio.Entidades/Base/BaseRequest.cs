using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Entidades.Base
{
    public abstract class BaseRequest : BaseEntidade
    {
        public virtual bool ValideEntidade()
        {
            return CodigoSessao != Guid.Empty;
        }
    }
}
