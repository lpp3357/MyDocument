using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OverHeadRecord.BLL.V1;
using OverHeadRecord.Model.V1;

namespace OverHeadRecord.API.Controllers
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

        private string msg = string.Empty;

        /// <summary>
        /// 查询主分类列表
        /// </summary>
        /// <returns></returns>
        [HttpPost("QueryMainClass")]
        public JsonResult QueryMainClass()
        {
            List<MainClassModel> list = classBLL.SelectMainClass();
            return Json(new ResultClass(true, list));
        }

        /// <summary>
        /// 新增主分类
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddMainClass")]
        public JsonResult AddMainClass(string ValueName)
        {
            bool result = false;
            if (!string.IsNullOrWhiteSpace(ValueName))
            {
                result = classBLL.AddMainClass(ValueName, out msg);
            }
            return Json(new ResultClass(result, null, msg));
        }

        /// <summary>
        /// 修改主分类
        /// </summary>
        /// <returns></returns>
        [HttpPost("UpdateMainClass")]
        public JsonResult UpdateMainClass(MainClassModel model)
        {
            bool result = false;
            if (model != null)
            {
                result = classBLL.UpdateMainClass(model, out msg);
            }
            return Json(new ResultClass(result, null, msg));
        }


        /// <summary>
        /// 查询次分类列表
        /// </summary>
        /// <returns></returns>
        [HttpPost("QuerySubClass")]
        public JsonResult QuerySubClass(string ParentID)
        {
            List<SubClassModel> list = null;
            if (!string.IsNullOrWhiteSpace(ParentID))
            {
                list = classBLL.SelectSubClass(ParentID);
            }
            return Json(new ResultClass(true, list));
        }

        /// <summary>
        /// 新增次分类
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddSubClass")]
        public JsonResult AddSubClass(string ValueName, string ParentID)
        {
            bool result = false;
            if (!string.IsNullOrWhiteSpace(ValueName) && !string.IsNullOrWhiteSpace(ParentID))
            {
                result = classBLL.AddSubClass(ValueName, ParentID, out msg);
            }
            return Json(new ResultClass(result, null, msg));
        }

        /// <summary>
        /// 修改次分类
        /// </summary>
        /// <returns></returns>
        [HttpPost("UpdateSubClass")]
        public JsonResult UpdateSubClass(SubClassModel model)
        {
            bool result = false;
            if (model != null)
            {
                result = classBLL.UpdateSubClass(model, out msg);
            }
            return Json(new ResultClass(result, null, msg));
        }
    }

    /// <summary>
    /// 返回结果
    /// </summary>
    public class ResultClass
    {
        /// <summary>
        /// 代码
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        public string msg { get; set; }

        // <summary>
        /// 是否成功
        /// </summary>
        public bool success { get; set; }

        public object data { get; set; }

        public ResultClass(bool result, object data, string msg = "")
        {
            this.code = result ? 200 : 500;
            this.success = result;
            this.msg = result ? "操作成功!" : "操作失败!";
            if (!string.IsNullOrWhiteSpace(msg))
            {
                this.msg = msg;
            }
            this.data = data;
        }
    }
}