using OverHeadRecord.DAO.DataConfig;
using OverHeadRecord.Model.V1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OverHeadRecord.DAO.V1
{
    /// <summary>
    /// 操作usermodel表
    /// </summary>
    public class UserDAO : DBContextSugar<UserModel>
    {
        /// <summary>
        /// 查询从分类
        /// </summary>
        /// <returns></returns>
        public DataTable QueryUser(string userid)
        {
            var SubData = Db.Queryable<UserModel>().Where(user => user.State == 1 && user.NumberID == userid).ToDataTable();
            return SubData;
        }
    }
}
