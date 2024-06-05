# Projeto Carteira de Jogos

O projeto "Carteira de Jogos API" é uma aplicação que permite a gestão completa de jogos e usuários, oferecendo funcionalidades de criação, consulta, atualização e exclusão (CRUD). A API facilita o cadastro de jogos e usuários, onde os jogos adicionados são automaticamente vinculados à lista de jogos do usuário. Também permite que os jogos sejam adicionados à lista de favoritos do usuário, passando por diversas validações, como a verificação do usuário que está adicionando aos favoritos, verifica a duplicidade na lista de favoritos e se o jogo está realmente na lista de jogos do usuário.

A API também proporciona a gestão dos jogos no sentido de permitir a ativação e inativação. Remover um jogo da lista de jogos do usuário não o exclui permanentemente, apenas o marca como inativo, possibilitando sua reativação futura. Em termos de segurança, o uso da API requer autenticação, que é realizada através de login com email e senha cadastrados. O sistema implementa autenticação baseada em JSON Web Tokens (JWT), assegurando que somente usuários autenticados possam acessar e manipular os dados.

| :placard: Vitrine.Dev | Guilherme Henrique                                                                                                                           |
| --------------------- | -------------------------------------------------------------------------------------------------------------------------------------------- |
| :sparkles: Nome       | **CarteiraDeJogos-API**                                                                                                                      |
| :label: Tecnologias   | C#, .NET, ASP.NET, SQL Server                                                                                                                |
| :inbox_tray: Download | Download App (em breve)                                                                                                                      |

## Detalhes do projeto

> - **Cadastrar, Alterar, Deletar e Listar Jogos: Permite a criação, atualização, exclusão e listagem de jogos.**
> - **Ativação de Jogos: Possibilita a ativação de jogos, alterando seu status.**
> - **Cadastrar, Alterar, Deletar e Listar Usuários: Permite a criação, atualização, exclusão e listagem de usuários.**
> - **Adicionar e Remover Jogos Favoritos: Usuários podem adicionar e remover jogos de sua lista de favoritos.**
> - **Login com JWT: As operações POST, PUT e DELETE requerem autenticação via JWT, obtido através do endpoint /Login.**

As requisições com os verbos POST, PUT e DELETE precisam ser autenticadas com o Jwt obtido através do endpoint de `/Login`, cadastrado através do `POST /Usuarios` (livre de autenticação).

## Escalamento do projeto

- Implementado os conceitos de repository, para a clareza do código. ✅
- Implementado 44 testes para garantir a qualidade do código. ✅
- Implementar segurança de login, com o JWT. ✅
- Implementar a alteração de ativação dos jogos. ✅
- Criar as telas com windows forms para realizar as operações. ✅
- Implementar um app com Flutter para o consumo da API.

## Configurando o projeto

Faça um clone do repositório em seu diretório de preferencia, adicione o arquivo `appsettings.json` na raiz do projeto JomedAPI, você pode utilizar o modelo disponibilizado [Aqui][appsettings].<br>
Faça a alteração da chave do JWT, e a alteração da connection string do seu banco de dados SQL Server. Na raiz do projeto execute o comando `dotnet ef migrations add "Criando as migrações para o banco de dados."`, e depois `dotnet ef database update`.
Dessa forma o banco de dados estará atualizado para rodar a aplicação.

## Login

- `POST /Login`: Tenta fazer o login do usuário cadastrado através do endpoint `POST /Usuarios`. É necessário passar no corpo da requisição o json com o campo de `email` e `senha`.

  ```json
  {
    "email": "string",
    "senha": "string"
  }
  ```

  Caso o usuário e-mail e senha seja a mesma cadastrada no banco de dados, retorna um HTTP 200 com o token jwt de autenticação, e caso as credenciais estejam incorretas, retorna um HTTP 401 com a mensagem `E-mail ou senha inválido.`.

  ```
      eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjI1NzYiLCJlbWFpbCI6InN0cmluZyIsImV4cCI6MTcxNTk2MjUwMiwiaXNzIjoiZHUxZSVrbGFBc2RFI0A2Z3dtNjJkYSQzNnc1ZEBBVmczZGFzOTVkJSIsImF1ZCI6Imd1aWgxODg2In0.MqN2w9ht-hDGnqoDxSAEqmq9RP1NfItNmzva5NV8Vhk
  ```

