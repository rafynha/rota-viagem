using System;
using System.IO;
using api.rotas.domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bc = api.rotas.business;

namespace api.rotas.tests
{
    [TestClass]
    public class InserirRotaUnitTest
    {
        public static string _nomeArquivo { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            _nomeArquivo =
             string.IsNullOrWhiteSpace(_nomeArquivo) ?
             $"input-routes-{Guid.NewGuid()}" :
             _nomeArquivo;
        }

        [TestMethod]
        public void InserirRotaComArquivoInexistente()
        {
            Rota request = new Rota()
            {
                Origem = "UnitTestOrigemNew",
                Destino = "UnitTestDestinoNew",
                Valor = 10
            };
            new bc.Rota().Criar(request, $"C:/Users/Public/Documents/{_nomeArquivo}.csv");
        }

        [TestMethod]
        public void InserirRotaComSucesso()
        {
            Rota request = new Rota()
            {
                Origem = "UnitTestOrigem",
                Destino = "UnitTestDestino",
                Valor = 10
            };
            new bc.Rota().Criar(request, $"C:/Users/Public/Documents/{_nomeArquivo}.csv");
        }

        [TestMethod]
        public void InserirRotaExistente()
        {
            try
            {
                Rota request = new Rota()
                {
                    Origem = "UnitTestOrigemRotaExistente",
                    Destino = "UnitTestDestinoRotaExistente",
                    Valor = 10
                };
                new bc.Rota().Criar(request, $"C:/Users/Public/Documents/{_nomeArquivo}.csv");
                new bc.Rota().Criar(request, $"C:/Users/Public/Documents/{_nomeArquivo}.csv");
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex.Message.ToLower().Contains("já cadastrada"));
            }
        }

        [TestMethod]
        public void InserirRotaComParametrosInvalidos()
        {
            try
            {
                Rota request = new Rota()
                {
                    Origem = "UnitTestOrigemRotaExistente",
                    Destino = "UnitTestDestinoRotaExistente",
                    Valor = 10
                };
                new bc.Rota().Criar(request, "");
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex.Message.ToLower().Contains("parâmetros inválidos"));
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (!string.IsNullOrWhiteSpace(_nomeArquivo))
                File.Delete($"C:/Users/Public/Documents/{_nomeArquivo}.csv");
        }
    }
}
