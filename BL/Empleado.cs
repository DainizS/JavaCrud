using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JSanchezCRUDJavaScripEntities context = new DL.JSanchezCRUDJavaScripEntities())
                {
                    var empleadoItem = context.EmpleadoGetAll().ToList();

                    if (empleadoItem.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var empleadoItems in empleadoItem)
                        {
                            ML.Empleado empleado = new ML.Empleado();

                            empleado.Id = empleadoItems.Id;
                            empleado.NumeroNomina = empleadoItems.NumeroNomina;
                            empleado.Nombre = empleadoItems.Nombre;

                            empleado.ApellidoPaterno = empleadoItems.ApellidoPaterno;
                            empleado.ApellidoMaterno = empleadoItems.ApellidoMaterno;

                            empleado.CatEntidadFederativa = new ML.CatEntidadFederativa();
                            empleado.CatEntidadFederativa.Id = empleadoItems.IdEstado.Value;
                            empleado.CatEntidadFederativa.Estado = empleadoItems.Estado;

                            result.Objects.Add(empleado);

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
                result.Correct = true;
                result.ErrorMessage = Ex.Message;
            }
            return result;
        }

        public static ML.Result GetById(int IdEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JSanchezCRUDJavaScripEntities context = new DL.JSanchezCRUDJavaScripEntities())
                {
                    var empleadoItem = context.EmpleadoGetById(IdEmpleado).SingleOrDefault(); ;

                    if (empleadoItem != null)
                    {
                        ML.Empleado empleado = new ML.Empleado();

                        empleado.Id = empleadoItem.Id;
                        empleado.NumeroNomina = empleadoItem.NumeroNomina;
                        empleado.Nombre = empleadoItem.Nombre;

                        empleado.ApellidoPaterno = empleadoItem.ApellidoPaterno;
                        empleado.ApellidoMaterno = empleadoItem.ApellidoMaterno;

                        empleado.CatEntidadFederativa = new ML.CatEntidadFederativa();
                        empleado.CatEntidadFederativa.Id = empleadoItem.IdEstado.Value;
                        empleado.CatEntidadFederativa.Estado = empleadoItem.Estado;

                        result.Object = empleado;
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
                result.Correct = true;
                result.ErrorMessage = Ex.Message;
            }
            return result;
        }


        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JSanchezCRUDJavaScripEntities context = new DL.JSanchezCRUDJavaScripEntities())
                {
                    var empleadoItem = context.EmpleadoAdd(empleado.NumeroNomina, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.CatEntidadFederativa.Id);

                    if (empleadoItem != null)
                    {
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
                result.Correct = true;
                result.ErrorMessage = Ex.Message;
            }
            return result;
        }



        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JSanchezCRUDJavaScripEntities context = new DL.JSanchezCRUDJavaScripEntities())
                {
                    var empleadoItem = context.EmpleadoUpdate(empleado.Id, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.CatEntidadFederativa.Id);

                    if (empleadoItem != null)
                    {
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
                result.Correct = true;
                result.ErrorMessage = Ex.Message;
            }
            return result;
        }



        public static ML.Result Delete(int IdEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JSanchezCRUDJavaScripEntities context = new DL.JSanchezCRUDJavaScripEntities())
                {
                    var empleadoItem = context.EmpleadoDelete(IdEmpleado);

                    if (empleadoItem != null)
                    {
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
                result.Correct = true;
                result.ErrorMessage = Ex.Message;
            }
            return result;
        }


       

    }
}
