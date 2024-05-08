# Projeto Carteira de Jogos

O projeto carteira de jogos é um projeto onde é possível cadastrar, alterar, deletar e adicionar os jogos aos favoritos. O projeto envolve uma complexidade onde cada jogo cadastrado é incluido na lista de jogos do usuário, e ao ser excluido o jogo é inativado, não aparecendo mais para o usuário. Também é possível adicionar os jogos a lista de favoritos, caso esse jogo já esteja na lista de jogos do usuário.

| :placard: Vitrine.Dev | Guilherme Henrique            |
| --------------------- | ----------------------------- |
| :sparkles: Nome       | **CarteiraDeJogos-API**       |
| :label: Tecnologias   | C#, .NET, ASP.NET, SQL Server |
| :inbox_tray: Download | [Download Zip](https://github.com/guih1886/carteiradejogos/raw/main/CarteiraDeJogos/Assets/carteiraDeJogos.rar)<br>[Download App]() Em breve |

### Detalhes do projeto

> - **Cadastrar, Alterar, deletar, listar e detalhar os jogos.**
> - **Cadastrar, Alterar, deletar, listar e detalhar os usuários.**
> - **Adicionar e remover os jogos na lista de jogos favoritos do usuário.**

### Escalamento do projeto (em breve)

- Implementar os testes para garantir a qualidade do código.
- Implementar um app com Flutter para o consumo da API.

##

### Usuários

- `POST /Usuarios`: Essa rota recebe através do corpo da requisição um JSON com os dados de `nome`, `senha` e `confirmacaoSenha` para o cadastro no banco de dados, aqui utilizado o SQL Server. O usuário não é cadastrado caso as senhas sejam divergentes.

  ```json
  {
    "nome": "Guilherme Henrique",
    "senha": "1234",
    "confirmacaoSenha": "1234"
  }
  ```

  A resposta é um DTO de leitura com os campos de `nome`, `jogos` e `jogosFavoritos` do usuário.

  ```json
  {
    "nome": "Guilherme Henrique",
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
  O retorno é um HTTP 200 e o json do usuário modificado em caso de sucesso, e um 404 caso o usuário não seja localizado.

  ```json
  {
    "nome": "Guilherme Henrique",
    "jogos": [1, 3, 5, 8, 10, 15, 18, 21, 22, 27, 31, 35, 39, 41, 45, 48],
    "jogosFavoritos": [1, 5, 15, 31]
  }
  ```

- `DELETE /Usuarios/{id}`: Apaga o usuário com o `Id` correspondente. Em caso de sucesso é retornado o HTTP 204 e caso não encontre o usuário é retornado o HTTP 404.

##

### Jogos

- `POST /Jogos`: A rota cria um jogo no banco de dados, utilizando um DTO de criação com os dados `nome`, `endereçoImagem`, `descricao`, `genero`, `anoLançamento`, `plataforma`, `nota` e `usuarioId`.
  Os campos opcionais são gênero, ano de lançamento, plataforma e nota. E os demais são obrigátorios, e o campo de `usuarioId` é uma chave estrangeira que faz referência ao Id de usuário, e portanto, deve ser um valor válido para a inclusão. O jogo ao ser criado é marcado automaticamente como ativo.

  ```json
  {
    "nome": "Super Mário",
    "enderecoImagem": "https://jogoveio.com.br/wp-content/uploads/2019/04/super-mario-bros-nes.png",
    "descricao": "O objetivo do jogo é percorrer o Reino do Cogumelo, sobreviver às forças do vilão Bowser e salvar a Princesa Peach.",
    "genero": 1,
    "anoLancamento": "1981",
    "plataforma": "Super Nintendo",
    "nota": 0,
    "usuarioId": 3
  }
  ```

  Em caso de sucesso, é retornado um HTTP 200 com o json do jogo criado, e o Id do jogo é adicionado automaticamente à lista de jogos do usuário que cadastrou o jogo.
  Em caso de falha, será retornado um HTTP 400 e a/as mensagens de erro sobre quais campos estão ausentes.

  ```json
  {
    "nome": "Guilherme Henrique",
    "jogos": [5, 6, 7],
    "jogosFavoritos": []
  }
  ```

- `GET /Jogos`: Retorna uma lista de todos os jogos ativos através do DTO de leitura.

  ```json
  [
    {
      "nome": "Jogo Teste",
      "enderecoImagem": "",
      "descricao": "jogo teste para o metodo post",
      "genero": "Sem_Genero",
      "anoLancamento": "",
      "plataforma": "",
      "nota": 0
    },
    {
      "nome": "Super Mário",
      "enderecoImagem": "https://jogoveio.com.br/wp-content/uploads/2019/04/super-mario-bros-nes.png",
      "descricao": "O objetivo do jogo é percorrer o Reino do Cogumelo, sobreviver às forças do vilão Bowser e salvar a Princesa Peach.",
      "genero": "Aventura",
      "anoLancamento": "1981",
      "plataforma": "Super Nintendo",
      "nota": 8
    }
  ]
  ```

- `GET /Jogos/{id}`: Detalha o jogo ativo com o `Id` correspondente e retorna o HTTP 200 e o json do jogo. Caso não encontre o jogo é retornado o HTTP 404.

  ```json
  {
    "nome": "Super Mário",
    "enderecoImagem": "https://jogoveio.com.br/wp-content/uploads/2019/04/super-mario-bros-nes.png",
    "descricao": "O objetivo do jogo é percorrer o Reino do Cogumelo, sobreviver às forças do vilão Bowser e salvar a Princesa Peach.",
    "genero": "Aventura",
    "anoLancamento": "1981",
    "plataforma": "Super Nintendo",
    "nota": 8
  }
  ```

- `PUT /Jogos/{id}`: Faz a alteração de um jogo ativo com o `Id` correspondente. O DTO de update somente permite a modificação nesse caso dos campos de `nome`, `endereçoImagem`, `descricao`, `genero`, `anoLançamento`, `plataforma`, `nota`, protegendo assim os campos mais sensíveis.
  O retorno é um HTTP 200 e o json do jogo modificado em caso de sucesso e um 404 caso o jogo não seja localizado.

  ```json
  {
    "nome": "Mario Kart",
    "enderecoImagem": "um endereco",
    "descricao": "Jogo do mário de corrida com kards, muito divertido.",
    "genero": "Corrida",
    "anoLancamento": "1994",
    "plataforma": "Nintendo",
    "nota": 8
  }
  ```

- `DELETE /Jogos/{id}`: Marca o jogo com o `Id` correspondente como inativo. Em caso de sucesso é retornado o HTTP 204 e caso não encontre o usuário é retornado o HTTP 404.
  O jogo é retirado da lista de jogos e de jogos favoritos de todos os usuários cadastrados.

##

### Jogos Do Usuário

- `POST /JogosDoUsuario/{id}/adicionarJogoFavorito/{idJogoFavorito}`: Adiciona um jogo ativo cadastrado `idJogoFavorito` à lista de jogos favoritos do usuário com o `id` informado. Retorna um HTTP 200 com a lista de jogos favoritos em caso de sucesso.

  ```json
  [6]
  ```

  Em caso de falha retorna um HTTP 400 caso o jogo já esteja na lista de jogos favoritos do usuário com a mensagem `"Jogo já está na lista."` ou caso o jogo não esteja cadastrado, com a mensagem `"Jogo não está na lista de jogos."`.
  Caso o usuário ou o jogo não seja encontrando ou esteja inativo, retorna um HTTP 404 com a mensagem "`Usuario não encontrado.`" ou "`Jogo não encontrado.`".

- `GET /JogosDoUsuario/{id}/todosJogos`: Retorna a lista de todos os jogos ativos cadastrados do usuário.

  ```json
  [5, 6, 7]
  ```

- `GET /JogosDoUsuario/{id}/jogosfavoritos`: Retorna a lista de todos os jogos favoritos ativos cadastrados do usuário.

  ```json
  [6]
  ```

- `DELETE /JogosDoUsuario/{id}/removerJogo/{idJogo}`: Remove o jogo da lista de jogos do usuário e marca o jogo como inativo. Retorna o HTTP 204 em caso de sucesso,
  e caso o usuário não seja encontrado retorna o HTTP 404 com a mensagem "`Usuario não encontrado.`" ou "`Jogo não está na lista.`" caso o `idJogo` não seja de um jogo na lista de jogos do usuário.

- `DELETE /JogosDoUsuario/{id}/removerJogoFavorito/{idJogoFavorito}`: Remove o jogo da lista de jogos favoritos do usuário. Retorna o HTTP 204 em caso de sucesso,
  e caso o usuário não seja encontrado retorna o HTTP 404 com a mensagem "`Usuario não encontrado.`" ou "`Jogo não está na lista.`" caso o `idJogoFavorito` não seja de um jogo na lista de jogos favoritos do usuário.

### Imagens

![](https://github.com/guih1886/carteiradejogos/blob/main/CarteiraDeJogos/Assets/Images/swagger.png#vitrinedev)
![](https://github.com/guih1886/carteiradejogos/blob/main/CarteiraDeJogos/Assets/Images/schemas.png)
![](https://github.com/guih1886/carteiradejogos/blob/main/CarteiraDeJogos/Assets/Images/modeloJogos.png)
![](https://github.com/guih1886/carteiradejogos/blob/main/CarteiraDeJogos/Assets/Images/modeloUsuarios.png)


##

### Configurando o zip

Faça o download e extraia a pasta do aplicativo. No arquivo `appsettings.json` será necessário adicionar a string de conexão com o banco de dados SQL Server. Exercutar o aplicativo carteiraDeJogos.exe.