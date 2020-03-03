using Senai.inlock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.inlock.WebApi.Interfaces
{
   interface IJogosRepository
    {
        List<JogosDomains> listar();

        JogosDomains BuscarPorId(int id);

        void Cadastrar(JogosDomains NovoJogo);

        void Deletar(int id);

      
    }
}
