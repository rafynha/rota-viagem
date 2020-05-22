using System;
using System.Collections.Generic;
using System.Linq;
using component.domain.Interfaces.Infrastructure;
using inf = api.rotas.infrastructure;

namespace api.rotas.business
{
    public class Rota
    {
        private IRota _rotaInf { get; set; }
        public Rota()
        {
            this._rotaInf = new inf.Rota();
        }

        public void Criar(domain.Rota rota, string caminho)
        {
            if (string.IsNullOrWhiteSpace(caminho) || rota == null || string.IsNullOrWhiteSpace(rota.Origem) ||
            string.IsNullOrWhiteSpace(rota.Destino))
                throw new Exception($"Parâmetros inválidos --> caminho: {caminho}, origem: {rota?.Origem}, destino: {rota?.Destino}");

            // Validar existência da combinação de origem + destino
            domain.Rota rotaBuscada = this.BuscarPorOrigemDestino(rota.Origem, rota.Destino, caminho);

            if (rotaBuscada != null)
                throw new Exception($"Rota já cadastrada --> caminho: {caminho}, origem: {rota?.Origem}, destino: {rota?.Destino}");

            _rotaInf.Criar(rota, caminho);
        }

        public List<domain.Rota> Buscar(string caminho)
        {
            return _rotaInf.BuscarTodos(caminho);
        }

        public domain.Rota BuscarPorOrigemDestino(string origem, string destino, string caminho)
        {
            if (string.IsNullOrWhiteSpace(caminho) || string.IsNullOrWhiteSpace(origem) ||
            string.IsNullOrWhiteSpace(destino))
                throw new Exception($"Parâmetros inválidos --> caminho: {caminho}, origem: {origem}, destino: {destino}");

            return _rotaInf.BuscarPorOrigemDestino(origem, destino, caminho);
        }


        public string BuscarMelhorRota(string origem, string destino, string caminho)
        {
            if (string.IsNullOrWhiteSpace(caminho) || string.IsNullOrWhiteSpace(origem) ||
            string.IsNullOrWhiteSpace(destino))
                throw new Exception($"Parâmetros inválidos --> caminho: {caminho}, origem: {origem}, destino: {destino}");

            origem = origem.ToUpper();
            destino = destino.ToUpper();

            var rotasCadastradas = this.Buscar(caminho);
            if (rotasCadastradas == null || rotasCadastradas.Count == 0)
                throw new Exception("Não existem rotas cadastradas");

            if (rotasCadastradas.FirstOrDefault(x => x.Origem.Equals(origem)) == null ||
             rotasCadastradas.FirstOrDefault(x => x.Destino.Equals(destino)) == null)
                throw new Exception("Rota não encontrada");

            List<domain.Grafo> grafo = new List<domain.Grafo>();
            rotasCadastradas.ForEach(x => grafo.Add(domain.Grafo.RotaToGrafo(x)));

            Grafo grafoBusiness = new Grafo(grafo);
            List<domain.RotaVerificada> retornoRotas = grafoBusiness.BuscarCaminho(origem, destino);

            if (rotasCadastradas == null || rotasCadastradas.Count == 0)
                throw new Exception("Não existem rotas cadastradas");

            var maisBarata = retornoRotas.OrderBy(x => x.Valor).First();
            return $"MELHOR ROTA: {maisBarata.Nome} - VALOR: ${maisBarata.Valor}";
        }

    }
}
