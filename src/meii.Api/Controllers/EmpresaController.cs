using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using meii.Api.ViewModel;
using meii.Business.Entities;
using meii.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace meii.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;
        public EmpresaController(IEmpresaService empresaService, 
            IEmpresaRepository empresaRepository, IMapper mapper)
        {
            _empresaService = empresaService;
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }
        // GET: api/<EmpresaController>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<EmpresaViewModel>> ListarTodasEmpresas()
        {
            return _mapper.Map<IEnumerable<EmpresaViewModel>>(await _empresaRepository.GetAll());
        }

        // GET api/<EmpresaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmpresaController>
        [AllowAnonymous]
        [HttpPost("pessoa-juridica")]
        public async Task<ActionResult<EmpresaViewModel>> Post(EmpresaPessoaJuridicaViewModel empresaPessoaJuridicaViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var empresa = _mapper.Map<Empresa>(empresaPessoaJuridicaViewModel);

            await _empresaService.Salvar(empresa);

            return Ok(_mapper.Map<EmpresaViewModel>(empresa));
        }

        // PUT api/<EmpresaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmpresaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
