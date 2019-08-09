using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace ConsoleApp1
{
    class prog
    {
        [STAThread]
        public static void Main()
        {
            Window win = new Window();
            win.Title = "Бросок тела";
            win.Show;
            Application app = new Application();
            app.Run();

        }
        public static void Main(string[] arg)
        {
            string[] znach= File.ReadAllLines("C:\\Users\\Lenovo\\Desktop\\файл\\значения.txt"); //Записываем построчно значения из файлов в массив
            double x0 = Convert.ToDouble(znach[0]); //т.к. значения которые считывали были string, то переводим в double
            double a = Convert.ToDouble(znach[1]);
            double v = Convert.ToDouble(znach[2]);
            double dt = Convert.ToDouble(znach[3]);
            //Console.Write("Введите x0 ");
            //double x0 = Convert.ToDouble(Console.ReadLine());
            //Console.Write("\nВведите угол броска ");
            //double a = Convert.ToDouble(Console.ReadLine());
            //Console.Write("\nВведите скорость ");
            //double v = Convert.ToDouble(Console.ReadLine());
            //Console.Write("\nВведите интервал dt ");
            //double dt = Convert.ToDouble(Console.ReadLine());
            a = a * 3.14 / 180;  
            double t = 2 * v * Math.Sin(a) / 9.8;
            //Console.Write($"\nВремя полёта {t}");
            File.WriteAllText("C:\\Users\\Lenovo\\Desktop\\файл\\test.txt", $"\nВремя полёта:{t}, Угол: {a}, Начальная cкорость {v}, Интервал времени {dt}"); //Создаём файл или перезаписываем файл с начальными условиями
            double x = 0;
            double y = 0;
            
            for (double t1 = 0; t1 <= t; t1 += dt)
            {
                x = x0 + v * Math.Cos(a) * t1;
                y = v * Math.Sin(a) * t1 - (9.8 * Math.Pow(t1, 2) / 2);
                File.AppendAllText("C:\\Users\\Lenovo\\Desktop\\файл\\test.txt", $"\nx={x},y={y},Время полёта:{t1}"); //Записываем координаты и время путём добавления текста к файлу
                Console.WriteLine($"\nx= {x},y= {y}, Время полёта: {t1}");
            }
            Console.ReadKey();
        }
    }
}