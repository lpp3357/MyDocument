using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OverHeadRecord.BLL.Utils;
using OverHeadRecord.BLL.V1;

namespace OverHeadRecord.API.Controllers.v1
{
    /// <summary>
    /// 分类控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")] //设置跨域处理的 代理
    public class GeneralController : Controller
    {
        /// <summary>
        /// 通用业务逻辑类
        /// </summary>
        private GeneralBLL generalBLL = new GeneralBLL();
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
        /// 获取 当前月及天数   v1
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetQueryDate")]
        public JsonResult GetQueryDate(string Year,string Month)
        {
            data = generalBLL.GetQueryDate(Year, Month);
            return Json(new ResultClass(true, data));
        }
    }
}