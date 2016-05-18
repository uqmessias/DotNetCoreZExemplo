using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore.Dominio.Servicos
{
    public class ClienteServico
    {
        public Cliente Criar(string nome, string cpf)
        {
            return new Cliente(nome, cpf);
        }
    }
}
