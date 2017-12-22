//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp
//{
//    class OutRefTest
//    {
//        public static void Main(string[] args)
//        {          
//            Employee employee = new Employee { Name = "Jason" };
//            Change(employee);
//            Console.WriteLine(employee.Name);
//            ChangeTheName(employee);
//            Console.WriteLine(employee.Name);
//            ChangeName(ref employee);
//            Console.WriteLine(employee.Name);
//            Console.ReadKey();                                  
//        }

//        public class Employee
//        {
//            public string Name { get; set; }            
//        }

//        public static void Change(Employee employee)
//        {
//            employee = new Employee {Name="Jane" };
//        }

//        public static void ChangeTheName(Employee employee)
//        {
//            employee.Name = "namechanged";
//        }
//        public static void ChangeName(ref Employee employee)
//        {
//            employee.Name = "refnamechanged";
//        }
//    }

//}
