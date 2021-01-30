using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace University
{
    /// <summary>
    /// Student.
    /// </summary>
    [Table(Name = "Students")]
    public class Student : IUniversity
    {
        /// <summary>
        /// Students id.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        /// <summary>
        /// Student's name.
        /// </summary>
        [Column]
        public string Name { get; set; }

        /// <summary>
        /// Student's surname.
        /// </summary>
        [Column]
        public string Surname { get; set; }

        /// <summary>
        /// Date birth.
        /// </summary>
        [Column]
        public DateTime DateBirth { get; set; }

        /// <summary>
        /// Gender.
        /// </summary>
        [Column]
        public string Gender { get; set; }

        /// <summary>
        /// Group.
        /// </summary>
        [Column]
        public int StudentGroup { get; set; }

        /// <summary>
        /// Standard constructor.
        /// </summary>
        public Student()
        {
        }

        /// <summary>
        /// Create new student.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="surname">Surname.</param>
        /// <param name="dateBirth">Date birth.</param>
        /// <param name="gender">Gender.</param>
        /// <param name="group">Group.</param>
        public Student(string name, string surname, DateTime dateBirth, string gender, int group)
        {
            if (String.IsNullOrWhiteSpace(name) || String.IsNullOrWhiteSpace(surname))
            {
                throw new ArgumentNullException("Name or surname can not be null.");
            }

            this.Name = name;
            this.Surname = surname;
            this.DateBirth = dateBirth;
            this.Gender = gender;
            this.StudentGroup = group;
        }

        /// <summary>
        /// Get id.
        /// </summary>
        /// <param name="list">List with student.</param>
        /// <returns>Id.</returns>
        public int GetId(List<Student> list)
        {
            int id = -1;

            foreach (var student in list)
            {
                if (this.Name == student.Name &&
                    this.Surname == student.Surname &&
                    this.DateBirth == student.DateBirth && 
                    this.Gender == student.Gender &&
                    this.StudentGroup == student.StudentGroup)
                {
                    id = student.Id;
                    break;
                }
            }

            return id;
        }
    }
}