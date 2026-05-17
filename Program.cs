ConsoleColor colorOriginal = Console.ForegroundColor;

var usuario = "admin";
var contrasena = "123";
var intentos = 3;
string entradaUsuario;

while (intentos > 0) 
{
    Console.WriteLine("===== Registro de estudiantes =====");
    Console.WriteLine("     Ingrese sus credenciales     ");
    Console.WriteLine();

    Console.WriteLine($"Tienes {intentos} intentos");

    Console.Write("Ingresa tu usuario: ");
    var usuarioIngresado = Console.ReadLine();

    Console.Write("Ingresa tu contraseña: ");
    var contrasenaIngresada = Console.ReadLine();

    Console.WriteLine(); //Salto de linea

    if(!string.IsNullOrWhiteSpace(usuarioIngresado)) // Se verifica si usuario ingresado no esta vacio
    {

        if (!string.IsNullOrWhiteSpace(contrasenaIngresada)) // Se verifica si contraseña ingresada no esta vacio
        {

            if (usuarioIngresado.Equals(usuario) && contrasenaIngresada.Equals(contrasena))
            {
                intentos = 3; // Reseteamos la variable

                MostrarMensaje("               ***** BIENVENIDO *****          ", ConsoleColor.DarkBlue);
        
                ////Entramos al menu                
                var opcion = Menu();

                if (opcion == 7)
                {
                    return; // Terminamos el programa
                }
                else if (opcion == 6)
                {
                    continue; // Regresamos al Login
                }

            } 

            else
            {
                MostrarMensaje("Credenciales incorrectas\n", ConsoleColor.Yellow);                
                intentos--;
            }
        }
        else
        {
            MostrarMensaje("La contraseña no puede estar vacia\n", ConsoleColor.Yellow);            
        }
    
    }
    else
    {
        MostrarMensaje("El usuario no puede estar vacio\n", ConsoleColor.Yellow);        
    }

}

if(intentos.Equals(0)) // Si se usaron todos los intentos, el sistema se bloquea
{
    MostrarMensaje("Demasiados intentos. Sistema bloqueado.", ConsoleColor.Red);    
    return;
}



// FUNCIONES
int Menu()
{
    var menu = "\n========= SISTEMA DE REGISTRO DE ESTUDIANTES =========\n" +
                            "\n1. Registrar estudiante\r\n2. Mostrar estudiantes\r\n3. Buscar estudiante\r\n4. Mostrar promedio\r\n5. Mostrar aprobados y reprobados\r\n6. Cerrar sesion\r\n7. Salir" +
                            "\n\nSeleccione una opción: ";

    // Menu principal
    var opcion = 0;

    // Variables para los datos
    var cantidadEstudiantes = 0;
    string[] nombres = new string[100];
    int[] edades = new int[100];
    double[] notas = new double[100];

    do
    {
        Console.Write(menu); //Imprimimos menu

        if (!int.TryParse(Console.ReadLine(), out opcion)) // Verificamos la entrada del usuario
        {
            MostrarMensaje("\nIngrese un numero como opcion", ConsoleColor.Yellow);
            continue;
        }

        switch (opcion) // Evaluamos las opciones
        {
            case 1: //  REGISTRAMOS AL ESTUDIANTE

                RegistroEstudiante(ref cantidadEstudiantes,  nombres,  notas,  edades);
                break;

            case 2: // Mostramos los estudiantes registrados

                MostrarEstudiantes(cantidadEstudiantes, nombres, notas, edades);               
                break;

            case 3: //Buscar estudiante

                BuscarEstudiante(cantidadEstudiantes, nombres, notas, edades);
                break;

            case 4: //PROMEDIO GENERAL DE NOTAS
                
                PromedioGeneralNotas(cantidadEstudiantes, notas);                
                break;
            case 5:

                MostrarAprobadosReprobados(cantidadEstudiantes, notas);
                break;

            case 6:

                Console.WriteLine("CERRANDO SESION");
                break;

            case 7:

                MostrarMensaje("\nAdios", ConsoleColor.Yellow);
                break;

            default:
                MostrarMensaje("\nIngrese una opcion valida", ConsoleColor.Yellow);                
                break;
        } 

    } while (opcion != 6 && opcion != 7); // Si el usuario ingresa 6 o 7, el ciclo termina

    return opcion;
}


