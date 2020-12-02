using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using tutoring_app.Data;
using tutoring_app.Models;

namespace tutoring_app.Data
{
    public static class ContextSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any subjects
                if (context.Subjects.Any())
                {
                    return;   // DB has been seeded
                }

                context.Subjects.AddRange(
                    new Subject
                    {
                        Id = "0",
                        Name = "Calculus 1",
                        Description = "Derivatives, differentiation techniques, optimization, definite integral, and the Fundamental Theorem of Calculus."
                    },

                    new Subject
                    {
                        Id = "1",
                        Name = "Calculus 2",
                        Description = "Integration techniques, application of integrals, parametric equations, polar coordinates, series and sequences, vectors, and 3D spaces."
                    },

                    new Subject
                    {
                        Id = "2",
                        Name = "Biology",
                        Description = "Function of macromolecules, cellular respiration, photosynthesis, genetics, cell reproduction, DNA structure and synthesis, and genetic expression."
                    },

                    new Subject
                    {
                        Id = "3",
                        Name = "Computer Programming 1",
                        Description = "Algorithms, control structures, data types, variables, array traversal, and functions."
                    },

                    new Subject
                    {
                        Id = "4",
                        Name = "English Composition",
                        Description = "Thesis writing, textual analysis, summary writing, argumentative writing, and literary analysis."
                    },

                    new Subject
                    {
                        Id = "5",
                        Name = "Physics 1",
                        Description = "Forces, energy, laws of motion, oscillatory motion, and gravity."
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
