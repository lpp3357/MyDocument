using OverHeadRecord.DAO.DataConfig;
using OverHeadRecord.Model.V1;
using SqlSugar;
using System.Data;

namespace OverHeadRecord.DAO.V1
{
    /// <summary>
    /// 操作SubClassModel表
    /// </summary>
    public class SubClassDao : DBContextSugar<SubClassModel>
    {

        /// <summary>
        /// 添加次分类
        /// </summary>
        /// <returns></returns>
        public bool InsertSubClass(SubClassModel model, out string msg)
        {
            msg = string.Empty;
            var SubData = Db.Queryable<SubClassModel>().Where(m => m.State < 3 && m.ValueName == model.ValueName && m.ParentID == model.ParentID).ToList();
            if (SubData.Count > 0)
            {
                msg = $"次分类名称：{model.ValueName} 已存在!";
                return false;
            }
            var row = Db.Insertable(model).ExecuteCommand();
            return row > 0 ? true : false;
        }

        /// <summary>
        /// 修改次分类
        /// </summary>
        /// <param name="model"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdateSubClass(SubClassModel model, out string msg)
        {
            msg = string.Empty;
            var MainData = Db.Queryable<SubClassModel>().Where(m => m.State < 3 && m.ValueName == model.ValueName && m.NumberID != model.NumberID && m.ParentID == model.ParentID).ToList();
            if (MainData.Count > 0 && model.State < 3)
            {
                msg = $"次分类名称：{model.ValueName} 已存在!";
                return false;
            }
            var row = Db.Updateable(model).UpdateColumns(it => new { it.ValueName, it.State, it.ParentID }).ExecuteCommand();
            return row > 0 ? true : false;
        }


        /// <summary>
        /// 查询次级分类
        /// </summary>
        /// <returns></returns>
        public DataTable SelectSubClass(string ParentID)
        {
            var SubData = Db.Queryable<SubClassModel, MainClassModel>((sub, main) => new object[] {
                JoinType.Left,sub.ParentID==main.NumberID
            }).
            //Select((sub, main) => new { NumberID = sub.NumberID, ValueName = sub.ValueName, ParentID = sub.ParentID, State = sub.State })
            Select((sub, main) => new { sub.NumberID, sub.ValueName, sub.ParentID, MainValueName = main.ValueName, sub.State })
            .Where(sub => sub.State < 3 && sub.ParentID == ParentID).ToDataTable();
            return SubData;
        }
    }
}
