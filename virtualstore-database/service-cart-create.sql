-- Create Cart table
CREATE TABLE Cart (
    CartId INT PRIMARY KEY,
    UserId INT NOT NULL,
    CouponCode VARCHAR(256),
    CreatedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    LastModifiedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    IsActive BOOLEAN NOT NULL DEFAULT true
);

-- Create CartHeaders table
CREATE TABLE CartHeaders (
    CartHeaderId INT PRIMARY KEY,
    CartId INT NOT NULL,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    CreatedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    LastModifiedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    IsActive BOOLEAN NOT NULL DEFAULT true
);

-- Create CartItems table
CREATE TABLE CartItems (
    CartItemId INT PRIMARY KEY,
    CartHeaderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    CreatedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    LastModifiedDate TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    IsActive BOOLEAN NOT NULL DEFAULT true
);
