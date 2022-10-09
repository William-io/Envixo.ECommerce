API, versão: .NET 6

## Installation

Usar o CLI Dotnet Package, 

```bash
> dotnet add package Flunt --version 2.0.5
> dotnet add package Microsoft.EntityFrameworkCore --version 6.0.9
> dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.9
```
## Run
```
Defina a conexão do banco de dados em appsettings.Development.json, na seção ConnectionStrings:Connection.
```


### Request methods [ Category ] 

| Method   | URL                                      | Description                              |
| -------- | ---------------------------------------- | ---------------------------------------- |
| `GET`    | `/categories`                            | Obter lista de categorias.               |
| `POST`   | `/categories`                            | Crie uma categoria com um nome.          |
| `PUT`    | `/categories/{id}`                       | Precisa-se inserir o ID.                 |
| `DELETE` | `/categories/{id}`                       | Precisa-se inserir o ID.                 |

#### Schema

```
{
  "name": "string",
  "active": true
}
```

### Request methods [ Product ] 

| Method   | URL                                      | Description                              |
| -------- | ---------------------------------------- | ---------------------------------------- |
| `GET`    | `/products`                              | Obter lista de produtos.                 |
| `GET`    | `/products/{title}`                      | Obter lista de produtos por titulo.      |
| `GET`    | `/products/showcase`                     | Obter lista de produtos por parginação.  |
| `POST`   | `/products`                              | Crie uma categoria com um nome.          |
| `PUT`    | `/products/{id}`                         | Precisa-se inserir o ID.                 |
| `DELETE` | `/products/{id}`                         | Precisa-se inserir o ID.                 |


#### Schema

```
{
  "title": "string",
  "description": "string",
  "midiaUrl": "string",
  "status": true,
  "price": 0,
  "promotionalPrice": 0,
  "tags": [
    "string"
  ],
  "categoryId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
```
