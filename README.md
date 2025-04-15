# Developer Evaluation Project

`READ CAREFULLY`

## Instructions
**The test below will have up to 7 calendar days to be delivered from the date of receipt of this manual.**

- The code must be versioned in a public Github repository and a link must be sent for evaluation once completed
- Upload this template to your repository and start working from it
- Read the instructions carefully and make sure all requirements are being addressed
- The repository must provide instructions on how to configure, execute and test the project
- Documentation and overall organization will also be taken into consideration

## Use Case
**You are a developer on the DeveloperStore team. Now we need to implement the API prototypes.**

As we work with `DDD`, to reference entities from other domains, we use the `External Identities` pattern with denormalization of entity descriptions.

Therefore, you will write an API (complete CRUD) that handles sales records. The API needs to be able to inform:

* Sale number
* Date when the sale was made
* Customer
* Total sale amount
* Branch where the sale was made
* Products
* Quantities
* Unit prices
* Discounts
* Total amount for each item
* Cancelled/Not Cancelled

It's not mandatory, but it would be a differential to build code for publishing events of:
* SaleCreated
* SaleModified
* SaleCancelled
* ItemCancelled

If you write the code, **it's not required** to actually publish to any Message Broker. You can log a message in the application log or however you find most convenient.

### Business Rules

* Purchases above 4 identical items have a 10% discount
* Purchases between 10 and 20 identical items have a 20% discount
* It's not possible to sell above 20 identical items
* Purchases below 4 items cannot have a discount

These business rules define quantity-based discounting tiers and limitations:

1. Discount Tiers:
   - 4+ items: 10% discount
   - 10-20 items: 20% discount

2. Restrictions:
   - Maximum limit: 20 items per product
   - No discounts allowed for quantities below 4 items

## Overview
This section provides a high-level overview of the project and the various skills and competencies it aims to assess for developer candidates. 

See [Overview](/.doc/overview.md)

## Tech Stack
This section lists the key technologies used in the project, including the backend, testing, frontend, and database components. 

See [Tech Stack](/.doc/tech-stack.md)

## Frameworks
This section outlines the frameworks and libraries that are leveraged in the project to enhance development productivity and maintainability. 

See [Frameworks](/.doc/frameworks.md)

<!-- 
## API Structure
This section includes links to the detailed documentation for the different API resources:
- [API General](./docs/general-api.md)
- [Products API](/.doc/products-api.md)
- [Carts API](/.doc/carts-api.md)
- [Users API](/.doc/users-api.md)
- [Auth API](/.doc/auth-api.md)
-->

## Project Structure
This section describes the overall structure and organization of the project files and directories. 

See [Project Structure](/.doc/project-structure.md)

---

Aqui está a documentação convertida para o formato Markdown:

```markdown
# Documentação da API de Vendas

## Introdução
Esta documentação descreve as operações disponíveis na API de vendas, incluindo como criar, atualizar, cancelar e recuperar vendas. A API foi desenvolvida com base nos princípios de Domain-Driven Design (DDD) e contém regras de negócios específicas para descontos e limites de quantidade.

## Como Rodar

1. **Pré-requisitos**:
   - .NET Core SDK instalado.
   - Banco de dados PostgreSQL configurado.
   - Ferramentas de gerenciamento de banco de dados como DBeaver ou pgAdmin para gerenciar o PostgreSQL.

2. **Executando a API**:
   - Clone o repositório do GitHub: `git clone <link-do-repositório>`
   - Navegue até o diretório do projeto: `cd <diretório-do-projeto>`
   - Configure a string de conexão do banco de dados no arquivo `appsettings.json`.
   - Execute o projeto: `dotnet run`

## Endpoints

### Criar Venda

- **Método**: `POST`
- **URL**: `/api/sales`
- **Corpo da Requisição**:

  ```json
  {
    "customerName": "John Doe",
    "branch": "Main",
    "saleDate": "2023-10-10T14:48:00.000Z",
    "products": [
      {
        "productId": "guid",
        "quantity": 5,
        "unitPrice": 10.0,
        "discount": 0.0
      }
    ]
  }
  ```

- **Regras de Negócio**:
  - Descontos são aplicados para compras de 4 ou mais itens idênticos.
  - Compras acima de 20 itens idênticos não são permitidas.

### Atualizar Venda

- **Método**: `PUT`
- **URL**: `/api/sales`
- **Corpo da Requisição**:
  
  Similar ao corpo de criação, com a adição do `saleId` para identificar a venda a ser atualizada.

### Cancelar Venda

- **Método**: `PATCH`
- **URL**: `/api/sales/{id}/cancel`
- **Descrição**: Cancela uma venda pelo ID.
- **Exemplo de Resposta**:
  
  ```json
  {
    "success": true,
    "message": "Sale canceled successfully"
  }
  ```

### Consultar Venda

- **Método**: `GET`
- **URL**: `/api/sales/{id}`
- **Descrição**: Retorna os detalhes de uma venda pelo ID.
- **Exemplo de Resposta**:

  ```json
  {
    "success": true,
    "data": {
      "saleId": "guid",
      "customerName": "John Doe",
      "branch": "Main",
      "saleDate": "2023-10-10T14:48:00.000Z",
      "products": [
        {
          "productId": "guid",
          "quantity": 5,
          "unitPrice": 10.0,
          "discount": 1.0,
          "totalItemAmount": 45.0
        }
      ]
    }
  }
  ```

## Regras de Negócio Principais

1. **Descontos por Quantidade**:
   - 10% de desconto para 4 ou mais itens idênticos.
   - 20% de desconto para 10 a 20 itens idênticos.
   - Compras acima de 20 itens não são permitidas.

2. **Eventos de Venda** (opcional):
   - Registre eventos de Venda Criada, Modificada e Cancelada, bem como Itens Cancelados, no log de aplicação.

Esta documentação fornece uma visão geral das funcionalidades básicas e regras da API de vendas. Para detalhes completos e exemplos de implementação, consulte o código fonte no repositório do projeto.
```

Esse texto em Markdown pode ser usado em repositórios de código como GitHub para fornecer documentação clara e estruturada para usuários e desenvolvedores.