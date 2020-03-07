using Desafio.Entidades.Argumentos.Request;
using Desafio.Entidades.Argumentos.Response;
using Desafio.Entidades.Entidades;
using Desafio.Repositorio.Contexto;
using Desafio.Servicos.Base;
using Desafio.Utils.Conversor;
using Desafio.Utils.Validadores;
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


        public override PessoaResponse CadastraEntidade(PessoaRequest request)
        {


            decimal i = 0;
            bool apenasNumeros = decimal.TryParse(request.CPF, out i);

            if (!apenasNumeros)
            {
                return new PessoaResponse
                {
                    Erro = true,
                    Alertas = {
                        Erros = {
                            "CPF deve conter apenas numeros"
                        }
                    }
                };
            }

            if (string.IsNullOrEmpty(request.CPF) || !Validadores.CPFValido(request.CPF))
            {
                return new PessoaResponse
                { 
                    Erro  = true,
                    Alertas = {
                        Erros = {
                            "CPF Invalido"
                        }
                    }
                };

            }


            if(string.IsNullOrEmpty(request.UF) || request.UF.Length != 2)
            {
                return new PessoaResponse
                {
                    Erro = true,
                    Alertas = {
                        Erros = {
                            "UF Invalido"
                        }
                    }
                };
            }




            decimal cpf = decimal.Parse(request.CPF);
            var obj = Consulte(x => decimal.Parse(x.CPF) == cpf);
            if (!obj.Erro)
            {
                return new PessoaResponse
                {
                    Erro = true,
                    Alertas = {
                        Erros = {
                            "CPF ja existe"
                        }
                    }
                };

            }

            return base.CadastraEntidade(request);
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
