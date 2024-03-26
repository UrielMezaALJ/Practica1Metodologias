using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Practica1Metodologias
{
    public class Alumno : Persona
    {
        int legajo;
        double promedio;

        public Alumno(int l, double p, string n, int d) : base(n, d)   
        {
            this.legajo = l;
            this.promedio = p;
        }
        
        public int getlegajo()
        {
            return this.legajo;
        }

        public double getpromedio() 
        {
            return this.promedio;
        }

        public override bool sosIgual(IComparable c)
        {
            return this.legajo == ((Alumno)c).getlegajo();
        }
        public override bool sosMenor(IComparable c)
        {
            return legajo > ((Alumno)c).getlegajo();
        }
        public override bool sosMayor(IComparable c)
        {
            return this.legajo < ((Alumno)c).getlegajo();
        }

        public override string ToString()
        {
            return this.getNombre() + " " + legajo.ToString();
        }
    }
}
