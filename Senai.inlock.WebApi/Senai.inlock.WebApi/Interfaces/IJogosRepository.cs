using Senai.inlock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.inlock.WebApi.Interfaces
{
   interface IJogosRepository
    {
        List<EstudioDomains> listar();

        EstudioDomains BuscarPorId(int id);

        void Cadastrar(EstudioDomains NovoEstudio);

        void Atualizar(int id, EstudioDomains EstudioAtualizado);

        void Deletar(int id);

      
    }
}
