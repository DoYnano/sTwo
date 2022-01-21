using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1FinalHomework

{
    /// <summary>
    /// 数据库的工具类
    /// </summary>
    class DBHander
    {
        private const string connStr = @"Data Source=.;Initial Catalog=OldPeople_Home;User ID=sa;Pwd=sasa";

        private SqlConnection conn;//字段

        public SqlConnection Conn //属性
        {
            get {
                if (conn == null)
                {
                    conn = new SqlConnection(connStr);
                }
                return conn; 
            }
        }
        //公共的打开数据库连接
        public void OpenConnection()
        {
            //数据库状态：关闭状态Closed，中断状态Broken
            if (Conn.State == ConnectionState.Closed)//关闭状态
            {
                 Conn.Open();//打开数据库
             }
            if (Conn.State == ConnectionState.Broken)
            {
                Conn.Close();//先关闭
                Conn.Open();//再打开
            }
        }
        //公共的关闭数据库连接
        public void CloseConnection()
        {
            //数据库状态，打开状态Open，中断状态Broken
            if (Conn.State == ConnectionState.Open ||
                Conn.State == ConnectionState.Broken)
            {
                Conn.Close();//关闭
            }
        }



    }
}
