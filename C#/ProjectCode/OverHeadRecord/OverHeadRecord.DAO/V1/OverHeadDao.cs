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
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        public object QueryOverHead(string Year, string Month, string Day, string userid)
        {
            string StartDate = string.Empty;
            string EndDate = string.Empty;
            if (!string.IsNullOrWhiteSpace(Year) && string.IsNullOrWhiteSpace(Month) && string.IsNullOrWhiteSpace(Day))
            {
                //获取一年的范围
                StartDate = Year + "-01-01";
                EndDate = (Int32.Parse(Year) + 1) + "-12-31";
            }
            else
            if (!string.IsNullOrWhiteSpace(Year) && !string.IsNullOrWhiteSpace(Month) && string.IsNullOrWhiteSpace(Day))
            {
                //获取一月的范围
                StartDate = Year + "-" + Month + "-01";
                EndDate = Convert.ToDateTime(StartDate).AddMonths(1).Date.ToString();
            }
            else
            if (!string.IsNullOrWhiteSpace(Year) && !string.IsNullOrWhiteSpace(Month) && !string.IsNullOrWhiteSpace(Day))
            {
                StartDate = Year + "-" + Month + "-" + Day;
                EndDate = Convert.ToDateTime(StartDate).AddDays(1).Date.ToString();
            }
            else { return null; }
            if (string.IsNullOrWhiteSpace(userid)) return null;
            var OverData = Db.Queryable<OverHeadModel, MainClassModel, SubClassModel, FromClassModel>(
                (ov, main, sub, fm) =>
                new object[] {
                JoinType.Left,ov.MainClassID == main.NumberID,
                JoinType.Left,ov.SubClassID == sub.NumberID,
                JoinType.Left,ov.FromClassID == fm.NumberID
            }).Where(
                ov => ov.UseTime.Date >= Convert.ToDateTime(StartDate).Date && ov.UseTime.Date < Convert.ToDateTime(EndDate).Date && ov.UserID == userid)
              .Select(
                (ov, main, sub, fm) =>
                new { ov.NumberID, MainValueName = main.ValueName, SubValueName = sub.ValueName, FromValueName = fm.ValueName, ov.DataNumber, UseTimeStr = ov.UseTime.ToString("MM-dd HH:mm:ss"), ov.Note, ov.UseTime })
                .OrderBy(
                ov => ov.UseTime, OrderByType.Desc)
                .ToList();
            return OverData;
        }
    }
}
