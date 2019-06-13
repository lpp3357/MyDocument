using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class ClassController : Controller
    {
        /// <summary>
        /// 分类逻辑处理类
        /// </summary>
        ClassBLL classBLL = new ClassBLL();

        /// <summary>
        /// 查询主分类列表
        /// </summary>
        /// <returns></returns>
        [HttpPost("SelectMainCalss")]
        public JsonResult QueryMainClass()
        {
            List<MainClassModel> list = classBLL.SelectMainClass();
            return Json(list);
        }

        /// <summary>
        /// 查询子级分类列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("QuerySubClass")]
        public JsonResult QuerySubClass()
        {
            List<SubClassModel> list = classBLL.SelectSubClass();
            return Json(list);
        }

        /// <summary>
        /// 新增主分类
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddMainClass")]
        public JsonResult AddMainClass(MainClassModel model)
        {
            bool result = classBLL.AddMainClass(model);
            return Json(new ResultClass(result));
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

        public ResultClass(bool result)
        {
            this.code = result ? 200 : 500;
            this.msg = result ? "操作成功" : "操作失败";
        }
    }
}