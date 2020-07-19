using System;


public class Autentificar
{

     public static bool comprobar(string[]nombre, string[] usuarios, string[] rol, bool[] estado, int[] password, string clave, string user, DateTime[] fecha_de_creacion)
      {
        Int32.TryParse(clave, out int clav);

        int cont = 0;

        for (int i = 0; i < usuarios.Length; i++)
        {
            
            if (usuarios[i] == user && password[i] == clav && estado[i] == true)
            {
                cont++;                
            }

            if (i == usuarios.Length-1 && cont == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n ~ Usuario y/o clave incorrectos ~ ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\n ~ Presione una tecla para continuar y validar otro usuario ");
                return false;
            }
            else if (cont == 1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\n ~ Saludos, {0}.", nombre[i]);
                Console.WriteLine("\n ~ Acaba de ingresar con el USUARIO: {0} y su ROL es: {1}.", usuarios[i], rol[i]);
                Console.WriteLine(" ~ Este usuario fue creado : {0}", fecha_de_creacion[i]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\n ~ Presione ESC o cualquier tecla para salir. ~");
                Console.WriteLine(" ~ Presione S para cerrar sesion e iniciar con otro usuario. ~  ");

                ConsoleKeyInfo keys = Console.ReadKey(true);
                if (keys.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
                else if(keys.Key == ConsoleKey.S)
                {
                    return false;
                }
                else
                {
                    Environment.Exit(0);
                }
            }

            if (usuarios[i] == user && password[i] == clav && estado[i] == false)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\n ~ Este usuario esta inactivo ~ ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\n ~ Presione una tecla para continuar y validar otro usuario ");
                return false;
            }
        }
        return true;
    }

    public static string Validar_Usuario()
    {

        string user = "";
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
                    if (user.Length == 13) 
                        break;

                }
                else
                {
                    user = "";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n ~ ADVERTENCIA: Caracter invalido, solo ingrese numeros (los guiones se ingresan automaticamente) ~");
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
        return user;
    }

    public static string Validar_Password() 
    {
        string pass = "";
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
        return pass;
    }

}

