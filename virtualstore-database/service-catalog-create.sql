DROP TABLE IF EXISTS product;
DROP TABLE IF EXISTS category;

CREATE TABLE category (
    CategoryId SERIAL PRIMARY KEY,
    Name TEXT,
    Description TEXT,
    CreatedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    LastModifiedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    IsActive BOOLEAN NOT NULL DEFAULT true
);

CREATE TABLE product (
    ProductId SERIAL PRIMARY KEY,
    Name TEXT,
    Description TEXT,
    Brand TEXT,
    Price REAL,
    Stock INTEGER,
    CategoryId INTEGER,
    CreatedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    LastModifiedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    IsActive BOOLEAN NOT NULL DEFAULT true
    FOREIGN KEY (CategoryId) REFERENCES category(CategoryId)
);