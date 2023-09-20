﻿using Bogus;
using UsersManagementAPI.Models;

namespace UsersManagementAPI.Fake
{
    public static class FakeData
    {
        private static List<User> _users;
        public static List<User> GetUsers(int num)
        {
            if (_users == null)
            {
                _users = new Faker<User>()
                    .RuleFor(u => u.Id, f => f.IndexFaker + 1)
                    .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                    .RuleFor(u => u.LastName, f => f.Name.LastName())
                    .RuleFor(u => u.Address, f => f.Address.FullAddress())
                    .Generate(num);
            }
            return _users;
        }
    }
}