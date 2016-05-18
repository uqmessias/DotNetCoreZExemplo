using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.Api.Helpers;
using Microsoft.AspNetCore.Mvc;
using DotNetCore.Dominio.Servicos;
using DotNetCore.Dominio;
using System.Linq;

namespace DotNetCore.Api.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        private readonly ClienteServico _clienteServico;
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClientesController(IClienteRepositorio clienteRepositorio, ClienteServico clienteServico)
        {
            _clienteRepositorio = clienteRepositorio;
            _clienteServico = clienteServico;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _clienteRepositorio.ObterTodos().Select(it => it.Nome);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<string> Get(Guid id)
        {
            var cliente = await _clienteRepositorio.ProcurarItenPor(id);
            return cliente.Nome;
        }

        // POST api/values
        [HttpPost, Transaction]
        public async Task Post([FromBody]string value)
        {
            var cliente = _clienteServico.Criar(value, "123123123");
            await _clienteRepositorio.Inserir(cliente);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
