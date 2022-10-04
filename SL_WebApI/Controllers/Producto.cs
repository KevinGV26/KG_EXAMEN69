using Microsoft.AspNetCore.Mvc;

namespace SL_WebApI.Controllers
{
    public class Producto : Controller
    {


        [Route("/api/producto/GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            //ML.Producto producto = new ML.Producto();


            var result = BL.Producto.GetAll();

            if(result.correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
