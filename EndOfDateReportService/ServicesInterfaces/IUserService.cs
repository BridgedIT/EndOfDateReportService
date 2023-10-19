﻿using EndOfDateReportService.Domain;

namespace EndOfDateReportService.ServicesInterfaces
{
    public interface IUserService
    {
        public User CreateUser(User user);

        public User UpdateUser(User User);

        public void DeleteUser(User user);

        public void LogIn(User user);

        public void LogOut(User user);
    }
}