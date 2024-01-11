-- Drop das tabelas relacionadas com CASCADE
DROP TABLE IF EXISTS CouponCategory;
DROP TABLE IF EXISTS CouponUsageHistory;
DROP TABLE IF EXISTS Coupon;

-- Criação da tabela Coupon
CREATE TABLE IF NOT EXISTS Coupon (
    CouponID SERIAL PRIMARY KEY,
    Code VARCHAR(50) NOT NULL UNIQUE,
    DiscountPercent DECIMAL(5, 2) NOT NULL,
    CreatedDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    ExpiresDate DATE NOT NULL,
    LastModifiedDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    IsActive BOOLEAN NOT NULL DEFAULT true
);

-- Criação da tabela CategoryCoupon
CREATE TABLE IF NOT EXISTS CouponCategory (
    CouponCategoryID SERIAL PRIMARY KEY,
    CouponID INT NOT NULL,
    CategoryId INT NOT NULL,
    CategoryName VARCHAR(50) NOT NULL,
    CreatedDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    LastModifiedDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    IsActive BOOLEAN NOT NULL DEFAULT true
);

-- Criação da tabela CouponUsageHistory
CREATE TABLE IF NOT EXISTS CouponUsageHistory (
    CouponUsageHistoryID SERIAL PRIMARY KEY,
    CouponID INT NOT NULL,
    CartID INT NOT NULL,
    OrderId INT NOT NULL,
    ValueOfProducts DECIMAL(10, 2) DEFAULT 0,
    DiscountAmount DECIMAL(10, 2) DEFAULT 0,
	UserID INT NOT NULL,
    Username VARCHAR(50) NOT NULL,
    CreatedDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    LastModifiedDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    IsActive BOOLEAN NOT NULL DEFAULT true
);


