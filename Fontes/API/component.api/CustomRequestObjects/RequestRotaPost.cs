using System;
using api.rotas.domain;

namespace api.rotas.CustomRequestObjects
{
    public class RequestRotaPost : Rota
    {
        public string caminhoArquivo { get; set; }
    }
}