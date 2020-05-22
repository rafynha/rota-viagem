using System.Collections.Generic;
using api.rotas.domain;

namespace component.domain.Interfaces.Infrastructure
{
    public interface IRota : IRepository<Rota>
    {
        void Criar(Rota entity, string caminho);
        Rota BuscarPorOrigemDestino(string origem, string destino, string caminho);
        void Atualizar(Rota rota, string caminho);
        List<Rota> BuscarTodos(string caminho);
    }
}