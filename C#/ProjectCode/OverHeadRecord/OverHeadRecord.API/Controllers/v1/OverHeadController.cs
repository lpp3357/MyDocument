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
    /// 开销控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")] //设置跨域处理的 代理
    public class OverHeadController : Controller
    {

        /// <summary>
        /// 开销逻辑处理类
        /// </summary>
        private OverHeadBLL overHeadBLL = new OverHeadBLL();
        /// <summary>
        /// 返回的消息
        /// </summary>
        private string msg = string.Empty;
        /// <summary>
        /// 返回的数据
        /// </summary>
        private object data = null;


        /// <summary>
        /// 添加开销    v1
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddOverHead")]
        public JsonResult AddOverHead(OverHeadModel model)
        {
            bool result = overHeadBLL.AddOverHead(model);
            return Json(new ResultClass(result, null));
        }



        /// <summary>
        /// 查询开销列表   v1
        /// </summary>
        /// <returns></returns>
        [HttpPost("QueryOverHead")]
        public JsonResult QueryOverHead(string OverDate)
        {
            data = overHeadBLL.QueryOverHead(OverDate);
            return Json(new ResultClass(true, data));
        }

    }
}