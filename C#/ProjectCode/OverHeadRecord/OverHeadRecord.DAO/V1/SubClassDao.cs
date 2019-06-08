using OverHeadRecord.DAO.DataConfig;
using OverHeadRecord.Model.V1;
using System.Data;

namespace OverHeadRecord.DAO.V1
{
    /// <summary>
    /// 操作SubClassModel表
    /// </summary>
    public class SubClassDao : DBContextSugar
    {
        /// <summary>
        /// 查询次级分类
        /// </summary>
        /// <returns></returns>
        public DataTable SelectSubClass()
        {
            var SubData = Db.Queryable<SubClassModel>().Where(m => m.State == 1).ToDataTable();
            return SubData;
        }
    }
}