<br>

## Usuários

- `POST /Usuarios`: Essa rota recebe através do corpo da requisição um JSON com os dados de `nome`, `email`, `senha` e `confirmacaoSenha` para o cadastro no banco de dados, aqui utilizado o SQL Server.
  O usuário não é cadastrado caso as senhas sejam divergentes ou o e-mail já esteja cadastrado, e retorna um HTTP 400 a mensagem de erro `"As senhas não são iguais."` ou `E-mail já cadastrado.`.

  ```json
  {
    "nome": "Guilherme Henrique",
    "email": "guilherme@email.com",
    "senha": "1234",
    "confirmacaoSenha": "1234"
  }
  ```

  Em caso de sucesso, a resposta é um HTTP 201 e o DTO de leitura com os campos de `id`, `nome`, `jogos` e `jogosFavoritos` do usuário.

  ```json
  {
    "id": 1,
    "nome": "Guilherme Henrique",
    "jogos": [],
    "jogosFavoritos": []
  }
  ```

- `GET /Usuarios`: Retorna o HTTP 200 e a lista de todos os usuários através do DTO de leitura.

  ```json
  [
    {
      "id": 1,
      "nome": "Pedro Henrique",
      "jogos": [],
      "jogosFavoritos": []
    },
    {
      "id": 2,
      "nome": "Guilherme Henrique",
      "jogos": [],
      "jogosFavoritos": []
    }
  ]
  ```

- `GET /Usuarios/{id}`: Detalha o usuário com o `Id` correspondente. Caso não encontre o usuário é retornado o HTTP 404 com a mensagem `Usuário não encontrado.`.

  ```json
  {
    "id": 2,
    "nome": "Guilherme Henrique",
    "jogos": [],
    "jogosFavoritos": []
  }
  ```

- `PUT /Usuarios/{id}`: Faz a alteração do usuário com o `Id` correspondente. O DTO de update somente permite a modificação nesse caso dos campos de `nome`, `jogos` e `jogosFavoritos`, protegendo assim os campos mais sensíveis.
  O retorno é um HTTP 200 e o json do usuário modificado em caso de sucesso, e um 404 com a mensagem `Usuário não encontrado.` caso o usuário não seja localizado.

  ```json
  {
    "id": 2,
    "nome": "Guilherme Henrique",
    "jogos": [1, 3, 5, 8, 10, 15, 18, 21, 22, 27, 31, 35, 39, 41, 45, 48],
    "jogosFavoritos": [1, 5, 15, 31]
  }
  ```

- `DELETE /Usuarios/{id}`: Apaga o usuário com o `Id` correspondente. Em caso de sucesso é retornado o HTTP 204 e caso não encontre o usuário é retornado o HTTP 404 com a mensagem `Usuário não encontrado.`.

<br>

## Jogos

- `POST /Jogos`: A rota cria um jogo no banco de dados, utilizando um DTO de criação com os dados `nome`, `endereçoImagem`, `descricao`, `genero`, `anoLançamento`, `plataforma`, `nota` e `usuarioId`.
  O campo de `usuarioId` é uma chave estrangeira que faz referência ao Id de usuário, e portanto, deve ser um valor válido para a inclusão. O jogo ao ser criado é marcado automaticamente como ativo.
  Em caso de sucesso, é retornado um HTTP 200 com o Dto de leitura do jogo criado, e o Id do jogo é adicionado automaticamente à lista de jogos do usuário que cadastrou o jogo.

  ```json
  {
    "nome": "Super Mário",
    "enderecoImagem": "https://jogoveio.com.br/wp-content/uploads/2019/04/super-mario-bros-nes.png",
    "descricao": "O objetivo do jogo é percorrer o Reino do Cogumelo, sobreviver às forças do vilão Bowser e salvar a Princesa Peach.",
    "genero": 1,
    "anoLancamento": "1981",
    "plataforma": "Super Nintendo",
    "ativo": 1,
    "nota": 0,
    "usuarioId": 3
  }
  ```

  Em caso de falha, será retornado um HTTP 404 e a mensagen de erro sobre quais campos estão ausentes ou com erros, ou a mensagem `Erro ao localizar o usuário com o id {UsuarioId}.`

