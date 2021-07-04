using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
//对数据库进行连接和操作
namespace baokan
{
   
    class Dataconnct
    {
        SqlConnection sc;
        public SqlConnection connect()
        {
            //数据库连接字串符
            string str = @"Data Source=DESKTOP-IIU0MPE;Initial Catalog=BaoKan;Integrated Security=True";
            //创建数据库连接对象
            sc = new SqlConnection(str);
            //打开数据库
            sc.Open();
            //返回数据库对象
            return sc;
        }

        public SqlCommand command(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, connect());
            return cmd;

        }

        //数据库操作
        //更新操作
        public int Execute(string sql)
        {
            return command(sql).ExecuteNonQuery();
        }

        //读操作
        public SqlDataReader read(string sql)
        {
            return command(sql).ExecuteReader();

        }

        //关闭数据库连接
        public void DataconnctClose()
        {
            sc.Close();
        }

    }
}
