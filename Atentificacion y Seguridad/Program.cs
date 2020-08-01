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
            String[] nombre= { "Allena Gómez", "Hannah Mejía", "Johnny Ramos", "Jesús Reyes" };
            int[] password = { 1234, 5670, 8901, 1011 };
            String[] rol = { "Supervisor", "Administrador", "Vendedor" , "Vendedor" };
            bool[] estado= { true, true, false, true};

             DateTime fecha1 = new DateTime(2020, 7, 14); DateTime fecha2 = new DateTime(2020, 7, 13);
             DateTime fecha3 = new DateTime(2020, 6, 10);  DateTime fecha4 = new DateTime(2020, 1, 11);

            DateTime[] fecha_de_creacion = { fecha1, fecha2, fecha3, fecha4 };

            Console.ForegroundColor = ConsoleColor.White;            

            Console.WriteLine("\n .............................................");
            Console.WriteLine(" .............................................");
            Console.WriteLine(" ............. SISTEMA DE ACCESO ............. ");
            Console.WriteLine(" .............................................");
            Console.WriteLine(" .............................................");

                              
            string ValidacionU = Autentificar.Validar_Usuario();
            string ValidacionP= Autentificar.Validar_Password();
                       

            while (Autentificar.comprobar(nombre, usuarios, rol, estado, password, ValidacionP, ValidacionU, fecha_de_creacion) == false)
             {
           
             Console.ReadKey();                
             Console.Clear();
             Console.ForegroundColor = ConsoleColor.White;
             Console.WriteLine("\n .............................................");
             Console.WriteLine(" .............................................");
             Console.WriteLine(" ............. SISTEMA DE ACCESO ............. ");
             Console.WriteLine(" .............................................");
             Console.WriteLine(" .............................................");

              ValidacionU=Autentificar.Validar_Usuario();
              ValidacionP = Autentificar.Validar_Password();
            }


        }
    }
}
