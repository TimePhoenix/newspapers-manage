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
    public partial class yonghu1_1_2 : Form
    {
        string BID       = "";
        string BNAME     = "";
        string Bpay      = "";
        int    BYuliang  = 0;
        public yonghu1_1_2()
        {
            InitializeComponent();
        }
        public yonghu1_1_2(string Bid,string Bname,string Bprice,string Byuliang)
        {
            InitializeComponent();
            BID    = label6.Text = Bid;
            BNAME  = label7.Text = Bname;
            BYuliang = int.Parse(Byuliang);
            Bpay   = Bprice;
                     label10.Text = Bprice +" RMB";
        }
        
        

        private void yonghu1_1_2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                int test1     = int.Parse(textBox1.Text);
                int test2     = int.Parse(textBox1.Text);
                float test8   = float.Parse(Bpay);
                int number1   = int.Parse(textBox1.Text);      //报刊份数
                int number2   = int.Parse(textBox2.Text);      //订阅期数
                                                             // MessageBox.Show($"{ Data.UName}");
                label8.Text = (test8 * number1 * number2).ToString() + "RMB";
                if (test1 > 0 && test1 > 0)
                {
                    Dataconnct dao = new Dataconnct();
                    int SUB = BYuliang - number1;
                    string sql  = $"INSERT INTO BookOrder([YongHuNumber],BookNumber,FenShu,Cycle,[Datebuy]) VALUES('{Data.UID}', '{BID}', '{textBox1.Text}', '{textBox2.Text}', GETDATE());UPDATE Book SET Bookamount = '{SUB}' WHERE BookNumber = '{BID}'; ";
                    
                    if (dao.Execute(sql) > 1)
                    {
                        MessageBox.Show($"用户:{ Data.UName} 成功购买该报刊");
                    }
                    else
                    {
                        MessageBox.Show("购买失败！");

                    }
                    dao.DataconnctClose();
                }
                else
                {
                    MessageBox.Show("订单数量或订阅的期数不能为0！");

                }


            }
            else
            {
                MessageBox.Show("订单数量或订阅的期数不能为空！");


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                int test1 = int.Parse(textBox1.Text);
                int test2 = int.Parse(textBox1.Text);
                float test8 = float.Parse(Bpay);
                int number1 = int.Parse(textBox1.Text);      //报刊份数
                int number2 = int.Parse(textBox2.Text);      //订阅期数
                                                             // MessageBox.Show($"{ Data.UName}");
                label8.Text = (test8 * number1 * number2).ToString() + "RMB";
            }
            else
            {
                MessageBox.Show("订单数量或订阅的期数不能为空！");


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
