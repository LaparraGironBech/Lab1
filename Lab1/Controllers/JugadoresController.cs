using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Lab1.Models.Data;
using Lab1.Models;


namespace Lab1.Controllers
{
    public class JugadoresController : Controller
    {
        //Cargar archivo CSV
        private IHostingEnvironment Environment;
        public JugadoresController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }
        // GET: JugadoresController

        public ActionResult Index()
        {                 
                return View(Singleton.Instance.JugadoresList);                       
        }


        // GET: JugadoresController/Details/5
        public ActionResult Details(int id)
        {
            Jugadores ViewJugadores;
            if (Singleton.Instance.L==0)
            {
                ViewJugadores = Singleton.Instance.JugadoresGeneric.ObtenerPos(devolverpos(id)).Data;
                return View(ViewJugadores);
            }
            else
            {
                ViewJugadores = Singleton.Instance.JugadoresList.Find(x => x.Id == id);
                return View(ViewJugadores);
            }
             
        }

        // GET: JugadoresController/Create
        public ActionResult Create()
        {
            return View();
        }
        public IActionResult search(string Buscar, string Busqueda, string salary)
        {

            int cont = 0;
           
            foreach(var item in Singleton.Instance.JugadoresBuscados)
                {
                cont++;
            }
            for (int i = 0; i < cont; i++)
            {
                Singleton.Instance.JugadoresBuscados.RemoveAt(0);
            }

            int opcion = Convert.ToInt32(Buscar);
            if (Singleton.Instance.L==0)
            {
                switch(opcion)
                {
                    case 0://Busqueda por nombre y apellido
                        for (int i = 0; i < Singleton.Instance.JugadoresGeneric.Cantidad; i++)
                        {
                            string NombreyApellido = Singleton.Instance.JugadoresGeneric.ObtenerPos(i).Data.Name + " " + Singleton.Instance.JugadoresGeneric.ObtenerPos(i).Data.Lastname;
                            if (NombreyApellido == Busqueda)
                            {
                                Jugadores Buscado = Singleton.Instance.JugadoresGeneric.ObtenerPos(i).Data;
                                Singleton.Instance.JugadoresBuscados.Add(Buscado);
                            }
                        }
                    break;

                    case 1://Búsqueda por Posición
                        for (int i = 0; i < Singleton.Instance.JugadoresGeneric.Cantidad; i++)
                        {
                            string Posicion = Singleton.Instance.JugadoresGeneric.ObtenerPos(i).Data.Position;
                            if (Posicion == Busqueda)
                            {
                                Jugadores Buscado = Singleton.Instance.JugadoresGeneric.ObtenerPos(i).Data;
                                Singleton.Instance.JugadoresBuscados.Add(Buscado);
                            }
                        }
                        break;


                    case 2://Búsqueda por Salario
                        int M = Convert.ToInt32(salary);
                        double saliocomparer = Convert.ToDouble(Busqueda);

                        for (int i = 0; i < Singleton.Instance.JugadoresGeneric.Cantidad; i++)
                        {
                            double Salario = Singleton.Instance.JugadoresGeneric.ObtenerPos(i).Data.Salary;
                            switch (M)
                            {
                                case 0://buscar menores a 
                                    if (saliocomparer >= Salario)
                                    {
                                        Jugadores Buscado = Singleton.Instance.JugadoresGeneric.ObtenerPos(i).Data;
                                        Singleton.Instance.JugadoresBuscados.Add(Buscado);
                                    }
                                    break;
                                case 1://buscar iguales a
                                    if (Salario == saliocomparer)
                                    {
                                        Jugadores Buscado = Singleton.Instance.JugadoresGeneric.ObtenerPos(i).Data;
                                        Singleton.Instance.JugadoresBuscados.Add(Buscado);
                                    }
                                    break;
                                case 2://buscar mayoresa 
                                    if (Salario >= saliocomparer)
                                    {
                                        Jugadores Buscado = Singleton.Instance.JugadoresGeneric.ObtenerPos(i).Data;
                                        Singleton.Instance.JugadoresBuscados.Add(Buscado);
                                    }
                                    break;
                            }

                        }

                        break;


                    case3://salario por Club
                        for (int i = 0; i < Singleton.Instance.JugadoresGeneric.Cantidad; i++)
                        {
                            string Club = Singleton.Instance.JugadoresGeneric.ObtenerPos(i).Data.Club;
                            if (Club == Busqueda)
                            {
                                Jugadores Buscado = Singleton.Instance.JugadoresGeneric.ObtenerPos(i).Data;
                                Singleton.Instance.JugadoresBuscados.Add(Buscado);
                            }
                        }
                        break;
                }            
            }
            else
            {
                switch (opcion)
                {
                    case 0://Busqueda por nombre y apellido
                        for (int i = 0; i < Singleton.Instance.JugadoresList.Count; i++)
                        {
                            string NombreyApellido = Singleton.Instance.JugadoresList[i].Name + " " + Singleton.Instance.JugadoresList[i].Lastname;
                            if (NombreyApellido == Busqueda)
                            {
                                Jugadores Buscado = Singleton.Instance.JugadoresList[i];
                                Singleton.Instance.JugadoresBuscados.Add(Buscado);
                            }
                        }
                        break;

                    case 1://Búsqueda por Posición
                        for (int i = 0; i < Singleton.Instance.JugadoresList.Count; i++)
                        {
                            string Posicion = Singleton.Instance.JugadoresList[i].Position;
                            if (Posicion == Busqueda)
                            {
                                Jugadores Buscado = Singleton.Instance.JugadoresList[i];
                                Singleton.Instance.JugadoresBuscados.Add(Buscado);
                            }
                        }
                        break;


                    case 2://Búsqueda por Salario
                        int M = Convert.ToInt32(salary);
                        double saliocomparer = Convert.ToDouble(Busqueda);

                        for (int i = 0; i < Singleton.Instance.JugadoresList.Count; i++)
                        {
                            double Salario = Singleton.Instance.JugadoresList[i].Salary;
                            switch (M)
                            {
                                case 0://buscar menores a 
                                    if (saliocomparer >= Salario )
                                    {
                                        Jugadores Buscado = Singleton.Instance.JugadoresList[i];
                                        Singleton.Instance.JugadoresBuscados.Add(Buscado);
                                    }
                                    break;
                                case 1://buscar iguales a
                                    if (Salario == saliocomparer)
                                    {
                                        Jugadores Buscado = Singleton.Instance.JugadoresList[i];
                                        Singleton.Instance.JugadoresBuscados.Add(Buscado);
                                    }
                                    break;
                                case 2://buscar mayoresa 
                                    if (Salario >= saliocomparer)
                                    {
                                        Jugadores Buscado = Singleton.Instance.JugadoresList[i];
                                        Singleton.Instance.JugadoresBuscados.Add(Buscado);
                                    }
                                    break;
                            }

                        }
                        break;


                    case3://salario por Club
                        for (int i = 0; i < Singleton.Instance.JugadoresList.Count; i++)
                        {
                            string Club = Singleton.Instance.JugadoresList[i].Club;
                            if (Club == Busqueda)
                            {
                                Jugadores Buscado = Singleton.Instance.JugadoresList[i];
                                Singleton.Instance.JugadoresBuscados.Add(Buscado);
                            }
                        }
                        break;
                }
            }
            
            return View(Singleton.Instance.JugadoresBuscados);
        }
        public ActionResult Index1()
        {
            return View(Singleton.Instance.JugadoresGeneric);
        }

