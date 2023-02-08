using demoApp.DBModels;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using VimeoDotNet;
using VimeoDotNet.Net;
using Microsoft.AspNetCore.Http;
using System.IO;
using RestSharp;
using Newtonsoft.Json;
using demoApp.DataTransferObject.Application;
using VimeoVSV.Web.DBModels;
using VimeoVSV.DBModels;
using System.Collections.Generic;
using VimeoVSV.Web.Helper;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;

namespace demoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly pubsContext _context;
        HttpClient httpClient = new HttpClient();
        Random rnd = new Random();
        List<VSVShopVideos> VideosList = new List<VSVShopVideos>();
        List<int> PlayedEntertaimentVideosList = new List<int>();
        List<int> PlayedIntrosVideosList = new List<int>();

        public HomeController(ILogger<HomeController> logger, pubsContext context)
        {
            _logger = logger;
            _context = context;

        }
        public IActionResult Index()
        {
            if (Convert.ToInt32(HttpContext.Session.GetString("AccID")) > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
            //var search = _context.DemoTbls.FromSqlRaw("EXECUTE Customers_SearchCustomers").ToList();
        }
        public IActionResult Login()
        {
            //var content = Path.Combine(_env.WebRootPath + "/images/textfile.txt");
            HttpContext.Session.Remove("AccID");
            return View();
        }
        public async Task<string> Logout()
        {
            ViewBag.VsvaccountId = null;
            var resp = new StatusCode { Status = 200 };
            return JsonConvert.SerializeObject(resp);
        }
        [HttpPost]
        public async Task<string> Login([FromBody] VsvAccountDTO obj)
        {
            var data = _context.Vsvaccounts.Where(x => x.Email == obj.Email && x.Password == obj.Password).FirstOrDefault();
            if (data != null)
            {
                var resp = new StatusCode { Status = 200, VsvaccountId = data.VsvaccountId };
                HttpContext.Session.SetString("AccID", data.VsvaccountId.ToString());
                return JsonConvert.SerializeObject(resp);
            }
            else
            {
                var resp = new StatusCode { Status = 401 };
                return JsonConvert.SerializeObject(resp);
            }
        }
        [HttpPost]
        public async Task<string> SavePlaysVideos([FromBody] List<VSVShopVideos> VideosList)
        {
            try
            {
                foreach (var resp in VideosList)
                {
                    if (resp.VSVAccountID != null)
                    {
                        var vsvPlayObj = new Vsvplay
                        {
                            VsvaccountId = (int)resp.VSVAccountID,
                            VidId = (int)resp.VidId,
                            PlayTimeStamp = resp.PlayTimeStamp,
                        };
                        _context.Vsvplays.Add(vsvPlayObj);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "";
        }
        [HttpPost]
        public async Task<string> GetEntertainmentVideos(int loopIndex)
        {
            int accountId = Convert.ToInt32(HttpContext.Session.GetString("AccID"));
            Helper helper = new Helper();
            try
            {
                // VsvShop Entertainment video //
                var countEntertainment = _context.VsventertainmentVideos.Count();
                if (countEntertainment > 0)
                {                   
                    var VsventertainmentVideo = _context.VsventertainmentVideos.ToList().ElementAt(helper.GetRandomNumber(countEntertainment));
                    if (VsventertainmentVideo != null)
                    {
                        var VsventertainmentVideosObj = new VSVShopVideos
                        {
                            Url = VsventertainmentVideo.Url,
                            VideoId = helper.GetVimeoVideoId(VsventertainmentVideo.Url)
                    };
                        VideosList.Add(VsventertainmentVideosObj);
                    }
                }
                // VsvShop Intro video //
                var countIntros = _context.VsvshopIntros.Where(x => x.VsvaccountId == accountId).Count();
                if (countIntros > 0)
                {
                    int respRandomNumIntro = helper.GetRandomNumber(countIntros);
                    var VsvshopIntro = _context.VsvshopIntros.Where(x => x.VsvaccountId == accountId).ToList().ElementAt(respRandomNumIntro);
                    if (VsvshopIntro != null)
                    {
                        var VsvshopIntrosvideoId = helper.GetVimeoVideoId(VsvshopIntro.IntroUrl);
                        var VsvshopIntrosObj = new VSVShopVideos
                        {
                            Url = VsvshopIntro.IntroUrl,
                            VideoId = VsvshopIntrosvideoId
                        };
                        VideosList.Add(VsvshopIntrosObj);
                        PlayedIntrosVideosList.Add(respRandomNumIntro);
                    }
                }
                // VsvShop prod video //
                var countProdvideo = _context.Vsvaccountprodvideos.Where(x => x.VsvaccountId == accountId).Count();
                if (countProdvideo > 0)
                {
                    int respRandomNumProdFirst = helper.GetRandomNumber(countProdvideo);
                    var prodVideo1  = GetProdVideos(accountId, respRandomNumProdFirst);
                    if (prodVideo1 != null)
                        VideosList.Add(prodVideo1);
                   int respRandomNumProdSecond = helper.GetRandomNumber(countProdvideo);
                    var prodVideo2 = GetProdVideos(accountId, respRandomNumProdSecond);
                    if (prodVideo2 != null)
                        VideosList.Add(prodVideo2);
                    int respRandomNumProdThird = helper.GetRandomNumber(countProdvideo);
                    var prodVideo3 = GetProdVideos(accountId, respRandomNumProdThird);
                    if (prodVideo3 != null)
                        VideosList.Add(prodVideo3);
                }
                // VsvShop outro video //
                var countOutros = _context.VsvshopOutros.Where(x => x.VsvaccountId == accountId).Count();
                if (countOutros > 0)
                {
                    int respRandomNumOutro = helper.GetRandomNumber(countOutros);
                    var VsvshopOutros = _context.VsvshopOutros.Where(x => x.VsvaccountId == accountId).ToList().ElementAt(respRandomNumOutro);
                    if (VsvshopOutros != null)
                    {
                        var VsvshopOutrosObj = new VSVShopVideos
                        {
                            Url = VsvshopOutros.OutroUrl,
                            VideoId = helper.GetVimeoVideoId(VsvshopOutros.OutroUrl)
                    };
                        VideosList.Add(VsvshopOutrosObj);
                    }
                }
                var objDTO = new VSVShopVideosDTO
                {
                    VideosLists = VideosList,
                    LoopEnded = false
                };
                return JsonConvert.SerializeObject(objDTO);
                #region Old Code
                //else
                //{
                //    // VsvShop entertainment video //
                //    var VsventertainmentVideos = _context.VsventertainmentVideos.OrderBy(x => x.Evid).Skip(loopIndex).Take(1).FirstOrDefault();
                //    if (VsventertainmentVideos != null)
                //    {
                //        var VsventertainmentVideosObj = new VSVShopVideos
                //        {
                //            Url = VsventertainmentVideos.Url,
                //            VideoId = VsventertainmentVideos.Url.Substring(VsventertainmentVideos.Url.LastIndexOf("/") + 1)
                //        };
                //        VideosList.Add(VsventertainmentVideosObj);
                //    }
                //    // VsvShop Intros video //
                //    var VsvshopIntros = _context.VsvshopIntros.Where(x => x.VsvaccountId == accountId).OrderBy(x => x.ShopIntroId).Skip(loopIndex).Take(1).FirstOrDefault();
                //    if (VsvshopIntros != null)
                //    {
                //        var VsvshopIntrosvideoUrl = VsvshopIntros.IntroUrl.Substring(VsvshopIntros.IntroUrl.LastIndexOf("com/") + 4);
                //        var VsvshopIntrosObj = new VSVShopVideos
                //        {
                //            Url = VsvshopIntros.IntroUrl,
                //            VideoId = VsvshopIntrosvideoUrl.Split('/')[0]
                //        };
                //        VideosList.Add(VsvshopIntrosObj);
                //    }
                //    else
                //    {
                //        introVideoIndex++;
                //        if (introVideoIndex == 1)
                //        {
                //            var VsvshopIntroVideo = _context.VsvshopIntros.Where(x => x.VsvaccountId == accountId).OrderBy(x => x.ShopIntroId).Take(1).FirstOrDefault();
                //            var VsvshopIntrosvideoUrl = VsvshopIntroVideo.IntroUrl.Substring(VsvshopIntroVideo.IntroUrl.LastIndexOf("com/") + 4);
                //            var VsvshopIntrosObj = new VSVShopVideos
                //            {
                //                Url = VsvshopIntroVideo.IntroUrl,
                //                VideoId = VsvshopIntrosvideoUrl.Split('/')[0]
                //            };
                //            VideosList.Add(VsvshopIntrosObj);
                //        }
                //        else
                //        {
                //            var VsvshopIntroVideo = _context.VsvshopIntros.Where(x => x.VsvaccountId == accountId).OrderBy(x => x.ShopIntroId).Skip(introVideoIndex - 1).Take(introVideoIndex).FirstOrDefault();
                //            var VsvshopIntrosvideoUrl = VsvshopIntroVideo.IntroUrl.Substring(VsvshopIntroVideo.IntroUrl.LastIndexOf("com/") + 4);
                //            var VsvshopIntrosObj = new VSVShopVideos
                //            {
                //                Url = VsvshopIntroVideo.IntroUrl,
                //                VideoId = VsvshopIntrosvideoUrl.Split('/')[0]
                //            };
                //            VideosList.Add(VsvshopIntrosObj);
                //        }
                //    }
                //    // VsvShop prod video //
                //    if (prodVideoIndex > 0)
                //    {
                //        var Vsvaccountprodvideos = _context.Vsvaccountprodvideos.Where(x => x.VsvaccountId == accountId).OrderBy(x => x.VsvaccountId).Skip(prodVideoIndex * 3).Take(3).ToList();
                //        if(Vsvaccountprodvideos.Count !=0)
                //        {
                //            foreach (var resp in Vsvaccountprodvideos)
                //            {
                //                var VsvaccountprodvideosvideoUrl = resp.Url.Substring(resp.Url.LastIndexOf("com/") + 4);
                //                var VsvaccountprodvideosObj = new VSVShopVideos
                //                {
                //                    VidId = resp.VidId,
                //                    VSVAccountID = resp.VsvaccountId,
                //                    PlayTimeStamp = DateTime.Now,
                //                    Url = resp.Url,
                //                    VideoId = VsvaccountprodvideosvideoUrl.Split('/')[0]
                //                };
                //                VideosList.Add(VsvaccountprodvideosObj);
                //            }
                //        }
                //        else
                //        {
                //            var Vsvaccountprod = _context.Vsvaccountprodvideos.Where(x => x.VsvaccountId == accountId).OrderBy(x => x.VsvaccountId).Take(3).ToList();
                //            foreach (var resp in Vsvaccountprod)
                //            {
                //                var VsvaccountprodvideosvideoUrl = resp.Url.Substring(resp.Url.LastIndexOf("com/") + 4);
                //                var VsvaccountprodvideosObj = new VSVShopVideos
                //                {
                //                    VidId = resp.VidId,
                //                    VSVAccountID = resp.VsvaccountId,
                //                    PlayTimeStamp = DateTime.Now,
                //                    Url = resp.Url,
                //                    VideoId = VsvaccountprodvideosvideoUrl.Split('/')[0]
                //                };
                //                VideosList.Add(VsvaccountprodvideosObj);
                //                prodVideoIndex = 0;
                //            }
                //        }
                //    }
                //    // VsvShop Outros video //
                //    var VsvshopOutros = _context.VsvshopOutros.Where(x => x.VsvaccountId == accountId).OrderBy(x => x.VsvaccountId).Skip(loopIndex).Take(1).FirstOrDefault();
                //    if (VsvshopOutros != null)
                //    {
                //        var VsvshopOutrosObj = new VSVShopVideos
                //        {
                //            Url = VsvshopOutros.OutroUrl,
                //            VideoId = VsvshopOutros.OutroUrl.Substring(VsvshopOutros.OutroUrl.LastIndexOf("/") + 1)
                //        };
                //        VideosList.Add(VsvshopOutrosObj);
                //    }
                //    else
                //    {
                //        outroVideoIndex++;
                //        if (outroVideoIndex == 1)
                //        {
                //            var VsvshopOutroVideo = _context.VsvshopOutros.Where(x => x.VsvaccountId == accountId).OrderBy(x => x.VsvaccountId).Take(outroVideoIndex).FirstOrDefault();
                //            var VsvshopOutrosObj = new VSVShopVideos
                //            {
                //                Url = VsvshopOutroVideo.OutroUrl,
                //                VideoId = VsvshopOutroVideo.OutroUrl.Substring(VsvshopOutroVideo.OutroUrl.LastIndexOf("/") + 1)
                //            };
                //            VideosList.Add(VsvshopOutrosObj);
                //        }
                //        else
                //        {
                //            var VsvshopOutroVideo = _context.VsvshopOutros.Where(x => x.VsvaccountId == accountId).OrderBy(x => x.VsvaccountId).Skip(outroVideoIndex - 1).Take(outroVideoIndex).FirstOrDefault();
                //            var VsvshopOutrosObj = new VSVShopVideos
                //            {
                //                Url = VsvshopOutroVideo.OutroUrl,
                //                VideoId = VsvshopOutroVideo.OutroUrl.Substring(VsvshopOutroVideo.OutroUrl.LastIndexOf("/") + 1)
                //            };
                //            VideosList.Add(VsvshopOutrosObj);
                //        }
                //    }
                //    if (VsventertainmentVideos == null)
                //    {
                //        var objDTO = new VSVShopVideosDTO
                //        {
                //            VideosLists = VideosList,
                //            LoopEnded = true
                //        };
                //        return JsonConvert.SerializeObject(objDTO);
                //    }
                //    else
                //    {
                //        var objDTO = new VSVShopVideosDTO
                //        {
                //            VideosLists = VideosList,
                //            LoopEnded = false
                //        };
                //        return JsonConvert.SerializeObject(objDTO);
                //    }
                //}
                #endregion
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }
        private VSVShopVideos GetProdVideos(int accountId, int randomNum)
        {
            Helper helper = new Helper();
            var Vsvaccountprodvideos = _context.Vsvaccountprodvideos.Where(x => x.VsvaccountId == accountId).ToList().ElementAt(randomNum);
            if (Vsvaccountprodvideos != null)
            {
                var VsvaccountprodvideosvideoId = helper.GetVimeoVideoId(Vsvaccountprodvideos.Url);
                var VsvaccountprodvideosObj = new VSVShopVideos
                {
                    VidId = Vsvaccountprodvideos.VidId,
                    VSVAccountID = Vsvaccountprodvideos.VsvaccountId,
                    PlayTimeStamp = DateTime.Now,
                    Url = Vsvaccountprodvideos.Url,
                    VideoId = VsvaccountprodvideosvideoId
                };
                return VsvaccountprodvideosObj;              
            }
            return null;
        }
        [HttpPost]
        public async Task<ActionResult> Upload(IFormFile file)
        {
            string uploadstatus = "";
            if (file != null)
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var acctoken = "6b77a633924e636f9d0c7742e87a1812";
                VimeoClient vimeoClient = new VimeoClient(acctoken);
                var authCheck = await vimeoClient.GetAccountInformationAsync();
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                string s = Convert.ToBase64String(fileBytes);
                // act on the Base64 data
                if (authCheck.Name != null)
                {
                    IUploadRequest uploadRequest = new UploadRequest();
                    BinaryContent binaryContent = new BinaryContent(fileBytes, file.ContentType);
                    int chunksize = 0;
                    int contentlength = (int)file.Length;
                    int temp1 = contentlength / 1024;
                    if (temp1 > 1)
                    {
                        chunksize = temp1 / 1024;
                        chunksize = temp1 / 10;
                        chunksize = chunksize * 1048576;
                    }
                    else
                    {
                        chunksize = 1048576;
                    }
                    uploadRequest = await vimeoClient.UploadEntireFileAsync(binaryContent, chunksize, null);
                    uploadstatus = "file uploaded" + String.Concat("https://vimeo.com/", uploadRequest.ClipId.Value.ToString(), "/none");
                    ViewBag.UploadStatus = uploadstatus;
                }
            }
            return RedirectToAction("index", "Home");
        }
        public async Task<string> getVimeoUploadUrl(int videoFileSize, string accessToken)
        {
            var vimeoUploadUrl = "";
            var acctoken = "6b77a633924e636f9d0c7742e87a1812";
            VimeoClient vimeoClient = new VimeoClient(acctoken);
            var authCheck = await vimeoClient.GetAccountInformationAsync();
            string vimeoApiUrl = "https://api.vimeo.com/me/videos"; // Vimeo URL
            try
            {
                string body =
                    @"{'upload': {'approach': 'post','size': '" + videoFileSize + "'}}".Replace("'", "\"");
                HttpContent content = new StringContent(body);
                using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, vimeoApiUrl))
                {
                    requestMessage.Headers.Authorization =
                        new AuthenticationHeaderValue("Bearer", acctoken);
                    requestMessage.Headers.Add("Accept", "application/vnd.vimeo.*+json;version=3.4");
                    requestMessage.Headers.Add("ContentType", "application/json");
                    requestMessage.Content = content;
                    var response = await httpClient.SendAsync(requestMessage).ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var myJsonObject = JObject.Parse(result);
                    vimeoUploadUrl = myJsonObject.SelectToken("upload.upload_link").ToString();
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return vimeoUploadUrl;
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
