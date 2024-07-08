using DoctorApp.Services.BLL.Servicios.Interfaces;
using DoctorApp.Services.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DoctorApp.Services.API.Controllers
{
    public class MedicoController : BaseApiController
    {
        public readonly IMedicoServicio _service;
        private ApiResponse _response;

        public MedicoController(IMedicoServicio service)
        {
            _service = service;
            _response = new();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                _response.Resultado = await _service.ObtenerTodos();
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
            }

            return Ok(_response);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(MedicoDto modeloDto)
        {
            try
            {
                await _service.Agregar(modeloDto);
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
            }

            return Ok(_response);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(MedicoDto modeloDto)
        {
            try
            {
                await _service.Actualizar(modeloDto);
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.NoContent;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
            }

            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _service.Remover(id);
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.NoContent;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
            }

            return Ok(_response);
        }
    }
}
