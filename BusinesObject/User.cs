﻿
namespace Lesson_11_BDD.BusinesObject
{
    public class User
    {
        private readonly string name;
        private readonly string password;

        public string[] DataUser { get; private set; }

        public User(string name, string password)
        {
            this.name = name;
            this.password = password;
            DataUser = new[] { this.name, this.password };
        }
    }
}
