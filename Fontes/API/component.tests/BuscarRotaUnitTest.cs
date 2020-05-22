using System;
using System.IO;
using api.rotas.domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bc = api.rotas.business;

namespace api.rotas.tests
{
    [TestClass]
    public class BuscarRotaUnitTest
    {
        public static string _nomeArquivo { get; set; }
        private static string _origem { get; set; }
        private static string _destino { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            _nomeArquivo =
             string.IsNullOrWhiteSpace(_nomeArquivo) ?
             $"input-routes-{Guid.NewGuid()}" :
             _nomeArquivo;

            _origem = "A";
            _destino = "F";
            string caminhoCompletoArquivo = $"C:/Users/Public/Documents/{_nomeArquivo}.csv";

            Rota request = new Rota();

            request.Origem = "A";
            request.Destino = "B";
            request.Valor = 4;
            new bc.Rota().Criar(request, caminhoCompletoArquivo);

            request.Origem = "B";
            request.Destino = "C";
            request.Valor = 1;
            new bc.Rota().Criar(request, caminhoCompletoArquivo);

            request.Origem = "B";
            request.Destino = "D";
            request.Valor = 5;
            new bc.Rota().Criar(request, caminhoCompletoArquivo);

            request.Origem = "C";
            request.Destino = "D";
            request.Valor = 8;
            new bc.Rota().Criar(request, caminhoCompletoArquivo);

            request.Origem = "A";
            request.Destino = "C";
            request.Valor = 2;
            new bc.Rota().Criar(request, caminhoCompletoArquivo);

            request.Origem = "C";
            request.Destino = "E";
            request.Valor = 10;
            new bc.Rota().Criar(request, caminhoCompletoArquivo);

            request.Origem = "D";
            request.Destino = "E";
            request.Valor = 2;
            new bc.Rota().Criar(request, caminhoCompletoArquivo);

            request.Origem = "D";
            request.Destino = "F";
            request.Valor = 6;
            new bc.Rota().Criar(request, caminhoCompletoArquivo);

            request.Origem = "E";
            request.Destino = "F";
            request.Valor = 2;
            new bc.Rota().Criar(request, caminhoCompletoArquivo);
        }

        [TestMethod]
        public void BuscarTodos()
        {
            var rotas = new bc.Rota().Buscar($"C:/Users/Public/Documents/{_nomeArquivo}.csv");
            Assert.IsTrue(rotas != null && rotas.Count > 0);
        }

        [TestMethod]
        public void BuscarRotaExistente()
        {
            var retorno = new bc.Rota().BuscarMelhorRota(_origem, _destino, $"C:/Users/Public/Documents/{_nomeArquivo}.csv");
            Assert.IsFalse(string.IsNullOrWhiteSpace(retorno));
        }

        [TestMethod]
        public void BuscarRotaNaoExistente()
        {
            try
            {
                var retorno = new bc.Rota().BuscarMelhorRota("X", _destino, $"C:/Users/Public/Documents/{_nomeArquivo}.csv");
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Rota não encontrada"));
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