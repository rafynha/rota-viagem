# Pré requisitos

- .NET Core 3.1
  - .NET Core 3.1 Desktop Runtime (v3.1.4) - Windows x64
  - .NET Core 3.1 SDK (v3.1.300) - Windows x64
- Visual Studio Code

# Como executar

## Execução a partir do código compilado

Para executar o código já compilado, basta efetuar os passos abaixo com base no diretório que foi extraido o projeto:

### API REST

1. Abra o console do windows
2. Digite: `cd C:\<Meu Diretório de fontes e publish>\Publish\API`
3. Digite: `.\api.rotas.exe`

O resultado abaixo deve ser exibido:

```mermaid
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\<Meu Diretório de fontes e publish>\Publish\API

```

Pronto, a API está no ar.

### Console

1. Abra o console do windows
2. Digite: `cd C:\<Meu Diretório de fontes e publish>\Publish\CONSOLE`
3. Digite: `.\Console.exe <Caminho completo do meu arquivo de dados>` (ex.: C:\Users\Public\Documents\input-routes.csv)

O resultado abaixo deve ser exibido:

```mermaid
***********************************************************************************************************

                 _____   _____   __   _   _____   _   _   _       _____       ___   _____   _____   _____
                /  ___| /  _  \ |  \ | | /  ___/ | | | | | |     |_   _|     /   | |  _  \ /  _  \ |  _  \
                | |     | | | | |   \| | | |___  | | | | | |       | |      / /| | | | | | | | | | | |_| |
                | |     | | | | | |\   | \___  \ | | | | | |       | |     / / | | | | | | | | | | |  _  /
                | |___  | |_| | | | \  |  ___| | | |_| | | |___    | |    / /  | | | |_| | | |_| | | | \ \
                \_____| \_____/ |_|  \_| /_____/ \_____/ |_____|   |_|   /_/   |_| |_____/ \_____/ |_|  \_\

                 _____   _____
                |  _  \ | ____|
                | | | | | |__
                | | | | |  __|
                | |_| | | |___
                |_____/ |_____|

                 _____    _____   _____       ___   _____
                |  _  \  /  _  \ |_   _|     /   | /  ___/
                | |_| |  | | | |   | |      / /| | | |___
                |  _  /  | | | |   | |     / / | | \___  \
                | | \ \  | |_| |   | |    / /  | |  ___| |
                |_|  \_\ \_____/   |_|   /_/   |_| /_____/

***********************************************************************************************************
Por favor informe a rota. (Ex. GRU-CDG)
Rota:
```

## Execução a partir do código fonte

### API REST

1. Abra a pasta do projeto, `C:\<Meu Diretório de fontes e publish>\Fontes\API`, no Visual Studio Code.
2. No terminal digite: `cd component.api`.
3. Digite: `dotnet run`

O resultado abaixo deve ser exibido:

```mermaid
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\<Meu Diretório de fontes e publish>\Publish\API

```

### Console

1. Abra a pasta do projeto, `C:\<Meu Diretório de fontes e publish>\Fontes\CONSOLE`, no Visual Studio Code.
2. No terminal digite: `dotnet run <Caminho completo do meu arquivo de dados>` (ex.: C:\Users\Public\Documents\input-routes.csv)

O resultado abaixo deve ser exibido:

```mermaid
***********************************************************************************************************

                 _____   _____   __   _   _____   _   _   _       _____       ___   _____   _____   _____
                /  ___| /  _  \ |  \ | | /  ___/ | | | | | |     |_   _|     /   | |  _  \ /  _  \ |  _  \
                | |     | | | | |   \| | | |___  | | | | | |       | |      / /| | | | | | | | | | | |_| |
                | |     | | | | | |\   | \___  \ | | | | | |       | |     / / | | | | | | | | | | |  _  /
                | |___  | |_| | | | \  |  ___| | | |_| | | |___    | |    / /  | | | |_| | | |_| | | | \ \
                \_____| \_____/ |_|  \_| /_____/ \_____/ |_____|   |_|   /_/   |_| |_____/ \_____/ |_|  \_\

                 _____   _____
                |  _  \ | ____|
                | | | | | |__
                | | | | |  __|
                | |_| | | |___
                |_____/ |_____|

                 _____    _____   _____       ___   _____
                |  _  \  /  _  \ |_   _|     /   | /  ___/
                | |_| |  | | | |   | |      / /| | | |___
                |  _  /  | | | |   | |     / / | | \___  \
                | | \ \  | |_| |   | |    / /  | |  ___| |
                |_|  \_\ \_____/   |_|   /_/   |_| /_____/

***********************************************************************************************************
Por favor informe a rota. (Ex. GRU-CDG)
Rota:
```

# API REST Endpoints

A API contém 3 endpoints, sendo dois para GET e um para POST.

### GET - /Rota

Esse endpoint é responsável por listar todos os registros cadastrados no arquivo .csv.

#### Parâmetros

| Nome           | Tipo   | Exemplo                                      |
| -------------- | ------ | -------------------------------------------- |
| caminhoArquivo | string | `C:\Users\Public\Documents\input-routes.csv` |

#### Requisição

