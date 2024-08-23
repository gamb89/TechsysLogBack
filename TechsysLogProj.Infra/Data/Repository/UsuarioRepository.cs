using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechsysLogProj.Domain.Entity;
using TechsysLogProj.Domain.Interfaces.Repositoy;

namespace TechsysLogProj.Infra.Data.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private IMongoDatabase _database;
        public UsuarioRepository(IMongoDatabase database) : base(database, "Usuario")
        {
            _database = database;
                }

        public async Task<Usuario> Autenticar(string user)
        {
            var collection = await _database.GetCollection<Usuario>("Usuario").FindAsync(x => x.Email.Equals(user));
            var usuario = collection.FirstOrDefault();

            return usuario;
            

        }
    }
}
