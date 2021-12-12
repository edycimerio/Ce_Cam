using Cliente.Domain.Dtos;
using Cliente.Domain.Interfaces;
using Cliente.Repository.Entities;
using Cliente.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Domain.Services
{
    public class ClientesService : IClientesService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Clientes> Details(int? id)
        {
            var _clientes = await _clienteRepository.Details(id);
            Clientes newClientes = new Clientes();

            if (_clientes != null)
            {
                newClientes.ClienteId = _clientes.ClienteId;
                newClientes.RazaoSocial = _clientes.RazaoSocial;
                newClientes.Cnpj = _clientes.Cnpj;
                newClientes.DataCadastro = _clientes.DataCadastro;
                newClientes.Ativo = _clientes.Ativo;
            }

            return newClientes;
        }
        public async Task<bool> Create(Clientes clientes)
        {
            ClientesEntity objClientesEntity = new ClientesEntity();

            if (clientes != null)
            {
                objClientesEntity.ClienteId = clientes.ClienteId;
                objClientesEntity.RazaoSocial = clientes.RazaoSocial;
                objClientesEntity.Cnpj = clientes.Cnpj;
                objClientesEntity.DataCadastro = clientes.DataCadastro;
                objClientesEntity.Ativo = clientes.Ativo;
                try
                {
                    await _clienteRepository.Create(objClientesEntity);

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<Clientes> Edit(int? id)
        {
            var _clientes = await _clienteRepository.Edit(id);

            Clientes newClientes = new Clientes();

            if (_clientes != null)
            {
                newClientes.ClienteId = _clientes.ClienteId;
                newClientes.RazaoSocial = _clientes.RazaoSocial;
                newClientes.Cnpj = _clientes.Cnpj;
                newClientes.DataCadastro = _clientes.DataCadastro;
                newClientes.Ativo = _clientes.Ativo;
            }

            return newClientes;
        }

        public async Task<bool> Edit(Clientes clientes)
        {
            if (clientes != null)
            {
                if (clientes.ClienteId > 0)
                {
                    ClientesEntity objClientesEntity = new ClientesEntity();

                    objClientesEntity.ClienteId = clientes.ClienteId;
                    objClientesEntity.RazaoSocial = clientes.RazaoSocial;
                    objClientesEntity.Cnpj = clientes.Cnpj;
                    objClientesEntity.DataCadastro = clientes.DataCadastro;
                    objClientesEntity.Ativo = clientes.Ativo;

                    try
                    {
                        await _clienteRepository.Edit(objClientesEntity);

                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                return false;
            }

            return false;
        }

        public async Task<Clientes> Delete(int? id)
        {
            var _clientes = await _clienteRepository.Delete(id);

            Clientes newClientes = new Clientes();

            if (_clientes != null)
            {
                newClientes.ClienteId = _clientes.ClienteId;
                newClientes.RazaoSocial = _clientes.RazaoSocial;
                newClientes.Cnpj = _clientes.Cnpj;
                newClientes.DataCadastro = _clientes.DataCadastro;
                newClientes.Ativo = _clientes.Ativo;
            }

            return newClientes;
        }

        public async Task DeleteConfirmed(int id)
        {
            await _clienteRepository.DeleteConfirmed(id);
        }

        public async Task<IList<Clientes>> ListClientes()
        {
            var lista = await _clienteRepository.ListClientes();

            IList<Clientes> listaRetorno = new List<Clientes>();

            foreach (ClientesEntity obj in lista)
            {
                Clientes newClientes = new Clientes();
                newClientes.ClienteId = obj.ClienteId;
                newClientes.RazaoSocial = obj.RazaoSocial;
                newClientes.Cnpj = obj.Cnpj;
                newClientes.DataCadastro = obj.DataCadastro;
                newClientes.Ativo = obj.Ativo;

                listaRetorno.Add(newClientes);

            }

            return listaRetorno;
        }

        public async Task<bool> ClientesExists(int id)
        {
            var _existe = await _clienteRepository.ClientesExists(id);

            return _existe;
        }        
    }
}
