using System;
using System.Collections.Generic;
using Friendzone.Models;
using Friendzone.Services;
using Microsoft.AspNetCore.Mvc;

namespace Friendzone.Controllers
{
  [ApiController]
  [Route("api/profiles")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _ps;

    public ProfilesController(ProfilesService ps)
    {
      _ps = ps;
    }

    [HttpGet]
    public ActionResult<List<Profile>> Get()
    {
      try
      {
        List<Profile> profiles = _ps.Get();
        return Ok(profiles);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Profile> Get(int id)
    {
      try
      {
        Profile profile = _ps.Get(id);
        return Ok(profile);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



  }
}