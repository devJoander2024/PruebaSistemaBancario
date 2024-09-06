INSERT INTO [dbo].[User] (Username, Email, Password, Estado, Role)
VALUES ('walther.olivo', 'walther.olivo@example.com', 'Password1', 'Activo', 'Role_Admin'),
       ('john.doe', 'john.doe@example.com', 'Password2', 'Activo', 'Role_Cliente'),
       ('jane.smith', 'jane.smith@example.com', 'Password3', 'Inactivo', 'Role_Cliente'),
       ('carlos.lopez', 'carlos.lopez@example.com', 'Password4', 'Activo', 'Role_Admin'),
       ('lucia.martinez', 'lucia.martinez@example.com', 'Password5', 'Activo', 'Role_Cliente');

INSERT INTO [dbo].[TipoPrestamo] (Descripcion, Estado)
VALUES ('Préstamo personal', 'Activo'),
       ('Préstamo hipotecario', 'Activo'),
       ('Préstamo automotriz', 'Activo'),
       ('Préstamo estudiantil', 'Inactivo'),
       ('Línea de crédito', 'Activo');
       
INSERT INTO [dbo].[Prestamo] (Descripcion, Cantidad, Estado, TipoPrestamoId)
VALUES ('Préstamo para compra de automóvil', 10000, 'Activo', 3),
       ('Préstamo para estudios universitarios', 5000, 'Activo', 4),
       ('Línea de crédito aprobada', 15000, 'Activo', 5),
       ('Préstamo hipotecario para casa', 120000, 'Activo', 2),
       ('Préstamo personal para vacaciones', 2000, 'Inactivo', 1);
