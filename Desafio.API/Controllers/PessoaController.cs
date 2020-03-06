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
        public PessoaController(ContextoAPI context)
        {
            ServicoDePessoa = new ServicoDePessoa<ContextoAPI>(context);
        }

        
        [HttpGet]
        public List<PessoaResponse> Get()
        {
            return ServicoDePessoa.Consulte().ToList();
        }

        [HttpGet("ConsultePorCodigo/{codigo}")]
        public PessoaResponse Get(Guid codigo)
        {
            return ServicoDePessoa.Consulte(codigo);
        }

        [HttpPost]
        public PessoaResponse Salve(PessoaRequest pessoa)
        {
            return ServicoDePessoa.CadastraEntidade(pessoa);
        }

        [HttpPut]
        public PessoaResponse Altere(PessoaRequest pessoa)
        {
            return ServicoDePessoa.AtualizarEntidade(pessoa);
        }

        [HttpPut("Delete")]
        public PessoaResponse Delete(Guid codigoEntidade)
        {
            var pes = ServicoDePessoa.Consulte(codigoEntidade);
            if(pes.Erro)
            {
                return pes;
            }

            pes.Ativo = false;
            return ServicoDePessoa.AtualizarEntidade(ConvertMap.Converta<PessoaResponse,PessoaRequest>(pes));
        }

    }
}
