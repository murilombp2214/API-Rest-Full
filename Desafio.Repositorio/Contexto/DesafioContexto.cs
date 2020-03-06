using Desafio.Entidades.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Repositorio.Contexto
{
    public class DesafioContexto<Derivada> : DbContext
        where Derivada : DesafioContexto<Derivada>
    {
        public DesafioContexto(DbContextOptions<Derivada> options) : base(options)
        {

        }
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
