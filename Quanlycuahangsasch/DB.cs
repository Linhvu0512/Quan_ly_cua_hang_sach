using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlycuahangsasch
{
    class DB
    {
        public static string str = @"Data Source=desktop-ibut2kf\sqlexpress;Initial Catalog=BOOKSTORE;Integrated Security=True";
        public static SqlConnection conn = new SqlConnection(str);
    }
}
