using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechsysLogProj.Domain.Interfaces;
using TechsysLogProj.Domain.Interfaces.Repositoy;
using TechsysLogProj.Infra.Context;

namespace TechsysLogProj.Infra.Data.UnitOfWork
{
    public  class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoContext _context;

        public UnitOfWork(IMongoContext context)
        {
            _context = context;
        }

        public IPedidoRepository Pedido { get; private set; }

        public async Task<bool> SaveChanges()
        {
            var changes = await _context.SaveChanges();

            return changes > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
