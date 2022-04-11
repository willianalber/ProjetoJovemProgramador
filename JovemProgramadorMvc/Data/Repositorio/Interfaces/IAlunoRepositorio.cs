using System.Collections.Generic;
using System.Threading.Tasks;
using JovemProgramadorMvc.Models;

namespace JovemProgramadorMvc.Data.Repositorio.Interfaces
{
    public interface IAlunoRepositorio
    {
        bool Inserir(AlunoModel aluno);
        IList<AlunoModel> BuscarAlunos();
    }
}
