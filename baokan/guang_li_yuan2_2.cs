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
    public partial class guang_li_yuan2_2 : Form
    {
        string BID = "";
        public guang_li_yuan2_2()
        {
            InitializeComponent();
        }

        //定义一个含参构造函数
        public guang_li_yuan2_2(string id,string bookname,string pub,string pay,string content,string type,string ntype,string amount)
        {
            InitializeComponent();

            //参数传递
            BID = textBox1.Text = id;
            textBox2.Text     = bookname;
            textBox3.Text     = pub;
            textBox4.Text     = pay;
            textBox5.Text     = content;
            textBox6.Text     = type;
            label8.Text       = ntype;
            textBox8.Text     = amount;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Dataconnct Dataconnct = new Dataconnct();
                string sql = $"UPDATE  Book SET BookNumber = '{textBox1.Text}',BookName = '{textBox2.Text}',Publish = '{textBox3.Text}',MonthPay = '{textBox4.Text}',Content = '{textBox5.Text}',BookType = '{textBox6.Text}',Bookamount = '{textBox8.Text}' WHERE BookNumber = '{BID}'";
                if (Dataconnct.Execute(sql) > 0)
                {
                    MessageBox.Show("修改成功！");

                }
                else
                {
                    MessageBox.Show("修改失败！");

                }
                Dataconnct.DataconnctClose();

            }
            catch
            {

                MessageBox.Show("该编号已被占用，请核对后重新输入！");
            }
        }

        private void guang_li_yuan2_2_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //判断按键是不是要输入的类型。

            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;


            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (textBox4.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(textBox4.Text, out oldf);

                    b2 = float.TryParse(textBox4.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
        }
    }
}
    

