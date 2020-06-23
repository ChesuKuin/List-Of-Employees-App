Использую базу данных (localdb)\MSSQLLocal
                      List Of Employees  


SET IDENTITY_INSERT [dbo].[Employees] ON
INSERT INTO [dbo].[Employees] ([Id], [LastName], [FirstName], [Departament]) VALUES (1, N'Кузнецова', N'Мария', N'Образования')
INSERT INTO [dbo].[Employees] ([Id], [LastName], [FirstName], [Departament]) VALUES (2, N'Васнин', N'Семен', N'Спорта')
INSERT INTO [dbo].[Employees] ([Id], [LastName], [FirstName], [Departament]) VALUES (3, N'Васильков', N'Тимур', N'Digital')
SET IDENTITY_INSERT [dbo].[Employees] OFF
