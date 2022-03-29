using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JovemProgramadorMvc.Data.Context;
using JovemProgramadorMvc.Data.Repositorio.Interfaces;
using JovemProgramadorMvc.Models;

namespace JovemProgramadorMvc.Data.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly BancoContexto _bancoContexto;
        public AlunoRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }

        public async Task<AlunoModel> Inserir(AlunoModel aluno)
        {
            await _bancoContexto.Aluno.AddAsync(aluno);
            await _bancoContexto.SaveChangesAsync();
            return aluno;
        }
    }
}
