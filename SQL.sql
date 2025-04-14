
DROP TABLE IF EXISTS "Users";
CREATE TABLE "Users" (
    "Id" UUID DEFAULT gen_random_uuid() PRIMARY KEY, -- Campo ID com UUID gerado automaticamente
    "Email" VARCHAR(100) NOT NULL, -- Campo Email, obrigatório, com limite de 100 caracteres
    "Password" VARCHAR(100) NOT NULL, -- Campo Password, obrigatório, com limite de 100 caracteres
    "Phone" VARCHAR(20) NOT NULL, -- Campo Phone, obrigatório, com limite de 20 caracteres
    "Role" VARCHAR(20) NOT NULL, -- Campo Role, obrigatório, com limite de 20 caracteres
    "Status" VARCHAR(20) NOT NULL, -- Campo Status, obrigatório, com limite de 20 caracteres
    "Username" VARCHAR(50) NOT NULL, -- Campo Username, obrigatório, com limite de 50 caracteres
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT NOW(), -- Data de criação do produto
    "UpdatedAt" TIMESTAMP NULL -- Data de atualização do produto
);

DROP TABLE IF EXISTS "Sales";
CREATE TABLE "Sales" (
    "Id" UUID DEFAULT gen_random_uuid() PRIMARY KEY, -- Identificador único da venda
    "SaleNumber" SERIAL NOT NULL, -- Número incremental da venda
    "SaleDate" TIMESTAMP NOT NULL, -- Data da venda
    "CustomerName" VARCHAR(100) NOT NULL, -- Nome do cliente
    "Branch" VARCHAR(100) NOT NULL, -- Filial onde a venda foi realizada
    "TotalAmount" NUMERIC(10, 2) NOT NULL, -- Valor total da venda
    "IsCancelled" BOOLEAN NOT NULL DEFAULT FALSE -- Indicador de venda cancelada
);

DROP TABLE IF EXISTS "Products";
CREATE TABLE "Products" (
    "Id" UUID DEFAULT gen_random_uuid() PRIMARY KEY, -- Identificador único do produto
    "Name" VARCHAR(100) NOT NULL, -- Nome do produto
    "Description" TEXT, -- Descrição do produto (opcional)
    "Price" NUMERIC(10, 2) NOT NULL, -- Preço unitário do produto
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT NOW(), -- Data de criação do produto
    "UpdatedAt" TIMESTAMP NULL -- Data de atualização do produto
);

DROP TABLE IF EXISTS "SaleProducts";
CREATE TABLE "SaleProducts" (
    "Id" UUID DEFAULT gen_random_uuid() PRIMARY KEY, -- Identificador único do produto na venda
    "SaleId" UUID NOT NULL REFERENCES "Sales"("Id") ON DELETE CASCADE, -- Relacionamento com Sales
    "ProductId" UUID NOT NULL REFERENCES "Products"("Id") ON DELETE CASCADE, -- Relacionamento com Products
    "Quantity" INT NOT NULL, -- Quantidade do produto vendido
    "UnitPrice" NUMERIC(10, 2) NOT NULL, -- Preço unitário do produto na venda
    "Discount" NUMERIC(10, 2) NOT NULL DEFAULT 0, -- Desconto aplicado
    "TotalItemAmount" NUMERIC(10, 2) NOT NULL -- Valor total do item (após desconto)
);

INSERT INTO "Products" ("Id", "Name", "Description", "Price", "CreatedAt")
VALUES
    (gen_random_uuid(), 'Notebook Gamer', 'Notebook com alto desempenho para jogos, 16GB RAM, SSD 512GB.', 6500.00, NOW()),
    (gen_random_uuid(), 'Smartphone Pro', 'Smartphone com câmera tripla, 128GB de armazenamento.', 3200.00, NOW()),
    (gen_random_uuid(), 'Fone de Ouvido Bluetooth', 'Fone de ouvido sem fio com cancelamento de ruído.', 800.00, NOW()),
    (gen_random_uuid(), 'Monitor 4K Ultra HD', 'Monitor de alta resolução, 27 polegadas, ideal para trabalhos gráficos.', 1800.00, NOW()),
    (gen_random_uuid(), 'Teclado Mecânico RGB', 'Teclado mecânico com iluminação RGB e switches silenciosos.', 450.00, NOW());


	