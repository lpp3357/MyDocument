using OverHeadRecord.BLL.Utils;
using OverHeadRecord.DAO.V1;
using OverHeadRecord.Model.V1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OverHeadRecord.BLL.V1
{
    /// <summary>
    /// 分类BLL层
    /// </summary>
    public class ClassBLL
    {

        /// <summary>
        /// 主分类数据处理类
        /// </summary>
        private MainClassDao MainDao;

        /// <summary>
        /// 次级分类数据处理类
        /// </summary>
        private SubClassDao SubDao;

        public ClassBLL()
        {
            MainDao = new MainClassDao();
            SubDao = new SubClassDao();
        }


        /// <summary>
        /// 查询主分类列表
        /// </summary>
        /// <returns></returns>
        public List<MainClassModel> SelectMainClass()
        {
            DataTable data = MainDao.SelectMainClass();
            return DataConversion.DataTableConvertToList<MainClassModel>(data);
        }

        /// <summary>
        /// 查询次级分类列表
        /// </summary>
        /// <returns></returns>
        public List<SubClassModel> SelectSubClass()
        {
            DataTable data = SubDao.SelectSubClass();
            return DataConversion.DataTableConvertToList<SubClassModel>(data);
        }
    }





    //public class ClassBLL<T> where T : new()
    //{
    //    private T tBLL;
    //    public ClassBLL()
    //    {
    //        tBLL = new T();
    //    }
    //}
}
