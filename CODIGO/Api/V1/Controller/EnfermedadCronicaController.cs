using System;
using ECE.Model.DAO;
using Entidad.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ECE.Api.V1.Controllers
{
    [ApiController]
    [Route("api/v1/enfermedades-cronicas")]
    public class EnfermedadCronicaController : ControllerBase
    {
        private readonly enfermedadCronicaDao _enfermedadCronicaDao;
        private readonly IConfiguration _configuration;

        public EnfermedadCronicaController(enfermedadCronicaDao enfermedadCronicaDao, IConfiguration configuration)
        {
            _enfermedadCronicaDao = enfermedadCronicaDao;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Llamada al DAO para obtener el registro
            var result = await _enfermedadCronicaDao.GetAll();

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
            // Llamada al DAO para obtener los registros
            var result = await _enfermedadCronicaDao.GetAll();

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
            var result = await _enfermedadCronicaDao.GetCompleto();

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
            var result = await _enfermedadCronicaDao.GetPageFetch(page, fetch);

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


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Llamada al DAO para obtener el registro
            var result = await _enfermedadCronicaDao.GetByIdAsync(id);

            // Verifica si la operación fue exitosa
            if (result.Success)
            {
                // Si es exitosa, devuelve el resultado con un estado 200 OK
                return Ok(result.Result);
            }
            else
            {
                // Si no fue exitosa, devuelve un error con el detalle

                return NoContent();
                // return BadRequest(new { message = result.Messages });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EnfermedadCronica enf)
        {
            // Llamada al DAO para obtener el registro
            var result = await _enfermedadCronicaDao.AddAsync(enf);

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
        public async Task<IActionResult> Put([FromBody] EnfermedadCronica enf, int id)
        {
            enf.id_enf_cronica = id;
            // Llamada al DAO para actualizar el registro
            var result = await _enfermedadCronicaDao.UpdateAsync(enf, id);

            // Verifica si la operación fue exitosa
            if (result.Success)
            {
                // Si es exitosa, devuelve un mensaje con estado 200 OK
                // return Ok(new { message = "Registro editado exitosamente.", id = enf.id_enf_cronica });
                return Ok();
            }
            else
            {
                // Si no fue exitosa, devuelve un error con el detalle

                // return NoContent();
                return BadRequest(new { message = result.Messages });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            // Llamada al DAO para actualizar el registro
            var result = await _enfermedadCronicaDao.DeleteAsync(id);

            // Verifica si la operación fue exitosa
            if (result.Success)
            {
                // Si es exitosa, devuelve un mensaje con estado 200 OK
                // return Ok(new { message = "Registro eliminado exitosamente.", id = id });
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
