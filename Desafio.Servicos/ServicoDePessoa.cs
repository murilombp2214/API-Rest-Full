using Desafio.Entidades.Argumentos.Request;
using Desafio.Entidades.Argumentos.Response;
using Desafio.Entidades.Entidades;
using Desafio.Repositorio.Contexto;
using Desafio.Servicos.Base;
using Desafio.Utils.Conversor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio.Servicos
{
    public class ServicoDePessoa<Context> : ServicoBase<Context, Pessoa, PessoaRequest, PessoaResponse>
        where Context : DesafioContexto<Context>
    {
        public ServicoDePessoa(Context context) : base(context)
        {
        }

        public IEnumerable<PessoaResponse> Consulte(string uf)
        {
            foreach (var item in DBSet.Where(x => x.UF == uf).ToList())
            {
                yield return ConvertMap.Converta<Pessoa, PessoaResponse>(item);
            }
        }
    }
}
