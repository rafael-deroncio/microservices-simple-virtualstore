DROP TABLE IF EXISTS Users;
DROP TABLE IF EXISTS Claims;
DROP TABLE IF EXISTS Logins;
DROP TABLE IF EXISTS Roles;
DROP TABLE IF EXISTS UserRoles;
DROP TABLE IF EXISTS UserTokens;

-- Tabela de Usuários
CREATE TABLE Users
(
    UserId SERIAL PRIMARY KEY,
    UserName VARCHAR(256) NOT NULL,
    Email VARCHAR(256) NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    SecurityStamp VARCHAR(255),
    PhoneNumber VARCHAR(20),
    TwoFactorEnabled BOOLEAN NOT NULL,
    LockoutEndDateUtc TIMESTAMPTZ,
    LockoutEnabled BOOLEAN NOT NULL,
    AccessFailedCount INT NOT NULL,
    CreatedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    LastModifiedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    IsActive BOOLEAN NOT NULL DEFAULT true
);

-- Tabela de Reivindicações do Usuário
CREATE TABLE Claims
(
    ClaimId SERIAL PRIMARY KEY,
    UserId INT REFERENCES Users (UserId) NOT NULL,
    ClaimType VARCHAR(256),
    ClaimValue VARCHAR(256),
    CreatedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    LastModifiedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP
);

-- Tabela de Logins Externos
CREATE TABLE Logins
(
    LoginProvider VARCHAR(128) NOT NULL,
    ProviderKey VARCHAR(128) NOT NULL,
    UserId INT REFERENCES Users(UserId) NOT NULL,
    PRIMARY KEY (LoginProvider, ProviderKey),
    CreatedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP
);

-- Tabela de Papeis
CREATE TABLE Roles
(
    RoleId SERIAL PRIMARY KEY,
    Name VARCHAR(256) NOT NULL,
    CreatedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    LastModifiedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP
);

-- Tabela de Associação entre Usuários e Papeis
CREATE TABLE UserRoles
(
    UserId INT REFERENCES Users(UserId) NOT NULL,
    RoleId INT REFERENCES Roles(RoleId) NOT NULL,
    PRIMARY KEY (UserId, RoleId),
    CreatedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP
);

-- Tabela de Tokens de Usuário
CREATE TABLE UserTokens
(
    UserTokenId SERIAL PRIMARY KEY,
    UserId INT REFERENCES Users(UserId) NOT NULL,
    LoginProvider VARCHAR(128) NOT NULL,
    Name VARCHAR(128) NOT NULL,
    Value VARCHAR(256) NOT NULL,
    CreatedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP
);


SELECT
    USR.UserId,
    USR.UserName,
    USR.Email,
    USR.PasswordHash,
    USR.SecurityStamp,
    USR.PhoneNumber,
    USR.TwoFactorEnabled,
    USR.LockoutEndDateUtc,
    USR.LockoutEnabled,
    USR.AccessFailedCount,
    USR.CreatedDate AS UserCreatedDate,
    USR.LastModifiedDate AS UserLastModifiedDate,
    USR.IsActive,

    CLM.ClaimId,
    CLM.ClaimType,
    CLM.ClaimValue,
    CLM.CreatedDate AS ClaimCreatedDate,
    CLM.LastModifiedDate AS ClaimLastModifiedDate,
    
    LGN.LoginProvider,
    LGN.ProviderKey,
    LGN.CreatedDate AS LoginCreatedDate,
    ROL.RoleId,
    ROL.Name AS RoleName,
    ROL.CreatedDate AS RoleCreatedDate,
    ROL.LastModifiedDate AS RoleLastModifiedDate,
    USL.CreatedDate AS UserRoleCreatedDate,
    UST.UserTokenId,
    UST.LoginProvider AS TokenLoginProvider,
    UST.Name AS TokenName,
    UST.Value AS TokenValue,
    UST.CreatedDate AS TokenCreatedDate
FROM
    Users U
LEFT JOIN Claims C ON USR.UserId = CLM.UserId
LEFT JOIN Logins L ON USR.UserId = LGN.UserId
LEFT JOIN UserRoles UR ON USR.UserId = USL.UserId
LEFT JOIN Roles R ON USL.RoleId = ROL.RoleId
LEFT JOIN UserTokens UT ON USR.UserId = UST.UserId
WHERE
    USR.UserName = 'username'; -- Substitua 'username' pelo nome de usuário desejado
