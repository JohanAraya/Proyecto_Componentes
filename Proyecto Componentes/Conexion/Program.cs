// See https://aka.ms/new-console-template for more information
using Datos.Contextos;

Console.WriteLine("Hello, World!");
Conexion db = new Conexion();
db.Database.EnsureCreated();
Console.WriteLine("Listo");
Console.ReadKey();
