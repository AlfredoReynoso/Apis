using Apis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Apis.Controllers
{
    public class ProductoController : ApiController
    {

        private readonly FerreteriaContext db;


        //Get api/producto
        public IEnumerable<CatProductos> Get()
        {
            var db = new FerreteriaContext();
            return db.CatProductos.ToList();

        }

        //Get api/producto/5
        public IHttpActionResult Get(int id)
        {
            var db = new FerreteriaContext();
            var productos = db.CatProductos.Find(id);
            if (productos == null)
            {
                return NotFound();
            }
            return Ok(productos);

        }

        //Post api/producto
        public IHttpActionResult Post([FromBody] CatProductos catProductos)
        {
            var db = new FerreteriaContext();

            if (catProductos == null)
            {
                return BadRequest("El cuerpo de la solicitud no contiene datos válidos.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CatProductos.Add(catProductos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = catProductos.id }, catProductos);
        }

        //PUT api/producto

        public IHttpActionResult Put(int id, [FromBody] CatProductos catProductos)
        {
            var db = new FerreteriaContext();

            if (catProductos == null)
            {
                return BadRequest("El cuerpo de la solicitud no contiene datos válidos.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productoexistente = db.CatProductos.Find(id);
            if (productoexistente == null)
            {
                return NotFound();
            }

            productoexistente.nombre = catProductos.nombre;
            productoexistente.fechaAlta = DateTime.Now;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        //DELETE api/produtco
        public IHttpActionResult Delete(int id)
        {
            var db = new FerreteriaContext();
            var catProducto = db.CatProductos.Find(id);

            if (catProducto == null)
            {
                return NotFound();
            }

            db.CatProductos.Remove(catProducto);
            db.SaveChanges();

            return Ok(catProducto);
        }
    }
}
