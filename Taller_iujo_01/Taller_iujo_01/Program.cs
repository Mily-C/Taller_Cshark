/*
 * Creado por SharpDevelop.
 * Usuario: usuario
 * Fecha: 17/4/2026
 * Hora: 10:56 a. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;
using System.Text;

namespace Taller_iujo_01
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("===Taller 01===");
			
			//1. El dato del usuario
			string Registro_de_Usuario = "   ID_777;   August;   Evaluacion;  95";
			Console.WriteLine(Registro_de_Usuario);
			
			string Registro_Limpio = Registro_de_Usuario.Trim();
			Console.WriteLine(Registro_Limpio);
			
			string[] partes = Registro_Limpio.Split(';');
			string ID = partes[0].Trim();
			string Nombre = partes[1].Trim();
			string Tarea = partes[2].Trim();
			string Nota = partes[3].Trim();
			
			Console.WriteLine(string.Format("El id es: {0} del usuario {1} en la evaluacion {2} con la nota {3}", ID, Nombre, Tarea, Nota));
			

				
			//Flujo en archivos
			
			string Ruta_Raiz = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Datos IUJO");
			
			if(!Directory.Exists(Ruta_Raiz))
			{
				Directory.CreateDirectory(Ruta_Raiz);
				Console.WriteLine("Se ha creado correctamente");
			}
			
			string archivotexto = Path.Combine(Ruta_Raiz, "notas.txt");
			
			Console.WriteLine(archivotexto);
			
			using(StreamWriter sw = new StreamWriter(archivotexto, true))
			{
				sw.WriteLine(string.Format("ID : {0} nota {1} {2:yyyy-MM-dd HH:mm}", ID, Nota, DateTime.Now));
			}
			
			Console.WriteLine("Archivo Registro guardado en notas.txt.");
	
			
			//Reto 1
			
			Console.WriteLine("\nRegistro de Seguridad");
            Console.Write("Ingrese usuario y clave separados por ';':\n ");
            string Entrada_Usuario = Console.ReadLine();

            if (!string.IsNullOrEmpty(Entrada_Usuario) && Entrada_Usuario.Contains(";"))
            {
                string[] Partes_Login = Entrada_Usuario.Split(';');
                string Password = Partes_Login[1].Trim();

                if (Password.Contains("123"))
                {
                    string Ruta_Seguridad = Path.Combine(Ruta_Raiz, "seguridad.txt");
                    using (StreamWriter sw = new StreamWriter(Ruta_Seguridad, true))
                    {
                        sw.WriteLine(string.Format("[{0:yyyy-MM-dd HH:mm}] Clave Debil detectada: {1}", DateTime.Now, Password));
                    }
                    Console.WriteLine("Clave debil detectada");
                }
                else
                {
                    Console.WriteLine("Clave aceptada.");
                }
            }
		
		    //Reto 2
		    Console.WriteLine("\n Clonador de Imagenes ");
            Console.WriteLine("Arrastre una imagen a la consola o escriba su ruta:");
            
            string Nombre_Avatar = "avatar.jpg";
            string Nombre_Respaldo = "respaldo.jpg";

            string Origen = Console.ReadLine().Replace("\"", ""); 
            string Destino = Path.Combine(Ruta_Raiz, Nombre_Respaldo);
            
            if (File.Exists(Origen))
            {
            	string Ruta_Minuscula = Origen.ToLower();
            	if (Ruta_Minuscula.EndsWith(".jpg") || Ruta_Minuscula.EndsWith(".png"))
            	{
                      using (FileStream fsIn = new FileStream(Origen, FileMode.Open, FileAccess.Read))
                      using (FileStream fsOut = new FileStream(Destino, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[1024];
                    int Cantidad;
                    while ((Cantidad = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fsOut.Write(buffer, 0, Cantidad);
                    }
                }
                    FileInfo inspector = new FileInfo(Destino);
                    if (inspector.Exists)
                    {
                    	Console.WriteLine("\nLa imagen "+ Nombre_Avatar +" ha sido clonada correctamente como "+ Nombre_Respaldo);
                        Console.WriteLine("Imagen detectada \nSu tamaño es de... " + inspector.Length + " bytes!");
                        Console.WriteLine("\nPuedes encontrar tu copia de tu imagen aqui: " + Destino + "\n");
                    }
              }
              else
              {
                  Console.WriteLine("\nEl archivo no es una imagen valida (jpg/png)");
                  Console.WriteLine("\nNo se realizo la clonacion :C");
              }
            }
            else
            {
                Console.WriteLine("Algo anda mal, No se encontro 'avatar.jpg' para clonar");
            }
            
            //Reto 3
            Console.WriteLine("\nSe esta iniciando una limpieza de archivos...");
            string[] archivosEnCarpeta = Directory.GetFiles(Ruta_Raiz);
            foreach (string ruta in archivosEnCarpeta)
            {
                FileInfo info = new FileInfo(ruta);
                
                if (info.Length > 5120 && info.Name != "notas.txt")
                {
                    string Nombre_Borrado = info.Name;
                    long Tamaño_en_KB = info.Length / 1024;
                    
                    Console.WriteLine("Se ha detectado un archivo pesado, el cual es..." + Nombre_Borrado + "!" + "\ny pesa..."+ Tamaño_en_KB + "KB");
                    info.Delete();
                    Console.WriteLine("Se ha elimino el archivo pesado para ahorrar el espacio disponible, bye bye " + Nombre_Borrado +"!");
                }
            }

			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}