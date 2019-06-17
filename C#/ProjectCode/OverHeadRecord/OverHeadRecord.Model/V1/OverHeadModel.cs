using SqlSugar;
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
        [SugarColumn(IsPrimaryKey = true)] //是主键 
        public string NumberID { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// 主分类ID
        /// </summary>
        public string MainClassID { get; set; }

        /// <summary>
        /// 次分类ID
        /// </summary>
        public string SubClassID { get; set; }

        /// <summary>
        /// 从分类ID
        /// </summary>
        public string FromClassID { get; set; }

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


        /// <summary>
        /// 主分类名称
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string MainValueName { get; set; }

        /// <summary>
        /// 次分类名称
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string SubValueName { get; set; }

        /// <summary>
        /// 从分类名称
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string FromValueName { get; set; }
    }
}
