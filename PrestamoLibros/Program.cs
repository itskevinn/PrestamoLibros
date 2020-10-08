using System;
using System.Collections.Generic;

namespace PrestamoLibros
{
    class Program
    {
        static List<Socio> socios = new List<Socio>();
        static List<Libro> libros = new List<Libro>();

        static void Main(string[] args)
        {
            int id;
            int tipoOp;
            string continuar;
            Socio socio = new Socio();
            socio.Multa = false;
            socio.Prestamos = new List<Prestamo>();
            socio.Id = 12345678;
            socios.Add(socio);
            Libro _libro = new Libro();
            _libro.Id = 123456;
            _libro.Tipo = "Novedad";
            _libro.Estado = "Disponible";
            libros.Add(_libro);
            Libro libro1 = new Libro();
            libro1.Id = 123457;
            libro1.Tipo = "Novedad";
            libro1.Estado = "Disponible";
            libros.Add(libro1);
            Libro libro2 = new Libro();
            libro2.Id = 123458;
            libro2.Tipo = "Novedad";
            libro2.Estado = "Reservado";
            libros.Add(libro2);
            Console.WriteLine("Digite su número de identificación");
            id = Convert.ToInt32(Console.ReadLine());
            socio = socios.Find(s => s.Id == id);
            if (socio != null)
            {
                if (socio.Multa)
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
                do
                {
                    Console.Clear();
                    Console.WriteLine("Seleccione el tipo de libro a solicitar");
                    Console.WriteLine("1. Novedad");
                    Console.WriteLine("2. Ordinario");
                    Console.WriteLine("3. Recoger reserva");
                    Console.WriteLine("4. Salir");
                    tipoOp = Convert.ToInt32(Console.ReadLine());
                    if (tipoOp == 1)
                    {
                        string opt = null;
                        do
                        {
                            int cod;
                            Console.WriteLine("Digite el código del libro");
                            cod = Convert.ToInt32(Console.ReadLine());
                            Libro libro = libros.Find(l => l.Id == cod);
                            if (libro != null)
                            {
                                if (libro.Estado == "Disponible")
                                {
                                    if (libro.Tipo.ToLower() == "novedad")
                                    {
                                        DateTime fecha = DateTime.Today;
                                        Prestamo prestamoNovedad = new Prestamo();
                                        prestamoNovedad.FechaDevolucion = fecha.AddDays(3);
                                        prestamoNovedad.FechaPrestamo = fecha;
                                        libro.Estado = "Prestado";
                                        prestamoNovedad.Libros.Add(libro);
                                        Console.WriteLine("Como es novedad, se debe devoler el " + prestamoNovedad.FechaDevolucion.ToString("dd/MM/yyyy"));
                                        socio.Prestamos.Add(prestamoNovedad);
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
                    }
                    else if (tipoOp == 2)
                    {
                        string opt = null;
                        do
                        {
                            int cod;
                            Console.WriteLine("Digite el código del libro");
                            cod = Convert.ToInt32(Console.ReadLine());
                            Libro libro = libros.Find(l => l.Id == cod);
                            if (libro != null)
                            {
                                if (libro.Estado == "Disponible")
                                {
                                    if (libro.Tipo.ToLower() == "novedad")
                                    {
                                        DateTime fecha = DateTime.Today;
                                        Prestamo prestamoOrdinario = new Prestamo();
                                        prestamoOrdinario.FechaDevolucion = fecha.AddDays(7);
                                        prestamoOrdinario.FechaPrestamo = fecha;
                                        libro.Estado = "Prestado";
                                        prestamoOrdinario.Libros.Add(libro);
                                        Console.WriteLine("Como es ordinario, se debe devoler el " + prestamoOrdinario.FechaDevolucion.ToString("dd/MM/yyyy"));
                                        socio.Prestamos.Add(prestamoOrdinario);
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
                    }
                    if (tipoOp == 3)
                    {
                        string opt = "N";
                        do
                        {
                            int cod;
                            Console.WriteLine("Digite el código del libro");
                            cod = Convert.ToInt32(Console.ReadLine());
                            Libro libro = libros.Find(l => l.Id == cod);
                            if (libro != null)
                            {
                                if (libro.Estado.ToLower() == "reservado")
                                {
                                    string recOpt;
                                    Console.WriteLine("¿Desea recoger el libro? S/N");
                                    recOpt = Console.ReadLine();
                                    if (recOpt.ToLower() == "s")
                                    {
                                        Libro __libro = libros.Find(l => l.Estado.ToLower().Equals("reservado"));
                                        __libro.Estado = "Prestado";
                                        libros.Remove(__libro);
                                        libros.Add(__libro);
                                        Console.WriteLine("Libro recogido!");
                                        Console.ReadKey();
                                    }
                                    else opt = "N";
                                }
                                else
                                {
                                    Console.WriteLine("¡Este libro no está reservado!");
                                    opt = "N";
                                }
                            }
                            else
                            {
                                Console.WriteLine("¡Este libro no existe!");
                                opt = "N";
                            }
                        } while (opt.ToUpper() == "S");
                    }
                    if (tipoOp == 4)
                    {
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    if (tipoOp == 5)
                    {
                        Console.WriteLine("Socio de ID: " + socio.Id);
                        Console.WriteLine("Usted prestó los siguientes libros: \n");
                        foreach (var prestamo in socio.Prestamos)
                        {
                            foreach (var libro in prestamo.Libros)
                            {
                                Console.WriteLine("ID del libro: " + libro.Id + " - Fecha de devolución:   " + prestamo.FechaDevolucion.ToString("dd/MM/yyyy") + "\n");
                            }
                        }
                    }
                    Console.WriteLine("¿Desea continuar? S/N");
                    continuar = Console.ReadLine();
                    if (continuar.ToUpper() == "S") tipoOp = 4;
                    Console.ReadKey();
                    Console.Clear();
                }
                while (tipoOp > 3);
            }
            else
                Console.WriteLine("Usted no se encuentra registrado");
            Console.ReadKey();
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
