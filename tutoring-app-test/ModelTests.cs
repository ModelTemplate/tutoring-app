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
        [InlineData("2017-12-31", 45, "default  45")]
           // [InlineData("2017-12-31", 40, "2017-12-31  40")]
           // [InlineData("2017-12-31", 10, "2017-12-31  10")]
        public void CorrectCreatScheduleViewModel(string date, int subId, string expected)
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
            Assert.True(quoteApiModel.author == null);
        }

        [Theory]
        [InlineData("Jane", "Content1", "Jane Content1")]
        [InlineData("Bob", "Content2", "Bob Content2")]
        [InlineData("Beth", "Content3", "Beth Content3")]
        public void correctQuoteApiModelInfo(string author, string content, string expected)
        {
            QuoteApiModel quoteApiModel = new QuoteApiModel();
            quoteApiModel.author = author;
            quoteApiModel.content = content;
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
            Assert.True(schedule.Date == new DateTime(01 / 01 / 0001));
        }

            [Theory]
            [InlineData("2020-12-12", "2020-12-12")]
            [InlineData("2020-12-08", "2020-12-08")]
            [InlineData("2020-12-01", "2020-12-01")]
        public void CorrectScheduleTest(string date, string expected)
        {
            var expDate = DateTime.Parse(date);
            Schedule schedule = new Schedule();
            schedule.Date = expDate;

            Assert.True(condition:schedule.ScheduleInfo() == expected);
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

    /// <summary>
    /// Test for UserRegisterationViewModel
    /// Fact - validate Name
    /// Theory - validate for correct UserRegistrationViewModel info
    /// </summary>
    public class UserRegistrationViewModelTest
    {
        [Fact]
        public void DefaultName()
        {
            UserRegistrationViewModel userRegistrationViewModel = new UserRegistrationViewModel();
            Assert.True(userRegistrationViewModel.FirstName == null);
        }
        [Theory]
        [InlineData("Bob",  "Jones", "Bob Jones")]
        [InlineData("Sarah", "Smith","Sarah Smith")]
        [InlineData("Jo", "smith", "Jo Smith")]
         
        public void CorrectUserRegistrationViewModel(string firstName, string lastName, string expected)
        {
            
            UserRegistrationViewModel userRegistrationViewModel = new UserRegistrationViewModel();
            userRegistrationViewModel.FirstName = firstName;
            userRegistrationViewModel.LastName = lastName;

            Assert.True(userRegistrationViewModel.FullName() == expected);
            
        }
    }
}
