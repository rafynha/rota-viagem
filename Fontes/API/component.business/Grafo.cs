using System;
using System.Collections.Generic;
using System.Linq;

namespace api.rotas.business
{
    public class Grafo
    {
        private List<domain.RotaVerificada> _lstRotas { get; set; }
        private List<domain.Grafo> _lstGrafo { get; set; }
        private List<domain.Rota> _lstVisitados { get; set; }
        public Grafo(List<domain.Grafo> grafo)
        {
            this._lstGrafo = grafo;
            this._lstRotas = new List<domain.RotaVerificada>();
            this._lstVisitados = new List<domain.Rota>();
        }

        public List<domain.RotaVerificada> BuscarCaminho(string origem, string destino)
        {
            List<domain.Grafo> listaOrigem = new List<domain.Grafo>();
            _lstGrafo.Where(x => x.Aresta.Origem.Equals(origem)).ToList().ForEach(x => listaOrigem.Add(x.Clone()));
            foreach (var itemGrafo in listaOrigem)
            {
                _lstVisitados = new List<domain.Rota>();
                itemGrafo.Conexoes = new List<domain.Grafo>();
                BuscarCaminho(itemGrafo, origem, destino, itemGrafo.Aresta.Valor);

            }
            return _lstRotas;
        }

        private void BuscarCaminho(domain.Grafo grafo, string origem, string destino, int valor)
        {
            try
            {
                _lstVisitados.Add(grafo.Aresta);

                if (grafo.Aresta.Destino == destino)
                {
                    if (grafo.Pai == null)
                    {
                        domain.RotaVerificada rt = new domain.RotaVerificada();
                        rt.Nome = $"{grafo.Aresta.Origem}|{grafo.Aresta.Destino}";
                        rt.Valor = valor;
                        _lstRotas.Add(rt);
                    }
                    else
                    {
                        domain.RotaVerificada rt = new domain.RotaVerificada();
                        rt.Nome = $"{origem}{grafo.Rota}|{grafo.Aresta.Destino}";
                        rt.Valor = valor;
                        _lstRotas.Add(rt);
                    }
                }
                else
                {
                    var lstRotas = _lstGrafo.Where(x => x.Aresta.Origem == grafo.Aresta.Destino).ToList();
                    if (lstRotas != null)
                    {
                        foreach (var item in lstRotas)
                        {
                            if (_lstVisitados.Where(x => x.Origem == item.Aresta.Origem && x.Destino == item.Aresta.Destino)?.Count() > 0)
                                continue;

                            item.Pai = grafo;

                            item.Rota = $"{grafo.Rota}|{grafo.Aresta.Destino}";
                            int valorAtual = valor + item.Aresta.Valor;
                            item.Conexoes = new List<domain.Grafo>();
                            grafo.Conexoes.Add(item);
                            BuscarCaminho(item, origem, destino, valorAtual);
                            _lstVisitados.Remove(_lstVisitados.Last());
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}