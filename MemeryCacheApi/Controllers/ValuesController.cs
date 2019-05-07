using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace MemeryCacheApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMemoryCache _cache;

        public ValuesController(IMemoryCache cache)
        {
            _cache = cache;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<Test> Get()
        {
            Test test = new Test();

            if (!_cache.TryGetValue("GetAllArticles", out List<string> articles))
            {
                articles = new List<string>
                {
                    "111",
                    "2222",
                    "3333"
                };

                _cache.Set("GetAllArticles", articles);
            }
            test.articles = articles;

            if (!_cache.TryGetValue("now", out string now))
            {
                now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //设置绝对过期：设定时间一到就过期。适合要定期更新的场景。5秒以后过期
                _cache.Set("now", now, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(5)));
                //设置相对过期：距离最后一次使用（TryGetValue）后指定时间后过期。最后一次使用该信息5秒后过期
               // _cache.Set("now", now, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(5)));
            }
            test.nowTime = now;
            return test;
        }

        public class Test
        {
            public IEnumerable<string> articles { get; set; }

            public string nowTime { get; set; }
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
