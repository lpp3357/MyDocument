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
        private MainClassDao MainDao = new MainClassDao();

        /// <summary>
        /// 次分类数据处理类
        /// </summary>
        private SubClassDao SubDao = new SubClassDao();

        /// <summary>
        /// 从分类数据处理类
        /// </summary>
        private FromClassDao FromDao = new FromClassDao();

        /// <summary>
        /// 查询主分类列表
        /// </summary>
        /// <returns></returns>
        public List<MainClassModel> SelectMainClass(string userid)
        {
            DataTable data = MainDao.SelectMainClass(userid);
            return DataConversion.DataTableConvertToList<MainClassModel>(data);
        }

        /// <summary>
        /// 新增主分类 
        /// </summary>
        /// <returns></returns>
        public bool AddMainClass(string MainClassValue, string userid, out string msg)
        {
            MainClassModel model = new MainClassModel
            {
                ValueName = MainClassValue,
                NumberID = CreateNumberClass.CreateNumber(),
                State = 1,
                UserID = userid
            };
            return MainDao.InsertMainClass(model, out msg);
        }

        /// <summary>
        /// 修改主分类 
        /// </summary>
        /// <returns></returns>
        public bool UpdateMainClass(MainClassModel model, out string msg)
        {
            return MainDao.UpdateMainClass(model, out msg);
        }


        /// <summary>
        /// 查询次分类列表
        /// </summary>
        /// <returns></returns>
        public List<SubClassModel> QuerySubClass(string ParentID, string userid)
        {
            DataTable data = SubDao.QuerytSubClass(ParentID, userid);
            return DataConversion.DataTableConvertToList<SubClassModel>(data);
        }

        /// <summary>
        /// 新增次分类 
        /// </summary>
        /// <returns></returns>
        public bool AddSubClass(string SubClassValue, string ParentID, string userid, out string msg)
        {
            SubClassModel model = new SubClassModel
            {
                NumberID = CreateNumberClass.CreateNumber(),
                ValueName = SubClassValue,
                ParentID = ParentID,
                State = 1,
                UserID = userid
            };
            return SubDao.InsertSubClass(model, out msg);
        }

        /// <summary>
        /// 修改次分类 
        /// </summary>
        /// <returns></returns>
        public bool UpdateSubClass(SubClassModel model, out string msg)
        {
            return SubDao.UpdateSubClass(model, out msg);
        }


        /// <summary>
        /// 查询从分类列表
        /// </summary>
        /// <returns></returns>
        public List<FromClassModel> QueryFromClass(string ParentID, string userid)
        {
            DataTable data = FromDao.QueryFromClass(ParentID, userid);
            return DataConversion.DataTableConvertToList<FromClassModel>(data);
        }

        /// <summary>
        /// 新增从分类 
        /// </summary>
        /// <returns></returns>
        public bool AddFromClass(string SubClassValue, string ParentID, string userid, out string msg)
        {
            FromClassModel model = new FromClassModel
            {
                NumberID = CreateNumberClass.CreateNumber(),
                ValueName = SubClassValue,
                ParentID = ParentID,
                State = 1,
                UserID= userid
            };
            return FromDao.InsertFromClass(model, out msg);
        }

        /// <summary>
        /// 修改从分类 
        /// </summary>
        /// <returns></returns>
        public bool UpdateFromClass(FromClassModel model, out string msg)
        {
            return FromDao.UpdateFromClass(model, out msg);
        }

    }
}
