using OverHeadRecord.DAO.DataConfig;
using OverHeadRecord.Model.V1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OverHeadRecord.DAO.V1
{
    /// <summary>
    /// 操作MainClassModel表
    /// </summary>
    public class MainClassDao : DBContextSugar
    {

        /// <summary>
        /// 添加主分类
        /// </summary>
        /// <returns></returns>
        public bool InsertMainClass(MainClassModel model)
        {
            return MainClassDb.Insert(model);
        }


        /// <summary>
        /// 查询次级分类
        /// </summary>
        /// <returns></returns>
        public DataTable SelectMainClass()
        {
            var MainData = Db.Queryable<MainClassModel>().Where(m => m.State == 1).ToDataTable();
            return MainData;
        }

    }
}
