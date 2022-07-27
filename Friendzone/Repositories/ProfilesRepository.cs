using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Friendzone.Models;

namespace Friendzone.Repositories
{
  public class ProfilesRepository
  {
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Profile> Get()
    {
      string sql = @"
      SELECT
      p.*,
      a.*
      FROM profiles p
      JOIN accounts a ON p.creatorId = a.id; 
      ";
      return _db.Query<Account, Profile, Profile>(sql, (account, profile) =>
      {
        profile.Creator = account;
        return profile;
      }).ToList();
    }

    internal Profile Get(int id)
    {
      string sql = @"
      SELECT
      p.*;
      a.*
      FROM profiles p
      JOIN accounts a ON p.creatorId = a.id; 
      ";
      return _db.Query<Account, Profile, Profile>(sql, (account, profile) =>
      {
        profile.Creator = account;
        return profile;
      }, new { id }).FirstOrDefault();
    }
  }
}