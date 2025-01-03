using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TsaakAPI.Entities;
using TsaakAPI.Model.DAO;

namespace TsaakAPI.Api.V1.Controller
{
    [ApiController]
    [Route("tsaak/api/v1/[controller]")]
    public class EnfermedadCardiovascularController : ControllerBase
    {
        private readonly EnfermedadCardiovascularDao _enfermedadCardiovascularDao;
        private readonly IConfiguration _configuration;

        public EnfermedadCardiovascularController(EnfermedadCardiovascularDao enfermedadCardiovascularDao, IConfiguration configuration)
        {
            _enfermedadCardiovascularDao = enfermedadCardiovascularDao;
            _configuration = configuration;

        }


        /*[HttpGet]
        public async Task<IActionResult> GetEnfermedadCardiovascular()
        {
            var result = await _enfermedadCardiovascularDao.ObtenerEnfermedadCardiovascular();

            if (!result.Success || result.Result == null || !result.Result.Any())
            {
                return NotFound(result); // Return 404 if no records are found
            }

            return Ok(result); // Return 200 with the list of results
        }*/


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Llamada al DAO para obtener el registro
            var result = await _enfermedadCardiovascularDao.GetByIdAsync(id);

            // Verifica si la operación fue exitosa
            if (result.Success)
            {
                // Si es exitosa, devuelve el resultado con un estado 200 OK
                return Ok(result.Result);
            }
            else
            {
                // Si no fue exitosa, devuelve un error con el detalle
                return BadRequest(new { message = result.Messages });
            }
        }

        [HttpGet("PageFetch")]
        public async Task<IActionResult> Get([FromQuery] int page = 1, [FromQuery] int fetch = 10)
        {
            // Llamada al DAO para obtener los registros con paginación
            var result = await _enfermedadCardiovascularDao.GetPageFetch(page, fetch);

            HttpContext.Response.Headers.Add("Custom-Header", $"Registros: {fetch}");

            // Verifica si la operación fue exitosa
            if (result.Success)
            {
                // Si es exitosa, devuelve el resultado con un estado 200 OK
                return Ok(result);
            }
            else
            {
                // Si no fue exitosa, devuelve un error con el detalle

                return NoContent();
                // return BadRequest(new { message = result.Messages });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Llamada al DAO para obtener el registro
            var result = await _enfermedadCardiovascularDao.GetAll();

            // Verifica si la operación fue exitosa
            if (result.Success)
            {
                // Si es exitosa, devuelve el resultado con un estado 200 OK
                return Ok(result.Result);
            }
            else
            {
                // Si no fue exitosa, devuelve un error con el detalle
                return BadRequest(new { message = result.Messages });
            }
        }

        [HttpGet("completo")]
        public async Task<IActionResult> GetCompleto()
        {
            // Llamada al DAO para obtener el registro
            var result = await _enfermedadCardiovascularDao.GetCompleto();

            // Verifica si la operación fue exitosa
            if (result.Success)
            {
                // Si es exitosa, devuelve el resultado con un estado 200 OK
                return Ok(result.Result);
            }
            else
            {
                // Si no fue exitosa, devuelve un error con el detalle
                return BadRequest(new { message = result.Messages });
            }
        }

        [HttpGet("diccionario")]
        public async Task<IActionResult> GetDiccionario()
        {
            // Llamada al DAO para obtener el registro
            var result = await _enfermedadCardiovascularDao.GetAll();

            // Verifica si la operación fue exitosa
            if (result.Success)
            {
                // Transformar la lista en un formato de diccionario
                var diccionario = result.Result.Select(enf => new Dictionary<string, object>
        {
            { "1", enf.Id },
            { "2", enf.Nombre },
            { "3", enf.Descripcion },
            { "4", enf.Estado }
        }).ToList();

                // Si es exitosa, devuelve el diccionario con un estado 200 OK
                return Ok(diccionario);
                // Si es exitosa, devuelve el resultado con un estado 200 OK
                return Ok(result.Result);
            }
            else
            {
                // Si no fue exitosa, devuelve un error con el detalle
                return BadRequest(new { message = result.Messages });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EnfermedadCardiovascular enf)
        {
            // Llamada al DAO para obtener el registro
            var result = await _enfermedadCardiovascularDao.AddAsync(enf);

            // Verifica si la operación fue exitosa
            if (result.Success)
            {
                // Si es exitosa, devuelve el ID del nuevo registro con un estado 201 Created

                // return CreatedAtAction(nameof(Post), new { id = result.Result }, new { message = "Registro agregado exitosamente.", id = result.Result });
                return Ok();
            }
            else
            {
                // Si no fue exitosa, devuelve un error con el detalle

                return NoContent();
                // return BadRequest(new { message = result.Messages });
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromBody] EnfermedadCardiovascular enf, int id)
        {
            enf.id_enf_cardiovascular = id;
            // Llamada al DAO para actualizar el registro
            var result = await _enfermedadCardiovascularDao.UpdateAsync(enf, id);

            // Verifica si la operación fue exitosa
            if (result.Success)
            {
                // Si es exitosa, devuelve un mensaje con estado 200 OK

                // return Ok(new { message = "Registro editado exitosamente.", id = enf.id_enf_cardiovascular });
                return Ok();
            }
            else
            {
                // Si no fue exitosa, devuelve un error con el detalle

                return NoContent();
                // return BadRequest(new { message = result.Messages });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            // Llamada al DAO para actualizar el registro
            var result = await _enfermedadCardiovascularDao.DeleteAsync(id);

            // Verifica si la operación fue exitosa
            if (result.Success)
            {
                // Si es exitosa, devuelve un mensaje con estado 200 OK

                // return Ok(new { message = "Registro eliminado exitosamente.", id = id});
                return Ok();
            }
            else
            {
                // Si no fue exitosa, devuelve un error con el detalle

                return NoContent();
                // return BadRequest(new { message = result.Messages });
            }
        }


    }
}
