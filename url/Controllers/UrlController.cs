using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlCreation.Data;
using UrlCreation.Models.Url;
using UrlCreation.Utilities;

namespace UrlCreation.Controllers
{
    [ApiController]
    [Route("/")]
    public class UrlController : ControllerBase
    {
        private readonly IApplicationDbContext dbContext;

        public UrlController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        [ProducesResponseType(typeof(GetUrl), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public ActionResult<GetUrl> Post([FromBody]PostUrl model)
        {
            var code = RandomIdGenerator.GetBase62(7);

            var url = new Entities.Url(code, model.url);

            this.dbContext.Add(url);
            this.dbContext.SaveChanges();

            var result = new GetUrl
            {
                Code = url.Code,
                Link = new Uri($"http://{this.HttpContext.Request.Host}/{url.Code}", UriKind.Absolute),
                LongUrl = url.LongUrl
            };

            return this.CreatedAtRoute("Url", new { code = url.Code }, result);
        }

        [HttpGet]
        [Route("/{code}", Name = "Url")]
        [ProducesResponseType(typeof(GetUrl), StatusCodes.Status301MovedPermanently)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public ActionResult<GetUrl> Get([FromRoute(Name ="code")]string code)
        {
            var result = this.dbContext.Urls.Single(x => x.Code == code);

            return this.RedirectPermanent(result.LongUrl);
        }
    }
}
