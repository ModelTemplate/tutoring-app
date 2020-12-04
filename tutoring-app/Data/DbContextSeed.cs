using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using tutoring_app.Data;
using tutoring_app.Models;

namespace tutoring_app.Data
{
    /// <summary>
    /// Seeding the database with these default subjects
    /// </summary>
    public static class DbContextSeed
    {
        public async static Task Initialize(ApplicationDbContext context)
        {
            await SeedSubjects(context);
            await SeedStudents(context);
            await SeedTutors(context);
        }

        private async static Task SeedSubjects(ApplicationDbContext context)
        {
            // Look for any subjects
            if (context.Subjects.Any())
            {
                return; // DB has been seeded
            }

            context.Subjects.AddRange(
                new Subject
                {
                    Id = 0,
                    Name = "Calculus 1",
                    Description = "Derivatives, differentiation techniques, optimization, definite integral, and the Fundamental Theorem of Calculus."
                },

                new Subject
                {
                    Id = 1,
                    Name = "Calculus 2",
                    Description = "Integration techniques, application of integrals, parametric equations, polar coordinates, series and sequences, vectors, and 3D spaces."
                },

                new Subject
                {
                    Id = 2,
                    Name = "Biology",
                    Description = "Function of macromolecules, cellular respiration, photosynthesis, genetics, cell reproduction, DNA structure and synthesis, and genetic expression."
                },

                new Subject
                {
                    Id = 3,
                    Name = "Computer Programming 1",
                    Description = "Algorithms, control structures, data types, variables, array traversal, and functions."
                },

                new Subject
                {
                    Id = 4,
                    Name = "English Composition",
                    Description = "Thesis writing, textual analysis, summary writing, argumentative writing, and literary analysis."
                },

                new Subject
                {
                    Id = 5,
                    Name = "Physics 1",
                    Description = "Forces, energy, laws of motion, oscillatory motion, and gravity."
                }
            );
            context.SaveChanges();
        }

        private async static Task SeedStudents(ApplicationDbContext context)
        {
            // Look for any students
            if (context.Students.Any())
            {
                return; // DB has been seeded
            }

            context.Students.AddRange(
                new Student
                {
                    Id = 0,
                    FirstName = "Sam",
                    LastName = "Fisher",
                    Email = "samfisher@email.com",
                },

                new Student
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Smith",
                    Email = "johnsmith@localhost",
                },

                new Student
                {
                    Id = 2,
                    FirstName = "Mary",
                    LastName = "Jane",
                    Email = "MaryJane1999@domain.com",
                },

                new Student
                {
                    Id = 3,
                    FirstName = "Jeff",
                    LastName = "Bezos",
                    Email = "bezosJeff@amazon.com",
                },

                new Student
                {
                    Id = 4,
                    FirstName = "Laura",
                    LastName = "Croft",
                    Email = "croft@laura.com",
                }
            );
            context.SaveChanges();
        }

        private async static Task SeedTutors(ApplicationDbContext context)
        {
            // Look for any tutors
            if (context.Tutors.Any())
            {
                return; // DB has been seeded
            }

            context.Tutors.AddRange(
                new Tutor
                {
                    Id = 0,
                    FirstName = "Snow",
                    LastName = "White",
                    Email = "snowwhite@tutor.com",
                },

                new Tutor
                {
                    Id = 1,
                    FirstName = "Davey",
                    LastName = "Jones",
                    Email = "djones@tutor.com",
                },

                new Tutor
                {
                    Id = 2,
                    FirstName = "Mary",
                    LastName = "Poppins",
                    Email = "Poppins@tutor.com",
                },

                new Tutor
                {
                    Id = 3,
                    FirstName = "Emily",
                    LastName = "Bronte",
                    Email = "emilyBronte@tutor.com",
                },

                new Tutor
                {
                    Id = 4,
                    FirstName = "Bill",
                    LastName = "Gates",
                    Email = "TheBillGates@tutor.com",
                }
            );
            context.SaveChanges();
        }
    }
}
