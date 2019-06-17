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
    /// 操作FromClassModel表
    /// </summary>
    public class FromClassDao : DBContextSugar<FromClassModel>
    {

        /// <summary>
        /// 添加从分类
        /// </summary>
        /// <returns></returns>
        public bool InsertFromClass(FromClassModel model, out string msg)
        {
            msg = string.Empty;
            var SubData = Db.Queryable<FromClassModel>().Where(m => m.State < 3 && m.ValueName == model.ValueName && m.ParentID == model.ParentID).ToList();
            if (SubData.Count > 0)
            {
                msg = $"从分类名称：{model.ValueName} 已存在!";
                return false;
            }
            var row = Db.Insertable(model).ExecuteCommand();
            return row > 0 ? true : false;
        }

        /// <summary>
        /// 修改从分类
        /// </summary>
        /// <param name="model"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdateFromClass(FromClassModel model, out string msg)
        {
            msg = string.Empty;
            var MainData = Db.Queryable<FromClassModel>().Where(m => m.State < 3 && m.ValueName == model.ValueName && m.NumberID != model.NumberID && m.ParentID == model.ParentID).ToList();
            if (MainData.Count > 0 && model.State < 3)
            {
                msg = $"从分类名称：{model.ValueName} 已存在!";
                return false;
            }
            var row = Db.Updateable(model).UpdateColumns(it => new { it.ValueName, it.State, it.ParentID }).ExecuteCommand();
            return row > 0 ? true : false;
        }


        /// <summary>
        /// 查询从分类
        /// </summary>
        /// <returns></returns>
        public DataTable QueryFromClass(string ParentID)
        {
            var SubData = Db.Queryable<FromClassModel, SubClassModel>((frta, sub) => new object[] {
                JoinType.Left,frta.ParentID==sub.NumberID
            }).
            Select((frta, sub) => new { frta.NumberID, frta.ValueName, frta.ParentID, SubValueName = sub.ValueName, frta.State })
            .Where(frta => frta.State < 3 && frta.ParentID == ParentID).ToDataTable();
            return SubData;
        }
    }
}
