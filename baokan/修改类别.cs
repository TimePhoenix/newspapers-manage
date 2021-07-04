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
    public partial class 修改类别 : Form
    {
        string TID = "";
        public 修改类别()
        {
            InitializeComponent();
        }

        public 修改类别(string btype,string bntype)
        {
            InitializeComponent();
            TID = label2.Text = btype;
            textBox1.Text = bntype;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 修改类别_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string sql_t_up = $"UPDATE BookInType SET BooKTypeName = '{textBox1.Text}' WHERE BookType = '{TID}'";
                Dataconnct dao = new Dataconnct();
                if (dao.Execute(sql_t_up) > 0)
                {
                    MessageBox.Show("修改成功！");

                }
                else
                {
                    MessageBox.Show("修改失败！");

                }
                dao.DataconnctClose();

            }
            else
            {
                MessageBox.Show("不能为空！");

            }
        }
    }
}
