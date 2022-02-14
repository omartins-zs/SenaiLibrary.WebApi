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




<details>
  <summary>Explicação do `Summary`</summary>
  
 
`<summary>` marca deve ser usada para descrever um tipo ou um membro de tipo
 
`<summary>` ->	Aqui é a descrição do membro. Você descreve exatamente para qual fim é o método, variável, classe e etc.  

`<return>` ->	Como o nome já diz, descreve entre essa tag que tipo de informação seu método irá retornar (se ele retornar alguma coisa).

`<param name="NOME">` ->	Utilizada para definir informações de um parâmetro da função (se ela possuir). Possui o atributo name, onde seu valor deve ser o nome do parâmetro.

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

  
### Referencia
  
[É uma boa prática utilizar ´summary´ para documentação?](https://pt.stackoverflow.com/questions/9847/%C3%89-uma-boa-pr%C3%A1tica-utilizar-summary-para-documenta%C3%A7%C3%A3o)
