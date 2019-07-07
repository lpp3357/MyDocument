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
    /// 用户控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")] //设置跨域处理的代理
    public class UserController : Controller
    {

        /// <summary>
        /// 用户逻辑处理类
        /// </summary>
        private UserBLL userBLL = new UserBLL();
        /// <summary>
        /// 返回的消息
        /// </summary>
        private string msg = string.Empty;
        /// <summary>
        /// 返回的数据
        /// </summary>
        private object data = null;


        /// <summary>
        /// 查询用户信息   v1
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        [HttpPost("QueryUser")]
        public JsonResult QueryUser(string userid)
        {
            data = userBLL.QueryUser(userid);
            return Json(new ResultClass(true, data));
        }

        /// <summary>
        /// 获取前一天的日期
        /// </summary>
        /// <param name="CurrentDate">当前日期</param>
        /// <returns></returns>
        [HttpPost("GetFrontDate")]
        public JsonResult GetFrontDate(string CurrentDate)
        {
            DateTime dateTime;
            DateTime.TryParse(CurrentDate, out dateTime);
            data = dateTime.AddDays(-1).ToString("yyyy-MM-dd HH:mm");
            return Json(new ResultClass(true, data));
        }
    }
}