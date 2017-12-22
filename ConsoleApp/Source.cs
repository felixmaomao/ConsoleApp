using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
namespace ConsoleApp
{
    public  class Source
    {
        public static DataTable table;

        static Source()
        {
            LoadData();
        }

        public static void LoadData()
        {
            //fill in the table
        }
    }
}
