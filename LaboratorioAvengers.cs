using System;
using System.IO;

class Program
{
    static string directorioBase = @"C:\LaboratorioAvengers";
    static string archivoInventos = Path.Combine(directorioBase, "inventos.txt");
    static string carpetaBackup = Path.Combine(directorioBase, "Backup");
    static string carpetaArchivosClasificados = Path.Combine(directorioBase, "ArchivosClasificados");
    static string carpetaProyectosSecretos = Path.Combine(directorioBase, "ProyectosSecretos");

    static void Main(string[] args)
    {
        CrearDirectorio(directorioBase);
        MostrarMenu();
    }

    static void MostrarCarga(string mensaje)
    {
        Console.Clear();
        Console.WriteLine(mensaje);
        for (int i = 0; i < 3; i++)
        {
            Console.SetCursorPosition(mensaje.Length, Console.CursorTop);
            Console.Write(".");
            System.Threading.Thread.Sleep(500);
        }
        Console.Clear();
    }

    static void MostrarMenu()
    {
        while (true)
        {
            MostrarCarga("Cargando menú...");
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("------------LaboratorioAvengers-------------");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("   ");
            Console.WriteLine("1. Crear archivo de inventos");
            Console.WriteLine("   ");
            Console.WriteLine("2. Agregar invento");
            Console.WriteLine("   ");
            Console.WriteLine("3. Leer archivo línea por línea");
            Console.WriteLine("   ");
            Console.WriteLine("4. Leer todo el archivo");
            Console.WriteLine("   ");
            Console.WriteLine("5. Copiar archivo");
            Console.WriteLine("   ");
            Console.WriteLine("6. Mover archivo");
            Console.WriteLine("   ");
            Console.WriteLine("7. Crear carpeta");
            Console.WriteLine("   ");
            Console.WriteLine("8. Verificar existencia de archivo");
            Console.WriteLine("   ");
            Console.WriteLine("9. Eliminar archivo");
            Console.WriteLine("   ");
            Console.WriteLine("10. Listar archivos");
            Console.WriteLine("   ");
            Console.WriteLine("0. Salir");
            Console.WriteLine("--------------------------------------------");

            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    MostrarCarga("Creando archivo...");
                    CrearArchivo();
                    break;
                case "2":
                    Console.Write("Ingrese el nombre del invento a agregar: ");
                    string invento = Console.ReadLine();
                    MostrarCarga("Agregando invento...");
                    AgregarInvento(invento);
                    break;
                case "3":
                    MostrarCarga("Leyendo archivo...");
                    LeerLineaPorLinea();
                    break;
                case "4":
                    MostrarCarga("Leyendo todo el archivo...");
                    LeerTodoElTexto();
                    break;
                case "5":
                    MostrarCarga("Copiando archivo...");
                    CopiarArchivo();
                    break;
                case "6":
                    MostrarCarga("Moviendo archivo...");
                    MoverArchivo();
                    break;
                case "7":
                    MostrarCarga("Creando carpeta...");
                    CrearCarpeta();
                    break;
                case "8":
                    MostrarCarga("Verificando existencia de archivo...");
                    VerificarExistenciaArchivo();
                    break;
                case "9":
                    MostrarCarga("Eliminando archivo...");
                    EliminarArchivo();
                    break;
                case "10":
                    MostrarCarga("Listando archivos...");
                    ListarArchivos();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void CrearArchivo()
    {
        Console.WriteLine("   "); // Añadido el espacio
        try
        {
            if (!File.Exists(archivoInventos))
            {
                File.Create(archivoInventos).Close();
                Console.WriteLine("Archivo 'inventos.txt' creado exitosamente.");
                Console.WriteLine("--------------------------------------------------");
            }
            else
            {
                Console.WriteLine("El archivo 'inventos.txt' ya existe.");
                Console.WriteLine("--------------------------------------------");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear el archivo: {ex.Message}");
            Console.WriteLine("--------------------------------------------");
        }
    }

    static void AgregarInvento(string invento)
    {
        Console.WriteLine("   "); // Añadido el espacio
        try
        {
            File.AppendAllText(archivoInventos, invento + Environment.NewLine);
            Console.WriteLine($"Invento '{invento}' agregado exitosamente.");
            Console.WriteLine("--------------------------------------------------");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al agregar el invento: {ex.Message}");
            Console.WriteLine("--------------------------------------------");
        }
    }

    static void LeerLineaPorLinea()
    {
        Console.WriteLine("   "); 
        try
        {
            if (File.Exists(archivoInventos))
            {
                var lineas = File.ReadLines(archivoInventos);
                foreach (var linea in lineas)
                {
                    Console.WriteLine(linea);
                }
            }
            else
            {
                Console.WriteLine("Error: El archivo 'inventos.txt' no existe. ¡Ultron debe haberlo borrado!");
                Console.WriteLine("------------------------------------------------------------------------------");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer el archivo: {ex.Message}");
            Console.WriteLine("--------------------------------------------");
        }
    }

    static void LeerTodoElTexto()
    {
        Console.WriteLine("   "); 
        try
        {
            if (File.Exists(archivoInventos))
            {
                string contenido = File.ReadAllText(archivoInventos);
                Console.WriteLine(contenido);
            }
            else
            {
                Console.WriteLine("Error: El archivo 'inventos.txt' no existe. ¡Ultron debe haberlo borrado!");
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer el archivo: {ex.Message}");
            Console.WriteLine("--------------------------------------------");
        }
    }

    static void CopiarArchivo()
    {
        Console.WriteLine("   "); 
        try
        {
            if (File.Exists(archivoInventos))
            {
                CrearDirectorio(carpetaBackup);
                string archivoDestino = Path.Combine(carpetaBackup, "inventos_backup.txt");
                File.Copy(archivoInventos, archivoDestino, true);
                Console.WriteLine("Archivo copiado exitosamente a 'Backup'.");
                Console.WriteLine("--------------------------------------------");
            }
            else
            {
                Console.WriteLine("Error: El archivo 'inventos.txt' no existe.");
                Console.WriteLine("------------------------------------------------");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al copiar el archivo: {ex.Message}");
            Console.WriteLine("--------------------------------------------");
        }
    }

    static void MoverArchivo()
    {
        Console.WriteLine("   "); // Añadido el espacio
        try
        {
            if (File.Exists(archivoInventos))
            {
                CrearDirectorio(carpetaArchivosClasificados);
                string archivoDestino = Path.Combine(carpetaArchivosClasificados, "inventos.txt");
                File.Move(archivoInventos, archivoDestino);
                archivoInventos = archivoDestino;
                Console.WriteLine("Archivo movido exitosamente a 'ArchivosClasificados'.");
                Console.WriteLine("----------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Error: El archivo 'inventos.txt' no existe.");
                Console.WriteLine("------------------------------------------------");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al mover el archivo: {ex.Message}");
            Console.WriteLine("--------------------------------------------");
        }
    }

    static void CrearCarpeta()
    {
        Console.WriteLine("   "); 
        Console.Write("Ingrese el nombre de la carpeta: ");
        string nombreCarpeta = Console.ReadLine();
        string rutaCarpeta = Path.Combine(directorioBase, nombreCarpeta);

        try
        {
            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Carpeta '{nombreCarpeta}' creada exitosamente.");
                Console.WriteLine("--------------------------------------------------");
            }
            else
            {
                Console.WriteLine($"La carpeta '{nombreCarpeta}' ya existe.");
                Console.WriteLine("--------------------------------------------");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear la carpeta: {ex.Message}");
            Console.WriteLine("--------------------------------------------");
        }
    }

    static void VerificarExistenciaArchivo()
    {
        Console.WriteLine("   "); 
        if (File.Exists(archivoInventos))
        {
            Console.WriteLine("El archivo 'inventos.txt' existe.");
            Console.WriteLine("--------------------------------------------");
        }
        else
        {
            Console.WriteLine("Error: El archivo 'inventos.txt' no existe. ¡Ultron debe haberlo borrado!");
            Console.WriteLine("------------------------------------------------------------------------------");
        }
    }

    static void EliminarArchivo()
    {
        Console.WriteLine("   "); 
        try
        {
            if (File.Exists(archivoInventos))
            {
                File.Delete(archivoInventos);
                Console.WriteLine("Archivo 'inventos.txt' eliminado exitosamente.");
                Console.WriteLine("--------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Error: El archivo 'inventos.txt' no existe.");
                Console.WriteLine("--------------------------------------------------");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al eliminar el archivo: {ex.Message}");
            Console.WriteLine("--------------------------------------------");
        }
    }

    static void ListarArchivos()
    {
        Console.WriteLine("   "); 
        try
        {
            if (Directory.Exists(directorioBase))
            {
                var archivos = Directory.GetFiles(directorioBase);
                Console.WriteLine("Archivos en 'LaboratorioAvengers':");
                Console.WriteLine("--------------------------------------------");
                foreach (var archivo in archivos)
                {
                    Console.WriteLine(Path.GetFileName(archivo));
                }
            }
            else
            {
                Console.WriteLine("Error: El directorio 'LaboratorioAvengers' no existe.");
                Console.WriteLine("----------------------------------------------------------");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al listar los archivos: {ex.Message}");
            Console.WriteLine("--------------------------------------------");
        }
    }

    static void CrearDirectorio(string ruta)
    {
        if (!Directory.Exists(ruta))
        {
            Directory.CreateDirectory(ruta);
        }
    }
}
