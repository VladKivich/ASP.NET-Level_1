using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public enum EmployesPostsEnum
    {
        Unknown =0,
        Manager = 1,
        TopManager = 2,
        Worker = 3,
        Director = 4,
        Temporary = 5
    }

    public enum Gender
    {
        notspecified = 0,
        male = 1,
        female = 2
    }


    public class Employee
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public EmployesPostsEnum Post {get; set;}

        public Gender Gender { get; set; }

        public int Age { get; set; }

        public string[] EnumString { get; set; }

        public Employee(int ID, string FirstName, string LastName, EmployesPostsEnum Post, int Age, Gender Gender)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Post = Post;
            this.Age = Age;
            this.Gender = Gender;
            EnumString = Enum.GetNames(typeof(Gender));
        }

        public Employee()
        {
            this.ID = 0;
            this.FirstName = "Unknown";
            this.LastName = "Unknown";
            this.Post = EmployesPostsEnum.Unknown;
            this.Age = 18;
            this.Gender = Gender.notspecified;
        }
    }
}
