using OverHeadRecord.Model.V1;
using System;
using System.Collections.Generic;
using System.Text;

namespace OverHeadRecord.BLL.V1
{
    /// <summary>
    /// 通用业务逻辑类
    /// </summary>
    public class GeneralBLL
    {
        /// <summary>
        /// 获取 当前月及天数
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <returns></returns>
        public List<string> GetQueryDate(string Year, string Month)
        {
            //默认当前月
            if (string.IsNullOrWhiteSpace(Month)) Month = DateTime.Now.Month.ToString();
            string DateStr = Year + "-" + Month + "-01";
            DateTime date;
            List<string> list = new List<string>();
            if (!DateTime.TryParse(DateStr, out date)) return list;
            //获当前月的天数  
            //当月1号计算到下月一号
            DateTime newDate = date.AddMonths(1);
            TimeSpan span = newDate.Subtract(date);
            int TotalDays = span.Days;
            list = new List<string> {
                "月:"+DateTime.Now.Month.ToString(),
                "天数:"+TotalDays,
                "天:"+DateTime.Now.Day.ToString()
            };
            return list;
        }
    }

}
