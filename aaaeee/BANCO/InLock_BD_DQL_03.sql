use Inlock_games_manha

   SELECT * FROM TipoUsuario;
   SELECT * FROM Usuario;
   SELECT * FROM Jogos;
   SELECT * FROM Estudio;

select Jogos.NomeJogo ,Jogos.Descricao ,Jogos.DataLancamento ,Jogos.Preco ,Estudio.NomeEstudio 
from Jogos
inner join Estudio on Estudio.Id_Estudio =Jogos.Id_Estudio
