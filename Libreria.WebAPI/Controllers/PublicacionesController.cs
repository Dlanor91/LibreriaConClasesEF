using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libreria.Dominio.EntidadesNegocio;
using Libreria.Dominio.InterfacesRepositorios;
using Libreria.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Libreria.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacionesController : ControllerBase
    {
        public IRepositorioPublicacion RepoPublicaciones { get; set; }

        public PublicacionesController(IRepositorioPublicacion repo)
        {
            RepoPublicaciones = repo;
        }


        //GET api/publicaciones/6
        [HttpGet("{id}")]
        [Route("{id}", Name ="Get")]
        public IActionResult FindById(int id)
        {
            return Ok();
        }

            // GET api/publicaciones/autor/5
            [HttpGet("autor/{idAutor}")]
        public IActionResult Get(int idAutor)
        {
            try
            {
                if (idAutor == 0) return BadRequest();

                IEnumerable<Publicacion> pubs = RepoPublicaciones.ObtenerLasPublicacionesDelAutor(idAutor);
                IEnumerable<DTOPublicacion> dtos = pubs.Select(pub => new DTOPublicacion()
                {
                    Id = pub.Id,
                    CantidadPaginas = pub.CantidadPaginas,
                    Titulo = pub is Libro ? (pub as Libro).Titulo : null,
                    Numero = pub is Revista ? (pub as Revista).Numero : 0,
                    Anio = pub is Revista ? (pub as Revista).Anio : 0,
                    NombresAutores = string.Join(", ", pub.AutoresPublicaciones.Select(ap => ap.Autor.Nombre))
                });

                return Ok(dtos);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // POST api/publicaciones/alta/libro
        [HttpPost]
        [Route("alta/libro")]
        public IActionResult Post([FromBody] Libro libro)
        {
            try
            {
                if (!libro.Validar()) return BadRequest();
                //if (!ModelState.IsValid) return BadRequest();

                bool ok = RepoPublicaciones.Add(libro);
                if (!ok) return Conflict();

                return CreatedAtRoute("Get", new { id = libro.Id }, libro);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // POST api/publicaciones/alta/revista
        [HttpPost]
        [Route("alta/revista")]
        public IActionResult Post([FromBody] Revista revista)
        {
            try
            {
                if (!revista.Validar()) return BadRequest();
                //if (!ModelState.IsValid) return BadRequest();

                bool ok = RepoPublicaciones.Add(revista);
                if (!ok) return Conflict();

                return CreatedAtRoute("Get", new { id = revista.Id }, revista);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
