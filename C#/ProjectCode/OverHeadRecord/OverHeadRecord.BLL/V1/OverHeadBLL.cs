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
    /// 开销BLL层
    /// </summary>
    public class OverHeadBLL
    {
        /// <summary>
        /// 开销数据处理类
        /// </summary>
        private OverHeadDao overHeadDao = new OverHeadDao();

        /// <summary>
        /// 新增开销
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddOverHead(OverHeadModel model)
        {
            model.NumberID = CreateNumberClass.CreateNumber();
            model.CreateTime = DateTime.Now;
            return overHeadDao.AddOverHead(model);
        }

        /// <summary>
        /// 查询开销列表
        /// </summary>
        /// <returns></returns>
        public List<OverHeadVM> QueryOverHead(string OverDate)
        {
            DataTable data = overHeadDao.QueryOverHead(OverDate);
            return DataConversion.DataTableConvertToList<OverHeadVM>(data);
        }
    }
}
