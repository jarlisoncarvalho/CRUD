using Crud.Data;
using Crud.Models;
using Crud.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Crud.Repository
{
    public class Usuariorepository : IUsuariorespository
    {
        private readonly SistemasTarefasDbContext _dbContext;
        public Usuariorepository(SistemasTarefasDbContext sistemasTarefasDbContext)
        {
            _dbContext = sistemasTarefasDbContext;
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuario.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuario.ToListAsync();

        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
          await _dbContext.Usuario.AddAsync(usuario);
           await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel Usuarioporid = await BuscarPorId(id);
            if(Usuarioporid == null)
            {
                throw new Exception($"Usuario para o id: {id} não foi encontrado no banco de dados.");
            } 
            Usuarioporid.Nome = usuario.Nome;
            Usuarioporid.Email = usuario.Email;

            _dbContext.Usuario.Update(Usuarioporid);
            await _dbContext.SaveChangesAsync();

            return Usuarioporid;
        }
        public async Task<bool> Apagar(int id)
        {
            UsuarioModel Usuarioporid = await BuscarPorId(id);
            if (Usuarioporid == null)
            {
                throw new Exception($"Usuario para o id: {id} não foi encontrado no banco de dados.");
            }
            _dbContext.Usuario.Remove(Usuarioporid);
            await _dbContext.SaveChangesAsync();
            return true;
        }

      
    }
}
