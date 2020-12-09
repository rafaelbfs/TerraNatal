using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Entities.Database;
using Entities.DAO;

namespace Entities.Controllers
{
  [ApiController]
  [Produces("application/json")]
  [Route("api/[controller]")]
  public class AccountsController : ControllerBase
  {

    private readonly AccountCharts accountChartsDao;

    private readonly ILogger<AccountsController> _logger;

    public AccountsController(ILogger<AccountsController> logger, AccountCharts accountCharts)
    {
      _logger = logger;
      accountChartsDao = accountCharts;
    }

    [HttpGet, Route("/charts")]
    public async Task<ActionResult<IEnumerable<AccountChart>>> GetAllCharts()
    {
      var result = await accountChartsDao.GetAll();
      return Ok(result);
    }

    [HttpGet, Route("/charts/{id}"), ActionName("GetChartById")]
    public async Task<ActionResult<AccountChart>> GetChart([FromRoute] int id)
    {
      var result = await accountChartsDao.GetOne(id);
      return Ok(result);
    }

    [HttpPost, Route("/charts")]
    public async Task<ActionResult<AccountCharts>> SaveNewChartAsync([FromBody] AccountCharts.Create accountChartCreateObj)
    {
      var result = await accountChartsDao.SaveNew(accountChartCreateObj);
      return CreatedAtAction("GetChartById", new { id = result.Id }, result);
    }

    [HttpDelete, Route("/charts/{id}"), Produces("text/plain")]
    public async Task<ActionResult<string>> Delete([FromRoute] int id)
    {
      var result = await accountChartsDao.Delete(id);
      return Ok(result ? "Deleted" : "No change");
    }
  }
}
