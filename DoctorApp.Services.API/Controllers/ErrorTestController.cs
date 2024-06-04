﻿using DoctorApp.Services.API.Errores;
using DoctorApp.Services.Data;
using DoctorApp.Services.Models.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorApp.Services.API.Controllers
{
    public class ErrorTestController : BaseApiController
    {
        private readonly ApplicationDbContext _context;

        public ErrorTestController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetNotAuthorized()
        {
            return "No autorizado";
        }

        [HttpGet("not-found")]
        public ActionResult<Usuario> GetNotFound()
        {
            var objeto = _context.Usuarios.Find(-1);
            if (objeto == null) return NotFound(new ApiErrorResponse(404));
            return objeto;
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var objeto = _context.Usuarios.Find(-1);
            var objetoString = objeto.ToString();
            return objetoString;
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest(new ApiErrorResponse(400));
        }
    }
}
