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

# Sales API Documentation

## Introduction
This documentation describes the operations available in the Sales API, including how to create, update, cancel, and retrieve sales. The API was developed based on Domain-Driven Design (DDD) principles and contains specific business rules for discounts and quantity limits.

## How to Run

1. **Prerequisites**:
   - .NET Core SDK installed.
   - Docker Desktop installed and configured.
   - PostgreSQL database configured.
   - Database management tools like DBeaver or pgAdmin to manage PostgreSQL.

2. **Running the API**:
   - Clone the GitHub repository: `git clone <repository-link>`
   - Navigate to the project directory: `cd <project-directory>`
   - Configure the database connection string in the `appsettings.json` file.
   - Run the project: `dotnet run`
   
## Database Migrations

The database migrations have been configured to facilitate system development and testing. They include fake product data that can be used to test the application's functionalities without the need to insert real data. This helps ensure the system works as expected before being deployed in a production environment.

### Fake Products

- Fake product data is automatically inserted during the migration process.

The inserted products can be viewed directly in the database using tools like pgAdmin or DBeaver. They are ready to be used in sales.

- **Verification**: Access the database to check product details.
- **Use in Sales**: Use these products to simulate and test sales transactions in the system.

These products were added to facilitate testing and ensure that sales functionalities work correctly.

## Endpoints

### Create Sale

- **Method**: `POST`
- **URL**: `/api/sales`
- **Request Body**:

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

- **Business Rules**:
  - Discounts are applied for purchases of 4 or more identical items.
  - Purchases of more than 20 identical items are not allowed.

### Update Sale

- **Method**: `PUT`
- **URL**: `/api/sales`
- **Request Body**:
  
  Similar to the creation body, with the addition of `saleId` to identify the sale to be updated.

### Cancel Sale

- **Method**: `PATCH`
- **URL**: `/api/sales/{id}/cancel`
- **Description**: Cancels a sale by ID.
- **Sample Response**:
  
  ```json
  {
    "success": true,
    "message": "Sale canceled successfully"
  }
  ```

### Retrieve Sale

- **Method**: `GET`
- **URL**: `/api/sales/{id}`
- **Description**: Returns the details of a sale by ID.
- **Sample Response**:

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

## Main Business Rules

1. **Quantity Discounts**:
   - 10% discount for 4 or more identical items.
   - 20% discount for 10 to 20 identical items.
   - Purchases over 20 items are not allowed.

2. **Sales Events** (optional):
   - Log Created, Modified, and Canceled Sales events, as well as Canceled Items, in the application log.
   
# Note on Unit Tests

## Absence of Unit Tests

Unfortunately, the current project does not include unit tests. Due to a tight deadline and other personal circumstances, it was not possible to implement comprehensive test coverage.

### Reasons for Absence

- **Tight Deadline**: The available time to complete this project was limited, requiring prioritization of core functionalities.
- **Professional Commitments**: Recent deliverables at my current company required significant time and dedication, limiting my ability to include unit tests.
- **Surgery Preparations**: I have been preparing for a scheduled surgery on 04/15, and decided to prioritize the necessary rest for the procedure.
- **Overtime**: I worked until 2 AM to ensure the project was delivered in its current state, balancing professional and personal demands.

Despite the absence of unit tests, efforts were directed to ensure essential functionalities were implemented and manually tested. I plan to add unit tests in future iterations to improve the system's robustness and reliability.
