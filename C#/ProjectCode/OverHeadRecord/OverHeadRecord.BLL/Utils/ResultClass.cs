using System;
using System.Collections.Generic;
using System.Text;

namespace OverHeadRecord.BLL.Utils
{

    /// <summary>
    /// 返回结果
    /// </summary>
    public class ResultClass
    {
        /// <summary>
        /// 代码
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        public string msg { get; set; }

        // <summary>
        /// 是否成功
        /// </summary>
        public bool success { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public object data { get; set; }


        public ResultClass(bool result, object data, string msg = "")
        {
            this.code = result ? 200 : 500;
            this.success = result;
            this.msg = result ? "操作成功!" : "操作失败!";
            if (!string.IsNullOrWhiteSpace(msg))
            {
                this.msg = msg;
            }
            this.data = data;
        }
    }
}
