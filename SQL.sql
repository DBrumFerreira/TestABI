
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
    (gen_random_uuid(), 'Brahma Chopp', 'Cerveja tipo lager com sabor leve e cremosidade característica, perfeita para festas e churrascos.', 6.50, NOW()),
    (gen_random_uuid(), 'Skol Pilsen', 'Cerveja Pilsen refrescante e leve, ideal para momentos de descontração.', 6.00, NOW()),
    (gen_random_uuid(), 'Antarctica Original', 'Cerveja de sabor tradicional e marcante, muito apreciada pelo público brasileiro.', 7.00, NOW()),
    (gen_random_uuid(), 'Budweiser', 'Cerveja lager americana com sabor equilibrado e aroma de malte.', 9.00, NOW()),
    (gen_random_uuid(), 'Stella Artois', 'Cerveja belga premium com sabor sofisticado e aroma elegante.', 10.50, NOW()),
    (gen_random_uuid(), 'Quilmes Cristal', 'Cerveja argentina tipo lager, leve e refrescante, ideal para acompanhar refeições.', 8.50, NOW()),
    (gen_random_uuid(), 'Labatt Blue', 'Cerveja canadense tipo lager com sabor suave e aroma refrescante.', 9.00, NOW()),
    (gen_random_uuid(), 'Presidente', 'Cerveja dominicana tipo Pilsen com sabor equilibrado e refrescante.', 8.00, NOW());


	