using Desafio.Entidades.Argumentos.Request;
using Desafio.Entidades.Argumentos.Response;
using Desafio.Entidades.Entidades;
using Desafio.Repositorio.Contexto;
using Desafio.Servicos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Servicos
{
    public class ServicoDeSessao<Context> : ServicoBase<Context, Sessao, SessaoRequest, SessaoResponse>
        where Context : DesafioContexto<Context>
    {
        public ServicoDeSessao(Context context) : base(context)
        {

        }

        public override SessaoResponse CadastraEntidade(SessaoRequest request)
        {
            SessaoResponse response = base.CadastraEntidade(request);
            if (!response.Erro)
            {
                response.CodigoSessao = response.Codigo;
            }

            return response;
        }
    }
}
