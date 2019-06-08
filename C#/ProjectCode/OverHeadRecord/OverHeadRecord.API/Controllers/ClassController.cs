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
        public JsonResult SelectMainCalss(MainClassModel model)
        {
            List<MainClassModel> list = classBLL.SelectMainClass();
            return Json(list);
        }

        /// <summary>
        /// 查询子级分类列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("SelectSubCalss")]
        public JsonResult SelectSubCalss()
        {
            List<SubClassModel> list = classBLL.SelectSubClass();
            return Json(list);
        }
    }
}