using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Productmanagment.DAl;
using Productmanagment.Model;

namespace Productmanagment.Controllers;

[ApiController]
[Route("[controller]")]
public class Productcontroller : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<Productcontroller> _logger;

    public Productcontroller(ILogger<Productcontroller> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [EnableCors()]
    public IEnumerable<Product> GetProducts()
    {
       List<Product> prd=Dataaccess.Getallproduct();
       return prd;
    }
    [Route("{bal}")]
    [HttpPost]
    [EnableCors()]

    public ActionResult<Product> Upadateprd(Product prd,double bal)
    {
        Dataaccess.Update(prd,bal);
        return Ok(new {message="product update"});
    }

    [HttpPost]
    [EnableCors()]
    public ActionResult<Product> Addproduct(Product prd)
    {
      Dataaccess.Insert(prd);
      return Ok(new{Message="data added"});
    }
}
