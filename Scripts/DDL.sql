CREATE TABLE [dbo].[User] (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL,
    Estado NVARCHAR(50) NOT NULL,
    Role NVARCHAR(50) NOT NULL
);

CREATE TABLE [dbo].[TipoPrestamo] (
    TipoPrestamoId INT PRIMARY KEY IDENTITY(1,1),
    Descripcion NVARCHAR(200) NOT NULL,
    Estado NVARCHAR(50) NOT NULL
);

CREATE TABLE [dbo].[Prestamo] (
    PrestamoId INT PRIMARY KEY IDENTITY(1,1),
    Descripcion NVARCHAR(200) NOT NULL,
    Cantidad INT NOT NULL,
    Estado NVARCHAR(50) NOT NULL,
    TipoPrestamoId INT NOT NULL,
    FOREIGN KEY (TipoPrestamoId) REFERENCES [dbo].[TipoPrestamo](TipoPrestamoId)
);
