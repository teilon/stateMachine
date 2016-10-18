using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stateMachine
{
    class Program
    {        
        static void Main(string[] args)
        {
            //DumpStatus temp = DumpStatus.Instance;
            DumpStatus temp = new DumpStatus();


            Console.WriteLine(temp.Current);

            temp.OnRoad();
            Console.WriteLine(temp.Current);
            temp.OnRoad();
            Console.WriteLine(temp.Current);
            temp.OnRoad();
            Console.WriteLine(temp.Current);

                    //temp.OnExcavator();
                    //Console.WriteLine(temp.Current);
                    //temp.OnExcavator();
                    //Console.WriteLine(temp.Current);

            temp.OnRoad();
            Console.WriteLine(temp.Current);

            temp.OnRoad();
            Console.WriteLine(temp.Current);

                    temp.OnExcavator();
                    Console.WriteLine(temp.Current);
                    temp.OnExcavator();
                    Console.WriteLine(temp.Current);

            //temp.OnRoad();
            //Console.WriteLine(temp.Current);


     temp.OnDepot();
     Console.WriteLine(temp.Current);

     temp.OnDepot();
     Console.WriteLine(temp.Current);

            //temp.OnRoad();
            //Console.WriteLine(temp.Current);

            //temp.OnRoad();
            //Console.WriteLine(temp.Current);


                temp.OnExcavator();
                Console.WriteLine(temp.Current);
                temp.OnExcavator();
                Console.WriteLine(temp.Current);


            temp.OnRoad();
            Console.WriteLine(temp.Current);

            temp.OnRoad();
            Console.WriteLine(temp.Current);

















            //temp.OnExcavator();
            //temp.OnDepot();
            //temp.OnParking();
            temp.OnRoad();

            //Console.WriteLine(temp.Current);




            //temp.AddFragment("");

            //delay
            Console.ReadLine();
        }
    }
}
