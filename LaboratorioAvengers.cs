using System;
using System.IO;

class Program
{
    // Defino las rutas base de los directorios y el archivo que voy a manejar.
    static string directorioBase = @"C:\LaboratorioAvengers";  // Directorio donde se guardarán todos los archivos.
    static string archivoInventos = Path.Combine(directorioBase, "inventos.txt");  // Archivo de inventos donde guardamos los nombres de los inventos.
    static string carpetaBackup = Path.Combine(directorioBase, "Backup");  // Carpeta para hacer respaldos del archivo.
    static string carpetaArchivosClasificados = Path.Combine(directorioBase, "ArchivosClasificados");  // Carpeta para mover el archivo.
    static string carpetaProyectosSecretos = Path.Combine(directorioBase, "ProyectosSecretos");  // Otra carpeta de proyectos secretos.

    // Esta es la función principal donde arranca el programa.
    static void Main(string[] args)
    {
        CrearDirectorio(directorioBase); // Primero me aseguro de que el directorio base exista.
        MostrarMenu(); // Luego muestro el menú para que el usuario elija qué acción hacer.
    }

    // Función para mostrar un mensaje de carga. Esta función crea la sensación de que el programa está procesando algo.
    static void MostrarCarga(string mensaje)
    {
        Console.Clear(); // Limpio la consola para mostrar la carga.
        Console.WriteLine(mensaje);  // Muestro el mensaje de carga.
        for (int i = 0; i < 3; i++) // Agrego 3 puntos que se van a ir agregando uno por uno, para simular el proceso.
        {
            Console.SetCursorPosition(mensaje.Length, Console.CursorTop);  // Muevo el cursor para agregar los puntos después del mensaje.
            Console.Write(".");  // Escribo un punto.
            System.Threading.Thread.Sleep(500); // Hago una pausa de medio segundo para que el punto sea visible.
        }
        Console.Clear(); // Limpio la consola después de la carga.
    }

