using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aliyun.Acs.Core;
 using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.vod.Model.V20170321;
namespace demo1.Controllers
{
    public class AliVideoController : Controller
    {
       private  demo1.AliyunAcs.AliyunServer aliServer = new AliyunAcs.AliyunServer();
        /// <summary>
        /// 视频列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 添加视频
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
 
            return View();
        }
        public ActionResult CreateUploadVideo(CreateUploadVideoRequest response)
        {
           
           var res= aliServer.CreateUploadVideo(response);
            return Json(res, JsonRequestBehavior.AllowGet);

        }
        public ActionResult RefreshUploadVideo(string videoId)
        {
            RefreshUploadVideoRequest d = new RefreshUploadVideoRequest();
            d.VideoId = videoId;
            var res = aliServer.RefreshUploadVideo(d);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
     }
}