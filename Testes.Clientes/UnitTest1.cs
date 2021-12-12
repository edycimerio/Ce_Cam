using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cliente.Domain.Interfaces;
using Cliente.Domain.Dtos;
//using Microsoft.IdentityModel.Tokens;
using Moq;

using NUnit.Framework;
using Cliente.Domain.Services;
using Cliente.Repository.Interfaces;
using Cliente.Repository.Repository;

namespace Testes.Clientes
{
    public class UnitTest1
    {
        //private ClientesService _clientesService;
        private ClientesService _clientesService;
        private Mock<IClienteRepository> _clienteRepository;

        [SetUp]
        public void SetUp()
        {
            _clienteRepository = new Mock<IClienteRepository>();
            _clientesService = new ClientesService(_clienteRepository.Object);
        }

        [Test]
        public async Task CreateCliente()
        {
            _clienteRepository.Setup(a => a.Create(It.IsAny<Cliente.Repository.Entities.ClientesEntity>()))
                .Returns(Task.FromResult(true))
               .Verifiable();

            Cliente.Domain.Dtos.Clientes obj = new Cliente.Domain.Dtos.Clientes();
            obj.RazaoSocial = "x";
            obj.Cnpj = "1";
            obj.DataCadastro = DateTime.Now;
            obj.Ativo = true;

            Assert.IsTrue(await _clientesService.Create(obj));
        }

        [Test]
        public async Task CreateClienteError()
        {
            _clienteRepository.Setup(a => a.Create(It.IsAny<Cliente.Repository.Entities.ClientesEntity>()))
                .Returns(Task.FromResult(false))
               .Verifiable();

            Assert.IsFalse(await _clientesService.Create(null));
        }


        [Test]
        public async Task EditCliente()
        {
            _clienteRepository.Setup(a => a.Create(It.IsAny<Cliente.Repository.Entities.ClientesEntity>()))
                .Returns(Task.FromResult(true))
               .Verifiable();

            Cliente.Domain.Dtos.Clientes obj = new Cliente.Domain.Dtos.Clientes();
            obj.ClienteId = 3;
            obj.RazaoSocial = "x";
            obj.Cnpj = "1";
            obj.DataCadastro = DateTime.Now;
            obj.Ativo = true;

            Assert.IsTrue(await _clientesService.Edit(obj));
        }

        [Test]
        public async Task EditClienteError()
        {
            _clienteRepository.Setup(a => a.Create(It.IsAny<Cliente.Repository.Entities.ClientesEntity>()))
                .Returns(Task.FromResult(false))
               .Verifiable();

            Cliente.Domain.Dtos.Clientes obj = new Cliente.Domain.Dtos.Clientes();
            obj = null;
            Assert.IsFalse(await _clientesService.Edit(obj));
        }

        [Test]
        public async Task EditClienteErrorId()
        {
            _clienteRepository.Setup(a => a.Create(It.IsAny<Cliente.Repository.Entities.ClientesEntity>()))
                .Returns(Task.FromResult(false))
               .Verifiable();

            Cliente.Domain.Dtos.Clientes obj = new Cliente.Domain.Dtos.Clientes();
            obj.ClienteId = 0;
            obj.RazaoSocial = "x";
            obj.Cnpj = "1";
            obj.DataCadastro = DateTime.Now;
            obj.Ativo = true;

            Assert.IsFalse(await _clientesService.Edit(obj));
        }
    }
}
