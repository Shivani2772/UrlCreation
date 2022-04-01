using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlCreation.Entities
{
    /// <summary>
    /// Url entity.
    /// </summary>
    public class Url
    {
        /// <summary>
        /// Initialize the url.
        /// </summary>
        /// <param name="shortUrl">Short url.</param>
        /// <param name="longUrl">long url.</param>
       
        public Url(string shortUrl, string longUrl)
        {
            this.ShortUrl = shortUrl;
            this.LongUrl = longUrl;
        }

        /// <summary>
        /// Ef core initialization constructor.
        /// </summary>
        protected Url()
        {
        }


        /// <summary>
        /// Gets the primary key of Url.
        /// </summary>
        public long id { get; private set; }

        /// <summary>
        /// Gets the unique code for url.
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// Gets the short url.
        /// </summary>
        public string ShortUrl { get; private set; }

        /// <summary>
        /// Gets the long url.
        /// </summary>
        public string LongUrl { get; private set; }
    }
}