- `GET /Jogos`: Retorna uma lista de todos os jogos através do DTO de leitura.

  ```json
  [
    {
      "id": 1,
      "nome": "Jogo Teste",
      "enderecoImagem": "",
      "descricao": "jogo teste para o metodo post",
      "genero": "Sem_Genero",
      "anoLancamento": "",
      "plataforma": "",
      "ativo": 1,
      "nota": 0
    },
    {
      "id": 2,
      "nome": "Super Mário",
      "enderecoImagem": "https://jogoveio.com.br/wp-content/uploads/2019/04/super-mario-bros-nes.png",
      "descricao": "O objetivo do jogo é percorrer o Reino do Cogumelo, sobreviver às forças do vilão Bowser e salvar a Princesa Peach.",
      "genero": "Aventura",
      "anoLancamento": "1981",
      "plataforma": "Super Nintendo",
      "ativo": 1,
      "nota": 8
    }
  ]
  ```

- `GET /Jogos/{id}`: Detalha o jogo com o `Id` correspondente e retorna o HTTP 200 e o json do jogo. Caso não encontre o jogo é retornado o HTTP 404 com a mensagem `Jogo não encontrado.`.

  ```json
  {
    "id": 2,
    "nome": "Super Mário",
    "enderecoImagem": "https://jogoveio.com.br/wp-content/uploads/2019/04/super-mario-bros-nes.png",
    "descricao": "O objetivo do jogo é percorrer o Reino do Cogumelo, sobreviver às forças do vilão Bowser e salvar a Princesa Peach.",
    "genero": "Aventura",
    "anoLancamento": "1981",
    "plataforma": "Super Nintendo",
    "ativo": 1,
    "nota": 8
  }
  ```

- `PUT /Jogos/{id}`: Faz a alteração de um jogo com o `Id` correspondente. O DTO de update somente permite a modificação nesse caso dos campos de `nome`, `endereçoImagem`, `descricao`, `genero`, `anoLançamento`, `plataforma`, `nota`, protegendo assim os campos mais sensíveis.
  O retorno é um HTTP 200 e o json do jogo modificado em caso de sucesso e um 404 com a mensagem `Jogo não encontrado.` caso o jogo não seja localizado.

  ```json
  {
    "id": 2,
    "nome": "Mario Kart",
    "enderecoImagem": "um endereco",
    "descricao": "Jogo do mário de corrida com kards, muito divertido.",
    "genero": "Corrida",
    "anoLancamento": "1994",
    "plataforma": "Nintendo",
    "ativo": 1,
    "nota": 8
  }
  ```

- `DELETE /Jogos/{id}`: Apaga o jogo com o `Id` correspondente. Em caso de sucesso é retornado o HTTP 204 e caso não encontre o usuário é retornado o HTTP 404 com a mensagem `Jogo não encontrado.`.
  O jogo é retirado da lista de jogos e de jogos favoritos do usuários.

<br>

## Jogos Do Usuário

- `POST /JogosDoUsuario/{id}/adicionarJogoFavorito/{idJogoFavorito}`: Adiciona um jogo ativo cadastrado `idJogoFavorito` à lista de jogos favoritos do usuário com o `id` informado.
  Retorna um HTTP 200 com a lista de jogos favoritos em caso de sucesso.

  ```json
  [6]
  ```

  Em caso de falha retorna um HTTP 400 caso o jogo já esteja na lista de jogos favoritos do usuário com a mensagem `"Jogo já está na lista."` ou caso o jogo não esteja cadastrado, com a mensagem `"Jogo não está na lista de jogos."`.
  Caso o usuário não seja encontrando ou esteja inativo, retorna um HTTP 404 com a mensagem `Usuario não encontrado.`.

