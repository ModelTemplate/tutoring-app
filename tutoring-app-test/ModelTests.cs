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

            Assert.True(student.FirstName + " " + student.LastName == expected);
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

            Assert.True(tutor.FirstName + " " + tutor.LastName == expected);
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
        [InlineData("Algebra 1", "Algebra 1")]
        [InlineData("English Composition", "English Composition")]
        [InlineData("Java Programming", "Java Programming")]
        public void CorrectSubjects(string name, string expected)
        {
            Subject subject = new Subject();
            subject.Name = name;

            Assert.True(subject.Name == expected);
        }
    }
}
