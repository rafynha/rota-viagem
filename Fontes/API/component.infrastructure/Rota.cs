using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using component.domain.Interfaces.Infrastructure;

namespace api.rotas.infrastructure
{
    public class Rota : IRota
    {
        public void Atualizar(domain.Rota rota, string caminho)
        {
            throw new NotImplementedException();
        }

        public domain.Rota BuscarPorOrigemDestino(string origem, string destino, string caminho)
        {
            if (!File.Exists(caminho))
                return null;

            domain.Rota linha = File.ReadAllLines(caminho)
            .Select(x => x.Split(';'))
            .Select(x => new domain.Rota()
            {
                Origem = x[0],
                Destino = x[1],
                Valor = Convert.ToInt32(x[2])
            })
            .ToList()
            .FirstOrDefault(x => x.Origem.Equals(origem) && x.Destino.Equals(destino));

            return linha;
        }

        public List<domain.Rota> BuscarTodos(string caminho)
        {
            if (!File.Exists(caminho))
                return null;

            var retorno = File.ReadAllLines(caminho)
            .Select(x => x.Split(';'))
            .Select(x => new domain.Rota()
            {
                Origem = x[0],
                Destino = x[1],
                Valor = Convert.ToInt32(x[2])
            })
            .ToList();

            return retorno;
        }

        public void Criar(domain.Rota entity, string caminho)
        {
            string info = $"{entity.Origem};{entity.Destino};{entity.Valor}";

            if (!File.Exists(caminho))
            {
                File.WriteAllText(caminho, info);
                return;
            }
            File.AppendAllText(caminho, Environment.NewLine + info);
        }

        #region Métodos padrões

        public int? Create(domain.Rota entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<domain.Rota> GeatAll()
        {
            throw new NotImplementedException();
        }

        public domain.Rota GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public domain.Rota GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public int? Update(domain.Rota entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
