using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using meii.Api.Extensions;
using meii.Api.ViewModel;
using meii.Business.Entities;
using meii.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace meii.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoService produtoService,
            IProdutoRepository produtoRepository,
            IMapper mapper)
        {
            _produtoService = produtoService;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        // GET: api/Produto
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<ProdutoVM>> ListarTodoProduto()
        {
            return _mapper.Map<IEnumerable<ProdutoVM>>(await _produtoRepository.GetAll());
        }

        // GET: api/Produto/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProdutoVM>> BuscarProdutoPorId(int id)
        {
            var produto = await _produtoRepository.BuscarProdutoCategoriaPorId(id);

            if (produto == null)
                return NotFound("Produto informado não foi encontrado.");

            return Ok(_mapper.Map<ProdutoVM>(produto));
        }

        // POST: api/Produto
        [ClaimsAuthorize("Produto", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<ProdutoVM>> SalvarProduto(ProdutoVM produtoVM)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var produto = await _produtoService.Salvar(_mapper.Map<Produto>(produtoVM));

            return Ok(_mapper.Map<ProdutoVM>(produto));
        }

        // PUT: api/Produto/5
        [ClaimsAuthorize("Produto", "Atualizar")]
        [HttpPut("{id:int}")]
        public async Task<ActionResult> AtualizarProduto (int id, ProdutoVM produto)
        {
            if (id != produto.Id)
                return BadRequest("Id da query difere do id do produto");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _produtoService.Atualizar(_mapper.Map<Produto>(produto));

            return NoContent();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduto(int id)
        {
            var produto = await _produtoRepository.GetId(id);

            if (produto == null)
                return NotFound("Produto informado não foi encontrado");

            await _produtoService.Excluir(produto);
            return NoContent();
        }
    }
}
