using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;

namespace WPF_MySQL
{
    /// <summary>
    /// MySQL 数据库操作类
    /// </summary>
    class MySQLOperate
    {
        public MySqlConnection MySqlInstance;
        public string SqlCmd;

        //连接数据库
        public void DatabaseConnect()
        {
            string str = "Server=127.0.0.1;User ID=root;Password=wen1229;Database=project;CharSet=gbk;";
            MySqlInstance = new MySqlConnection(str);//实例化链接
            MySqlInstance.Open();//开启连接
        }

        public DataSet DatabaseExcute()
        {
            MySqlCommand cmd = new MySqlCommand(SqlCmd, MySqlInstance);
            MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ada.Fill(ds);//查询结果填充数据集
            return ds;
        }

    }
}
