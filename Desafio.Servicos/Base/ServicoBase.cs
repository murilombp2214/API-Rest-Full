using Desafio.Entidades.Base;
using Desafio.Repositorio.Contexto;
using Desafio.Utils.Conversor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio.Servicos.Base
{
    public class ServicoBase<Context,EntidadeBD,Request,Response>
        where Context : DesafioContexto<Context>
        where EntidadeBD : BaseDB
        where Request : BaseRequest
        where Response : BaseResponse
    {
        protected Context Contexto { get; set; }

        protected DbSet<EntidadeBD> DBSet { get => Contexto.Set<EntidadeBD>();  }
        public ServicoBase(Context context)
        {
            Contexto = context;
        }


        public virtual Response CadastraEntidade(Request request)
        {
            try
            {
                EntidadeBD entidade = ConvertMap.Converta<Request, EntidadeBD>(request);
                DBSet.Add(entidade);
                Contexto.SaveChanges();
                return ConvertMap.Converta<EntidadeBD, Response>(entidade);
            }
            catch (Exception erro)
            {
                Response response = Activator.CreateInstance<Response>();
                response.Erro = true;
                response.Alertas.Erros.Add(erro.Message);
                return response;
            }
        }


        public virtual Response AtualizarEntidade(Request request)
        {
            try
            {
                EntidadeBD entidade = DBSet.Find(request.Codigo);

                if (entidade is null)
                {
                    return ErrorResponse("Entidade não encontarda");
                }

                ConvertMap.Convert(request, entidade);
                return ConvertMap.Converta<EntidadeBD, Response>(entidade);
            }
            catch (Exception erro)
            {
                return ErrorResponse(erro.Message);
            }
        }

        public virtual IEnumerable<Response> Consulte()
        {
            foreach (var item in DBSet.OrderBy(x => x.Codigo).ToList())
            {
                yield return ConvertMap.Converta<EntidadeBD, Response>(item);
            }
        }



        public virtual Response Consulte(Guid codigo)
        {
            try
            {
                EntidadeBD obj = DBSet.FirstOrDefault(x => x.Codigo == codigo) ?? Activator.CreateInstance<EntidadeBD>();
                return ConvertMap.Converta<EntidadeBD, Response>(obj);
            }
            catch (Exception erro)
            {
                return ErrorResponse(erro.Message);
            }
        }


        private Response ErrorResponse(string erro)
        {
            Response response = Activator.CreateInstance<Response>();
            response.Erro = true;
            response.Alertas.Erros.Add(erro);
            return response;
        }


    }
}
