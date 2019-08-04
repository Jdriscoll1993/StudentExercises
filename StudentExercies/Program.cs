using StudentExercies.Data;
using StudentExercises.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();

            List<Exercise> exercises = repository.GetAllExercises();
            PrintExercises("All Exercises", exercises);

            Pause();

            List<Exercise> javascriptExercises = repository.GetAllExercisesByLanguage("Javascript");
            PrintExercises("All Javascript Exercises", javascriptExercises);

            Pause();

            Exercise newExercise = new Exercise()
            {
                ExerciseName = "Reverse The String",
                ProgramLanguage = "Javascript"
            };

            var javascriptExercises2 = repository.GetAllExercisesByLanguage("Javascript");
            PrintExercises("All Javascript Exercises After Reverse String:", javascriptExercises2);

            Pause();

            List<Instructor> instructors = repository.GetInstructors();
            PrintInstructors("All Instructors:", instructors);

            Pause();

            Instructor newInstructor = new Instructor()
            {
                FirstName = "Steve",
                LastName = "Brownlee",
                SlackHandle = "coach",
                Specialty = "Being good at everything",
                CohortId = 2
            };
            List<Instructor> instructors2 = repository.GetInstructors();
            PrintInstructors("Instructors after Steve:", instructors2);


            Pause();

            var studentsAndExercises = repository.GetAllStudentsAndExercises();
            PrintStudentsAndExercises("All students and exercises:", studentsAndExercises);

        }

        public static void PrintExercises(string str, List<Exercise> exercises)
        {
            Console.WriteLine(str);
            exercises.ForEach(exer =>
            {
                Console.WriteLine($"{exer.Id}. {exer.ExerciseName} in {exer.ProgramLanguage}");
            });
        }
        public static void PrintInstructors(string str, List<Instructor> instructors)
        {
            Console.WriteLine(str);
            instructors.ForEach(instr =>
            {
                Console.WriteLine($"{instr.Id}. {instr.FirstName} {instr.LastName} - in Cohort {instr.Cohort.CohortName}");
            });
        }
        public static void PrintStudentsAndExercises(string str, List<Student> students)
        {
            Console.WriteLine(str);
            students.ForEach(student =>
            {
                Console.WriteLine($"{student.Id}. {student.FirstName} {student.LastName} - in Cohort {student.Cohort.CohortName}");
                Console.WriteLine($"{student.FirstName}'s Current Exercises:");
                student.CurrentExercises.ForEach(exercise => Console.WriteLine($"{exercise.ExerciseName}"));
            });
        }
        public static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
