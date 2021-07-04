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
    public partial class guang_li_yuan : Form
    {
        public guang_li_yuan()
        {
            InitializeComponent();
        }

        private void 报刊管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //打开报刊管理界面
            guang_li_yaun2 gly2 = new guang_li_yaun2();
            gly2.ShowDialog();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guangliyuan_btype gly_btype = new guangliyuan_btype();
            gly_btype.ShowDialog();
        }

        private void 用户信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 查看用户订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guang_li_yuan_user gly_lookuser = new guang_li_yuan_user();
            gly_lookuser.ShowDialog();
        }

        private void 删除用户信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guang_li_yuan_deluser gly_deluser = new guang_li_yuan_deluser();
            gly_deluser.ShowDialog();
        }

        private void 修改用户信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gaung_li_yuan_fixeduser_info gly_fix_uesr = new gaung_li_yuan_fixeduser_info();
            gly_fix_uesr.ShowDialog();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gly_psd_fix gly_fix_his_psw = new gly_psd_fix();
            gly_fix_his_psw.ShowDialog();
        }

        private void guang_li_yuan_Load(object sender, EventArgs e)
        {

        }
    }
}
