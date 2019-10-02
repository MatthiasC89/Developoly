using System;
using System.Collections.Generic;
using System.Text;

namespace Developoly.Client.Entities
{
    public class DevToCourse
    {
        private Dev _dev;
        private Course _course;

        public Course Course { get => _course; set => _course = value; }
        public Dev Dev { get => _dev; set => _dev = value; }

        public DevToCourse(Course course, Dev dev)
        {
            Course = course;
            Dev = dev;
        }
    }
}
