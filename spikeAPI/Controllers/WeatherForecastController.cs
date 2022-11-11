using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace spikeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private context _context;

    public WeatherForecastController(context context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("neckDB")]
    public void neckDB()
    {
         _context.remakeDb();
    }
    
    [HttpPost]
    [Route("saveImg")]
    public ActionResult saveImage(Img img)
    {
        return Ok(_context.addImage(img));
    }

    [HttpGet]
    [Route("getSingleImg/{id}")]
    public ActionResult<Img> getSingleImg([FromRoute]int id)
    {
        return Ok(_context.getSingleImg(id));
    }
}