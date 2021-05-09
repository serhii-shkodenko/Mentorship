using Lecture3.Homework.Example.Models;
using System;
using System.Runtime;

namespace Lecture3.Homework.Example
{
    public static class UserExtensions
    {
        public static User ChangeName(this User user, string name)
        {
            GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
            GC.Collect();

            user.Name = name;
            return user;
        }
    }
}