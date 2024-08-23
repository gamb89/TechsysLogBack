using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechsysLogProj.Domain.Entity;
using TechsysLogProj.Domain.Interfaces.Repositoy;
using TechsysLogProj.Infra.Context;

namespace TechsysLogProj.Infra.Data.Repository
{
    public  class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(IMongoDatabase database) : base(database,"Pedido")
        {
        }
    }
}
