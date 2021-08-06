using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CatEntidadFederativa
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JSanchezCRUDJavaScripEntities context = new DL.JSanchezCRUDJavaScripEntities())
                {
                    var catEntidaFederativaItem = context.CatEntidadFederativaGetAll().ToList();

                    if (catEntidaFederativaItem.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var catEntidadFederativaItems in catEntidaFederativaItem)
                        {
                            ML.CatEntidadFederativa catentidadfederativa = new ML.CatEntidadFederativa();
                            catentidadfederativa.Id = catEntidadFederativaItems.Id;
                            catentidadfederativa.Estado = catEntidadFederativaItems.Estado;

                            result.Objects.Add(catentidadfederativa);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                   
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
            }
            return result;
        }
    }
}
