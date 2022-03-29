using System.Threading.Tasks;
using JovemProgramadorMvc.Models;

namespace JovemProgramadorMvc.Data.Repositorio.Interfaces
{
    public interface IAlunoRepositorio
    {
        Task<AlunoModel> Inserir(AlunoModel aluno);
    }
}
