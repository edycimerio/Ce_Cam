using Cliente.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Domain.Interfaces
{
    public interface IClientesService
    {
        Task<Clientes> Details(int? id);
        Task<bool> Create(Clientes clientes);
        Task<Clientes> Edit(int? id);
        Task<bool> Edit(Clientes _clientes);
        Task<Clientes> Delete(int? id);
        Task DeleteConfirmed(int id);
        Task<IList<Clientes>> ListClientes();

        Task<bool> ClientesExists(int id);
    }
}
