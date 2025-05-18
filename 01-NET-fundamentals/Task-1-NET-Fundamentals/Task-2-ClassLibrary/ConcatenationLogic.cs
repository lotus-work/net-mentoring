using System;

namespace Task_2_ClassLibrary
{
    public static class ConcatenationLogic
    {
        public static string WelcomeUser(string username)
        {
            var currentTime = DateTime.Now.ToString("HH:mm:ss");
            return $"{currentTime} Hello, {username}!";
        }
    }
}