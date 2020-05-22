using ConsoleApp.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ConsoleApp.Controller
{
    public class RotaController
    {
        public string Buscar(string rota, string caminhoArquivo)
        {
            if (string.IsNullOrWhiteSpace(rota))
                throw new System.Exception("Rota inválida");

            List<string> od = rota.Trim().Split('-').ToList();

            if (od.Count != 2)
                throw new System.Exception("Rota inválida");

            string urlFormatada = $"{Program._settings.ApiUrl}/Rota/Best?origem={od[0].Trim()}&destino={od[1].Trim()}&caminhoArquivo={WebUtility.UrlEncode(caminhoArquivo)}";
            string retorno = Web.Get(urlFormatada);

            return retorno.ToLower().Contains("melhor rota") ? retorno : throw new System.Exception(retorno);
        }
    }
}