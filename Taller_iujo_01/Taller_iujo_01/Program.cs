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
			
			if(!Directory.Exists("Ruta_Raiz"))
			{
				Directory.CreateDirectory("Ruta_Raiz");
				Console.WriteLine("Se ha creado correctamente");
			}
			
			string archivotexto = Path.Combine(Ruta_Raiz, "notas.txt");
			
			Console.WriteLine(archivotexto);
			
			using(StreamWriter sw = new StreamWriter(archivotexto, true))
			{
				sw.WriteLine(string.Format("ID : {0} nota {1} {yyyy-MM-dd HH:mm}", ID, Nota, DateTime.Now));
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}