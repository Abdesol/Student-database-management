using System;

namespace Student_database_management
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Student DataBase Management\n");
            string options = "1. Add a Student\n";
            options += "2. Remove a Student\n";
            options += "3. List All Students\n";
            options += "0. To Close the program";
            Student students = new Student();
            while (true)
            {
                Console.WriteLine(options);
                Console.Write("Enter from the above options: ");
                string option = Console.ReadLine();
                try
                {
                    int opt = Convert.ToInt32(option);
                    if (opt == 1)
                    {
                        Console.Write("Enter Student Name: ");
                        string name = Console.ReadLine();
                        while (true)
                        {
                            Console.Write("Enter Student Age: ");
                            try
                            {
                                int age = Convert.ToInt32(Console.ReadLine());
                                while (true)
                                {
                                    Console.Write("Enter Student Grade: ");
                                    try
                                    {
                                        int grade = Convert.ToInt32(Console.ReadLine());
                                        string response = students.add_stu(name, age, grade);
                                        Console.WriteLine(response);
                                        break;
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Please Enter a Number!");
                                    }
                                }
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Please Enter a Number!");
                            }

                        }
                    }
                    else if (opt == 2)
                    {
                        while (true)
                        {
                            try
                            {
                                Console.Write("Enter id of the student: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                string response = students.remove_stu(id);
                                Console.WriteLine(response);
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Please Enter a Number!!");
                            }
                        }
                    }
                    else if (opt == 3)
                    {
                        string response = students.ListStudents();
                        Console.WriteLine(response);
                    }
                    else if (opt == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nPlease Enter the correct option from above\n");
                    }
                }
                catch
                {
                    Console.WriteLine("\nPlease Enter a Number\n");
                }
            }

        }
    }
}
