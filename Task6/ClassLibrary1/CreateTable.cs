using CRUD;
using Excels.SortFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using University;

namespace Excels
{
    /// <summary>
    /// Class for create table.
    /// </summary>
    public class CreateTable
    {
        /// <summary>
        /// Create table with all data about students and exams.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="typeForSort">Type of sort.</param>
        /// <param name="typeSort">Type of sort.Type of sort.</param>
        public void CreateTableWithAllData(string path, SortBy typeForSort, TypeOfSort typeSort)
        {
            try
            {
                using (ExcelMain excel = new ExcelMain())
                {
                    if (excel.Open(path))
                    {
                        List<Rows> rows = Sort.ChooseSort(typeForSort, typeSort);

                        excel.Set(1, "A", "Date start session");
                        excel.Set(1, "B", "Date finish session");
                        excel.Set(1, "C", "Group");
                        excel.Set(1, "D", "Name");
                        excel.Set(1, "E", "Surname");
                        excel.Set(1, "F", "Gender");
                        excel.Set(1, "G", "Date birth");
                        excel.Set(1, "H", "Exam");
                        excel.Set(1, "I", "Exam date");
                        excel.Set(1, "J", "Grade");

                        int i = 2;
                        foreach (var row in rows)
                        {
                            excel.Set(i, "A", row.StartSession);
                            excel.Set(i, "B", row.FinishSession);
                            excel.Set(i, "C", row.Group);
                            excel.Set(i, "D", row.StudentsName);
                            excel.Set(i, "E", row.StudentsSurname);
                            excel.Set(i, "F", row.StudentsGender);
                            excel.Set(i, "G", row.StudentsDateBirth);
                            excel.Set(i, "H", row.ExamsTitle);
                            excel.Set(i, "I", row.ExamsDate);
                            excel.Set(i, "J", row.Grade);
                            i++;
                        }

                        excel.Save();
                        excel.Dispose();
                    }
                }
            }
            catch
            {
                Console.WriteLine("Table mistack");
            }
        }

        /// <summary>
        /// Create table with min,max and average grade per group.
        /// </summary>
        /// <param name="path">Path to file.</param>
        public void CreateTableWithMaxMinAvrageGrade(string path)
        {
            try
            {
                using (ExcelMain excel = new ExcelMain())
                {
                    if (excel.Open(path))
                    {
                        excel.Set(1, "A", "Группа");
                        excel.Set(1, "B", "Средняя оценка");
                        excel.Set(1, "C", "Минимальная оценка");
                        excel.Set(1, "D", "Максимальная оценка");

                        List<Group> groups = new CRUDFactory().GroupFactory().Select();
                        int i = 2;

                        foreach (var group in groups)
                        {
                            int[] grades = CountMaxMinAvrageGrade(group);

                            excel.Set(i, "A", group.GroupName);
                            excel.Set(i, "B", grades[0]);
                            excel.Set(i, "C", grades[1]);
                            excel.Set(i, "D", grades[2]);

                            i++;
                        }

                        excel.Save();
                        excel.Dispose();
                    }
                }
            }
            catch
            {
                Console.WriteLine("Table mistack");
            }
        }

        /// <summary>
        /// Count max, min and average grade for group.
        /// </summary>
        /// <param name="group">Group.</param>
        /// <returns>Array with min,max and average grade.</returns>
        private int[] CountMaxMinAvrageGrade(Group group)
        {
            List<Rows> rows = Rows.GetRows();

            int max = 0;
            int min = 11;
            int avrage = 0;
            int number = 0;

            foreach (var row in rows)
            {
                if (row.Group == group.GroupName)
                {
                    avrage += row.Grade;
                    number++;

                    if (max < row.Grade)
                    {
                        max = row.Grade;
                    }

                    if (min > row.Grade)
                    {
                        min = row.Grade;
                    }
                }
            }

            return new int[] { avrage / number, min, max };
        }

        /// <summary>
        /// Create table with expelled students.
        /// </summary>
        /// <param name="path"></param>
        public void CreateTableWithExpelledStudents(string path)
        {
            try
            {
                using (ExcelMain excel = new ExcelMain())
                {
                    if (excel.Open(path))
                    {
                        List<Rows> rows = FoundStudentsForExpelledStudents();

                        excel.Set(1, "A", "Date start session");
                        excel.Set(1, "B", "Date finish session");
                        excel.Set(1, "C", "Group");
                        excel.Set(1, "D", "Name");
                        excel.Set(1, "E", "Surname");
                        excel.Set(1, "F", "Gender");
                        excel.Set(1, "G", "Date birth");
                        excel.Set(1, "H", "Exam");
                        excel.Set(1, "I", "Exam date");
                        excel.Set(1, "J", "Grade");

                        int i = 2;
                        foreach (var row in rows)
                        {
                            excel.Set(i, "A", row.StartSession);
                            excel.Set(i, "B", row.FinishSession);
                            excel.Set(i, "C", row.Group);
                            excel.Set(i, "D", row.StudentsName);
                            excel.Set(i, "E", row.StudentsSurname);
                            excel.Set(i, "F", row.StudentsGender);
                            excel.Set(i, "G", row.StudentsDateBirth);
                            excel.Set(i, "H", row.ExamsTitle);
                            excel.Set(i, "I", row.ExamsDate);
                            excel.Set(i, "J", row.Grade);
                            i++;
                        }

                        excel.Save();
                        excel.Dispose();
                    }
                }
            }
            catch
            {
                Console.WriteLine("Table mistack");
            }
        }

        /// <summary>
        /// Found student for expalled students.
        /// </summary>
        /// <returns>Return all students, who have grade less then 4.</returns>
        private List<Rows> FoundStudentsForExpelledStudents()
        {
            List<Rows> students = Rows.GetRows();
            List<Rows> studentsForExpalled = new List<Rows>();

            foreach (var student in students) 
            {
                if(student.Grade < 4)
                {
                    studentsForExpalled.Add(student);
                }
            }

            students.Distinct();
            return studentsForExpalled;
        }
    }
}
