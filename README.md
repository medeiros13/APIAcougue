# Açougue Back-end
## Descrição do projeto
Este projeto trata-se do back-end de um açougue, criado como um trabalho dos alunos: Augusto Garcia, Fernando Gamba, Gabriel Medeiros e Guilherme Basei para a disciplina de Desenvolvimento Web da [Universidade La Salle](https://www.unilasalle.edu.br/canoas).

O projeto comunica-se com o seguinte projeto de front-end: [Açougue Front-end](https://github.com/GuilhermeBasei/acouguedusgu).

## Preparando o ambiente
### Ferramentas necessárias para executar a aplicação
1. [Sqlite](https://www.sqlite.org/download.html);

2. [.NET 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0);

### Instalando dependências do projeto
Já com as ferramentas necessárias intaladas em seu computador e com o projeto clonado, é necessário instalar as dependências do projeto, para isso:

1. Acesse a pasta do projeto por linha de comando:
~~~
cd ApiAcougue
~~~
2. Execute o seguinte comando para restaurar os pacotes do nuget:
~~~
dotnet restore
~~~

### Criando o banco de dados
Agora que as dependências do projeto estão instaladas, é necessário criar o banco de dados local no seu computador.

O projeto utiliza o Sqlite como banco de dados, criando um arquivo app.db na pasta raíz do projeto.

Para criar o banco de dados, é necessário executar o comando:
~~~
dotnet ef database update
~~~

caso o comando acima dê erro, execute o comando abaixo e tente novamente rodar o comando acima:
~~~
dotnet tool install --global dotnet-ef
~~~

### Subindo a aplicação
Agora estamos com tudo pronto para subir a aplicação,
você pode executar o seguinte comando para rodar a aplicação:
~~~
dotnet run
~~~

Vale ressaltar que esta aplicação roda na **porta 5204** por padrão.

### Acessando a página do Swagger
O projeto dá suporte à OpenAPI (Swagger), após subir a aplicação, acesse o endereço:

http://localhost:5204/swagger/index.html

## Estrutura da aplicação
A aplicação foi desenvolvida utilizando a arquitetura MVC (Model View Controller), porém, como se trata de uma API, temos apenas os Models e os Controllers.

Os models estão estruturados conforme a imagem abaixo:
![Estrutura das models do projeto](/APIAcougue.png "Estrutura das models do projeto")

## Endpoints da aplicação
A aplicação conta com endpoints de Create, Read, Update, Delete para todas as Models, todas iniciam com o prefixo "v1/".

### Users
#### Buscar todos os usuários
* Endpoint: http://localhost:5204/v1/users
* HTTP Method: GET
* HTTP Success Response Code: OK (200)

#### Buscar usuário por id
* Endpoint: http://localhost:5204/v1/users/<userId>
* HTTP Method: GET
* HTTP Success Response Code: OK (200)

#### Adicionar novo usuário
* Endpoint: http://localhost:5204/v1/users/
* HTTP Method: POST
* HTTP Success Response Code: Created (201)
* Contract:
    * Request Payload:

```json
{
  "id": 0,
  "name": "string",
  "password": "string"
}
```

#### Alterar usuário
* Endpoint: http://localhost:5204/v1/users/<userId>
* HTTP Method: PUT
* HTTP Success Response Code: No Content (204)
* Contract:
    * Request Payload:

```json
{
  "id": 0,
  "name": "string",
  "password": "string"
}
```

#### Remover usuário
* Endpoint: http://localhost:5204/v1/users/<userId>
* HTTP Method: DELETE
* HTTP Success Response Code: OK (200)

### Products
#### Buscar todos os produtos
* Endpoint: http://localhost:5204/v1/products
* HTTP Method: GET
* HTTP Success Response Code: OK (200)

#### Buscar produto por id
* Endpoint: http://localhost:5204/v1/products/<productId>
* HTTP Method: GET
* HTTP Success Response Code: OK (200)

#### Adicionar novo produto
* Endpoint: http://localhost:5204/v1/products/
* HTTP Method: POST
* HTTP Success Response Code: Created (201)
* Contract:
    * Request Payload:

```json
{
  "id": 0,
  "description": "string",
  "price": 0
}
```

#### Alterar produto
* Endpoint: http://localhost:5204/v1/products/<productId>
* HTTP Method: PUT
* HTTP Success Response Code: No Content (204)
* Contract:
    * Request Payload:

```json
{
  "id": 2,
  "description": "string",
  "price": 0
}
```

#### Remover produto
* Endpoint: http://localhost:5204/v1/products/<productId>
* HTTP Method: DELETE
* HTTP Success Response Code: OK (200)

### Sales
#### Buscar todas as vendas
* Endpoint: http://localhost:5204/v1/sales
* HTTP Method: GET
* HTTP Success Response Code: OK (200)

#### Buscar venda por id
* Endpoint: http://localhost:5204/v1/sales/<saleId>
* HTTP Method: GET
* HTTP Success Response Code: OK (200)

#### Adicionar nova venda
* Endpoint: http://localhost:5204/v1/sales/
* HTTP Method: POST
* HTTP Success Response Code: Created (201)
* Contract:
    * Request Payload:

```json
{
  "id": 0,
  "customer": {
    "id": 0,
    "name": "string",
    "password": "string"
  },
  "items": [
    {
      "id": 0,
      "product": {
        "id": 0,
        "description": "string",
        "price": 0
      },
      "quantity": 0
    }
  ]
}
```

#### Alterar venda
* Endpoint: http://localhost:5204/v1/sales/<saleId>
* HTTP Method: PUT
* HTTP Success Response Code: No Content (204)
* Contract:
    * Request Payload:

```json
{
  "id": 0,
  "customer": {
    "id": 0,
    "name": "string",
    "password": "string"
  },
  "items": [
    {
      "id": 0,
      "product": {
        "id": 0,
        "description": "string",
        "price": 0
      },
      "quantity": 0
    }
  ]
}
```

#### Remover venda
* Endpoint: http://localhost:5204/v1/sales/<saleId>
* HTTP Method: DELETE
* HTTP Success Response Code: OK (200)

### Sale Items
#### Buscar todos os itens da venda
* Endpoint: http://localhost:5204/v1/saleitems
* HTTP Method: GET
* HTTP Success Response Code: OK (200)

#### Buscar item da venda por id
* Endpoint: http://localhost:5204/v1/saleitems/<saleItemId>
* HTTP Method: GET
* HTTP Success Response Code: OK (200)

#### Adicionar novo item da venda
* Endpoint: http://localhost:5204/v1/saleitems/
* HTTP Method: POST
* HTTP Success Response Code: Created (201)
* Contract:
    * Request Payload:

```json
{
  "id": 0,
  "product": {
    "id": 0,
    "description": "string",
    "price": 0
  },
  "quantity": 0
}
```

#### Alterar item da venda
* Endpoint: http://localhost:5204/v1/saleitems/<saleItemId>
* HTTP Method: PUT
* HTTP Success Response Code: No Content (204)
* Contract:
    * Request Payload:

```json
{
  "id": 0,
  "product": {
    "id": 0,
    "description": "string",
    "price": 0
  },
  "quantity": 0
}
```

#### Remover item da venda
* Endpoint: http://localhost:5204/v1/saleitems/<saleItemId>
* HTTP Method: DELETE
* HTTP Success Response Code: OK (200)
