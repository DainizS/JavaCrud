using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        [HttpGet]
        public ActionResult GetAll()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetData()
        {
            ML.Result result = BL.Empleado.GetAll();


            return Json(result, JsonRequestBehavior.AllowGet);
        }




        public JsonResult Add(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);
       
            
            return Json(result);
           
           
           
        }



        [HttpGet]
        public ActionResult Form()
        {
            return View(new ML.Empleado());
        }


  
    }
}