- `POST /JogosDoUsuario/{id}/ativarJogo/{idJogo}`: Ativa o jogo do usuário e o adiciona na lista de jogos do usuário, retorna um HTTP 200 e o json do jogo ativado em caso de sucesso.
  Caso o usuário não seja encontrando ou esteja inativo, retorna um HTTP 404 com a mensagem `Usuario não encontrado.`. Caso o jogo não seja encontrando, retorna um HTTP 404 com a mensagem `Jogo não encontrado.`,
  e se o jogo não pertencer ao `id` do usuário, retorna um HTTP 400 com a mensagem `Jogo não pertence ao usuário.`. Se até aqui estiver tudo certo, e o jogo já estiver ativo, retorna um HTTP 400 com a mensagem `Jogo já está ativo.`.

- `POST /JogosDoUsuario/{id}/inativarJogo/{idJogo}`: Inativa o jogo do usuário, retorna um HTTP 200 em caso de sucesso.
  Caso o usuário não seja encontrando ou esteja inativo, retorna um HTTP 404 com a mensagem `Usuario não encontrado.`. Caso o jogo não seja encontrando, retorna um HTTP 404 com a mensagem `Jogo não encontrado.`,
  e se o jogo não pertencer ao `id` do usuário, retorna um HTTP 400 com a mensagem `Jogo não pertence ao usuário.`. Se até aqui estiver tudo certo, e o jogo já estiver inativo, retorna um HTTP 400 com a mensagem `Jogo já está inativo.`.

- `GET /JogosDoUsuario/{id}/todosJogos`: Retorna um HTTP 200 com a lista de todos os jogos cadastrados do usuário.
  Caso o usuário não seja encontrando ou esteja inativo, retorna um HTTP 404 com a mensagem `Usuario não encontrado.`.

  ```json
  [5, 6, 7]
  ```

- `GET /JogosDoUsuario/{id}/jogosfavoritos`: Retorna um HTTP 200 com a lista de todos os jogos favoritos ativos cadastrados do usuário.
  Caso o usuário não seja encontrando ou esteja inativo, retorna um HTTP 404 com a mensagem "`Usuario não encontrado.`.

  ```json
  [6]
  ```

- `DELETE /JogosDoUsuario/{id}/removerJogo/{idJogo}`: Remove o jogo da lista de jogos e da lista de jogos favoritos do usuário e marca o jogo como inativo. Retorna o HTTP 204 em caso de sucesso,
  e caso o usuário não seja encontrado retorna o HTTP 404 com a mensagem "`Usuario não encontrado.`" ou o HTTP 400 com a mensagem "`Jogo não está na lista.`" caso o `idJogo` não seja de um jogo na lista de jogos do usuário.

- `DELETE /JogosDoUsuario/{id}/removerJogoFavorito/{idJogoFavorito}`: Remove o jogo da lista de jogos favoritos do usuário. Retorna o HTTP 204 em caso de sucesso,
  e caso o usuário não seja encontrado retorna o HTTP 404 com a mensagem "`Usuario não encontrado.`" ou o HTTP 400 com a mensagem "`Jogo não está na lista.`" caso o `idJogoFavorito` não seja de um jogo na lista de jogos favoritos do usuário.

<br>

## Windows Forms

A entrada no sistema começa na tela de login, o qual faz uma requisição para `/Login` com os dados do formulário. Apresenta os erros de login caso possua ou abre a tela principal do sistema.

