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
        /// <param name="code">Code for url.</param>
        /// <param name="longUrl">long url.</param>
       
        public Url(string code, string longUrl)
        {
            this.Code = code;
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
        public long Id { get; private set; }

        /// <summary>
        /// Gets the code for the url.
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// Gets the long url.
        /// </summary>
        public string LongUrl { get; private set; }
    }
}
