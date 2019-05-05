using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;


namespace MyAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private static IMemoryCache _cache;// = new MemoryCache(new MemoryCacheOptions());
        //private MemoryCacheEntryOptions _options;



        private static void MyCallback(object key, object value, EvictionReason reason, object state)
        {
            var message = $"Cache entry was removed : {reason}";
            //((HomeController)state).
        //cache.Set("callbackMessage", message);
        }

        public ValuesController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;

            /*if (_options == null)
            {
                // _cache = memoryCache;
                //_cache = new MemoryCache(new MemoryCacheOptions());
                _options = new MemoryCacheEntryOptions();
                _options.AbsoluteExpiration =
                    DateTime.Now.AddMinutes(2);
                _options.SlidingExpiration = TimeSpan.FromMinutes(2);
                _options.RegisterPostEvictionCallback(MyCallback, this);

                ////  _cache = new MemoryCache("myCache");
                //  _cache = MemoryCache.Default;// new MemoryCache("myCahe");
            }*/

        }

        static int i;
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            var TEST = _cache.Get("entry" + i);
            i++;


            MemoryCacheEntryOptions options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(25), // cache will expire in 25 seconds
                //SlidingExpiration = TimeSpan.FromSeconds(5) // caceh will expire if inactive for 5 seconds,                
            };

            options.RegisterPostEvictionCallback(MyCallback, this);

            _cache.Set("entry" + i, "", options);
           
            return new string[] { "value1", "value2" };
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
