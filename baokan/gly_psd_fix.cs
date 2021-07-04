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
    public partial class gly_psd_fix : Form
    {
        public gly_psd_fix()
        {
            InitializeComponent();
        }

        private void gly_psd_fix_Load(object sender, EventArgs e)
        {
            label2.Text = Data.UID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dataconnct Dataconnct = new Dataconnct(); 
            if (textBox3.Text != "" && textBox4.Text != "")
            {
                if (textBox3.Text == textBox4.Text)
                {
                    string sql_fpsd_gly = $"UPDATE GuanLiYuan SET GLYPassword = '{textBox3.Text}' WHERE GLYName = '{Data.UID}'";
                    if (Dataconnct.Execute(sql_fpsd_gly) > 0)
                    {
                        MessageBox.Show("修改成功！");
                    }
                    else
                    {
                        MessageBox.Show("修改失败！请稍后再试");
                    }
                }
                else
                {
                    MessageBox.Show("两次输入的密码不同，请重新输入！");

                }
            }
            else
            {
                MessageBox.Show("密码不能为空！");
            }
        }
    }
}
