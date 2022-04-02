using System.Collections.Generic;
using System.Threading.Tasks;
using JovemProgramadorMvc.Models;

namespace JovemProgramadorMvc.Data.Repositorio.Interfaces
{
    public interface IAlunoRepositorio
    {
        AlunoModel Inserir(AlunoModel aluno);
        IList<AlunoModel> BuscarAlunos();
    }
}
