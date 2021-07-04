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
    public partial class guang_li_yuan_consume : Form
    {
        public guang_li_yuan_consume()
        {
            InitializeComponent();
        }

        private void guang_li_yuan_consume_Load(object sender, EventArgs e)
        {
            BookTable_userconsum();
        }

        //查看用户消费情况
        public void BookTable_userconsum()
        {
            //首先将order数据清空
            dataGridView1.Rows.Clear();

            //实例化对数据库的操作
            Dataconnct Dataconnct = new Dataconnct();
            string sql = $"SELECT SUM(Total) AS '订单总金额',YongHuNumber ,RealName, Tel,Addr FROM Order_YH GROUP BY  YongHuNumber,RealName,Tel,Addr";

            //读取数据查询结果
            IDataReader dc = Dataconnct.read(sql);

            //对查询结果一行一行地读
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());

            }

            //关闭连接
            dc.Close();
            Dataconnct.DataconnctClose();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookTable_userconsum();
            MessageBox.Show("已获取最新信息！");
        }
    }
}
