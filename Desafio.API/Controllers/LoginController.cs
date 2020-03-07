using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.API.Contexto;
using Desafio.Entidades.Argumentos.Request;
using Desafio.Entidades.Argumentos.Response;
using Desafio.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ServicoDeSessao<ContextoAPI> ServicoDeSessao { get; set; }
        public LoginController(ContextoAPI context)
        {
            ServicoDeSessao = new ServicoDeSessao<ContextoAPI>(context);
        }
        [HttpPost]
        public SessaoResponse Login(string login, string senha)
        {
            try
            {
                if (login == "root" && senha == "123456")
                {
                    return ServicoDeSessao.CadastraEntidade(new SessaoRequest
                    {
                        CodigoPessoa = new Guid("8be7aef2-795d-42a2-8420-7d5ceefda727"),
                        Ativo = true,
                        InicioSessao = DateTime.Now,
                    });
                }

                throw new Exception("Ops.. login incorreto");
            }
            catch (Exception erro)
            {

                return new SessaoResponse
                {
                    Erro = true,
                    Alertas = {
                    Erros = {
                        erro.Message
                    }
                  }
                };
            }

        }


        private void Init(ContextoAPI context)
        {
            var servPessoa = new ServicoDePessoa<ContextoAPI>(context);

         

            var resposta = servPessoa.CadastraEntidade(new PessoaRequest()
            {
                Ativo = true,
                CPF = "96179162077",
                DataNascimento = DateTime.Now,
                Nome = "root",
                UF = "GO"
            });

        }
    }
}