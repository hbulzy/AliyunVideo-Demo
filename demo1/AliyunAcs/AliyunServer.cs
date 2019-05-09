using Aliyun.Acs.Core;
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
    public class AliyunServers
    {
        private DefaultAcsClient acsClient;
        public AliyunServers()
        {
            // 初始化客户端

            var aliyunAccessKeyID = "";//     
            var aliyunAccessKeySecret = "";// 
            //cn-shanghai 国内，不用其它值
            IClientProfile clientProfile = DefaultProfile.GetProfile("cn-shanghai", aliyunAccessKeyID, aliyunAccessKeySecret);
            acsClient = new DefaultAcsClient(clientProfile);
        }

        #region 媒资分类 参考地址：https://help.aliyun.com/document_detail/84754.html?spm=a2c4g.11186623.6.907.c6b62ebbsUUpVp

        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AddCategoryResponse AddCategory(AddCategoryRequest request)
        {
            AddCategoryResponse response = new AddCategoryResponse();
            try
            {
                response = acsClient.GetAcsResponse(request);
            }
            catch (Exception ex)
            {
                
            }
            return response;
        }

        /// <summary>
        /// 编辑分类
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateCategoryResponse UpdateCategory(UpdateCategoryRequest request)
        {
            UpdateCategoryResponse response = new UpdateCategoryResponse();
            try
            {
                response = acsClient.GetAcsResponse(request);
            }
            catch (Exception ex)
            {
                
            }
            return response;
        }
        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteCategoryResponse DelCategory(DeleteCategoryRequest request)
        {
            DeleteCategoryResponse response = new DeleteCategoryResponse();
            try
            {
                response = acsClient.GetAcsResponse(request);
            }
            catch (Exception ex)
            {
                
            }
            return response;
        }

        /// <summary>
        /// 查询分类及其子分类
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetCategoriesResponse GetCategories(GetCategoriesRequest request)
        {
            GetCategoriesResponse response = new GetCategoriesResponse();
            try
            {
                response = acsClient.GetAcsResponse(request);
            }
            catch (Exception ex)
            {
                
            }
            return response;
        }
        #endregion

        #region 媒体上传 参考地址：https://help.aliyun.com/document_detail/84750.html?spm=a2c4g.11186623.6.904.75b62ebbw9IiNW#h2--div-id-createuploadvideo-div-2

        /// <summary>
        /// 获取视频上传地址和凭证
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CreateUploadVideoResponse CreateUploadVideo(CreateUploadVideoRequest request)
        {
            CreateUploadVideoResponse response = new CreateUploadVideoResponse();
            try
            {
                response = acsClient.GetAcsResponse(request);
            }
            catch (Exception ex)
            {
                
            }
            return response;
        }

        /// <summary>
        /// 刷新视频上传凭证
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RefreshUploadVideoResponse RefreshUploadVideo(RefreshUploadVideoRequest request)
        {
            RefreshUploadVideoResponse response = new RefreshUploadVideoResponse();
            try
            {
                response = acsClient.GetAcsResponse(request);
            }
            catch (Exception ex)
            {
                
            }
            return response;
        }


       
        /// <summary>
        /// 获取图片上传地址和凭证
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CreateUploadImageResponse CreateUploadImage(CreateUploadImageRequest request)
        {
            CreateUploadImageResponse response = new CreateUploadImageResponse();
            try
            {
                response = acsClient.GetAcsResponse(request);
            }
            catch (Exception ex)
            {
                throw;
            }
            return response;
        }
        /// <summary>
        /// 获取图片信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetImageInfoResponse GetImageInfo(string imgId)
        {
            GetImageInfoRequest request = new GetImageInfoRequest();
            request.ImageId = imgId;
            GetImageInfoResponse response = new GetImageInfoResponse();
            try
            {
                response = acsClient.GetAcsResponse(request);
            }
            catch (Exception ex)
            {
                throw;
            }
            return response;
        }
        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="imgUrls">多个用,分割</param>
        /// <returns></returns>
        public void DeleteImage(string imgUrls)
        {
            DeleteImageRequest request = new DeleteImageRequest();
            request.DeleteImageType = "ImageURL";
            request.ImageURLs = imgUrls;
            //根据ImageId删除图片文件
            //request.DeleteImageType = "ImageId";
            //request.ImageIds = "ImageId1,ImageId2";
            //根据VideoId删除指定ImageType的图片文件
            //request.DeleteImageType = "VideoId";
            //request.VideoId = "VideoId";
            //request.ImageType = "SpriteSnapshot";
            DeleteImageResponse response = new DeleteImageResponse();
            try
            {
                response = acsClient.GetAcsResponse(request);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region 媒资管理

        /// <summary>
        /// 获取视频信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetVideoInfoResponse GetVideoInfo(GetVideoInfoRequest request)
        {
            GetVideoInfoResponse response = new GetVideoInfoResponse();
            try
            {
                response = acsClient.GetAcsResponse(request);
            }
            catch (Exception ex)
            {
                
            }
            return response;
        }
        /// <summary>
        /// 修改视频信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateVideoInfoResponse UpdateVideoInfo(UpdateVideoInfoRequest request)
        {
            UpdateVideoInfoResponse response = new UpdateVideoInfoResponse();
            try
            {
                response = acsClient.GetAcsResponse(request);
            }
            catch (Exception ex)
            {
                
            }
            return response;

        }
        /// <summary>
        /// 删除视频
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteVideoResponse DeleteVideo(DeleteVideoRequest request)
        {
            DeleteVideoResponse response = new DeleteVideoResponse();
            try
            {
                response = acsClient.GetAcsResponse(request);
            }
            catch (Exception ex)
            {
                
            }
            return response;
        }
        /// <summary>
        /// 获取源文件信息（含源片下载地址）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetMezzanineInfoResponse GetMezzanineInfo(GetMezzanineInfoRequest request)
        {
            GetMezzanineInfoResponse response = new GetMezzanineInfoResponse();
            try
            {
                response = acsClient.GetAcsResponse(request);
            }
            catch (Exception ex)
            {
                
            }
            return response;
        }
        /// <summary>
        /// 获取视频列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetVideoListResponse GetVideoList(GetVideoListRequest request)
        {
            GetVideoListResponse response = new GetVideoListResponse();
            try
            {
                response = acsClient.GetAcsResponse(request);
            }
            catch (Exception ex)
            {
                
            }
            return response;
        }
        /// <summary>
        /// 删除媒体流
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteStreamResponse DeleteStream(DeleteStreamRequest request)
        {
            DeleteStreamResponse response = new DeleteStreamResponse();
            try
            {
                response = acsClient.GetAcsResponse(request);
            }
            catch (Exception ex)
            {
                
            }
            return response;
        }
        /// <summary>
        /// 获取图片信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetImageInfoResponse GetImageInfo(GetImageInfoRequest request)
        {
            GetImageInfoResponse response = new GetImageInfoResponse();
            try
            {
                response = acsClient.GetAcsResponse(request);
            }
            catch (Exception ex)
            {
                
            }
            return response;
        }
        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteImageResponse DeleteImage(DeleteImageRequest request)
        {
            DeleteImageResponse response = new DeleteImageResponse();
            try
            {
                response = acsClient.GetAcsResponse(request);
            }
            catch (Exception ex)
            {
                
            }
            return response;
        }
        #endregion

        #region 音视频播放 参考地址：https://help.aliyun.com/document_detail/84751.html?spm=a2c4g.11186623.6.905.24c31552zYzv93

        /// <summary>
        /// 获取视频播放地址
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetPlayInfoResponse GetPlayInfo(GetPlayInfoRequest request)
        {
            GetPlayInfoResponse response = new GetPlayInfoResponse();
            try
            {
                response = acsClient.GetAcsResponse(request);
            }
            catch (Exception ex)
            {
                
            }
            return response;
        }
        /// <summary>
        /// 获取视频播放凭证
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetVideoPlayAuthResponse GetVideoPlayAuth(GetVideoPlayAuthRequest request)
        {
            GetVideoPlayAuthResponse response = new GetVideoPlayAuthResponse();
            try
            {
                response = acsClient.GetAcsResponse(request);
            }
            catch (Exception ex)
            {
                
            }
            return response;
        }
        #endregion
    }

}