![](https://github.com/guih1886/carteiradejogos/blob/main/CarteiraDeJogos/Assets/Images/Forms/login.png)

A API retorna um JWT com os dados do usuário, o qual é armazenado pelo sistema para fazer as requisições, a fim de evitar o erro [HTTP 401][http401] não autorizado.

<br>

Ao clicar no botão "cadastrar" na tela de login, abre a tela para o cadastro de usuários, que faz a requisição para `/Usuarios` enviando os dados do formulário. Caso tenha erros, é exibido no label de erro, e em caso de sucesso é mostrado uma mensagem de sucesso e redirecionado para a tela de login.

![](https://github.com/guih1886/carteiradejogos/blob/main/CarteiraDeJogos/Assets/Images/Forms/cadastrar.png)

<br>

Ao fazer o login com sucesso, é aberto a tela principal, o qual tem um menu com as funcionalidades de `Listar Jogos`, `Listar os jogos Favoritos`, `Cadastro de Jogos`, `Perfil` e `Sair`.

![](https://github.com/guih1886/carteiradejogos/blob/main/CarteiraDeJogos/Assets/Images/Forms/menu.png)
![](https://github.com/guih1886/carteiradejogos/blob/main/CarteiraDeJogos/Assets/Images/Forms/principal.png)

<br>

A tela de `Todos os Jogos` tem a função de listar todos os jogos cadastrados do usuário, ativos e inativos. Abaixo tem a quantidade de jogos cadastrados do usuário.

![](https://github.com/guih1886/carteiradejogos/blob/main/CarteiraDeJogos/Assets/Images/Forms/jogos.png)

<br>

A tela de `Jogos favoritos` tem a função de listar todos os jogos favoritos cadastrados do usuário, ativos e inativos. Abaixo tem a quantidade de jogos favoritos cadastrados do usuário.

![](https://github.com/guih1886/carteiradejogos/blob/main/CarteiraDeJogos/Assets/Images/Forms/jogosFavoritos.png)

<br>

A proxima tela é a de `Cadastro de jogos`, o qual faz a função CRUD completa de jogos. Nessa tela tem o botão de "Favoritos" como um atalho para a `Lista de Jogos Favoritos`.

![](https://github.com/guih1886/carteiradejogos/blob/main/CarteiraDeJogos/Assets/Images/Forms/cadastroJogos.png)

Ao clicar no botão "Novo", o formulário é desbloqueado possibilitando o cadastro de jogos, ao clicar em "Salvar" o sistema faz a requisição `POST /Jogos` para cadastrar o jogo, e apresenta os erros no label de erro caso possua, ou a mensagem que o jogo foi cadastrado com sucesso.
Ao selecionar "Buscar", é aberto a tela de busca de jogos, o qual possui diversos filtros como `Ativo/Inativo`, `Favoritos`, `Id`, `Nome`, `Genero` e `Plataforma` que podemos fazer para buscar o jogo que desejamos com mais facilidade.

![](https://github.com/guih1886/carteiradejogos/blob/main/CarteiraDeJogos/Assets/Images/Forms/buscaJogos.png)

<br>

Ao encontrar o jogo desejado e seleciona-lo, ele é carregado para a tela de cadastro de jogos, preenchendo os campos para alteração, caso necessário. Nesse ponto, ao salvar, é feito a requisição para `PUT /Jogos/{id}` para editar o jogo.

![](https://github.com/guih1886/carteiradejogos/blob/main/CarteiraDeJogos/Assets/Images/Forms/cadastroJogosSelecionado.png)

Nesse ponto podemos editar qualquer campo do jogo, além da possibilidade de ativar ou inativar e incluir ou retirar da lista de favoritos através das flags.

<br>

Ao clicar no botão de "Perfil" na tela principal, é exibido os dados do usuário logado, com as informações de `Id`, `Nnome`, `Lista dos Ids dos Jogos` e a `Lista dos Ids dos Jogos Favoritos`.

![](https://github.com/guih1886/carteiradejogos/blob/main/CarteiraDeJogos/Assets/Images/Forms/usuario.png)

Nessa tela é possivel editar o cadastro do usuário, o qual é limitada apenas ao nome, pois a lista de jogos e de jogos favoritos é administrado tela tela de Cadastro de Jogos.

## Imagens

![](https://github.com/guih1886/carteiradejogos/blob/main/CarteiraDeJogos/Assets/Images/swagger.png#vitrinedev)
![](https://github.com/guih1886/carteiradejogos/blob/main/CarteiraDeJogos/Assets/Images/schemas.png)
![](https://github.com/guih1886/carteiradejogos/blob/main/CarteiraDeJogos/Assets/Images/modeloJogos.png)
![](https://github.com/guih1886/carteiradejogos/blob/main/CarteiraDeJogos/Assets/Images/modeloUsuarios.png)
![](https://github.com/guih1886/carteiradejogos/blob/main/CarteiraDeJogos/Assets/Images/testes.png)


[appsettings]: https://raw.githubusercontent.com/guih1886/jomedAPI/main/JomedAPI/Assets/appsettings.json
[http401]: https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/401
