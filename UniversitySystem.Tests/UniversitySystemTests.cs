using UniversitetsSystem;
using Xunit;

namespace UniversitetsSystem.Tests
{
    public class UniversitySystemTests
    {
        [Fact]
        public void EnrollStudent_ShouldNotAllowSameStudentTwiceInSameCourse()
        {
            Student student = new Student("S100", "Ola Nordmann", "ola@uia.no", "ola", "1234");
            Course course = new Course("IS-110", "Programmering 1", 10, 30);

            bool firstEnroll = course.EnrollStudent(student);
            bool secondEnroll = course.EnrollStudent(student);

            Assert.True(firstEnroll);
            Assert.False(secondEnroll);
            Assert.Single(course.Students);
        }

        [Fact]
        public void AddCourse_ShouldNotAllowDuplicateCourseCodeOrName()
        {
            UniversitySystem system = new UniversitySystem();

            Course course1 = new Course("IS-110", "Programmering 1", 10, 30);
            Course course2 = new Course("IS-110", "Databaser", 10, 25);
            Course course3 = new Course("IS-120", "Programmering 1", 10, 25);

            bool firstAdd = system.AddCourse(course1);
            bool duplicateCode = system.AddCourse(course2);
            bool duplicateName = system.AddCourse(course3);

            Assert.True(firstAdd);
            Assert.False(duplicateCode);
            Assert.False(duplicateName);
            Assert.Single(system.Courses);
        }

        [Fact]
        public void BorrowAndReturnBook_ShouldUpdateAvailableCopiesCorrectly()
        {
            Book book = new Book("B100", "C# for Beginners", "A. Hansen", 2023, 3);

            bool borrowed = book.BorrowCopy();
            int afterBorrow = book.AvailableCopies;

            book.ReturnCopy();
            int afterReturn = book.AvailableCopies;

            Assert.True(borrowed);
            Assert.Equal(2, afterBorrow);
            Assert.Equal(3, afterReturn);
        }
    }
}