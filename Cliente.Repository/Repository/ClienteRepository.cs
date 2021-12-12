using Cliente.Repository.Entities;
using Cliente.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cliente.Repository.Repository
{
    public class ClienteRepository: IClienteRepository
    {
        private readonly ClienteContext _context;

        public ClienteRepository(ClienteContext context)
        {
            _context = context;
        }

        public async Task<ClientesEntity> Details(int? id)
        {
            var _clientes = await _context.Clientes
                .FirstOrDefaultAsync(m => m.ClienteId == id);

            return _clientes;
        }
        public async Task Create(ClientesEntity clientes)
        {
            _context.Add(clientes);
            await _context.SaveChangesAsync();
        }

        public async Task <ClientesEntity> Edit(int? id)
        {
            var _clientes = await _context.Clientes.FindAsync(id);

            return _clientes;
        }

        public async Task Edit(ClientesEntity _clientes)
        {
            _context.Update(_clientes);
            await _context.SaveChangesAsync();
        }

        public async Task<ClientesEntity> Delete(int? id)
        {
            var _clientes = await _context.Clientes
                .FirstOrDefaultAsync(m => m.ClienteId == id);

            return _clientes;
        }

        public async Task DeleteConfirmed(int id)
        {
            var _clientes = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(_clientes);
            await _context.SaveChangesAsync();           
        }

        public async Task<bool> ClientesExists(int id)
        {
            var existe = await Details(id);

            if(existe == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<IList<ClientesEntity>> ListClientes()
        {
            var lista = await _context.Clientes.ToListAsync();

            return lista;
        }
    }
}
