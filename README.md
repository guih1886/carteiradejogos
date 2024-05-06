# Projeto Carteira de Jogos

O projeto carteira de jogos é um projeto onde é possível cadastrar, alterar, deletar e adicionar os jogos aos favoritos. O projeto envolve uma complexidade onde cada jogo cadastrado é incluido na lista de jogos do usuário, e ao ser excluido o jogo é inativado, não aparecendo mais para o usuário. Também é possível adicionar os jogos a lista de favoritos, caso esse jogo já esteja na lista de jogos do usuário.

| :placard: Vitrine.Dev | Guilherme Henrique                                                                                     |
|-----------------------|--------------------------------------------------------------------------------------------------------|
| :sparkles: Nome       | **CarteiraDeJogos-API**                                                                                |
| :label: Tecnologias   | C#, .NET, ASP.NET, MySQL                                                                               |
| :inbox_tray: Download | [Download EXE]()                                                                                       |

### Detalhes do projeto
> - **Cadastrar, Alterar, deletar, listar e detalhar os jogos.**
> - **Cadastrar, Alterar, deletar, listar e detalhar os usuários.**
> - **Adicionar e remover os jogos na lista de jogos favoritos do usuário.**

##

- `POST /Usuarios`: Essa rota recebe através do corpo da requisição um JSON com os dados de `nome`, `senha` e `confirmacaoSenha` cadastrado
  previamente no banco de dados, aqui utilizado o MySQL. O usuário não é cadastrado caso as senhas sejam divergentes.

  ```json
    {
        "nome": "Guilherme Henrique",
        "senha": "1234",
        "confirmacaoSenha": "1234"
    }
  ```

####

##

### Imagens

![](https://github.com/guih1886/vollmedAPI/blob/main/src/main/resources/static/reqConsultas.png#vitrinedev)

