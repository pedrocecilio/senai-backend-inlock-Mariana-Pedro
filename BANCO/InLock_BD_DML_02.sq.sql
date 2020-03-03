

USE InLock_Games_Manha;

INSERT INTO TipoUsuario (TituloTipoUsuario)
VALUES					('Administrador')
						,('Comum');
GO

INSERT INTO Usuario (Id_TipoUsuario, Email, Senha)
VALUES	(1, 'admin@admin.com', 'admin'),
		(2, 'cliente@clinete.com', 'cliente')
GO

INSERT INTO Estudio (NomeEstudio)
VALUES	('Blizzard'),
		('Rockstar Studios'),
		('Square Enix');
GO

INSERT INTO Jogos (NomeJogo, Descricao, DataLancamento, Preco, Id_Estudio)
VALUES	('Diablo 3', 'É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.', '2012-05-15', 'R$99,00', 1),
		('Red Dead Redemption II', 'Jogo eletrônico de ação-aventura western',  '2018-10-26', 'R$ 120', 2)
GO



