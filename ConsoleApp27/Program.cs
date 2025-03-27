using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp27
{

	namespace ConsoleApp24
	{
		internal class Program
		{
			public class Producto
			{
				public string nombre { get; set; }
				public int cantidad { get; set; }
				public decimal precio { get; set; }

				public override string ToString()
				{
					return $"Nombre: {nombre}, Cantidad: {cantidad}, Precio: {precio:C}";
				}
			}

			public class GestionInventario
			{
				private List<Producto> inventario = new List<Producto>();

				public void AgregarProducto(Producto producto)
				{
					inventario.Add(producto);
					Console.WriteLine($"Producto '{producto.nombre}' agregado al inventario.");
				}

				public void MostrarInventario()
				{
					if (inventario.Count == 0)
					{
						Console.WriteLine("El inventario está vacío.");
						return;
					}

					Console.WriteLine("Inventario:");
					foreach (var producto in inventario)
					{
						Console.WriteLine(producto);
					}
				}

				public Producto BuscarProducto(string nombre)
				{
					return inventario.Find(producto => producto.nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
				}
			}

			public class Programa
			{
				public static void Main(string[] args)
				{
					GestionInventario gestionInventario = new GestionInventario();

					while (true)
					{
						Console.WriteLine("\nOpciones:");
						Console.WriteLine("1. Agregar producto");
						Console.WriteLine("2. Mostrar inventario");
						Console.WriteLine("3. Buscar producto");
						Console.WriteLine("4. Salir");
						Console.Write("Ingrese la opción: ");

						string opcion = Console.ReadLine();

						switch (opcion)
						{
							case "1":
								Console.Write("Nombre del producto: ");
								string nombre = Console.ReadLine();
								Console.Write("Cantidad: ");
								int cantidad = Convert.ToInt32(Console.ReadLine());
								Console.Write("Precio: ");
								decimal precio = Convert.ToDecimal(Console.ReadLine());

								Producto producto = new Producto { nombre = nombre, cantidad = cantidad, precio = precio };
								gestionInventario.AgregarProducto(producto);
								break;
							case "2":
								gestionInventario.MostrarInventario();
								break;
							case "3":
								Console.Write("Nombre del producto a buscar: ");
								string nombreBusqueda = Console.ReadLine();
								Producto productoEncontrado = gestionInventario.BuscarProducto(nombreBusqueda);
								if (productoEncontrado != null)
								{
									Console.WriteLine($"Producto encontrado: {productoEncontrado}");
								}
								else
								{
									Console.WriteLine("Producto no encontrado.");
								}
								break;
							case "4":
								return; 
							default:
								Console.WriteLine("Opción no válida.");
								break;
						}
					}
				}

			}
		}
	}

}
