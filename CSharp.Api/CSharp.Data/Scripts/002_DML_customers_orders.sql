USE CSharp 

GO 

INSERT INTO [dbo].[Customer] (Name, Email) VALUES ('Foo Bar', 'foo.bar@gmail.com');

INSERT INTO [dbo].[Customer] (Name, Email) VALUES ('John Bala Jones', 'john@gmail.com');

INSERT INTO [dbo].[Order] (CustomerId, Price, CreatedDate) VALUES (1, 11.11, GETDATE());

INSERT INTO [dbo].[Order] (CustomerId, Price, CreatedDate) VALUES (1, 1221, GETDATE());

INSERT INTO [dbo].[Order] (CustomerId, Price, CreatedDate) VALUES (2, 2222, GETDATE());

GO