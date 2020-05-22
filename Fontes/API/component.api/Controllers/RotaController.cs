using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.rotas.CustomRequestObjects;
using api.rotas.domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.rotas.Controllers
{
    /// <summary>
    /// Creates a TodoItem.
    /// </summary>    
    /// <response code="400">Requisição inválida</response>   
    /// <response code="404">A página requerida é inexistente</response>   
    /// <response code="500">Erro interno de servidor</response>            
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class RotaController : ControllerBase
    {

        private readonly ILogger<RotaController> _logger;
        private business.Rota _rotaBusiness { get; set; }

        public RotaController(ILogger<RotaController> logger)
        {
            _logger = logger;
            _rotaBusiness = new business.Rota();
        }

        #region Get

        /// <summary>
        /// Listar itens.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Rota>))]
        public IActionResult Get(string caminhoArquivo)
        {
            if (ModelState.IsValid)
            {
                var retorno = _rotaBusiness.Buscar(caminhoArquivo);
                return Ok(retorno);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Buscar melhor rota.
        /// </summary>
        [HttpGet]
        [Route("Best")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Rota>))]
        public IActionResult GetBest(string origem, string destino, string caminhoArquivo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var retorno = _rotaBusiness.BuscarMelhorRota(origem, destino, caminhoArquivo);
                    return Ok(retorno);
                }
                catch (System.Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }

            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        #endregion
        #region Post

        /// <summary>
        /// Inserir rota.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Produces("application/json")]
        public IActionResult Post([FromBody] RequestRotaPost model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    domain.Rota objRota = new Rota() { Origem = model.Origem, Destino = model.Destino, Valor = model.Valor };
                    _rotaBusiness.Criar(objRota, model.caminhoArquivo);
                    return Created("Rota/Get", objRota);
                }
                catch (System.Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        #endregion        
    }
}
