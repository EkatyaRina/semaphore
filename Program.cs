using System;
using System.Threading;

namespace SemaphoreApp
{
    class Program
    {        
        static void Main(string[] args)
        {
            for (int i = 1; i <= 7; i++)
            {
                Animal animal = new Animal(i);                
            }
            Console.ReadLine();            
        }
    }
    class Animal
    {
        // создаем семафор
        static Semaphore sem = new Semaphore(3, 3);
        Thread myThread;


        public Animal(int i)
        {
            myThread = new Thread(AnimalEat);
            myThread.Name = $"животное {i.ToString()}";
            myThread.Start();            
                      
        } 


        public void AnimalEat()
        {

                sem.WaitOne();

                Console.WriteLine($"{Thread.CurrentThread.Name} на поле");

                Console.WriteLine($"{Thread.CurrentThread.Name} ест");
            Thread.Sleep(1000);
            for (int i = 0; i <=3; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} сытo на {i} единиц");
            }
                Thread.Sleep(1000);

                Console.WriteLine($"{Thread.CurrentThread.Name} наелся, ушёл");
            sem.Release();
                  
            Console.WriteLine("end"); //это надо как-то после завершения всех потоков вставить

        }
    }
}

/* using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace SemaphoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 7; i++)
            {
                Animal animal = new Animal(i);
            }
            Console.ReadLine();
        }
        class Animal
        {
            // создаем семафор
            static Semaphore sem = new Semaphore(4, 4);
            Thread myThread;
            public Animal(int i)
            {
                myThread = new Thread(AnimalEat);
                myThread.Name = $"животное {i.ToString()}";
                myThread.Start();
            }

            public void AnimalEat()
            {
                int hungerLevel = 0;

                sem.WaitOne();

                Console.WriteLine($"{Thread.CurrentThread.Name} на поле");
                Console.WriteLine($"{Thread.CurrentThread.Name} ест");

                while (hungerLevel < 3) // Пока животное не насытилось
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} сытo на {hungerLevel} единиц");
                    Thread.Sleep(1000);
                    hungerLevel++;
                }

                Console.WriteLine($"{Thread.CurrentThread.Name} наелся, ушёл");
                sem.Release();
                Console.WriteLine("end");
            }
        }

    }
}
*/
