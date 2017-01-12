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
        public static MySqlConnection MySqlInstance;
        public static string SqlCmd;

        /// <summary>
        /// 连接Mysql数据库
        /// </summary>
        public static void DatabaseConnect()
        {
            string str = "Server=127.0.0.1;User ID=root;Password=wen1229;Database=project;CharSet=gbk;";
            MySqlInstance = new MySqlConnection(str);//实例化链接
            MySqlInstance.Open();//开启连接
        }

        /// <summary>
        /// 执行SQL语句，返回数据集
        /// </summary>
        /// <returns>填充查询结果的数据集</returns>
        public static DataSet DatabaseExcute()
        {
            MySqlCommand cmd = new MySqlCommand(SqlCmd, MySqlInstance);
            MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ada.Fill(ds);//查询结果填充数据集
            return ds;
        }

        /// <summary>
        /// 断开与数据库连接
        /// </summary>
        public static void DatabaseClose()
        {
            MySqlInstance.Close();
        }
    }
}
