# Projeto Carteira de Jogos

O projeto carteira de jogos é um projeto onde é possível cadastrar, alterar, deletar e adicionar os jogos aos favoritos. O projeto envolve uma complexidade onde cada jogo cadastrado é incluido na lista de jogos do usuário, e ao ser excluido o jogo é inativado, não aparecendo mais para o usuário. Também é possível adicionar os jogos a lista de favoritos, caso esse jogo já esteja na lista de jogos do usuário.

| :placard: Vitrine.Dev | Guilherme Henrique            |
| --------------------- | ----------------------------- |
| :sparkles: Nome       | **CarteiraDeJogos-API**       |
| :label: Tecnologias   | C#, .NET, ASP.NET, SQL Server |
| :inbox_tray: Download | [Download EXE]()              |

### Detalhes do projeto

> - **Cadastrar, Alterar, deletar, listar e detalhar os jogos.**
> - **Cadastrar, Alterar, deletar, listar e detalhar os usuários.**
> - **Adicionar e remover os jogos na lista de jogos favoritos do usuário.**

### Escalamento do projeto (breve)
  - Implementar os testes para garantir a qualidade do código.
  - Implementar um app com Flutter para o consumo da API.

##

### Jogos

##

### Usuários

- `POST /Usuarios`: Essa rota recebe através do corpo da requisição um JSON com os dados de `nome`, `senha` e `confirmacaoSenha` cadastrado
  previamente no banco de dados, aqui utilizado o SQL Server. O usuário não é cadastrado caso as senhas sejam divergentes.

  ```json
  {
    "nome": "Guilherme Henrique",
    "senha": "1234",
    "confirmacaoSenha": "1234"
  }
  ```

  A resposta é um DTO de leitura com os campos de `nome`, `jogos` e `jogosFavoritos`.

  ```json
  {
    "nome": "Pedro Henrique",
    "jogos": [],
    "jogosFavoritos": []
  }
  ```

- `GET /Usuarios`: Retorna uma lista de todos os usuários através do DTO de leitura.

  ```json
  [
    {
      "nome": "Pedro Henrique",
      "jogos": [],
      "jogosFavoritos": []
    },
    {
      "nome": "Guilherme Henrique",
      "jogos": [],
      "jogosFavoritos": []
    }
  ]
  ```

- `GET /Usuarios/{id}`: Detalha o usuário com o `Id` correspondente. Caso não encontre o usuário é retornado o HTTP 404.

  ```json
  {
    "nome": "Guilherme Henrique",
    "jogos": [],
    "jogosFavoritos": []
  }
  ```

- `PUT /Usuarios/{id}`: Faz a alteração do usuário com o `Id` correspondente. O DTO de update somente permite a modificação nesse caso dos campos de `nome`, `jogos` e `jogosFavoritos`, protegendo assim os campos mais sensíveis.
  O retorno do é um HTTP 200 em caso de sucesso e um 404 caso o usuário não seja localizado.

  ```json
  {
    "nome": "Guilherme Henrique",
    "jogos": [1, 3, 5, 8, 10, 15, 18, 21, 22, 27, 31, 35, 39, 41, 45, 48],
    "jogosFavoritos": [1, 5, 15, 31]
  }
  ```

- `DELETE /Usuarios/{id}`: Apaga o usuário com o `Id` correspondente. Em caso de sucesso é retornado o HTTP 204 e caso não encontre o usuário é retornado o HTTP 404.

####

##

### Imagens

![](#vitrinedev)
