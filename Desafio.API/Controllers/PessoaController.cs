using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Desafio.API.Contexto;
using Desafio.Entidades.Entidades;
using Desafio.Servicos.Base;
using Desafio.Entidades.Argumentos.Response;
using Desafio.Servicos;
using Desafio.Entidades.Argumentos.Request;
using Desafio.Utils.Conversor;

namespace Desafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private ServicoDePessoa<ContextoAPI> ServicoDePessoa { get; set; }
        private ServicoDeSessao<ContextoAPI> ServicoDeSessao { get; set; }
        public PessoaController(ContextoAPI context)
        {
            ServicoDePessoa = new ServicoDePessoa<ContextoAPI>(context);
            ServicoDeSessao = new ServicoDeSessao<ContextoAPI>(context);
        }

        
        [HttpGet]
        public List<PessoaResponse> Get(Guid codigoSessao)
        {
            try
            {
                ValideSessao(codigoSessao);
                return ServicoDePessoa.Consulte().ToList();
            }
            catch (Exception erro)
            {
                return new List<PessoaResponse>() { ErroPessoa(erro) };
            }
        }

        [HttpGet("ConsultePorCodigo/{codigo}")]
        public PessoaResponse Get(Guid codigoSessao, Guid codigo)
        {
            try
            {
                ValideSessao(codigoSessao);
                return ServicoDePessoa.Consulte(codigo);
            }
            catch (Exception erro)
            {

                return ErroPessoa(erro);
            }
        }

        [HttpGet("ConsultePorUF/{uf}")]
        public List<PessoaResponse> Get(Guid codigoSessao, string uf)
        {
            try
            {
                ValideSessao(codigoSessao);
                return ServicoDePessoa.Consulte(uf).ToList();
            }
            catch (Exception erro)
            {

                return new List<PessoaResponse>() { ErroPessoa(erro) };
            }
        }


        [HttpPost]
        public PessoaResponse Salve(PessoaRequest pessoa)
        {
            try
            {
                ValideSessao(pessoa.CodigoSessao);
                return ServicoDePessoa.CadastraEntidade(pessoa);
            }
            catch (Exception erro)
            {

                return ErroPessoa(erro);
            }
        }

        [HttpPut]
        public PessoaResponse Altere(PessoaRequest pessoa)
        {
            try
            {
                ValideSessao(pessoa.CodigoSessao);
                return ServicoDePessoa.AtualizarEntidade(pessoa);
            }
            catch (Exception erro)
            {

                return ErroPessoa(erro); throw;
            }
        }

        [HttpPut("Delete")]
        public PessoaResponse Delete(Guid codigoSessao, Guid codigoEntidade)
        {
            try
            {
                ValideSessao(codigoSessao);
                var pes = ServicoDePessoa.Consulte(codigoEntidade);
                if (pes.Erro)
                {
                    return pes;
                }

                pes.Ativo = false;
                return ServicoDePessoa.AtualizarEntidade(ConvertMap.Converta<PessoaResponse, PessoaRequest>(pes));
            }
            catch (Exception erro)
            {
                return ErroPessoa(erro);
            }
        }


        private void ValideSessao(Guid codigoSessao)
        {
            if(codigoSessao == Guid.Empty || ServicoDeSessao.Consulte(codigoSessao).Erro)
            {
                throw new Exception("Sessao invalida");
            }
        }

        private PessoaResponse ErroPessoa(Exception erro)
            => new PessoaResponse()
            {
                Erro = true,
                Alertas = {
                   Erros ={
                      erro.Message
                   }
                }
            };

    }
}
