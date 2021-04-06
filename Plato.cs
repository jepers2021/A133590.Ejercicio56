using System;
using System.Collections.Generic;
using System.Text;

namespace A133590.Ejercicio56
{
    class Plato
    {
        string nombre;
        int cargaCalorica;

        public Plato(string nombre, int cargaCalorica)
        {
            this.nombre = nombre;
            this.cargaCalorica = cargaCalorica;
        }

        public string Nombre { get => nombre; }
        public int CargaCalorica { get => cargaCalorica; }
    }
}
