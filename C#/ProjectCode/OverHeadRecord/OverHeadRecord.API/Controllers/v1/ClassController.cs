using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OverHeadRecord.BLL.Utils;
using OverHeadRecord.BLL.V1;
using OverHeadRecord.Model.V1;

namespace OverHeadRecord.API.Controllers.v1
{
    /// <summary>
    /// 分类控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")] //设置跨域处理的 代理
    public class ClassController : Controller
    {
        /// <summary>
        /// 分类逻辑处理类
        /// </summary>
        private ClassBLL classBLL = new ClassBLL();
        /// <summary>
        /// 返回的消息
        /// </summary>
        private string msg = string.Empty;
        /// <summary>
        /// 返回的结果
        /// </summary>
        private bool result = false;
        /// <summary>
        /// 返回的数据
        /// </summary>
        private object data = null;

        /// <summary>
        /// 查询主分类列表   v1
        /// </summary>
        /// <returns></returns>
        [HttpPost("QueryMainClass")]
        public JsonResult QueryMainClass()
        {
            data = classBLL.SelectMainClass();
            return Json(new ResultClass(true, data));
        }

        /// <summary>
        /// 新增主分类    v1
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddMainClass")]
        public JsonResult AddMainClass(string ValueName)
        {
            if (!string.IsNullOrWhiteSpace(ValueName))
            {
                result = classBLL.AddMainClass(ValueName, out msg);
            }
            return Json(new ResultClass(result, null, msg));
        }

        /// <summary>
        /// 修改主分类    v1
        /// </summary>
        /// <returns></returns>
        [HttpPost("UpdateMainClass")]
        public JsonResult UpdateMainClass(MainClassModel model)
        {
            if (model != null)
            {
                result = classBLL.UpdateMainClass(model, out msg);
            }
            return Json(new ResultClass(result, null, msg));
        }


        /// <summary>
        /// 查询次分类列表    v1
        /// </summary>
        /// <returns></returns>
        [HttpPost("QuerySubClass")]
        public JsonResult QuerySubClass(string ParentID)
        {
            if (!string.IsNullOrWhiteSpace(ParentID))
            {
                data = classBLL.QuerySubClass(ParentID);
            }
            return Json(new ResultClass(true, data));
        }

        /// <summary>
        /// 新增次分类    v1
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddSubClass")]
        public JsonResult AddSubClass(string ValueName, string ParentID)
        {
            if (!string.IsNullOrWhiteSpace(ValueName) && !string.IsNullOrWhiteSpace(ParentID))
            {
                result = classBLL.AddSubClass(ValueName, ParentID, out msg);
            }
            return Json(new ResultClass(result, null, msg));
        }

        /// <summary>
        /// 修改次分类    v1
        /// </summary>
        /// <returns></returns>
        [HttpPost("UpdateSubClass")]
        public JsonResult UpdateSubClass(SubClassModel model)
        {
            if (model != null)
            {
                result = classBLL.UpdateSubClass(model, out msg);
            }
            return Json(new ResultClass(result, null, msg));
        }


        /// <summary>
        /// 查询从分类列表    v1
        /// </summary>
        /// <returns></returns>
        [HttpPost("QueryFromClass")]
        public JsonResult QueryFromClass(string ParentID)
        {
            if (!string.IsNullOrWhiteSpace(ParentID))
            {
                data = classBLL.QueryFromClass(ParentID);
            }
            return Json(new ResultClass(true, data));
        }

        /// <summary>
        /// 新增从分类    v1
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddFromClass")]
        public JsonResult AddFromClass(string ValueName, string ParentID)
        {
            if (!string.IsNullOrWhiteSpace(ValueName) && !string.IsNullOrWhiteSpace(ParentID))
            {
                result = classBLL.AddFromClass(ValueName, ParentID, out msg);
            }
            return Json(new ResultClass(result, null, msg));
        }

        /// <summary>
        /// 修改从分类    v1
        /// </summary>
        /// <returns></returns>
        [HttpPost("UpdateFromClass")]
        public JsonResult UpdateFromClass(FromClassModel model)
        {
            if (model != null)
            {
                result = classBLL.UpdateFromClass(model, out msg);
            }
            return Json(new ResultClass(result, null, msg));
        }
    }
}