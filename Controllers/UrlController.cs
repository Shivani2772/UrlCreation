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

        // TODO: 201 or 200?
        [HttpPost]
        [ProducesResponseType(typeof(GetUrl), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public ActionResult<GetUrl> Post([FromBody]Posturl model)
        {
            var code = RandomIdGenerator.GetBase62(7);
            var url = new Entities.Url(code, model.url);

            this.dbContext.Add(url);
            this.dbContext.SaveChanges();

            var result = new GetUrl
            {
                Code = url.Code,
                Link = $"hi.ai/{url.Code}",
                LongUrl = url.LongUrl
            };

            return this.Ok(result);
        }

        [HttpGet]
        [Route("/")]
        [ProducesResponseType(typeof(GetUrl), StatusCodes.Status301MovedPermanently)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public ActionResult<GetUrl> Get([FromRoute] string code)
        {
            var result = this.dbContext.DbSetUrl.Single(x => x.Code == code);

            return this.RedirectPermanent(result.LongUrl);
        }
    }
}