curl

```mermaid
curl -X GET "http://localhost:5000/Rota?caminhoArquivo=C%3A%5CUsers%5CPublic%5CDocuments%5Cinput-routes.csv" -H "accept: application/json"
```

Request URL

```mermaid
http://localhost:5000/Rota?caminhoArquivo=C%3A%5CUsers%5CPublic%5CDocuments%5Cinput-routes.csv
```

#### Formato do Retorno

```mermaid
[
  {
    "origem": "string",
    "destino": "string",
    "valor": 0
  }
]
```

### GET - /Rota/Best

Esse endpoint é responsável por trazer o resultado da busca de melhor rota.

#### Parâmetros

| Nome           | Tipo   | Exemplo                                      |
| -------------- | ------ | -------------------------------------------- |
| origem         | string | `GRU`                                        |
| destino        | string | `CDG`                                        |
| caminhoArquivo | string | `C:\Users\Public\Documents\input-routes.csv` |

#### Requisição

curl

```mermaid
curl -X GET "http://localhost:5000/Rota/Best?origem=GRU&destino=CDG&caminhoArquivo=C%3A%5CUsers%5CPublic%5CDocuments%5Cinput-routes.csv" -H "accept: application/json"
```

Request URL

```mermaid
http://localhost:5000/Rota/Best?origem=GRU&destino=CDG&caminhoArquivo=C%3A%5CUsers%5CPublic%5CDocuments%5Cinput-routes.csv
```

#### Formato do Retorno

```mermaid
"MELHOR ROTA: GRU|BRC|SCL|ORL|CDG - VALOR: $40"
```

### POST - /Rota

Esse endpoint é responsável por incluir informações no arquivo .csv.

#### Parâmetros

| Nome           | Tipo   | Exemplo                                      |
| -------------- | ------ | -------------------------------------------- |
| origem         | string | `GRU`                                        |
| destino        | string | `CDG`                                        |
| caminhoArquivo | string | `C:\Users\Public\Documents\input-routes.csv` |
| Valor          | int    | `10`                                         |

#### Requisição

curl

```mermaid
curl -X POST "http://localhost:5000/Rota" -H "accept: */*" -H "Content-Type: application/json" -d "{\"caminhoArquivo\":\"string\",\"origem\":\"string\",\"destino\":\"string\",\"valor\":0}"
```

Request URL

```mermaid
http://localhost:5000/Rota
```

#### Formato da Requisição

```mermaid
{
  "caminhoArquivo": "string",
  "origem": "string",
  "destino": "string",
  "valor": 0
}
```

#### Formato do Retorno

```mermaid
{
  "origem": "string",
  "destino": "string",
  "valor": 0
}
```

# Descisões de Design

Escolhi um design que permite isolar cada camada da aplicação, camadas que no caso ainda podem ser melhoradas utilizando injeção de dependência. Criei também uma camada de domínio que contém todos os objetos de negócio e interfaces.

Para buscar a melhor rota busquei aplicar o conceito de grafo, mas não utilizei nenhum algoritmo pronto como o de Dijkstra. Para buscar a melhor rota basicamente é feito o mapeamento de todas as possíveis rotas e depois é escolhida a que tem o menor valor.

Obs.: Em questões de performance não seria o mais recomendado. Caso a performance seja um requisito, o ideal seria nesse caso então utilizar o algoritmo de Dijkstra.

# Estrutura de arquivos e pacotes

## API REST

A pasta raiz do projeto de api, contém as seguintes pastas, que são as camadas da aplicação.

- component.api

  - Essa pasta contém o projeto principal da API REST, é onde estão os endpoints que serão expostos e toda a configuração da API.

  Obs.: Nessa camada

- component.business
  - Essa pasta contém o projeto da camada de negócio, é onde toda a lógica de busca de melhor rota está implementada.
- component.domain
  - Essa pasta contém o projeto de domínio, no qual é responsável por guardar todos os objetos de negócio e interfaces da API REST.
- component.infrastructure
  - Essa pasta contém o projeto da camada de acesso a dados, todo acesso a dados deve ser efetuado a partir desta camada, sendo dados de qualquer origem, como por ex, arquivos, outras APIs, bancos de dados, etc.
- component.tests
  - Essa pasta contém o projeto de testes, no qual todos os testes unitários são implementados.

## Console

A pasta raiz do projeto de console, diferente da estrutura da api, não contém pastas com projetos, pois toda a carga de processamento está na API. Aqui temos apenas a interface para capturar os inputs, algumas validações simples dos dados inputados, o repasse das informações para a API e a exibição do retorno da mesma.

Abaixo segue a estrutura de pastas do projeto:

- raiz
  - Essa pasta contém a classe principal de execução e o arquivo de configuração `appsettings.js`, que é onde está configurado link da API REST.
- Controller
  - Essa pasta contém a classe de rota, é onde está implementada as validações de inputs e a chamada para a API REST.
- Model
  - Essa pasta contém os objetos necessários para a execução da aplicação
- Utils
  - Essa pasta contém uma classe de auxilio para requisições web, e pode conter qualquer classe que se enquadre no contexto de classe utilitária.
