using System;
using System.Collections.Generic;
using Friendzone.Models;
using Friendzone.Repositories;

namespace Friendzone.Services
{
  public class FollowsService
  {
    private readonly FollowsRepository _repo;

    public FollowsService(FollowsRepository repo)
    {
      _repo = repo;
    }

    internal Follow Create(Follow followData)
    {
      return _repo.Create(followData);
    }

    internal List<FollowersViewModel> GetFollowers(string id)
    {
      return _repo.GetFollowers(id);
    }

    internal List<FollowersViewModel> GetFollowing(string id)
    {
      return _repo.GetFollowing(id);
    }

    internal Follow Get(int id)
    {
      Follow found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal void Delete(int id, string userId)
    {
      Follow found = Get(id);
      if (found.FollowerId != userId)
      {
        throw new Exception("This isnt yours to unfollow silly.");
      }
      _repo.Delete(id);
    }
  }
}