using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace OverHeadRecord.Model.V1
{
    /// <summary>
    /// 从分类Model
    /// </summary>
    public class FromClassModel
    {
        /// <summary>
        /// 编号ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)] //是主键 
        public string NumberID { get; set; }

        /// <summary>
        /// 父级编号ID
        /// </summary>
        public string ParentID { get; set; }

        /// <summary>
        /// 值名称
        /// </summary>
        public string ValueName { get; set; }

        /// <summary>
        /// 状态 1-使用中 2-停用 3-删除
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 次分类名称
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string SubValueName { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserID { get; set; }

    }
}
