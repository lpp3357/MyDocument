using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OverHeadRecord.Model.V1;
using SqlSugar;

namespace OverHeadRecord.DAO.DataConfig
{
    //SqlSugar 框架 地址
    //http://www.codeisbug.com/Doc/8/1165



    /// <summary>
    /// SqlSugar 数据库配置类
    /// </summary>
    public class DBContextSugar<T> where  T:class,new ()
    {
        /// <summary>
        /// 定义数据库连接对象
        /// </summary>
        public SqlSugarClient Db;

        public DBContextSugar()
        {
            Db = new SqlSugarClient(new ConnectionConfig
            {
                //数据库连接字符
                ConnectionString = "server=129.28.186.60;uid=sa;pwd=520@hyy;database=OverHead",
                DbType = DbType.SqlServer,
                InitKeyType = InitKeyType.Attribute,
                //开启自动释放模式
                IsAutoCloseConnection = true
            });
            //调试代码  打印SQL
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" + Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
        }

        /**
         * 定义实体类的数据操作
         */

        ///// <summary>
        ///// 对MainClassModel表的操作
        ///// </summary>
        //public SimpleClient<MainClassModel> MainClassDb { get { return new SimpleClient<MainClassModel>(Db); } }

        ///// <summary>
        ///// 对OverHeadModel表的操作
        ///// </summary>
        //public SimpleClient<OverHeadModel> OverHeadDb { get { return new SimpleClient<OverHeadModel>(Db); } }

        ///// <summary>
        ///// 对SubClassModel表的操作
        ///// </summary>
        //public SimpleClient<SubClassModel> SubClassDb { get { return new SimpleClient<SubClassModel>(Db); } }

        ///// <summary>
        ///// 对UserModel表的操作
        ///// </summary>
        //public SimpleClient<UserModel> UserDb { get { return new SimpleClient<UserModel>(Db); } }

        public SimpleClient<T> CurrentDb { get { return new SimpleClient<T>(Db); } }//用来处理T表的常用操作


        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Delete(dynamic id)
        {
            return CurrentDb.Delete(id);
        }


        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Update(T obj)
        {
            return CurrentDb.Update(obj);
        }
    }
}
