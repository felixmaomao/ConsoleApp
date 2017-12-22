//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp
//{
//    class linqTest
//    {
//        public static void Main()
//        {
//            //----------Average
//            int[] arr = { 1,2,3,4,5,6};
//            int[] foo = { };
//            //Console.WriteLine(arr.Average());

//            //----------first
//            //int first = arr.First();
//            int first = foo.FirstOrDefault();
//            //Console.WriteLine(first);

//            Pet defaultpet = new Pet {Name="foo",Age="bar" };
//            List<Pet> pets = new List<Pet>();
//            foreach (Pet item in pets)
//            {
//                Console.WriteLine(item.Name);
//            }


//            Console.ReadKey();
//        }
//    }

//    class Pet
//    {
//        public string Name { get; set; }
//        public string Age { get; set; }
//    }
//}
