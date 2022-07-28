using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Friendzone.Models;
using Friendzone.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Friendzone.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FollowsController : ControllerBase
  {
    private readonly FollowsService _fs;

    public FollowsController(FollowsService fs)
    {
      _fs = fs;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Follow>> Create([FromBody] Follow followData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        followData.FollowerId = userInfo.Id;
        Follow follow = _fs.Create(followData);
        return Ok(follow);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Follow> Get(int id)
    {
      try
      {
        Follow follow = _fs.Get(id);
        return Ok(follow);
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Follow>> Delete(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _fs.Delete(id, userInfo.Id);
        return Ok(new { Message = "Un-followed" });
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
  }
}