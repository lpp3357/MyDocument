using OverHeadRecord.BLL.Utils;
using OverHeadRecord.DAO.V1;
using OverHeadRecord.Model.V1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OverHeadRecord.BLL.V1
{
    /// <summary>
    /// 用户BLL层
    /// </summary>
    public class UserBLL
    {
        /// <summary>
        /// 用户数据处理类
        /// </summary>
        private UserDAO userDao = new UserDAO();

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        public List<UserModel> QueryUser(string userid)
        {
            DataTable data = userDao.QueryUser(userid);
            return DataConversion.DataTableConvertToList<UserModel>(data); ;
        }

    }
}
