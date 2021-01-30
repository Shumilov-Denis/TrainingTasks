using University;

namespace CRUD
{
    /// <summary>
    /// CRUD factory.
    /// </summary>
    public class CRUDFactory
    {
        /// <summary>
        /// Exam factory.
        /// </summary>
        /// <returns>Exam CRUD.</returns>
        public ICRUD<Exam> ExamFactory()
        {
            return new ExamCRUD();
        }

        /// <summary>
        /// Student factory.
        /// </summary>
        /// <returns>Student CRUD.</returns>
        public ICRUD<Student> StudentFactory()
        {
            return new StudentCRUD();
        }

        /// <summary>
        /// Group factory.
        /// </summary>
        /// <returns>Group CRUD.</returns>
        public ICRUD<Group> GroupFactory()
        {
            return new GroupCRUD();
        }

        /// <summary>
        /// Session factory.
        /// </summary>
        /// <returns>Session CRUD.</returns>
        public ICRUD<Session> SessionFactory()
        {
            return new SessionCRUD();
        }

        /// <summary>
        /// Result factory.
        /// </summary>
        /// <returns>Result CRUD.</returns>
        public ICRUD<Result> ResultFactory()
        {
            return new ResultCRUD();
        }
    }
}
