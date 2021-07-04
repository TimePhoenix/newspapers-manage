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
    public partial class gly_fix_user_info_win : Form
    {
        string YHID = "";
        public gly_fix_user_info_win()
        {
            InitializeComponent();
        }

        public gly_fix_user_info_win(string yhid,string rname,string tel,string addr)
        {
            InitializeComponent();
            YHID = label5.Text = yhid;
            textBox1.Text      = rname;
            textBox2.Text      = tel;
            textBox3.Text      = addr;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void gly_fix_user_info_win_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" )
            {
                string sql_update = $"UPDATE YongHu SET RealName = '{textBox1.Text}',Tel ='{textBox2.Text}',Addr ='{textBox3.Text}' WHERE YongHuNumber = '{YHID}'";
                Dataconnct Dataconnct = new Dataconnct();
                if (Dataconnct.Execute(sql_update) > 0)
                {
                    MessageBox.Show("修改成功！");
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
                Dataconnct.DataconnctClose();
            }
            else
            {
                MessageBox.Show("不能为空！");
            }
        }
    }
}
