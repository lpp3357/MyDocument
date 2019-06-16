using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace OverHeadRecord.Model.V1
{
    /// <summary>
    /// 次级分类Model
    /// </summary>
    public class SubClassModel
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
        /// 主分类名称编号ID
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string MainValueName { get; set; }


        /// <summary>
        /// 值名称
        /// </summary>
        public string ValueName { get; set; }

        /// <summary>
        /// 状态 1-使用中 2-停用 3-删除
        /// </summary>
        public int State { get; set; }
    }
}
