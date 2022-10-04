using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace PL.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly IHostingEnvironment _hostingEnvironment;

        public ProductoController(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public ActionResult GetAll()
        {

            ML.Producto producto = new ML.Producto();

            ML.Result ApiResult = new ML.Result();


            using(var client =new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration["WebApi"]);

                var responseTask = client.GetAsync("api/producto/GetAll");


                responseTask.Wait();

                var result = responseTask.Result;

                if(result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<ML.Result>();

                    readtask.Wait();

                    ApiResult.Objects = new List<object>();

                    foreach (var resultItem in readtask.Result.Objects)
                    {
                        ML.Producto resultProducto = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(resultItem.ToString());
                        ApiResult.Objects.Add(resultProducto);
                    }
                }
            }
            producto.productos= ApiResult.Objects;


            //producto.fabricante = new ML.Fabricante();

            //ML.Result result = BL.Producto.GetAll();

            //if (result.correct)
            //{
            //    producto.productos = result.Objects;
            //}
            //else
            //{
            //    result.correct = false;
            //}
            return View(producto);
        }
    
    
    
    }
}
