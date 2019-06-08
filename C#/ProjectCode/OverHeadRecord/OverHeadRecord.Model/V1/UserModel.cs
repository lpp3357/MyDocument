using System;
using System.Collections.Generic;
using System.Text;

namespace OverHeadRecord.Model.V1
{
    /// <summary>
    /// 用户Model
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// 编号ID
        /// </summary>
        public string NumberID { get; set; }

        /// <summary>
        /// 值名称
        /// </summary>
        public string ValueName { get; set; }

        /// <summary>
        /// 性别 1-男 0-女
        /// </summary>
        public byte Sex { get; set; }

        /// <summary>
        /// 状态 1-使用中 2-停用 3-删除
        /// </summary>
        public int State { get; set; }
    }
}
