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
            var OverData = Db.Queryable<OverHeadModel, MainClassModel, SubClassModel, FromClassModel>((ov, main, sub, fm) => new object[] {
                JoinType.Left,ov.MainClassID == main.NumberID,
                JoinType.Left,ov.SubClassID == sub.NumberID,
                JoinType.Left,ov.FromClassID == fm.NumberID
            }).Where(ov => ov.UseTime.Date == Date.Date)
              .Select((ov, main, sub, fm) => new { ov.NumberID, MainValueName = main.ValueName, SubValueName = sub.ValueName, FromValueName = fm.ValueName, ov.DataNumber, ov.UseTime, ov.Note }).ToDataTable();
            return OverData;
        }
    }
}
