using System;
using System.Collections.Generic;
using System.Text;

namespace A133590.Ejercicio56
{
    class Dieta
    {
        Dictionary<string,Plato> platos;
        string nombre;
        int cargaCaloricaTotal;

        public Dieta(string nombre)
        {
            cargaCaloricaTotal = 0;
            platos = new Dictionary<string, Plato>();
            this.nombre = nombre;
        }

        public int CargaCaloricaTotal { get => cargaCaloricaTotal; }
        public string Nombre { get => nombre;  }

        public void AsignarPlato(Plato plato)
        {
            if(platos.ContainsKey(plato.Nombre))
            {
                Console.WriteLine("Plato ya asignado a esta dieta.");
                return;
            }
            platos.Add(plato.Nombre, plato);
            cargaCaloricaTotal += plato.CargaCalorica;
            Console.WriteLine($"Plato: {plato.Nombre} agregado correctamente a Dieta: {this.nombre}");
        }
    }
}
