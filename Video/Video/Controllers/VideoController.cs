using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Video.Models;

namespace Video.Controllers
{
    //public class Video
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
    public class VideosController : ApiController
    {
        VideoDb _db;

        public VideosController()
        {
            _db = new VideoDb();
            _db.Configuration.ProxyCreationEnabled = false;
        }
        // GET api/video
        public IEnumerable<Video.Models.Video> GetVideos()
        {
            return _db.Videos;
            ///return new string[] { "value1", "value2" };
        }

        // GET api/video/5
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/video
        //public string Post([FromBody]string value)
        //{
        //    return value;
        //}

        // POST api/video
        public Video.Models.Video Post(Video.Models.Video video)
        {
            return video;
        }

        // PUT api/video/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/video/5
        public void Delete(int id)
        {
        }
    }
}
