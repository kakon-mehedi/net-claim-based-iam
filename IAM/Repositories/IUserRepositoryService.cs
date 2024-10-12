using System;
using IAM.Models;

namespace IAM.Repositories;

public interface IUserRepositoryService
{
    User GetUserByUsername(string username);
    void AddUser(User user);
    void SaveChanges();
}
