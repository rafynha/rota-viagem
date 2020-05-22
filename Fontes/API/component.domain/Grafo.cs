using System.Collections.Generic;

namespace api.rotas.domain
{
    public class Grafo
    {
        #region Propriedades

        public Rota Aresta { get; set; }
        public string Rota { get; set; }
        public Grafo Pai { get; set; }
        public List<Grafo> Conexoes { get; set; }

        #endregion

        #region Métodos
        public Grafo Clone() => (Grafo)this.MemberwiseClone();

        public static Grafo RotaToGrafo(Rota rota) => new Grafo() { Aresta = rota };

        #endregion        
    }
}