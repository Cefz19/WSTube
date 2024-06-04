using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WSTube.Models;
using WSTube.Models.Respons;
using WSTube.Models.Request;

namespace WSTube.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult Get() 
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RegistroContext db = new RegistroContext())
                {
                    var lst = db.RegistroUsuarios.OrderByDescending(d => d.Id).ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex) 
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RegistroContext db = new RegistroContext())
                {
                    RegistroUsuario oRegistro = new RegistroUsuario();
                    oRegistro.Nombre = oModel.Nombre;
                    oRegistro.Apellido = oModel.Apellido;
                    oRegistro.Usuario = oModel.Usuario;
                    db.RegistroUsuarios.Add(oRegistro);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Edit(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RegistroContext db = new RegistroContext())
                {
                    RegistroUsuario oRegistro = db.RegistroUsuarios.Find(oModel.Id);
                    oRegistro!.Nombre = oModel.Nombre;
                    oRegistro.Apellido = oModel.Apellido;
                    oRegistro.Usuario = oModel.Usuario;
                    db.Entry(oRegistro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpDelete ("{Id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RegistroContext db = new RegistroContext())
                {
                    RegistroUsuario oRegistro = db.RegistroUsuarios.Find(Id);
                    db.Remove(oRegistro);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
    }
}
