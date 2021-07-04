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
    public partial class yonghu1 : Form
    {
        public yonghu1()
        {
            InitializeComponent();
        }

        private void 报刊浏览和购买ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yonghu1_1 yh1_1 = new yonghu1_1();
            yh1_1.ShowDialog();
        }

        private void 我的报刊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dataconnct dao_check = new Dataconnct();
            string sql_check = $"SELECT * FROM Order_YH WHERE YongHuNumber = '{Data.UID}'";

            //读取数据查询结果
            IDataReader dc = dao_check.read(sql_check);
            if (dc.Read())
            {
                yonghu1_1_1 yh1_1_1 = new yonghu1_1_1();
                yh1_1_1.ShowDialog();
            }
            else
            {
                MessageBox.Show("你还没有订阅报刊！");

            }

            dc.Close();
            dao_check.DataconnctClose();

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 修改个人信息收货地址等ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yonghu_infor_fixed yh_infor_fixed = new yonghu_infor_fixed();
            yh_infor_fixed.ShowDialog();
        }

        private void 密码修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yonghu_pad_fixed yh_psd_fix = new yonghu_pad_fixed();
            yh_psd_fix.ShowDialog();
        }
    }
}
