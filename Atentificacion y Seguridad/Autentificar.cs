using System;


public class Autentificar
{

     public static bool comprobar(long[] usuarios, string[] rol, bool[] estado, int[] password, string clave, long user, DateTime[] fecha_de_creacion)
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
                Console.WriteLine("\n\n ~ Usuario y/o clave incorrectos ~ ");
                Console.WriteLine();
                return false;
            }
            else if (cont == 1)
            {
                Console.WriteLine("\n\n ~ Acabas de ingresar con el usuario {0} y su rol es {1}", usuarios[i], rol[i]);
                Console.WriteLine(" ~ Este usuario fue creado : {0}", fecha_de_creacion[i]);
                Console.WriteLine();
                return true;
            }

            if (usuarios[i] == user && password[i] == clav && estado[i] == false)
            {
                Console.WriteLine("\n\n  ~ Este usuario esta inactivo ~ ");
                Console.WriteLine();
                return false;
            }
        }
        return true;
    }
}

