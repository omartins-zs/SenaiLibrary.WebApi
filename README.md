# Senai Library Web Api
API de Biblioteca de Jogos  


## Melhorias a fazer:

<details>
  <summary>Adicionar + Funcionalidades Com a Tabela Jogadores</summary>
 

- [ ] Criando Repositorio de Jogador

- [ ] Criar Controller de Jogador

- [ ] Criando metodo Listar Jogadores

- [ ] Adicionando EndPoint de GET no Controller

- [ ] Criando metodo Buscar By Id do Jogador

- [ ] Adicionando EndPoint de GET By Id no Controller

- [ ] Criando Metodo Cadastrar Jogador

- [ ] Adicionando EndPoint de POST no Controller

- [ ] Criando metodo Atualizar Jogador

- [ ] Adicionando EndPoint de PUT no Controller

- [ ] Criando metodo Deletar Jogador

- [ ] Adicionando EndPoint de DELETE no Controller

- [ ] Adicionando Restriçao no DELETE Jogador

</details>

<div align="center">

   <h3 align="center"><i>📖Documentaçao da Api</em></i></h3>
  
   <cite align="center">`http://localhost:5000`</cite>
  


| Método| Endpoint | Descrição |Corpo da solicitação| Corpo da resposta|
| :---------- | :--------- | :---------------------------------- | :--------- | :---------------------------------- |
| `GET` | `/api/jogos`   | Obter todos os jogos | `Nenhum` | Lista de livros|
|`GET`| `/api/jogos/{id}`| Obter um livro por um identificador |`Nenhum`| Um livro|
| `POST ` | `/api/jogos`   | Adicionar um livro| `Dados do livro` | Nenhum |
| `PUT` |`/api/jogos/{id}` | Atualizar os dados de um livro existente | `Dados do livro` | Nenhum |
| `DELETE` | `/api/jogos/{id}` | Excluir um livro | `Nenhum` | Nenhum |
| `POST` | `/api/login` | Criar um token | `Email e senha` | token |

    


  
</div>
