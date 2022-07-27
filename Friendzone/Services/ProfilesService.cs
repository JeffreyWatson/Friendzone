using System;
using System.Collections.Generic;
using Friendzone.Models;
using Friendzone.Repositories;

namespace Friendzone.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _repo;

    public ProfilesService(ProfilesRepository repo)
    {
      _repo = repo;
    }

    internal List<Profile> Get()
    {
      return _repo.Get();
    }

    internal Profile Get(int id)
    {
      Profile found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
  }
}