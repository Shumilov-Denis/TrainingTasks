using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    [Table(Name = "Students")]
    public class StudentDicorator : Student
    {
        /// <summary>
        /// Students id.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public new int Id 
        {
            get
            {
                return base.Id;
            }
            set
            {
                base.Id = value;
            }
        }

        /// <summary>
        /// Student's name.
        /// </summary>
        [Column]
        public new string Name 
        {
            get
            {
                return base.Name;
            }
            set
            {
                base.Name = value;
            }
        }

        /// <summary>
        /// Student's surname.
        /// </summary>
        [Column]
        public new string Surname 
        {
            get
            {
                return base.Surname;
            }
            set
            {
                base.Surname = value;
            }
        }

        /// <summary>
        /// Date birth.
        /// </summary>
        [Column]
        public new DateTime DateBirth 
        {
            get
            {
                return base.DateBirth;
            }
            set
            {
                base.DateBirth = DateBirth;
            }
        }

        /// <summary>
        /// Gender.
        /// </summary>
        [Column]
        public new string Gender 
        {
            get
            {
                return base.Gender;
            }
            set
            {
                base.Gender = value;
            }
        }

        /// <summary>
        /// Group.
        /// </summary>
        public new int StudentGroup 
        {
            get
            {
                return base.StudentGroup;
            }
            set
            {
                base.StudentGroup = value;
            }
        }

        /// <summary>
        /// Standard constructor.
        /// </summary>
        public StudentDicorator()
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
        public StudentDicorator(string name, string surname, DateTime dateBirth, string gender, int group)
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
        public int GetId(List<StudentDicorator> list)
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
