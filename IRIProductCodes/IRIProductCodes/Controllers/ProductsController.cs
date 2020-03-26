using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models;
using Newtonsoft.Json;
using Services;
using System.IO;

namespace IRIProductCodes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IRetailProductsService _service;
        private readonly FileDetails _fileOptions;

        public ValuesController(IRetailProductsService service, IOptionsMonitor<FileDetails> optionsAccessor)
        {
            _service = service;
            _fileOptions = optionsAccessor.CurrentValue;
        }
        // GET api/values
        [HttpGet]       
        public ActionResult<string> Get()
        {
            string fileRootPath = Directory.GetCurrentDirectory();
            var listItems = _service.GetProductWithCodes(fileRootPath, _fileOptions);
            return JsonConvert.SerializeObject(listItems);
        }
    }
}
