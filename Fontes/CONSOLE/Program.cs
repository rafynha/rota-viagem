using System;
using System.IO;
using ConsoleApp.Controller;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp
{
    class Program
    {
        public static Model.SettingsConfig _settings { get; set; }
        private static void Initialize()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();
            _settings = new Model.SettingsConfig();
            configuration.GetSection("Settings").Bind(_settings);

            CarregarTextoInicializacao();
        }

        private static void CarregarTextoInicializacao()
        {
            string textoInicializacaoLinha1 = @"              
                 _____   _____   __   _   _____   _   _   _       _____       ___   _____   _____   _____   
                /  ___| /  _  \ |  \ | | /  ___/ | | | | | |     |_   _|     /   | |  _  \ /  _  \ |  _  \  
                | |     | | | | |   \| | | |___  | | | | | |       | |      / /| | | | | | | | | | | |_| |  
                | |     | | | | | |\   | \___  \ | | | | | |       | |     / / | | | | | | | | | | |  _  /  
                | |___  | |_| | | | \  |  ___| | | |_| | | |___    | |    / /  | | | |_| | | |_| | | | \ \  
                \_____| \_____/ |_|  \_| /_____/ \_____/ |_____|   |_|   /_/   |_| |_____/ \_____/ |_|  \_\              
            ";
            string textoInicializacaoLinha2 = @"              
                 _____   _____  
                |  _  \ | ____| 
                | | | | | |__   
                | | | | |  __|  
                | |_| | | |___  
                |_____/ |_____|            
            ";
            string textoInicializacaoLinha3 = @"              
                 _____    _____   _____       ___   _____  
                |  _  \  /  _  \ |_   _|     /   | /  ___/ 
                | |_| |  | | | |   | |      / /| | | |___  
                |  _  /  | | | |   | |     / / | | \___  \ 
                | | \ \  | |_| |   | |    / /  | |  ___| | 
                |_|  \_\ \_____/   |_|   /_/   |_| /_____/            
            ";
            Console.WriteLine("***********************************************************************************************************");
            Console.WriteLine(textoInicializacaoLinha1);
            Console.WriteLine(textoInicializacaoLinha2);
            Console.WriteLine(textoInicializacaoLinha3);
            Console.WriteLine("***********************************************************************************************************");
        }

        private static bool VerificaArgumentos(string[] args)
        {
            bool retorno = args.Length != 0;
            if (!retorno)
                Console.WriteLine("\n\nPor favor informe o caminho completo do arquivo. --> Ex.: .\\Console.exe 'C:\\Users\\Desenvolvedor\\Documents\\input-routes.csv'\n\n");
            return retorno;
        }

        static void Main(string[] args)
        {
            Initialize();
            if (!VerificaArgumentos(args))
                return;

            bool sucesso = false;
            while (!sucesso)
            {
                try
                {
                    Console.WriteLine("Por favor informe a rota. (Ex. GRU-CDG)");
                    Console.Write("Rota: ");
                    var rota = Console.ReadLine();

                    RotaController rotaController = new RotaController();
                    var melhorRota = rotaController.Buscar(rota, args[0]);

                    Console.WriteLine(melhorRota + "\n\n");
                    Console.Write("Deseja efetuar nova consulta? (S/N): ");
                    var novaConsulta = Console.ReadLine();
                    sucesso = string.IsNullOrWhiteSpace(novaConsulta) || novaConsulta.ToLower().Contains('n');
                    if (!sucesso)
                    {
                        Console.Clear();
                        CarregarTextoInicializacao();
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine($"Erro --> {ex.Message}\n\n");
                    Console.WriteLine($"Tente novamente, ou digite CTRL+C para sair...\n\n");
                }
            }
            Console.WriteLine("Digite qualquer tecla para fechar o console...");
            Console.Read();
        }
    }
}
