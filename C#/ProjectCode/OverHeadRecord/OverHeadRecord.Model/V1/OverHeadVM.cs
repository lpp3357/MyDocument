using System;
using System.Collections.Generic;
using System.Text;

namespace OverHeadRecord.Model.V1
{
    /// <summary>
    /// 开销VM类
    /// </summary>
    public class OverHeadVM
    {
        /// <summary>
        /// 编号ID
        /// </summary>
        public string NumberID { get; set; }

         /// <summary>
        /// 主分类名称
        /// </summary>
        public string MainValueName { get; set; }

        /// <summary>
        /// 次分类名称
        /// </summary>
        public string SubValueName { get; set; }

        /// <summary>
        /// 从分类名称
        /// </summary>
        public string FromValueName { get; set; }

        /// <summary>
        /// 数据数量
        /// </summary>
        public decimal DataNumber { get; set; }

        /// <summary>
        /// 使用时间
        /// </summary>
        public DateTime UseTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }


       
    }
}
