using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;


namespace WSRebels
{
    /// <summary>
    /// Descripción breve de Register
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Register : System.Web.Services.WebService
    {

        //Crear el String con el nombre, plantea y hora actual
        public string CreateRegisterString(string name, string planet)
        {
            string RegisterString;
            
            try
            {
                if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(planet))
                {
                    RegisterString = "rebel " + name + " on " + planet + " at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    RegisterString = "Error";
                }
            }
            catch(Exception ex)
            {
                Class.LogControl.SaveLog(ex.ToString());
                RegisterString = "Error";
            }
            return RegisterString;
        }

        //Guardar el String de registro en un documento txt
        public bool SaveRegister(string register)
        {
            bool Saved = true;
            try
            {
                File.AppendAllText(Class.ConfigApp.DocumentPath, register + Environment.NewLine);
                
            }
            catch(Exception ex)
            {
                Class.LogControl.SaveLog(ex.ToString());
                Saved = false;
            }

            return Saved;
        }


        //Recibe nombre y planeta y debuelve bool segun lo ha podido registrar en el documento o no
        [WebMethod]
        public bool RegisterDone(string name, string planet)
        {
            bool Done = true;
            string RegisterString = CreateRegisterString(name, planet);
            try
            {
                if(string.Equals(RegisterString, "Error"))
                {
                    Done = false;
                }
                else
                {
                    Done = SaveRegister(RegisterString);
                }
            }
            catch(Exception ex)
            {
                Class.LogControl.SaveLog(ex.ToString());
                Done = false; 
            }
            return Done;
        }
    }
}
