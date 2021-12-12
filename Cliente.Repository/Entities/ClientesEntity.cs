using System;
using System.Collections.Generic;
using System.Text;

namespace Cliente.Repository.Entities
{
    public partial class ClientesEntity
    {
        public int ClienteId { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }


    }
}
