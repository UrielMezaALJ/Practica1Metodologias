using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Practica1Metodologias
{
    //10: Tuve que agregar un getElementos de la lista en las clases Pila y Cola para poder usarlas en el método "contiene" de la clase ColeccionMultiple.

    //17: Funciona porque Alumno se compara igual que su clase padre Persona, es decir por DNI. No tiene que implementar la interface IComparable, porque ya es "hijo" de un comparable por lo que también es IComparable.

    //19: Considero que si se podría haber echo sin usar interfaces pero esto supondría de más tiempo y recursos. Además, ´no sería flexible en caso de querer comparar otro tipo de objetos.
    public class Program
    {
        static void Main(string[] args)
        {
            
            Pila pila1 = new Pila();
            Cola cola1 = new Cola();
            ColeccionableMultiple cm = new ColeccionableMultiple(pila1, cola1);

            llenarAlumnos(cola1);
            llenarAlumnos(pila1);

            Console.WriteLine("Por el momento, sólo estamos trabajando con alumnos.\n");   
            informar(cm);

        }

        //EJERCICIO 5
        public static void llenar(IColeccionable c)
        {
            Random r = new Random();
        
            for (int i = 1; i<=20; i++)
            {
                c.agregar(new Numero(r.Next(1, 50)));
            }
        }

        //EJERCICIO 6
        public static void informar(IColeccionable c)
        {
            Console.WriteLine($"El coleccionable contiene {c.cuantos()} alumnos.");
            Console.WriteLine($"El alumno más antiguo es: {c.maximo()}");
            Console.WriteLine($"El alumno más nuevo es: {c.minimo()}");
            Console.WriteLine("1. Buscar Alumno (a).\n2. Buscar numero (n)");
            string opcion = Console.ReadLine();

            if(opcion == "a")
            {
                Console.WriteLine("legajo:");
                int legajo = int.Parse(Console.ReadLine());
                Alumno pBuscada = new Alumno(legajo, 0, "", 0);
                if (c.contiene(pBuscada))
                {
                    Console.WriteLine($"La persona de Legajo ({legajo}) está.");
                }

                else Console.WriteLine($"La persona de legajo ({legajo}) no está.");
            }

            else if (opcion == "n")
            {
                Console.WriteLine("Número:");    
                Numero buscado = new Numero(int.Parse(Console.ReadLine()));
                if (c.contiene(buscado))
                {
                    Console.WriteLine($"El elemento ({buscado.ToString()}) está en la colección.");
                }

                else Console.WriteLine($"El elemento ({buscado.ToString()}) no está en la colección.");
            }
            
        }

        public static void llenarPersonas(IColeccionable c)
        {
            Random r = new Random();
            List<string> nombres = new List<string> { "Juan", "Ana", "Carlos", "Maria", "Pedro", "Lucia" };

            for(int i = 1; i<=7; i++)
            {
                Persona p = new Persona(nombres[r.Next(nombres.Count)], r.Next(40000000, 45000000));
                c.agregar(p);
            }
        }

        public static void llenarAlumnos(IColeccionable c)
        {
            Random r = new Random();
            List<string> nombres = new List<string> { "Pepe", "Azul", "Uriel", "Marta", "Juliana", "Lucia", "Nahuel", "Nicolas", "Matias", "Mara", "Sofia", "Marina", "Yanina", "Marcela", "Adrian", "Antonela", "Hector", "Lucas", "Santiago", "Alejandro" };

            for (int i = 1; i <= 20; i++)
            {
                IComparable a = new Alumno(r.Next(70000, 75000), r.NextDouble() * 10, nombres[r.Next(nombres.Count)], r.Next(40000000, 45000000));
                c.agregar(a);
            }

        }
        
    }
}
