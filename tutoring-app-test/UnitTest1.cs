using System;
using Xunit;

using tutoring_app.Models;

namespace tutoring_app_test
{
    public class StudentTests
    {
        [Fact]
        public void DefaultName()
        {
            Student student = new Student();
            Assert.True(student.FirstName == "");
        }

        [Theory]
        [InlineData("Billy", "Watson", "Billy Watson")]
        [InlineData("", "Wtson", " Wtson")]
        [InlineData("(*^$^$^", "$&@)(@", "(*^$^$^ $&@)(@")]
        public void CorrectStudentFullName(string first, string last, string expected)
        {
            Student student = new Student();
            student.FirstName = first;
            student.LastName = last;

            Assert.True(student.FullName() == expected);
        }
    }

    public class TutorTests
    {
        [Fact]
        public void DefaultName()
        {
            Tutor tutor = new Tutor();
            Assert.True(tutor.FirstName == "");
        }

        [Theory]
        [InlineData("Billy", "Watson", "Billy Watson")]
        [InlineData("", "Wtson", " Wtson")]
        [InlineData("(*^$^$^", "$&@)(@", "(*^$^$^ $&@)(@")]
        public void CorrectTutorFullName(string first, string last, string expected)
        {
            Tutor tutor = new Tutor();
            tutor.FirstName = first;
            tutor.LastName = last;

            Assert.True(tutor.FullName() == expected);
        }
    }

    public class SubjectTests
    {
        [Fact]
        public void DefaultName()
        {
            Subject subject = new Subject();
            Assert.True(subject.Name == "");
        }

        [Theory]
        [InlineData("Math", 1, "Math 1")]
        [InlineData("English", 0, "English 0")]
        [InlineData("Java", 99, "Java 99")]
        public void CorrectSubjects(string name, int level, string expected)
        {
            Subject subject = new Subject();
            subject.Name = name;
            subject.Level = level;

            Assert.True(subject.SubjectInfo() == expected);
        }
    }


}