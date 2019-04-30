using Aliyun.Acs.vod.Model.V20170321;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace demo1.Controllers
{
    public class AliVideoController : Controller
    {
        private demo1.AliyunAcs.AliyunServers aliServer = new AliyunAcs.AliyunServers();
        /// <summary>
        /// 视频列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            GetVideoListRequest request = new GetVideoListRequest();
            request.PageNo = 1;
            request.PageSize = 20;
            ViewBag.list = aliServer.GetVideoList(request).VideoList;
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
        public ActionResult Play(string id)
        {
            GetVideoPlayAuthRequest resp = new GetVideoPlayAuthRequest();
            resp.VideoId = id;
            ViewBag.info = aliServer.GetVideoPlayAuth(resp);
            return View();
        }
        public ActionResult Del(string id)
        {
            DeleteVideoRequest resp = new DeleteVideoRequest();
            resp.VideoIds = id;
            ViewBag.info = aliServer.DeleteVideo(resp);
            return Redirect("/alivideo/index");
        }

        public ActionResult CreateUploadVideo(CreateUploadVideoRequest response)
        {

            var res = aliServer.CreateUploadVideo(response);
            return Json(res, JsonRequestBehavior.AllowGet);

        }
        public ActionResult RefreshUploadVideo(string videoId)
        {
            RefreshUploadVideoRequest d = new RefreshUploadVideoRequest();
            d.VideoId = videoId;
            var res = aliServer.RefreshUploadVideo(d);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddImg(CreateUploadImageRequest request)
        {
            return View();
        }
        public ActionResult CreateUploadImage(CreateUploadImageRequest request)
        {
            var res = aliServer.CreateUploadImage(request);
            GetImageInfoResponse imgInfo = aliServer.GetImageInfo(res.ImageId);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("auth", res);
            dic.Add("imginfo", imgInfo);
            return Json(dic, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteImage(string imgUrls)
        {
            aliServer.DeleteImage(imgUrls);
            return Json("", JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 阿里视频上传完后的回调
        /// </summary>
        /// <param name="EventTime"></param>
        /// <param name="EventType"></param>
        /// <param name="VideoId"></param>
        /// <param name="Size"></param>
        /// <param name="FileUrl"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public ActionResult PostCallBack(AliResponse obj)
        {
            string k = obj.VideoId;
            var list = Request.Params.AllKeys;
            //   string VideoId = Request["VideoId"];
            System.IO.File.WriteAllText(Server.MapPath("/VideoId.txt"), string.Join("|\r\n", list));

            return Content("ok");
        }
        public ActionResult GetPlayUrls()
        {
          var d=  aliServer.GetPlayInfo(new GetPlayInfoRequest() { VideoId = "b967f18331784062b4a677ff29b14925" });
            var s = "";
            foreach (var item in d.PlayInfoList)
            {
                s += "|"+item.PlayURL;
            }
            return Content(s);
        }
    }
    public class AliResponse
    {
        public DateTime EventTime { get; set; }

        public string EventType { get; set; }

        public string VideoId { get; set; }

        public string Status { get; set; }

        public string Bitrate { get; set; }

        public string Definition { get; set; }

        public string FileUrl { get; set; }

        public int Size { get; set; }
    }


}