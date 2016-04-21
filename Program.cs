using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Staff
{
    class Employee
    {
        private string firstname;
        private string lastname;
        private int age;
        private double salary;
        private const double min_salary = 1000;
        public string Firstname
        {
            get               // Прочитать имя
            {
                return firstname;
            }
            set              // Записать имя
            {
                if (value != "")
                   firstname = value;
            }
        }
        public string Lastname
        {
            get               // Прочитать фамилию
            {
                return lastname;
            }
            set              // Записать фамилию
            {
                if (value != "")
                    lastname = value;
            }
        }
        public int Age
        {
            get               // Прочитать возраст
            {
                return age;
            }
            set              // Записать возраст
            {
                if (value != 0)
                    age = value;
            }
        }
        public double Salary
        {
            get               // Прочитать размер оклада
            {
                return salary;
            }
            set              // Записать размер оклада
            {
                if (value > min_salary)
                    salary = value;
            }
        }
    }	

    class Program
    {  
        static Employee [] staff = new Employee[10];    // Массив записей о сотрудниках
    
        static void Main(string[] args)
        {
            ConsoleKey k = ConsoleKey.Enter;
            int n = 0;                                  // Текущая длина массива записей о сотрудниках
            Console.WriteLine("Введите данные о первом сотруднике.\nДля продолжения ввода нажимайте Enter, для завершения - Esc");
            do		                                    // Формирование массива записей о сотрудниках 
            {
                Employee p = new Employee ();
                Console.WriteLine();
                if (k != ConsoleKey.Enter)
                        Console.WriteLine("Повторите ввод фамилии сотрудника");
                p.Firstname = Console.ReadLine();
                p.Lastname = Console.ReadLine();
                p.Age = Int32.Parse(Console.ReadLine());
	  	        p.Salary = Double.Parse(Console.ReadLine());
                add(p,n++); 
                Console.Write("Ent/Esc>");
                k = Console.ReadKey().Key;
            }
            while (k != ConsoleKey.Escape) ;

	        print();	// Вывод списка сотрудников
	        Console.Write("\nВведите фамилию для поиска> ");
            if (staff[search(Console.ReadLine())] != null)		// Поиск в списке сотрудников
		        Console.WriteLine("Такой сотрудник есть в штате\n");
	        else
		        Console.WriteLine("Такого сотрудника нет в штате\n");
	        Console.Read();
	    }

        static int add (Employee p, int i)	            // Добавить запись о сотруднике
        {
	        if (i < staff.Length) 
	        { 
		        staff[i] = p;
		        return i;
	        }
	        else
		        return -1;
        } // add

        static void print()		                        // Показать список сотрудников 
        {
	        int i = 0;
            Console.WriteLine();
	        while (i < staff.Length && staff[i] != null)
	        {
		        Console.Write("{0} ",staff[i].Firstname); 
		        Console.Write("{0} ",staff[i].Lastname); 
		        Console.Write("{0} ",staff[i].Age);
		        Console.WriteLine("{0}",staff[i].Salary);
                i++;
	        }
        }   // print

        static int search(string key)                                    // Поиск записи с заданной фамилией 
        {
	        int i = 0;
            while (staff[i] != null  && key != staff[i].Lastname) ++i;
	        return i;
        }
    }

  }


	
    