        // POST: JugadoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Jugadores newJugadores = new Jugadores(Convert.ToInt32(collection["Id"]), collection["Name"], collection["Lastname"], collection["Club"], collection["Position"], Convert.ToDouble(collection["Salary"]), Convert.ToDouble(collection["Compensation"]));
                
                if (Singleton.Instance.L == 0) //En que lista agregar
                {
                    Singleton.Instance.JugadoresGeneric.AgregarPos(Convert.ToInt32(collection["Id"]), newJugadores);
                    return RedirectToAction(nameof(Index1));
                }
                else
                {
                    Singleton.Instance.JugadoresList.Add(newJugadores);
                    return RedirectToAction(nameof(Index));
                }
               
            }
            catch
            {
                return View();
            }
        }

        // GET: JugadoresController/Edit/5
        public ActionResult Edit(int id)
        {
            var editJugadores = Singleton.Instance.JugadoresList.Find(x => x.Id == id);

            Singleton.Instance.JugadoresList.Remove(editJugadores);
            return View(editJugadores);
        }

        // POST: JugadoresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Jugadores newJugadores = new Jugadores(Convert.ToInt32(collection["Id"]), collection["Name"], collection["Lastname"], collection["Club"], collection["Position"], Convert.ToDouble(collection["Salary"]), Convert.ToDouble(collection["Compensation"]));

                if (Singleton.Instance.L == 0) //En que lista agregar
                {
                    Singleton.Instance.JugadoresGeneric.AgregarPos(Convert.ToInt32(collection["Id"]), newJugadores);
                    return RedirectToAction(nameof(Index1));
                }
                else
                {
                    Singleton.Instance.JugadoresList.Add(newJugadores);
                    return RedirectToAction(nameof(Index));
                }

                
            }
            catch
            {
                return View();
            }
        }

        // GET: JugadoresController/Delete/5
        public ActionResult Delete(int id)
        {
            Jugadores deleteJugadores;
            if (Singleton.Instance.L==0)
            {
                deleteJugadores = Singleton.Instance.JugadoresGeneric.ObtenerPos(devolverpos(id)).Data;
                return View(deleteJugadores);
            }

            else
            {
                deleteJugadores = Singleton.Instance.JugadoresList.Find(x => x.Id == id);
                return View(deleteJugadores);
            }

            
        }

        // POST: JugadoresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if(Singleton.Instance.L==0)
                {
                    Singleton.Instance.JugadoresGeneric.Eliminarpos(devolverpos(id));
                    return RedirectToAction(nameof(Index1));
                }
                else
                {
                    var deleteJugadores = Singleton.Instance.JugadoresList.Find(x => x.Id == id);
                    Singleton.Instance.JugadoresList.Remove(deleteJugadores);
                    return RedirectToAction(nameof(Index));
                }
              
            }
            catch
            {
                return View();
            }
        }

        //Cargar csv
        public IActionResult loading(IFormFile postedFile)
        {
            
            if (postedFile != null)
            {
                string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileName = Path.GetFileName(postedFile.FileName);
                string filePath = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                string csvData = System.IO.File.ReadAllText(filePath);
                DataTable dt = new DataTable();
                bool firstRow = true;
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        if (!string.IsNullOrEmpty(row))
                        {
                            if (firstRow)
                            {

                                foreach (string cell in row.Split(','))
                                {

                                    //dt.Columns.Add(cell.Trim());

                                }

                                firstRow = false;
                            }
                            else
                            {
                                //dt.Rows.Add();
                                int i = 0;
                                int cont = 0;
                                string[] NodoM = new string[6] { "", "", "", "", "", ""};
                                int encontrar = 0;
                                string cell2 = "";
                                foreach (string cell in row.Split(','))
                                {
                                    if (cell.Substring(0, 1) != "\"" && encontrar == 0)
                                    {
                                        //dt.Rows[dt.Rows.Count - 1][i] = cell.Trim();
                                        NodoM[cont] = cell.Trim();
                                        cell2 = "";
                                        cont++;
                                        i++;
                                    }
                                    else
                                    {
                                        cell2 = cell2 + cell + ","; encontrar++;
                                        if (cell.Substring((cell.Length - 1), 1) == "\"")
                                        {
                                            encontrar = 0;
                                            cell2 = cell2.Remove(0, 1);
                                            cell2 = cell2.Remove(cell2.Length - 3, 3);
                                            //dt.Rows[dt.Rows.Count - 1][i] = cell2.Trim();
                                            NodoM[cont] = cell2.Trim();
                                            cont++;
                                            i++;
                                            cell2 = "";
                                        }

                                    }
                                }
                                //llenar listas------------------------------------>
                                Jugadores nuevoJugador = new Jugadores(Singleton.Instance.id, NodoM[2], NodoM[1], NodoM[0], NodoM[3], Convert.ToDouble(NodoM[4]), Convert.ToDouble(NodoM[5]));
                                if(Singleton.Instance.L==0)//si es lista artesanal
                                {
                                    
                                    Singleton.Instance.JugadoresGeneric.AgregarPos(Singleton.Instance.id, nuevoJugador);
                                    
                                }
                                else //si es lista de c#
                                {
                                    Singleton.Instance.JugadoresList.Add(nuevoJugador);                                 
                                }
                                Singleton.Instance.id++;
                            }
                        }
                    }
                }
            }

            if (Singleton.Instance.L == 0) { return Redirect("Index1"); } else { return Redirect("Index"); }
        }
        //metodo buscarposicion
        public int devolverpos(int iD)
        {
            int position;
            int cont = 0;
            bool encontrado = false;
            while (encontrado == false)
            {
                if (Singleton.Instance.JugadoresGeneric.ObtenerPos(cont).Data.Id == iD)
                {
                    return cont;
                }
                else
                {
                    cont++;
                }                
            }
            return cont;
        }
        public IActionResult regresar()
        {
            if (Singleton.Instance.L == 0)
            {
                return Redirect("Index1");
            }
            else
            {
                return Redirect("Index");
            }

        }

    }
}
