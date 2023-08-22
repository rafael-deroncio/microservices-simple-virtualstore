DROP TABLE IF EXISTS product;
DROP TABLE IF EXISTS catalog;

CREATE TABLE catalog (
    id_catalog SERIAL PRIMARY KEY,
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
    catalog_id INTEGER,
    registration_date DATE,
    modification_date DATE,
    FOREIGN KEY (catalog_id) REFERENCES catalog(id_catalog)
);