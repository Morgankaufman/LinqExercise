using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */
            

            //DONE: Print the Sum of numbers
            Console.WriteLine(numbers.Sum());

            //DONE: Print the Average of numbers
            Console.WriteLine(numbers.Average());

            Console.WriteLine();
            Console.WriteLine("Ascending Order");

            //DONE: Order numbers in ascending order and print to the console
            var ascOrder = numbers.OrderBy(x => x);

            foreach(var number in ascOrder)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("Descending order");

            //DONE: Order numbers in descending order and print to the console
            var descOrder = numbers.OrderBy(x => x);

            foreach(var number in descOrder)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("Numbers greater than 6");


            //DONE: Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(num => num > 6);

            foreach( var number in greaterThanSix)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("Four numbers out of ascending order.");

            //DONE: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!

            foreach (var number in ascOrder.Take(4))
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("Changing index four to my age.");
            //DONE: Change the value at index 4 to your age, then print the numbers in descending order
            numbers.SetValue(30, 4);

            var descWithAge = numbers.OrderByDescending(num => num);

            foreach(var number in descWithAge)
            {
                Console.WriteLine(number);
            }
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //DONE: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var filter = employees.Where(person => person.FirstName.ToLower().StartsWith('c') || person.FirstName.ToLower()[0] == 's')
                .OrderBy(person => person.FirstName);

            var secondFilter = employees.FindAll(name => name.FirstName.ToLower()[0] == 'c' || name.FirstName.ToLower()[0] == 's')
                .OrderBy(name => name.FirstName);
            
            foreach(var person in filter)
            {
                Console.WriteLine(person.FullName);
            }

            Console.WriteLine("################");

            //DONE: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var twentySix = employees.Where(x => x.Age > 26).OrderByDescending(x => x.Age).ThenBy(x => x.FirstName);

            foreach(var person in twentySix)
            {
                Console.WriteLine($"Name: {person.FullName}, Age: {person.Age}");
            }

            Console.WriteLine("############");

            //DONE: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            //DONE: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var sumAndYOE = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);

            Console.WriteLine($"Total YOE: {sumAndYOE.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine($"YOE Average: {sumAndYOE.Average(x => x.YearsOfExperience)}");

            Console.WriteLine("############");
            //DONE: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Criss", "Cross", 35, 10)).ToList();

            foreach(var person in employees)
            {
                Console.WriteLine(person.FullName);
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
