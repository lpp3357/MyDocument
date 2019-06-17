using OverHeadRecord.DAO.DataConfig;
using OverHeadRecord.Model.V1;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OverHeadRecord.DAO.V1
{
    /// <summary>
    /// 操作MainClassModel表
    /// </summary>
    public class MainClassDao : DBContextSugar<MainClassModel>
    {
        /// <summary>
        /// 添加主分类
        /// </summary>
        /// <returns></returns>
        public bool InsertMainClass(MainClassModel model, out string msg)
        {
            msg = string.Empty;
            var MainData = Db.Queryable<MainClassModel>().Where(m => m.State == 1 && m.ValueName == model.ValueName).ToList();
            if (MainData.Count > 0)
            {
                msg = $"主分类名称：{model.ValueName} 已存在!";
                return false;
            }
            var row = Db.Insertable(model).ExecuteCommand();
            return row > 0 ? true : false;
        }

        /// <summary>
        /// 修改主分类
        /// </summary>
        /// <param name="model"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdateMainClass(MainClassModel model, out string msg)
        {
            msg = string.Empty;
            var MainData = Db.Queryable<MainClassModel>().Where(m => m.State < 3 && m.ValueName == model.ValueName && m.NumberID != model.NumberID).ToList();
            if (MainData.Count > 0 && model.State < 3)
            {
                msg = $"主分类名称：{model.ValueName} 已存在!";
                return false;
            }
            var row = Db.Updateable(model).UpdateColumns(it => new { it.ValueName, it.State }).ExecuteCommand();
            return row > 0 ? true : false;
        }

        /// <summary>
        /// 查询主分类
        /// </summary>
        /// <returns></returns>
        public DataTable SelectMainClass()
        {
            var MainData = Db.Queryable<MainClassModel>().Where(m => m.State < 3).ToDataTable();
            return MainData;
        }

    }
}
