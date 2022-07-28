using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Friendzone.Models;

namespace Friendzone.Repositories
{
  public class FollowsRepository
  {
    private readonly IDbConnection _db;

    public FollowsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Follow Create(Follow followData)
    {
      string sql = @"
      INSERT INTO follows
      (followerId, followingId)
      VALUES
      (@FollowerId, @FollowingId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, followData);
      followData.Id = id;
      return followData;
    }

    internal List<FollowersViewModel> GetFollowing(string id)
    {
      string sql = @"
            SELECT
            a.*,
            f.id AS followId
            FROM follows f
            JOIN accounts a ON f.followerId = a.id
            WHERE f.followerId = @id
            ";
      return _db.Query<FollowersViewModel>(sql, new { id }).ToList();
    }

    internal List<FollowersViewModel> GetFollowers(string id)
    {
      string sql = @"
            SELECT
            a.*,
            f.id AS followId
            FROM follows f
            JOIN accounts a ON f.followingId = a.id
            WHERE f.followingId = @id
            ";
      return _db.Query<FollowersViewModel>(sql, new { id }).ToList();
    }

    internal Follow Get(int id)
    {
      string sql = @"
      SELECT *
      FROM follows
      WHERE id = @id
      ";
      return _db.QueryFirstOrDefault<Follow>(sql, new { id });
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM follows WHERE id = @followId LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}