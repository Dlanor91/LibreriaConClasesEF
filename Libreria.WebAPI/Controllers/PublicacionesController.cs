using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libreria.Dominio.EntidadesNegocio;
using Libreria.AccesoDatos;
using LibreriaDTO;
using Libreria.Dominio.InterfacesRepositorios;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Libreria.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacionesController : ControllerBase
    {

        public IRepositorioPublicacion RepoPublicacion { get; set; }

        public PublicacionesController(IRepositorioPublicacion repoPublicacion)
        {
            RepoPublicacion=repoPublicacion;
        }


        // GET: api/publicaciones
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/publicaciones/autor/5 no preciso parametros
        [HttpGet("autor/{idAutor}")]        
        public IActionResult Get(int idAutor)
        {
            try
            {
                if (idAutor == 0) return BadRequest();

                IEnumerable<Publicacion> pubs = RepoPublicacion.ObtenerlasPublicacionesDelAutor(idAutor);
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

        // POST api/publicaciones
        [HttpPost]
        [Route("LIbro")]
        public IActionResult Post([FromBody] Libro libro)
        {
            try
            {
                if (!libro.Validar()) return BadRequest();
                bool ok = RepoPublicacion.Add(libro);
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("Revista")]
        public IActionResult Post([FromBody] Revista revista)
        {
            bool ok = RepoPublicacion.Add(revista);
            return Ok();
        }

    }
}
