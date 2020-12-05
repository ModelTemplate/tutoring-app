using System;
using Xunit;

using tutoring_app.Models;

namespace tutoring_app_test
{
    /// <summary>
    /// Test CreateScheduleViewModel
    /// Fact - test CreateScheduleViewModel Date
    /// Theory - validate correctsome possibilities
    /// </summary>
    public class CreateScheduleViewModelTest
    {
        [Fact]
        public void TestDate()
        {
            CreateScheduleViewModel createScheduleViewModel = new CreateScheduleViewModel();
            //Assert.True(createScheduleViewModel.Date == new DateTime(01/01/0001));
            Assert.True(createScheduleViewModel.Date == default);
        }

        [Theory]
        [InlineData("2020-12-20", 45, "{12/20/2020 12:00:00 AM} 45")]
        [InlineData("2017-12-31", 40, "{12/31/2017 12:00:00 AM} 40")]
        [InlineData("2017-12-31", 10, "{12/31/2017 12:00:00 AM} 10")]
        public void CorrectCreateScheduleViewModel(string date, int subId, string expected)
        {
            CreateScheduleViewModel createScheduleViewModel = new CreateScheduleViewModel();
            var expDate = DateTime.Parse(date);
            createScheduleViewModel.Date = expDate;
            createScheduleViewModel.SelectedSubjectId = subId;
            Assert.True(createScheduleViewModel.CreateScheduleConcate() == expected);
        }
    }

    /// <summary>
    /// Test for QuoteApiModel
    /// Fact - test QuoteApiModel Author
    /// Theory - test QuoteApiModelInfo
    ///</summary>
    public class QuoteApiModelTest
    {
        [Fact]
        public void AuthorName()
        {
            QuoteApiModel quoteApiModel = new QuoteApiModel();
            Assert.True(quoteApiModel.Author == null);
        }

        [Theory]
        [InlineData("Jane", "Content1", "Jane Content1")]
        [InlineData("Bob", "Content2", "Bob Content2")]
        [InlineData("Beth", "Content3", "Beth Content3")]
        public void correctQuoteApiModelInfo(string author, string content, string expected)
        {
            QuoteApiModel quoteApiModel = new QuoteApiModel();
            quoteApiModel.Author = author;
            quoteApiModel.Content = content;
            Assert.True(quoteApiModel.QuoteApiModelInfo() == expected);
        }
    }

    /// <summary>
    /// Test Schedule Model    
    /// Fact - validate Schedule Date
    /// Theory - validate some other possibilities
    /// </summary>    
    public class ScheduleTests
    {
            [Fact]
        public void TestDate()
        {
            Schedule schedule = new Schedule();
            //Assert.True(schedule.Date == new DateTime(01 / 01 / 0001));
            Assert.True(schedule.Date == default);
        }

        [Theory]
        [InlineData("01/01/0001", "1/1/0001 12:00:00 AM")]
        [InlineData("2020-12-08", "12/8/2020 12:00:00 AM")]
        [InlineData("2020-12-01", "12/1/2020 12:00:00 AM")]
        public void CorrectScheduleTest(string date, string expected)
        {
            var expDate = DateTime.Parse(date);
            Schedule schedule = new Schedule();
            schedule.Date = expDate;

            Assert.True(schedule.ScheduleInfo() == expected);
        }
    }

    /// <summary>
    /// Test Studednt Model
    /// Fact - validate Student Name
    /// Theory - validate for correct student info
    /// </summary>
    public class StudentTests
    {
        [Fact]
        public void DefaultName()
        {
            Student student = new Student();
            Assert.True(student.FirstName == null);
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

    /// <summary>
    /// Test for UserRegisterationViewModel
    /// Fact - validate Subject Name
    /// Theory - validate for correct Subject info
    /// </summary>
    public class SubjectTests
    {
        [Fact]
        public void DefaultName()
        {
            Subject subject = new Subject();
            Assert.True(subject.Name == null);
        }

        [Theory]
        [InlineData("Math", 1, "Math 1")]
        [InlineData("English", 2, "English 2")]
        [InlineData("Java", 9, "Java 9")]
        public void CorrectSubjects(string name, int level, string expected)
        {
            Subject subject = new Subject();
            subject.Name = name;
            subject.Level = level;

            Assert.True(subject.SubjectInfo() == expected);
        }
    }

    /// <summary>
    /// Test for Tutor
    /// Fact - validate Tutor Name
    /// Theory - validate for correct Tutor info
    /// </summary>
    public class TutorTests
    {
        [Fact]
        public void DefaultName()
        {
            Tutor tutor = new Tutor();
            Assert.True(tutor.FirstName == null);
        }

        [Theory]
        [InlineData("Billy", "Watson", "Billy Watson")]
        [InlineData("Joe", "Smith", "Joe Smith")]
        [InlineData("Larry", "Simons", "Larry Simons")]
        public void CorrectTutorFullName(string first, string last, string expected)
        {
            Tutor tutor = new Tutor();
            tutor.FirstName = first;
            tutor.LastName = last;

            Assert.True(tutor.FullName() == expected);
        }
    }
}
