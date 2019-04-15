using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.vod.Model.V20170321;
using System;
namespace demo1.AliyunAcs
{
    /// <summary>
    /// 其他方法可到"服务端SDK" 中查询 https://help.aliyun.com/document_detail/101789.html?spm=a2c4g.11186623.6.847.36b82ebb0MdohR
    ///项目中引用的aliyun-net-sdk-core.vs2015  是下载https://github.com/aliyun/aliyun-openapi-net-sdk
    ///然后把其中的aliyun-net-sdk-core 和 aliyun-net-sdk-vod加到项目中编译的
    /// </summary>
    class AliyunServer
    {
        private string accessKeyId = "";
        private string accessKeySecret = "";
        /// <summary>
        /// 获取视频上传地址和凭证
        /// 接口参数和返回字段请参考   https://help.aliyun.com/document_detail/55407.html?spm=a2c4g.11186623.2.18.39e21552VFYOtf
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CreateUploadVideoResponse CreateUploadVideo(CreateUploadVideoRequest request)
        {
            CreateUploadVideoResponse response = new CreateUploadVideoResponse();
            try
            {
                DefaultAcsClient client = InitVodClient(accessKeyId, accessKeySecret);
                  response = client.GetAcsResponse(request);
                //上传到阿里云后可以根据 response.VideoId 得到相应信息存到自己的系统中，这里上传完后阿里云中得不到视频时长，视频时长是在回调函数中获取
                //......
            }
            catch (ServerException ex)
            {
               // Console.WriteLine(ex.ToString());
            }
            catch (ClientException ex)
            {
               // Console.WriteLine(ex.ToString());
            }
            return response;
        }
        public static DefaultAcsClient InitVodClient(string accessKeyId, string accessKeySecret)
        {
            // 点播服务接入区域
            string regionId = "cn-shanghai";
            IClientProfile profile = DefaultProfile.GetProfile(regionId, accessKeyId, accessKeySecret);
            // DefaultProfile.AddEndpoint(regionId, regionId, "vod", "vod." + regionId + ".aliyuncs.com");
            return new DefaultAcsClient(profile);
        }

        public RefreshUploadVideoResponse RefreshUploadVideo(RefreshUploadVideoRequest request)
        {
            RefreshUploadVideoResponse response = new RefreshUploadVideoResponse();
            try
            {
                // 初始化客户端
                DefaultAcsClient client = InitVodClient(accessKeyId, accessKeySecret);
                // 发起请求，并得到 response
                  response = client.GetAcsResponse(request);
                //Console.WriteLine("RequestId = " + response.RequestId);
                //Console.WriteLine("UploadAddress = " + response.UploadAddress);
                //Console.WriteLine("UploadAuth = " + response.UploadAuth);
            }
            catch (ServerException ex)
            {
               // Console.WriteLine(ex.ToString());
            }
            catch (ClientException ex)
            {
                //Console.WriteLine(ex.ToString());
            }
            return response;
        }
        /// <summary>
        /// 获取单个视频信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetVideoInfoResponse GetVideoInfo(GetVideoInfoRequest request)
        {
            GetVideoInfoResponse response = new GetVideoInfoResponse();
            try
            {
                DefaultAcsClient client = InitVodClient(accessKeyId, accessKeySecret);
                  response = client.GetAcsResponse(request);
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }
    }
}