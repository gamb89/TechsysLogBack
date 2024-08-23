using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechsysLogProj.Domain.Interfaces.Repositoy;

namespace TechsysLogProj.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPedidoRepository Pedido { get; } 
        Task<bool> SaveChanges();
    }
}
