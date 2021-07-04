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
    public partial class addBtype : Form
    {
        public addBtype()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Dataconnct dao = new Dataconnct();
                string Tid = textBox1.Text;
                string T_check = $"SELECT * FROM BookInType WHERE BookType  ='{Tid}'";
                IDataReader sr = dao.read(T_check);
                if (sr.Read())
                {
                    MessageBox.Show($"已存在类别编号为：{textBox1.Text}的分类", "增加失败!");
                }
                else
                {
                    DialogResult dr = MessageBox.Show("确认增添吗？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        string sql_Btype = $"INSERT INTO BookInType VALUES('{textBox1.Text}','{textBox2.Text}')";

                        if (dao.Execute(sql_Btype) > 0)
                        {

                            MessageBox.Show("增加成功！");

                        }
                        else
                        {
                            MessageBox.Show("增加失败!");
                        }


                    }
                }
                sr.Close();
                dao.DataconnctClose();

            }
        }

        private void addBtype_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
        }
    }
}
