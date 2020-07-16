//Jannabel Ramos Ramírez 2019-8510

/*En el siguiente proyecto crearemos una aplicación que pida al usuario su (username y clave). 
    El usuario sera el No. de cedula y la clave debe ser numerica, el sistma no debe permitir que
    el usuario acceda hasta que ponga su autenticacion correcta.

    El sistema debe tener al menos 3 usuarios registrados para validar, y los usuarios 
    al acceder tendran un rol (Supervisor, Administrador, Vendedor). 
    De acuerdo a su rol le mostrara el mensaje al acceder 
    "Acabas de ingresar con el usuario XXXX y su rol es XXXXX."

    Los usuarios algunos tendran un estado de (activo o inactivo) en caso de inactivo 
    sea positivo el usuario no podra acceder, el sistema debe mostrar un mensaje que ese
    usuario esta inactivo y volver a validar otro usuario.

    Datos de usuarios: Nombre, username, clave, rol, fecha de creacion, estado (Activo o inactivo).*/

using System;

namespace Atentificacion_y_Seguridad
{
    class Program
    {

      
        static void Main(string[] args)
        {
            /*
             Usuarios, contraseñas, roles, estado

              (sin guiones para acceder, están automáticos)
             
              User: 00102851605   password: 1234   rol: Supervisor (activo)
              User: 12345678910  password: 5670   rol: Administrador (activo)
              User: 25689741256 password: 8901    rol: Vendedor (inactivo)
              User: 46100000451  password: 1011     rol: Vendedor (activo)       */

                                          
            string[] usuarios = { "001-0285160-5", "123-4567891-0", "256-8974125-6", "461-0000045-1"};
            int[] password = { 1234, 5670, 8901, 1011 };
            String[] rol = { "Supervisor", "Administrador", "Vendedor" , "Vendedor" };
            bool[] estado= { true, true, false, true};

             DateTime fecha1 = new DateTime(2020, 7, 14); DateTime fecha2 = new DateTime(2020, 7, 13);
             DateTime fecha3 = new DateTime(2020, 6, 10);  DateTime fecha4 = new DateTime(2020, 1, 11);

            Console.ForegroundColor = ConsoleColor.White;

            DateTime[] fecha_de_creacion = {fecha1, fecha3, fecha3, fecha4};
            Console.WriteLine("\n .............................................");
            Console.WriteLine(" .............................................");
            Console.WriteLine(" ............. SISTEMA DE ACCESO ............. ");
            Console.WriteLine(" .............................................");
            Console.WriteLine(" .............................................");

            string user= "";

            Console.Write("\n ~ Ingrese su usuario: ");
            do
            {
                ConsoleKeyInfo keyuser = Console.ReadKey(true);

                if (keyuser.Key != ConsoleKey.Backspace && keyuser.Key != ConsoleKey.Enter)
                {
                    if (char.IsNumber(keyuser.KeyChar))
                    {
                        user += keyuser.KeyChar;
                        Console.Write(keyuser.KeyChar);

                        if (user.Length == 3 || user.Length == 11)
                        {
                            user += "-";
                            Console.Write("-");
                        }
                        if (user.Length == 13) break;

                    }
                    else
                    {
                        user = "";
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n ~ ADVERTENCIA: Caracter invalido, solo ingrese numeros (los guiones se ingresan automaticamente) ~");
                        
                        user = "";
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" ~ Ingrese su usuario: ");
                        continue;
                    }

                }
                else
                {
                    if (keyuser.Key == ConsoleKey.Backspace && user.Length > 0)
                    {
                        user = user.Substring(0, (user.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (keyuser.Key == ConsoleKey.Enter && user.Length == 13)
                    {
                        break;
                    }
                }
            } while (true);




            Console.Write("\n ~ Ingrese su clave: ");

            string pass = "";

            
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
               
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    if (char.IsNumber(key.KeyChar))
                    {
                        pass += key.KeyChar;
                        Console.Write("*");
                        if (pass.Length == 4) break;            
                
                    }
                    else
                    {
                        pass = "";
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n ~ ADVERTENCIA: Caracter invalido, solo ingrese numeros ~");                        
                        pass = "";
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" ~ Ingrese su clave: ");
                        continue;
                    }
                 
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                    pass = pass.Substring(0, (pass.Length - 1));
                    Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter && pass.Length == 4)
                    {
                        break;
                    }
                }
            } while (true);

          
            while (Autentificar.comprobar(usuarios, rol, estado, password, pass, user, fecha_de_creacion) == false)
             {
             pass = "";
             user = "";
             Console.ReadKey();                
             Console.Clear();
             Console.ForegroundColor = ConsoleColor.White;
             Console.WriteLine("\n .............................................");
             Console.WriteLine(" .............................................");
             Console.WriteLine(" ............. SISTEMA DE ACCESO ............. ");
             Console.WriteLine(" .............................................");
             Console.WriteLine(" .............................................");
  
                Console.Write("\n ~ Ingrese su usuario: ");
                do
                {
                    ConsoleKeyInfo keyuser = Console.ReadKey(true);

                    if (keyuser.Key != ConsoleKey.Backspace && keyuser.Key != ConsoleKey.Enter)
                    {
                        if (char.IsNumber(keyuser.KeyChar))
                        {
                            user += keyuser.KeyChar;
                            Console.Write(keyuser.KeyChar);

                            if (user.Length == 3 || user.Length == 11)
                            {
                                user += "-";
                                Console.Write("-");
                            }
                            if (user.Length == 13) break;

                        }
                        else
                        {
                            user = "";
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n ~ ADVERTENCIA: Caracter invalido, solo ingrese numeros (los guiones se ingresan automaticamente) ~");
                            user = "";
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" ~ Ingrese su usuario: ");
                            continue;
                        }
                     
                    }
                    else
                    {
                        if (keyuser.Key == ConsoleKey.Backspace && user.Length > 0)
                        {
                            user = user.Substring(0, (user.Length - 1));
                            Console.Write("\b \b");
                        }
                        else if (keyuser.Key == ConsoleKey.Enter && user.Length == 13)
                        {
                            break;
                        }
                    }
                } while (true);




                Console.Write("\n ~ Ingrese su clave: ");


                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        if (char.IsNumber(key.KeyChar))
                        {
                            pass += key.KeyChar;
                            Console.Write("*");
                            if (pass.Length == 4) break;

                        }
                        else
                        {
                            pass = "";
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n ~ ADVERTENCIA: Caracter invalido, solo ingrese numeros ~");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" ~ Ingrese su clave: ");
                            continue;
                        }

                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                        {
                            pass = pass.Substring(0, (pass.Length - 1));
                            Console.Write("\b \b");
                        }
                        else if (key.Key == ConsoleKey.Enter && pass.Length == 4)
                        {
                            break;
                        }
                    }
                } while (true);
            }


        }
    }
}
