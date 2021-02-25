using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using meii.Api.ViewModel;
using meii.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace meii.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CartaoFidelidadeController : ControllerBase
    {
        private ICartaoFidelidadeRepository _cartaoFidelidadeRepository;
        private readonly IMapper _mapper;
        public CartaoFidelidadeController(ICartaoFidelidadeRepository cartaoFidelidadeRepository ,
            IMapper mapper)
        {
            _cartaoFidelidadeRepository = cartaoFidelidadeRepository;
            _mapper = mapper;
        }
        // GET: api/<CartaoFidelidadeController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<CartaoFidelidadeVM>> Get()
        {
            var cartaoFidelidade = await _cartaoFidelidadeRepository.GetAll();
            return _mapper.Map<IEnumerable<CartaoFidelidadeVM>>(cartaoFidelidade);
        }

        // GET api/<CartaoFidelidadeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CartaoFidelidadeController>
        [HttpPost]
        public async Task<CartaoFidelidadeVM> Post(CartaoFidelidadeVM cartaoFidelidadeVM)
        {
            return null;
        }

        // PUT api/<CartaoFidelidadeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CartaoFidelidadeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
