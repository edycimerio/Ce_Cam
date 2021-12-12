using Cliente.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Repository.Interfaces
{
    public interface IClienteRepository
    {
        Task<ClientesEntity> Details(int? id);
        Task Create(ClientesEntity clientes);
        Task<ClientesEntity> Edit(int? id);
        Task Edit(ClientesEntity _clientes);
        Task<ClientesEntity> Delete(int? id);
        Task DeleteConfirmed(int id);        
        Task<IList<ClientesEntity>> ListClientes();
        Task<bool> ClientesExists(int id);
    }
}
