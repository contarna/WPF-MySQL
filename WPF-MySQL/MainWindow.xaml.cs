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

namespace WPF_MySQL
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        MySQLOperate mysql_Operate = new MySQLOperate();

        public MainWindow()
        {
            InitializeComponent();            
            mysql_Operate.DatabaseConnect();
        }

        private void Serach(object sender, RoutedEventArgs e)
        {
            mysql_Operate.SqlCmd = "select name,realname,sex from user";

            //MySqlCommand cmd = new MySqlCommand(SqlCmd, MySqlInstance);
            //MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //ada.Fill(ds);//查询结果填充数据集
            DataSet data=mysql_Operate.DatabaseExcute();
            dataGrid.ItemsSource = data.Tables[0].DefaultView;
        }
    }
}