//case 1
void RegistroEstudiante(ref int cantidadEstudiantes, string[] nombres, double[] notas, int[] edades)
{
    while (true)
    {
        Console.Write("\nIngresa el nombre del estudiante: ");
        var nombreEstudiante = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nombreEstudiante))
        {
            MostrarMensaje("\nEl nombre no puede estar vacio", ConsoleColor.Yellow);
        }
        else
        {
            nombres[cantidadEstudiantes] = nombreEstudiante;
            break;
        }
    }

    while (true) // Mientras la edad no sea valida, seguimos pidiendo la edad
    {
        Console.Write("\nIngresa la edad del estudiante: ");

        entradaUsuario = Console.ReadLine();

        if (int.TryParse(entradaUsuario, out int edadEstudiante)) //Validamos si es un numero
        {
            var edadValida = edadEstudiante > 0 && edadEstudiante <= 100;

            if (edadValida)
            {
                edades[cantidadEstudiantes] = edadEstudiante;
                break;
            }
            else
            {
                MostrarMensaje("\nIngresa una edad válida", ConsoleColor.Yellow);
            }
        }
        else if (string.IsNullOrWhiteSpace(entradaUsuario)) //Validamos si la entrada esta vacia
        {
            MostrarMensaje("\nLa edad no puede estar vacia", ConsoleColor.Yellow);
        }
        else
        {
            MostrarMensaje("\nIngresa un numero válido por favor", ConsoleColor.Yellow);
        }

    }

    while (true)
    {
        Console.Write("\nIngresa la nota del estudiante: ");
        entradaUsuario = Console.ReadLine();
        var notaEstudiante = 0D;

        if (double.TryParse(entradaUsuario, out notaEstudiante))
        {
            var rangoValido = notaEstudiante >= 0 && notaEstudiante <= 10;
            if (rangoValido)
            {
                notas[cantidadEstudiantes] = notaEstudiante;
                break;
            }
            else
            {
                MostrarMensaje("\nIngresa un rango válido (0-10)", ConsoleColor.Yellow);
            }
        }
        else if (string.IsNullOrWhiteSpace(entradaUsuario)) //Validamos si la entrada esta vacia
        {
            MostrarMensaje("\nLa nota no puede estar vacia", ConsoleColor.Yellow);
        }
        else
        {
            MostrarMensaje("\nIngresa un numero por favor", ConsoleColor.Yellow);
        }

    }

    Console.WriteLine("\nEstudiante registrado");
    cantidadEstudiantes++;
    
}


// case 2
void MostrarEstudiantes(int cantidadEstudiantes, string[] nombres, double[] notas, int[] edades)
{
    if (cantidadEstudiantes > 0)
    {
        Console.WriteLine("\n---- LISTA ----\n");
        for (int i = 0; i < cantidadEstudiantes; i++)
        {
            Console.WriteLine($"{i + 1}. {nombres[i]} - {edades[i]} años - Nota: {notas[i]}");
        }
    }
    else
    {
        MostrarMensaje("\nNo hay estudiantes registrados", ConsoleColor.Yellow);
    }
}
// case 3
void BuscarEstudiante(int cantidadEstudiantes, string[] nombres, double[] notas, int[] edades)
{
    // ++++
    if (cantidadEstudiantes > 0)
    {
        while (true)
        {
            Console.Write("\nIngresa el nombre del estudiante: ");
            var nombreEstudiante = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(nombreEstudiante))
            {

                var indiceEstudiante = -1;

                for (int i = 0; i < cantidadEstudiantes; i++)
                {
                    // Convertimos ambos a minúsculas para que coincidan siempre
                    if (nombres[i].ToLower().Equals(nombreEstudiante.ToLower()))
                    {
                        indiceEstudiante = i; // Guardamos la posición
                    }
                }


                if (indiceEstudiante > -1)
                {
                    Console.WriteLine("\nEstudiante encontrado:");
                    Console.WriteLine($"Edad: {edades[indiceEstudiante]}" +
                                      $"\nNota: {notas[indiceEstudiante]}");
                    break;
                }
                else
                {
                    Console.WriteLine("\nEstudiante no encontrado");
                    break;
                }
            }
            else
            {
                MostrarMensaje("\nIngresa el nombre por favor", ConsoleColor.Yellow);
            }

        }

    }
    else
    {
        MostrarMensaje("\nNo hay estudiantes registrados para realizar búsqueda", ConsoleColor.Yellow);
    }

   
}


void PromedioGeneralNotas(int cantidadEstudiantes, double[] notas)
{
    if (cantidadEstudiantes > 0)
    {
        var sumaTotalNotas = 0D;

        for (int i = 0; i < cantidadEstudiantes; i++)
        {
            sumaTotalNotas += notas[i];
        }

        var promedioNotas = sumaTotalNotas / cantidadEstudiantes;

        Console.WriteLine($"\nPromedio general: {promedioNotas:F2}");
    }
    else
    {
        MostrarMensaje("\nNo hay estudiantes registrados para mostrar promedio", ConsoleColor.Yellow);
    }
}

void MostrarAprobadosReprobados(int cantidadEstudiantes, double [] notas)
{
    if (cantidadEstudiantes > 0)
    {
        var estudiantesAprobados = 0;
        var estudiantesReprobados = 0;

        for (int i = 0; i < cantidadEstudiantes; i++)
        {
            if (notas[i] >= 6)
            {
                estudiantesAprobados++;
            }
            else
            {
                estudiantesReprobados++;
            }
        }

        Console.WriteLine($"\nEstudiantes aprobados: {estudiantesAprobados}\nEstudiantes reprobados: {estudiantesReprobados}");
    }
    else
    {
        MostrarMensaje("\nNo hay estudiantes registrados para mostrar aprobados y reprobados", ConsoleColor.Yellow);
    }
}

//Funcion para mostrar mensajes en consola
void MostrarMensaje(string texto, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(texto);
    Console.ForegroundColor = colorOriginal;
}