    // Función que muestra el menú y permite al usuario seleccionar qué opción ejecutar.
    static void MostrarMenu()
    {
        while (true) // El menú estará en un ciclo infinito hasta que el usuario decida salir.
        {
            MostrarCarga("Cargando menú...");  // Muestra el ícono de carga mientras carga el menú.
            Console.Clear(); // Limpio la pantalla antes de mostrar el menú.
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

            Console.Write("Seleccione una opción: ");  // Le pido al usuario que ingrese una opción.
            string opcion = Console.ReadLine();  // Leo la opción ingresada por el usuario.

            // Dependiendo de la opción, se ejecuta una acción diferente.
            switch (opcion)
            {
                case "1":
                    MostrarCarga("Creando archivo...");  // Muestra el ícono de carga antes de crear el archivo.
                    CrearArchivo();  // Creo el archivo de inventos.
                    break;
                case "2":
                    Console.Write("Ingrese el nombre del invento a agregar: ");
                    string invento = Console.ReadLine();  // Pido el nombre del invento al usuario.
                    MostrarCarga("Agregando invento...");  // Muestra el ícono de carga antes de agregar el invento.
                    AgregarInvento(invento);  // Agrego el invento al archivo.
                    break;
                case "3":
                    MostrarCarga("Leyendo archivo...");  // Muestra el ícono de carga antes de leer el archivo.
                    LeerLineaPorLinea();  // Leo el archivo línea por línea.
                    break;
                case "4":
                    MostrarCarga("Leyendo todo el archivo...");  // Muestra el ícono de carga antes de leer todo el archivo.
                    LeerTodoElTexto();  // Leo todo el archivo de una vez.
                    break;
                case "5":
                    MostrarCarga("Copiando archivo...");  // Muestra el ícono de carga antes de copiar el archivo.
                    CopiarArchivo();  // Copio el archivo a una carpeta de respaldo.
                    break;
                case "6":
                    MostrarCarga("Moviendo archivo...");  // Muestra el ícono de carga antes de mover el archivo.
                    MoverArchivo();  // Muevo el archivo a otra carpeta.
                    break;
                case "7":
                    MostrarCarga("Creando carpeta...");  // Muestra el ícono de carga antes de crear una nueva carpeta.
                    CrearCarpeta();  // Creo una nueva carpeta en el directorio base.
                    break;
                case "8":
                    MostrarCarga("Verificando existencia de archivo...");  // Muestra el ícono de carga antes de verificar si el archivo existe.
                    VerificarExistenciaArchivo();  // Verifico si el archivo "inventos.txt" existe.
                    break;
                case "9":
                    MostrarCarga("Eliminando archivo...");  // Muestra el ícono de carga antes de eliminar el archivo.
                    EliminarArchivo();  // Elimino el archivo "inventos.txt".
                    break;
                case "10":
                    MostrarCarga("Listando archivos...");  // Muestra el ícono de carga antes de listar los archivos.
                    ListarArchivos();  // Listo todos los archivos del directorio base.
                    break;
                case "0":
                    return;  // Si el usuario elige salir, salgo del programa.
                default:
                    Console.WriteLine("Opción no válida.");  // Si el usuario ingresa una opción incorrecta, muestro un mensaje de error.
                    break;
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");  // Pido al usuario que presione una tecla para volver al menú.
            Console.ReadKey();  // Espero a que el usuario presione una tecla.
        }
    }

    // Función para crear el archivo de inventos si no existe.
    static void CrearArchivo()
    {
        Console.WriteLine("   ");  // Añadido un espacio para que el texto no quede pegado al principio de la consola.
        try
        {
            if (!File.Exists(archivoInventos))  // Verifico si el archivo ya existe.
            {
                File.Create(archivoInventos).Close();  // Si no existe, lo creo.
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
            Console.WriteLine($"Error al crear el archivo: {ex.Message}");  // Si ocurre un error, lo manejo con un mensaje de error.
            Console.WriteLine("--------------------------------------------");
        }
    }

    // Función para agregar un invento al archivo.
    static void AgregarInvento(string invento)
    {
        Console.WriteLine("   ");  // Añadido un espacio para que el texto no quede pegado al principio de la consola.
        try
        {
            File.AppendAllText(archivoInventos, invento + Environment.NewLine);  // Agrego el invento al final del archivo.
            Console.WriteLine($"Invento '{invento}' agregado exitosamente.");
            Console.WriteLine("--------------------------------------------------");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al agregar el invento: {ex.Message}");  // Manejo cualquier error que ocurra al agregar el invento.
            Console.WriteLine("--------------------------------------------");
        }
    }

    // Función para leer el archivo línea por línea.
    static void LeerLineaPorLinea()
    {
        Console.WriteLine("   ");  // Añadido un espacio para que el texto no quede pegado al principio de la consola.
        try
        {
            if (File.Exists(archivoInventos))  // Verifico si el archivo existe.
            {
                var lineas = File.ReadLines(archivoInventos);  // Leo las líneas del archivo.
                foreach (var linea in lineas)  // Recorro cada línea.
                {
                    Console.WriteLine(linea);  // Muestra cada invento en la consola.
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
            Console.WriteLine($"Error al leer el archivo: {ex.Message}");  // Si ocurre un error, lo manejo con un mensaje de error.
            Console.WriteLine("--------------------------------------------");
        }
    }

    // Función para leer todo el contenido del archivo de una sola vez.
    static void LeerTodoElTexto()
    {
        Console.WriteLine("   ");  // Añadido un espacio para que el texto no quede pegado al principio de la consola.
        try
        {
            if (File.Exists(archivoInventos))  // Verifico si el archivo existe.
            {
                string contenido = File.ReadAllText(archivoInventos);  // Leo todo el contenido del archivo.
                Console.WriteLine(contenido);  // Muestra todo el contenido en la consola.
            }
            else
            {
                Console.WriteLine("Error: El archivo 'inventos.txt' no existe. ¡Ultron debe haberlo borrado!");
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer el archivo: {ex.Message}");  // Si ocurre un error, lo manejo con un mensaje de error.
            Console.WriteLine("--------------------------------------------");
        }
    }

    // Función para copiar el archivo de inventos a una carpeta de respaldo.
    static void CopiarArchivo()
    {
        Console.WriteLine("   ");  // Añadido un espacio para que el texto no quede pegado al principio de la consola.
        try
        {
            if (File.Exists(archivoInventos))  // Verifico si el archivo existe.
            {
                CrearDirectorio(carpetaBackup);  // Me aseguro de que la carpeta de respaldo exista.
                string archivoDestino = Path.Combine(carpetaBackup, "inventos_backup.txt");  // Defino la ruta del archivo de respaldo.
                File.Copy(archivoInventos, archivoDestino, true);  // Copio el archivo.
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
            Console.WriteLine($"Error al copiar el archivo: {ex.Message}");  // Manejo cualquier error al copiar el archivo.
            Console.WriteLine("--------------------------------------------");
        }
    }

    // Función para mover el archivo a otra carpeta.
    static void MoverArchivo()
    {
        Console.WriteLine("   ");  // Añadido un espacio para que el texto no quede pegado al principio de la consola.
        try
        {
            if (File.Exists(archivoInventos))  // Verifico si el archivo existe.
            {
                CrearDirectorio(carpetaArchivosClasificados);  // Me aseguro de que la carpeta de archivos clasificados exista.
                string archivoDestino = Path.Combine(carpetaArchivosClasificados, "inventos.txt");  // Defino la ruta del archivo destino.
                File.Move(archivoInventos, archivoDestino);  // Muevo el archivo.
                archivoInventos = archivoDestino;  // Actualizo la ruta del archivo inventos.
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
            Console.WriteLine($"Error al mover el archivo: {ex.Message}");  // Manejo cualquier error al mover el archivo.
            Console.WriteLine("--------------------------------------------");
        }
    }

    // Función para crear una nueva carpeta en el directorio base.
    static void CrearCarpeta()
    {
        Console.WriteLine("   ");  // Añadido un espacio para que el texto no quede pegado al principio de la consola.
        Console.Write("Ingrese el nombre de la carpeta: ");  // Pido el nombre de la carpeta.
        string nombreCarpeta = Console.ReadLine();  // Leo el nombre de la carpeta ingresado por el usuario.
        string rutaCarpeta = Path.Combine(directorioBase, nombreCarpeta);  // Defino la ruta de la carpeta a crear.

        try
        {
            if (!Directory.Exists(rutaCarpeta))  // Verifico si la carpeta ya existe.
            {
                Directory.CreateDirectory(rutaCarpeta);  // Si no existe, la creo.
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
            Console.WriteLine($"Error al crear la carpeta: {ex.Message}");  // Manejo cualquier error al crear la carpeta.
            Console.WriteLine("--------------------------------------------");
        }
    }

    // Función para verificar si el archivo inventos.txt existe.
    static void VerificarExistenciaArchivo()
    {
        Console.WriteLine("   ");  // Añadido un espacio para que el texto no quede pegado al principio de la consola.
        if (File.Exists(archivoInventos))  // Verifico si el archivo existe.
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

    // Función para eliminar el archivo inventos.txt.
    static void EliminarArchivo()
    {
        Console.WriteLine("   ");  // Añadido un espacio para que el texto no quede pegado al principio de la consola.
        try
        {
            if (File.Exists(archivoInventos))  // Verifico si el archivo existe.
            {
                File.Delete(archivoInventos);  // Elimino el archivo.
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
            Console.WriteLine($"Error al eliminar el archivo: {ex.Message}");  // Manejo cualquier error al eliminar el archivo.
            Console.WriteLine("--------------------------------------------");
        }
    }

    // Función para listar todos los archivos en el directorio base.
    static void ListarArchivos()
    {
        Console.WriteLine("   ");  // Añadido un espacio para que el texto no quede pegado al principio de la consola.
        try
        {
            if (Directory.Exists(directorioBase))  // Verifico si el directorio base existe.
            {
                var archivos = Directory.GetFiles(directorioBase);  // Obtengo todos los archivos del directorio base.
                Console.WriteLine("Archivos en 'LaboratorioAvengers':");
                Console.WriteLine("--------------------------------------------");
                foreach (var archivo in archivos)  // Recorro y muestro los archivos.
                {
                    Console.WriteLine(Path.GetFileName(archivo));  // Muestra solo el nombre del archivo.
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
            Console.WriteLine($"Error al listar los archivos: {ex.Message}");  // Manejo cualquier error al listar los archivos.
            Console.WriteLine("--------------------------------------------");
        }
    }

    // Función para crear un directorio si no existe.
    static void CrearDirectorio(string ruta)
    {
        if (!Directory.Exists(ruta))  // Verifico si el directorio ya existe.
        {
            Directory.CreateDirectory(ruta);  // Si no existe, lo creo.
        }
    }
}
