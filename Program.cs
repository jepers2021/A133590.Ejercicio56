using System;
using System.Collections.Generic;

namespace A133590.Ejercicio56
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 56");
            Dictionary<string, Dieta> dietas = new Dictionary<string, Dieta>();
            Dictionary<string, Plato> platos = new Dictionary<string, Plato>();
            while(true)
            {
                Console.WriteLine("1) Agregar un plato.");
                Console.WriteLine("2) Agregar una dieta.");
                Console.WriteLine("3) Asignar plato a dieta.");
                Console.WriteLine("4) Ver dietas disponibles para un paciente.");
                Console.WriteLine("5) Salir.");
                Console.Write("Ingrese una opcion: ");
                int opcion;
                bool exito = Int32.TryParse(Console.ReadLine(), out opcion);
                Console.Clear();
                switch (opcion)
                {
                    case 1:
                        {
                            Console.Write("Ingrese nombre del plato: ");
                            string nombre = String.Join(" ", Console.ReadLine().Trim().ToLower().Split());
                            while(nombre.Length == 0)
                            {
                                Console.Write("Ingreso inválido, ingrese el nombre del plato: ");
                                nombre = String.Join(" ", Console.ReadLine().Trim().ToLower().Split());
                            }
                            if(platos.ContainsKey(nombre))
                            {
                                Console.WriteLine("Plato ya existente.");
                                continue;
                            }

                            int cargaCalorica;
                            Console.Write("Ingrese la cantidad de calorias de este plato: ");
                            exito = Int32.TryParse(Console.ReadLine(), out cargaCalorica);
                            while(!exito || cargaCalorica <= 0)
                            {
                                Console.Write("Ingreso incorrecto, ingrese la cantidad de calorias de este plato: ");
                                exito = Int32.TryParse(Console.ReadLine(), out cargaCalorica);
                            }

                            platos.Add(nombre, new Plato(nombre, cargaCalorica));
                            Console.WriteLine("Plato agregado exitosamente");
                        }
                        break;

                    case 2:
                        {
                            Console.Write("Ingrese nombre de la dieta: ");
                            string nombre = String.Join(" ", Console.ReadLine().Trim().ToLower().Split());
                            while (nombre.Length == 0)
                            {
                                Console.Write("Ingreso inválido, ingrese el nombre de la dieta: ");
                                nombre = String.Join(" ", Console.ReadLine().Trim().ToLower().Split());
                            }
                            if (dietas.ContainsKey(nombre))
                            {
                                Console.WriteLine("Dieta ya existente.");
                                continue;
                            }

                            dietas.Add(nombre, new Dieta(nombre));
                            Console.WriteLine("Dieta agregada exitosamente");
                        }
                        break;

                    case 3:
                        {
                            Console.Write("Ingrese nombre del plato: ");
                            string nombrePlato = String.Join(" ", Console.ReadLine().Trim().ToLower().Split());
                            while (nombrePlato.Length == 0)
                            {
                                Console.Write("Ingreso inválido, ingrese el nombre del plato: ");
                                nombrePlato = String.Join(" ", Console.ReadLine().Trim().ToLower().Split());
                            }
                            Console.Write("Ingrese nombre de la dieta: ");
                            string nombreDieta = String.Join(" ", Console.ReadLine().Trim().ToLower().Split());
                            while (nombreDieta.Length == 0)
                            {
                                Console.Write("Ingreso inválido, ingrese el nombre del plato: ");
                                nombreDieta = String.Join(" ", Console.ReadLine().Trim().ToLower().Split());
                            }
                            if(platos.ContainsKey(nombrePlato) && dietas.ContainsKey(nombreDieta))
                            {
                                dietas[nombreDieta].AsignarPlato(platos[nombrePlato]);
                            }
                            else
                            {
                                Console.WriteLine("Ha ocurrido un error. Dieta o plato no existente.");
                            }

                        }
                        break;

                    case 4:
                        {
                            Console.Write("Ingrese sexo del paciente (H/M): ");
                            string sexo = Console.ReadLine();
                            exito = sexo.Equals("H", StringComparison.InvariantCultureIgnoreCase) || sexo.Equals("M", StringComparison.InvariantCultureIgnoreCase);
                            while(!exito)
                            {
                                Console.Write("Ingreso incorrecto, ingrese sexo del paciente (H/M): ");
                                sexo = Console.ReadLine();
                                exito = sexo.Equals("H", StringComparison.InvariantCultureIgnoreCase) || sexo.Equals("M", StringComparison.InvariantCultureIgnoreCase);
                            }
                            
                            
                            bool esMujer = sexo.Equals("M", StringComparison.InvariantCultureIgnoreCase);
                            Console.Write("Ingrese peso del paciente: ");
                            int peso;
                            exito = Int32.TryParse(Console.ReadLine(), out peso);
                            while (!exito || peso <= 0)
                            {
                                Console.Write("Ingreso incorrecto, ingrese peso del paciente: ");
                                exito = Int32.TryParse(Console.ReadLine(), out peso);
                            }
                            int minimasCalorias = peso * (esMujer ? 20 : 22);
                            int maximasCalorias = minimasCalorias + minimasCalorias / 2;
                            bool encontrado = false;
                            Console.WriteLine("Dietas recomendadas: ");
                            foreach(string dieta in dietas.Keys)
                            {
                                if(dietas[dieta].CargaCaloricaTotal >= minimasCalorias && dietas[dieta].CargaCaloricaTotal <= maximasCalorias)
                                {
                                    encontrado = true;
                                    Console.WriteLine($"    -{dietas[dieta].Nombre}");
                                }
                            }
                            if(!encontrado)
                            {
                                Console.WriteLine("Ninguna, no hay dietas disponibles para los datos ingresados.");
                            }
                        }
                        break;

                    case 5:

                        Console.WriteLine("Presione cualquier tecla para continuar..");
                        Console.ReadKey();
                        return;

                }

            }
        }
    }
}
