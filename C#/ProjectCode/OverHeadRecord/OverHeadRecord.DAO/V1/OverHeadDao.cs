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
    /// 操作OverHeadModel表
    /// </summary>
    public class OverHeadDao : DBContextSugar<OverHeadModel>
    {
        /// <summary>
        /// 新增开销
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddOverHead(OverHeadModel model)
        {
            var row = Db.Insertable(model).ExecuteCommand();
            return row > 0 ? true : false;
        }

        /// <summary>
        /// 查询开销
        /// </summary>
        /// <param name="OverDate">开销日期</param>
        /// <returns></returns>
        public DataTable QueryOverHead(string OverDate)
        {
            DateTime Date = Convert.ToDateTime(OverDate);
            var OverData = Db.Queryable<OverHeadModel, MainClassModel, SubClassModel, FromClassModel>((over, main, sub, from) => new object[] {
                JoinType.Left,over.MainClassID == main.NumberID,
                JoinType.Left,over.SubClassID == sub.NumberID,
                JoinType.Left,over.FromClassID == sub.NumberID
            }).Where(over => over.UseTime == Date)
              .Select((over, main, sub, from) => new { over.NumberID, MainValueName = main.ValueName, SubValueName = sub.ValueName, FromValueName = from.ValueName, over.DataNumber, over.UseTime, over.Note }).ToDataTable();
            return OverData;
        }
    }
}
