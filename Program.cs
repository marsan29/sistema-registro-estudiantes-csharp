
ConsoleColor colorOriginal = Console.ForegroundColor;

var usuario = "admin";
var contrasena = "123";
var intentos = 3;
string entradaUsuario;

while (intentos > 0) //
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
                Console.ForegroundColor = ConsoleColor.DarkBlue;

                //Entramos al menu
                Console.WriteLine("               ***** BIENVENIDO *****          ");
                Console.ForegroundColor = colorOriginal;

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
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nIngrese un numero como opcion");
                        Console.ForegroundColor = colorOriginal;
                        continue;
                    }

                    //Console.WriteLine(); //Salto de linea

                    switch (opcion) // Evaluamos las opciones
                    {
                        case 1: //  REGISTRAMOS AL ESTUDIANTE

                            while (true)
                            {
                                Console.Write("\nIngresa el nombre del estudiante: ");
                                var nombreEstudiante = Console.ReadLine();

                                if (string.IsNullOrWhiteSpace(nombreEstudiante))
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\nEl nombre no puede estar vacio");
                                    Console.ForegroundColor = colorOriginal;

                                }
                                else
                                {
                                    nombres[cantidadEstudiantes] = nombreEstudiante;
                                    break;
                                }
                            }
                            Console.WriteLine();
                            
                            while (true) // Mientras la edad no sea valida, seguimos pidiendo la edad
                            {
                                Console.Write("Ingresa la edad del estudiante: ");

                                entradaUsuario = Console.ReadLine();

                                if(int.TryParse(entradaUsuario, out int edadEstudiante)) //Validamos si es un numero
                                {
                                    var edadValida = edadEstudiante > 0 && edadEstudiante <= 100;

                                    if (edadValida)
                                    {
                                        edades[cantidadEstudiantes] = edadEstudiante;
                                        break;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\nIngresa una edad válida\n");
                                        Console.ForegroundColor = colorOriginal;
                                    }
                                }
                                else if (string.IsNullOrWhiteSpace(entradaUsuario)) //Validamos si la entrada esta vacia
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\nLa edad no puede estar vacia\n");
                                    Console.ForegroundColor = colorOriginal;

                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\nIngresa un numero válido por favor\n");
                                    Console.ForegroundColor = colorOriginal;
                                }
                                                                   
                            }
                    

                            Console.WriteLine();

                            while (true)
                            {
                                Console.Write("Ingresa la nota del estudiante: ");
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
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\nIngresa un rango válido (0-10)\n");
                                        Console.ForegroundColor = colorOriginal;

                                    }
                                }
                                else if (string.IsNullOrWhiteSpace(entradaUsuario)) //Validamos si la entrada esta vacia
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\nLa nota no puede estar vacia\n");
                                    Console.ForegroundColor = colorOriginal;

                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\nIngresa un numero por favor\n");
                                    Console.ForegroundColor = colorOriginal;
                                }

                            }

                            Console.WriteLine("\nEstudiante registrado");
                            cantidadEstudiantes++;

                            break;

                        
                        case 2: // Mostramos los estudiantes registrados
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
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\nNo hay estudiantes registrados");
                                Console.ForegroundColor = colorOriginal;
                            }

                            break;

                        case 3: 

                            if(cantidadEstudiantes > 0)
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
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\nIngresa el nombre por favor");
                                        Console.ForegroundColor = colorOriginal;
                                    }
                                    
                                }
                               
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\nNo hay estudiantes registrados para realizar búsqueda");
                                Console.ForegroundColor = colorOriginal;
                            }
                            break;

                        case 4://PROMEDIO GENERAL DE NOTAS

                            if(cantidadEstudiantes > 0)
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
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\nNo hay estudiantes registrados para mostrar promedio");
                                Console.ForegroundColor = colorOriginal;
                            }

                            break;
                        case 5:
                            
                            if(cantidadEstudiantes > 0)
                            {
                                var estudiantesAprobados = 0;
                                var estudiantesReprobados = 0;
                              
                                for(int i = 0; i < cantidadEstudiantes; i++)
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
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\nNo hay estudiantes registrados para mostrar aprobados y reprobados");
                                Console.ForegroundColor = colorOriginal;

                            }

                            break;
                        case 6:
                            Console.WriteLine("CERRANDO SESION");
                            break;
                        case 7:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nAdios \n");
                            Console.ForegroundColor = colorOriginal;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nIngrese una opcion valida");
                            Console.ForegroundColor = colorOriginal;
                            break;
                    } //Termina Switch

                } while (opcion == 6 || opcion == 7 ? false : true); // Si el usuario ingresa 6 o 7, el ciclo termina

                if (opcion == 7) 
                {             
                    return; // Terminamos el programa
                }
                else if (opcion == 6)
                {
                    continue;
                }// Regresamos al Login
                    ;
                }

            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Credenciales incorrectas\n");
                Console.ForegroundColor = colorOriginal;
                intentos--;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("La contraseña no puede estar vacia\n");
            Console.ForegroundColor = colorOriginal;
        }
    
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("El usuario no puede estar vacio\n");
        Console.ForegroundColor = colorOriginal;
    }

}

if(intentos.Equals(0)) // Si se usaron todos los intentos, es sistema de bloquea
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\nDemasiados intentos. Sistema bloqueado.");
    Console.ForegroundColor = colorOriginal;

    return;
}




