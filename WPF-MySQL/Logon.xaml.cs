using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Configuration;


namespace WPF_MySQL
{
    /// <summary>
    /// Logon.xaml 的交互逻辑
    /// </summary>
    public partial class Logon : Window
    {
        //MySQLOperate mysql_Operate = new MySQLOperate();

        public Logon()
        {
            InitializeComponent();
            MySQLOperate.DatabaseConnect();
            string isRemberPw = ConfigurationManager.AppSettings["RemberPW"];
            if (isRemberPw == "Yes")
            {
                RemberBox.IsChecked = true;
            }
            else
                RemberBox.IsChecked = false;
        }

        private void LogonBtn_Click(object sender, RoutedEventArgs e)
        {
            //获取用户名密码
            string userName = UserNameBox.Text;
            string passWord = PassWordBox.Password;

            if(userName.Length ==0 ||
                passWord.Length ==0)
            {
                MessageBox.Show("请输入用户名和密码！");
                return;
            }

            //查询
            MySQLOperate.SqlCmd = "select * from user where name='"+userName+"'";
            DataSet data = MySQLOperate.DatabaseExcute();
            if(data.Tables[0].Rows.Count==0)
            {
                MessageBox.Show("用户未注册！");
            }
            else
            {
                if(passWord == (String)data.Tables[0].Rows[0][1])
                {
                    MessageBox.Show("登录成功");
                }
                else
                {
                    MessageBox.Show("密码错误！");
                }
            }

            //保存是否记录密码选项
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if(RemberBox.IsChecked ==true)
            {
                cfa.AppSettings.Settings["RemberPW"].Value = "Yes";
            }
            else
            {
                cfa.AppSettings.Settings["RemberPW"].Value = "No";
            }
            cfa.Save();
            //ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
