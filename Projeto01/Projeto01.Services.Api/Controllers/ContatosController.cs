using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto01.Application.Commands;
using Projeto01.Application.Interfaces;

namespace Projeto01.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        //atributo
        private readonly IContatoAppService _contatoAppService;

        //construtor para injeção de dependência
        public ContatosController(IContatoAppService contatoAppService)
        {
            _contatoAppService = contatoAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ContatoCreateCommand command)
        {
            try
            {
                var contato = await _contatoAppService.Create(command);
                return StatusCode(201, contato);
            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Errors);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(ContatoUpdateCommand command)
        {
            try
            {
                var contato = await _contatoAppService.Update(command);
                return StatusCode(200, contato); 
            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Errors); 
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { ex.Message }); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var command = new ContatoDeleteCommand { Id = id };

                var contato = await _contatoAppService.Delete(command);
                return StatusCode(200, contato); 
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpGet("{page}/{limit}")]
        public IActionResult GetAll(int page, int limit)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok();
        }
    }
}
