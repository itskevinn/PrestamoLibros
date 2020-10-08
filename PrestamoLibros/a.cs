using System;
using System.Collections.Generic;

namespace PrestamoLibros
{
    class Programa
    {
        static List<Socio> socios = new List<Socio>();
        static List<Libro> libros = new List<Libro>();

        static void Ola(string[] args)
        {
            Socio socio;
            int tipoOp;
            string continuar;
            int id;
            Console.WriteLine("Digite su número de identificación");
            id = Convert.ToInt32(Console.ReadLine());
            socio = socios.Find(s => s.Id == id);
            if (socio == null)
            {
                //TODO
            }
            else
            {
                if (!socio.Multa)
                {
                    Libro libro = new Libro();

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Seleccione el tipo de libro a solicitar");
                        Console.WriteLine("1. Novedad");
                        Console.WriteLine("2. Ordinario");
                        Console.WriteLine("3. Recoger reserva");
                        Console.WriteLine("4. Salir");
                        tipoOp = Convert.ToInt32(Console.ReadLine());
                        string opt = null;

                        switch (tipoOp)
                        {
                            case 1:
                                do
                                {
                                    int cod;
                                    Console.WriteLine("Digite el código del libro");
                                    cod = Convert.ToInt32(Console.ReadLine());
                                    libro = libros.Find(l => l.Id == cod);
                                    if (libro != null)
                                    {
                                        if (libro.Estado == "Disponible")
                                        {
                                            if (libro.Tipo.ToLower() == "novedad")
                                            {
                                                //TODO
                                            }
                                            else Console.WriteLine("Este libro no es una novedad");
                                        }
                                        else Console.WriteLine("¡Este libro no está disponible!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("¡Este libro no existe!");
                                    }
                                    Console.WriteLine("¿Desea continuar añadiendo novedades? S/N");
                                    opt = Console.ReadLine();
                                } while (opt.ToUpper() == "S");
                                tipoOp = 5;
                                break;
                            case 2:
                                do
                                {
                                    int cod;
                                    Console.WriteLine("Digite el código del libro");
                                    cod = Convert.ToInt32(Console.ReadLine());
                                    libro = libros.Find(l => l.Id == cod);
                                    if (libro != null)
                                    {
                                        if (libro.Estado == "Disponible")
                                        {
                                            if (libro.Tipo.ToLower() == "novedad")
                                            {
                                                //TODO
                                            }
                                            else Console.WriteLine("Este libro no es ordinario");
                                        }
                                        else Console.WriteLine("¡Este libro no está disponible!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("¡Este libro no existe!");
                                    }
                                    Console.WriteLine("¿Desea continuar añadiendo ordinarios? S/N");
                                    opt = Console.ReadLine();
                                } while (opt.ToUpper() == "S");
                                tipoOp = 5;
                                break;
                            case 3:
                                opt = "N";
                                do
                                {
                                    int cod;
                                    cod = Convert.ToInt32(Console.ReadLine());
                                    foreach (var _libro in libros)
                                    {
                                        if (_libro.Id.Equals(cod))
                                        {
                                            libro = _libro;
                                        }
                                    }
                                    if (libro != null)
                                    {
                                        if (libro.Estado.ToLower() == "reservado")
                                        {
                                            //TODO

                                        }
                                        else
                                        {
                                            //TODO
                                        }
                                    }
                                    else
                                    {
                                        //TODO
                                    }
                                } while (opt.ToUpper() == "S");
                                break;
                            case 4:
                                break;
                        }
                        if (tipoOp == 5)
                        {
                            //TODO
                            foreach (var prestamo in socio.Prestamos)
                            {
                                foreach (var _libro in prestamo.Libros)
                                {
                                    Console.WriteLine("ID del libro: " + _libro.Id + " - Fecha de devolución:   " + prestamo.FechaDevolucion.ToString("dd/MM/yyyy") + "\n");
                                }
                            }
                            break;
                        }
                    }
                    while (tipoOp > 5);
                }
                else
                {
                    string pagoOpt;
                    Console.WriteLine("Usted no puede prestar libros, tiene multas pendientes");
                    Console.WriteLine("¿Desea pagar? S/N");
                    pagoOpt = Console.ReadLine();
                    if (pagoOpt.ToLower() == "s")
                    {
                        socio.Multa = false;
                    }
                    else socio.Multa = true;
                    Console.ReadLine();
                    return;
                }

            }
        }


        public class Socio
        {
            public Socio()
            {
                Prestamos = new List<Prestamo>();
            }
            public int Id { get; set; }
            public bool Multa { get; set; }
            public List<Prestamo> Prestamos { get; set; }
        }
        public class Prestamo
        {
            public Prestamo()
            {
                Libros = new List<Libro>();
            }
            public List<Libro> Libros { get; set; }
            public DateTime FechaPrestamo { get; set; }
            public DateTime FechaDevolucion { get; set; }
        }
        public class Libro
        {
            public int Id { get; set; }
            public string Tipo { get; set; }
            public string Estado { get; set; }
        }
    }
}
