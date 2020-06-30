using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using meii.Api.ViewModel;
using meii.Business.Entities;
using meii.Business.Entities.Notificacoes;
using meii.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace meii.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;
        public CategoriaController(
            ICategoriaService categoriaService,
            ICategoriaRepository categoriaRepository,
            IMapper mapper)
        {
            _categoriaService = categoriaService;
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        // GET: api/Categoria
        [HttpGet]
        public async Task<IEnumerable<CategoriaVM>> ListarTodos()
        {
            return _mapper.Map<IEnumerable<CategoriaVM>>(await _categoriaRepository.GetAll());
        }

        // GET: api/Categoria/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoriaVM>> BuscarPorId(int id)
        {
            var categoria = await _categoriaRepository.GetId(id);
            
            if(categoria == null)
                return NotFound("Categoria informado não foi encontrado.");

            return _mapper.Map<CategoriaVM>(categoria);
        }

        // POST: api/Categoria
        [HttpPost]
        public async Task<ActionResult<CategoriaVM>> Criar(CategoriaVM categoriaVM)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _categoriaService.Salvar(_mapper.Map<Categoria>(categoriaVM));

            return Ok(categoriaVM);
        }

        // PUT: api/Categoria/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Atualizar(int id, CategoriaVM categoriaVM)
        {
            if (id != categoriaVM.Id)
                return BadRequest("Id informado na query difere da categoria");

            var categoria = _categoriaRepository.Find(c => c.Id == id).Result.First();
            
            if (categoria == null)
                return NotFound("Categoria informado não foi encontrado.");

            categoria = _mapper.Map<Categoria>(categoriaVM);
            await _categoriaService.Atualizar(categoria);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var categoria = await _categoriaRepository.GetId(id);

            if (categoria == null)
                return NotFound("Categoria informado não foi encontrado.");

            await _categoriaService.Excluir(categoria);
            return NoContent();
        }
    }
}
