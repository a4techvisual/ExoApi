-- Banco de dados do ExoApi
-- Se o db.sql do livro didático tiver colunas diferentes, use o dele e
-- ajuste as propriedades em ExoApi/Models/Projeto.cs para bater com as colunas.

CREATE DATABASE ExoApi;
GO

USE ExoApi;
GO

CREATE TABLE Projetos (
    Id            INT PRIMARY KEY IDENTITY,
    Titulo        VARCHAR(250) NOT NULL,
    StatusProjeto VARCHAR(100),
    DataInicio    DATE,
    Tecnologias   VARCHAR(250),
    Requisitos    VARCHAR(250),
    Area          VARCHAR(150)
);
GO

INSERT INTO Projetos (Titulo, StatusProjeto, DataInicio, Tecnologias, Requisitos, Area) VALUES
('Plataforma de E-commerce', 'Em andamento', '2026-03-01', 'React, .NET, SQL Server', 'Login, carrinho, pagamento', 'Desenvolvimento'),
('Aplicativo de Agendamentos', 'Concluído',   '2025-08-15', 'React Native, Node.js',  'Agenda, notificações',       'Mobile'),
('Painel de Indicadores',      'Planejado',   '2026-11-10', 'Power BI, SQL Server',   'Relatórios mensais',          'Dados');
GO
