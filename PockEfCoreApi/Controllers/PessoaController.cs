﻿using Microsoft.AspNetCore.Mvc;
using PockEfCoreApi.Infra.Data;
using PockEfCoreApi.Infra.Data.Tables;
using PockEfCoreApi.Models;

namespace PockEfCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {

        private readonly PockDbContext _ctx;

        public PessoaController(PockDbContext context)
        {
            _ctx = context;
        }

        [HttpPost]
        public Task<IActionResult> AdicionarPessoa([FromBody] PessoaRequest request)
        {

            Pessoa pessoa = new()
            {
                Nome = request.Nome,
                Nascimento = request.Nascimento
            };

            Tipo tipo = _ctx.Tipos.FirstOrDefault(tipo => tipo.Nome == request.Tipo);
            if (tipo == null)
                tipo = new Tipo() { Nome = request.Tipo };
            pessoa.Tipos.Add(tipo);

            _ctx.Pessoas.Add(pessoa);
            _ctx.SaveChanges();

            IActionResult result = Created(string.Empty, new { Id = pessoa.Id });

            return Task.FromResult(result);
        }

    }
}
