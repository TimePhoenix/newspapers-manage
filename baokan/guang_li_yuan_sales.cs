using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baokan
{
    public partial class guang_li_yuan_sales : Form
    {
        public guang_li_yuan_sales()
        {
            InitializeComponent();
        }

        private void guang_li_yuan_sales_Load(object sender, EventArgs e)
        {
            BookTable_salesbynumber();
        }

        //查看报刊的销量
        public void BookTable_salesbynumber()
        {
            //首先将order数据清空
            dataGridView1.Rows.Clear();

            //实例化对数据库的操作
            Dataconnct Dataconnct = new Dataconnct();
            string sql = $"SELECT SUM(FenShu) AS '销量情况',SUM(Total) AS '毛利润' ,BookNumber,BookName,Bookamount FROM Order_YH GROUP BY BookNumber,BookName ,Bookamount ORDER BY SUM(FenShu) DESC";

            //读取数据查询结果
            IDataReader dc = Dataconnct.read(sql);

            //对查询结果一行一行地读
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());

            }
            string sql_sumlirun = "SELECT SUM(Total) AS '总毛利润' FROM Order_YH";
            dc = Dataconnct.read(sql_sumlirun);
            if (dc.Read())
            {
                label1.Text = "总毛利润 = " + dc[0].ToString() + " RMB";

            }

            //关闭连接
            dc.Close();
            Dataconnct.DataconnctClose();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookTable_salesbynumber();
            MessageBox.Show("已经刷新！");
        }
    }
}
