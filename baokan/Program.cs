using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baokan
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new baokan());           //正常启动
            //Application.Run(new guang_li_yuan2_1()); //调试，从管理员报刊录入界面启动
            //Application.Run(new guang_li_yaun2()); //调试，从管理员主界面启动
            //Application.Run(new yonghu1_1());        //调试，从用户购买报刊主界面进入
        }
    }
}
