using System;
using System.Collections.Generic;
using System.Text;

namespace OverHeadRecord.Model.V1
{
    /// <summary>
    /// 开销记录Model
    /// </summary>
    public class OverHeadModel
    {
        /// <summary>
        /// 编号ID
        /// </summary>
        public string NumberID { get; set; }

        /// <summary>
        /// 编号ID
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// 主分类ID
        /// </summary>
        public string MianClassID { get; set; }

        /// <summary>
        /// 次级分类ID
        /// </summary>
        public string SubClassID { get; set; }

        /// <summary>
        /// 数据数量
        /// </summary>
        public string DataNumber { get; set; }

        /// <summary>
        /// 使用时间
        /// </summary>
        public DateTime UseTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }

    }
}
