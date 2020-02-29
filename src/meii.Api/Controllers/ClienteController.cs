using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using meii.Api.ViewModel;
using meii.Business.Entities;
using meii.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace meii.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServices _clienteService;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteController(IClienteServices clienteService , 
            IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteService = clienteService;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }
        // GET: api/Cliente
        [HttpGet]
        public async Task<IEnumerable<ClienteViewModel>> Get()
        {
            var cliente = await _clienteRepository.GetAll();
            return _mapper.Map<IEnumerable<ClienteViewModel>>(cliente);
        }

        // GET: api/Cliente/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ClienteViewModel>> Get(int id)
        {
            var cliente = await _clienteRepository.GetId(id);

            if (cliente == null)
                return StatusCode(StatusCodes.Status302Found);

            return Ok(_mapper.Map<ClienteViewModel>(cliente));
        }

        // POST: api/Cliente
        [HttpPost]
        public async Task<ActionResult<ClienteViewModel>> Post(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var cliente = _mapper.Map<Cliente>(clienteViewModel);

            await _clienteService.Add(cliente);

            return Ok(_mapper.Map<ClienteViewModel>(cliente));
        }

        // PUT: api/Cliente/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
