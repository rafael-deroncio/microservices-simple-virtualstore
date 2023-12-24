-- Antes de excluir as tabelas, remova as chaves estrangeiras que dependem da tabela Users
ALTER TABLE IF EXISTS UserClaims DROP CONSTRAINT IF EXISTS userclaims_userid_fkey;
ALTER TABLE IF EXISTS UserLogins DROP CONSTRAINT IF EXISTS userlogins_userid_fkey;
ALTER TABLE IF EXISTS UserRoles DROP CONSTRAINT IF EXISTS userroles_userid_fkey;
ALTER TABLE IF EXISTS UserTokens DROP CONSTRAINT IF EXISTS usertokens_userid_fkey;
ALTER TABLE IF EXISTS UserAddresses DROP CONSTRAINT IF EXISTS useraddresses_userid_fkey;
ALTER TABLE IF EXISTS UserTelephones DROP CONSTRAINT IF EXISTS usertelephones_userid_fkey;

-- Agora, você pode excluir as tabelas
DROP TABLE IF EXISTS UserRoles;
DROP TABLE IF EXISTS UserClaims;
DROP TABLE IF EXISTS UserTokens;
DROP TABLE IF EXISTS UserLogins;
DROP TABLE IF EXISTS UserAddresses;
DROP TABLE IF EXISTS UserTelephones;
DROP TABLE IF EXISTS Users CASCADE;
DROP TABLE IF EXISTS Roles CASCADE;
DROP TABLE IF EXISTS Addresses CASCADE;
DROP TABLE IF EXISTS Telephones CASCADE;
DROP TABLE IF EXISTS Claims;
DROP TABLE IF EXISTS Tokens;
DROP TABLE IF EXISTS Logins;

-- Tabela de Papeis
CREATE TABLE Roles
(
    RoleId SERIAL PRIMARY KEY,
    RoleName VARCHAR(256) NOT NULL,
    CreatedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    LastModifiedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    IsActive BOOLEAN NOT NULL DEFAULT true
);

-- Tabela de Reivindicações (Claims)
CREATE TABLE Claims
(
    ClaimId SERIAL PRIMARY KEY,
    ClaimType VARCHAR(256),
    ClaimValue VARCHAR(256),
    CreatedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    LastModifiedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    IsActive BOOLEAN NOT NULL DEFAULT true
);

-- Tabela de Tokens
CREATE TABLE Tokens
(
    TokenId SERIAL PRIMARY KEY,
    TokenValue VARCHAR(128) NOT NULL,
    Expires TIMESTAMPTZ NOT NULL,
    Message VARCHAR(128) NOT NULL,
    CreatedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP
);

-- Tabela de Logins
CREATE TABLE Logins
(
    LoginId SERIAL PRIMARY KEY,
    LoginProvider VARCHAR(128) NOT NULL,
    ProviderKey VARCHAR(128) NOT NULL,
    CreatedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP
);

-- Tabela de Endereços
CREATE TABLE Addresses
(
    AddressId SERIAL PRIMARY KEY,
    Street VARCHAR(255) NOT NULL,
    City VARCHAR(100) NOT NULL,
    State VARCHAR(50) NOT NULL,
    ZipCode VARCHAR(20) NOT NULL,
    Country VARCHAR(100) NOT NULL,
    CreatedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    LastModifiedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    IsActive BOOLEAN NOT NULL DEFAULT true
);

-- Tabela de Telefones
CREATE TABLE Telephones
(
    TelephoneId SERIAL PRIMARY KEY,
    PhoneNumber VARCHAR(20) NOT NULL,
    PhoneType VARCHAR(50) NOT NULL,
    CreatedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    LastModifiedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    IsActive BOOLEAN NOT NULL DEFAULT true
);

-- Tabela de Usuários
CREATE TABLE Users
(
    UserId SERIAL PRIMARY KEY,
    UserName VARCHAR(256) NOT NULL,
    Name VARCHAR(256) NOT NULL,
    CPF VARCHAR(11) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender VARCHAR(1) NOT NULL,
    Email VARCHAR(256) NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    SecurityStamp VARCHAR(255),
    TwoFactorEnabled BOOLEAN NOT NULL,
    LockoutEndDateUtc TIMESTAMPTZ,
    LockoutEnabled BOOLEAN NOT NULL,
    AccessFailedCount INT NOT NULL,
    CreatedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    LastModifiedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    IsActive BOOLEAN NOT NULL DEFAULT true
);


-- Tabela de Associação entre Usuários e Endereços
CREATE TABLE UserAddresses
(
    Id SERIAL PRIMARY KEY,
    UserId INT REFERENCES Users(UserId) NOT NULL,
    AddressId INT REFERENCES Addresses(AddressId) NOT NULL,
    CreatedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    LastModifiedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    IsActive BOOLEAN NOT NULL DEFAULT true
);

-- Tabela de Associação entre Usuários e Telefones
CREATE TABLE UserTelephones
(
    Id SERIAL PRIMARY KEY,
    UserId INT REFERENCES Users(UserId) NOT NULL,
    TelephoneId INT REFERENCES Telephones(TelephoneId) NOT NULL,
    CreatedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    LastModifiedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    IsActive BOOLEAN NOT NULL DEFAULT true
);

-- Tabela de Associação entre Usuários e Papeis
CREATE TABLE UserRoles
(
    Id SERIAL PRIMARY KEY,
    UserId INT REFERENCES Users(UserId) NOT NULL,
    RoleId INT REFERENCES Roles(RoleId) NOT NULL,
    CreatedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    LastModifiedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    IsActive BOOLEAN NOT NULL DEFAULT true
);

-- Tabela de Associação entre Usuários e Reivindicações
CREATE TABLE UserClaims
(
    Id SERIAL PRIMARY KEY,
    UserId INT REFERENCES Users(UserId) NOT NULL,
    ClaimId INT REFERENCES Claims(ClaimId) NOT NULL,
    CreatedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    LastModifiedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    IsActive BOOLEAN NOT NULL DEFAULT true
);

-- Tabela de Tokens de Usuário
CREATE TABLE UserTokens
(
    Id SERIAL PRIMARY KEY,
    UserId INT REFERENCES Users(UserId) NOT NULL,
    TokenId INT REFERENCES Tokens(TokenId) NOT NULL,
    CreatedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    LastModifiedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    IsActive BOOLEAN NOT NULL DEFAULT true
);

-- Tabela de Associação entre Usuários e Logins
CREATE TABLE UserLogins
(
    Id SERIAL PRIMARY KEY,
    UserId INT REFERENCES Users(UserId) NOT NULL,
    LoginId INT REFERENCES Logins(LoginId) NOT NULL,
    CreatedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    LastModifiedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    IsActive BOOLEAN NOT NULL DEFAULT true
);
