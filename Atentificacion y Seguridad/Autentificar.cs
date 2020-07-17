using System;


public class Autentificar
{

     public static bool comprobar(string[] usuarios, string[] rol, bool[] estado, int[] password, string clave, string user, DateTime[] fecha_de_creacion)
      {

        int clav=0;
        Int32.TryParse(clave, out clav);
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
                Console.WriteLine();
                return false;
            }
            else if (cont == 1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\n ~ Acaba de ingresar con el USUARIO: {0} y su ROL es: {1}.", usuarios[i], rol[i]);
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
                Console.WriteLine();
                return false;
            }
        }
        return true;
    }
}

