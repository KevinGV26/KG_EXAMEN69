using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Fabricante
    {
        public static ML.Result FabricanteGetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BD_KevinManuelGarciaVegaContext context = new DL.BD_KevinManuelGarciaVegaContext())
                {
                    var query = context.Fabricantes.FromSqlRaw($"FabricanteGetAll").ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Fabricante fabricante = new ML.Fabricante();

                            fabricante.IdFabricante = obj.IdFabricante;
                            fabricante.Nombre = obj.Nombre;

                            result.Objects.Add(fabricante);
                        }
                        result.correct = true;
                    }
                    else
                    {
                        result.correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

    }
}
