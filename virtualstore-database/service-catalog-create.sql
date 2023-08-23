DROP TABLE IF EXISTS product;
DROP TABLE IF EXISTS catalog;
DROP TABLE IF EXISTS category;

CREATE TABLE category (
    id_category SERIAL PRIMARY KEY,
    name TEXT,
    description TEXT,
    active INTEGER,
    registration_date DATE
);

CREATE TABLE product (
    id_product SERIAL PRIMARY KEY,
    name TEXT,
    description TEXT,
    brand TEXT,
    price REAL,
    stock INTEGER,
    active INTEGER,
    id_category INTEGER,
    registration_date DATE,
    modification_date DATE,
    FOREIGN KEY (id_category) REFERENCES category(id_category)
);