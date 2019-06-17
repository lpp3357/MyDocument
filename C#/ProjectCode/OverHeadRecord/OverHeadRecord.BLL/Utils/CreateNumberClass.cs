using System;
using System.Collections.Generic;
using System.Text;

namespace OverHeadRecord.BLL.Utils
{
    /// <summary>
    /// 创建编号
    /// </summary>
    public static class CreateNumberClass
    {
        public static string CreateNumber()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
    }
}
