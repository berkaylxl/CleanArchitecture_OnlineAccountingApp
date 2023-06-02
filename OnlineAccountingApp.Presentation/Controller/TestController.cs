using Microsoft.AspNetCore.Mvc;
using OnlineAccountingApp.Presentation.Abstraction;

namespace OnlineAccountingApp.Presentation.Controller
{
    public sealed class TestController:ApiController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("İşlem Başarılı");
        }
        
    }
}
