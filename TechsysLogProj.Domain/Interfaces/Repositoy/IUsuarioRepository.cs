using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechsysLogProj.Domain.Entity;

namespace TechsysLogProj.Domain.Interfaces.Repositoy
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario> Autenticar(string user);
    }
}
