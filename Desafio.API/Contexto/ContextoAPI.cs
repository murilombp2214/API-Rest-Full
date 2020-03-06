using Desafio.Repositorio.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.API.Contexto
{
    public class ContextoAPI : DesafioContexto<ContextoAPI>
    {
        public ContextoAPI(DbContextOptions<ContextoAPI> options) : base(options)
        {

        }
    }
}
