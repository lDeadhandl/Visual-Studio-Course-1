using System;
using System.Collections.Generic;
using System.IO;
using System.Speech.Synthesis;

namespace Grades
{
    class Program
    {
        static void Main() // strah why do I have to use static? 
        {
            IGradeTracker book = CreateGradebook();

            // "mew" invokes a constructor to create a new object
            //Gradebook book = new Gradebook("Stef's book");
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75f);
         

            string[] lines = File.ReadAllLines("grades.txt");
            foreach(string line in lines)
            {
                float grade = float.Parse(line);
                book.AddGrade(grade);
            }

            try
            {
                //Console.WriteLine("Please enter a name");
                //book.Name = Console.ReadLine();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid Name");
            }
            //variable book2 is pointing to same object as book 
            //varibables can point to one object while also pointing to their own distinct
            //object
            //Gradebook book2 = book;
            //book2.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();

            
            

            book.NameChanged += OnNameChanged;
            book.NameChanged += OnNameChanged;
            book.NameChanged += OnNameChanged2;
            book.NameChanged -= OnNameChanged;
            //new addition below conflicts with the subscribers of the event 
            //to fix: add "event" in front of Delegate field
            //book.NameChanged = new NameChangedDelegate(OnNameChanged);
            book.Name = "Strah's book";
            WriteNames(book.Name);

            Console.WriteLine(stats.AverageGrade);
            Console.WriteLine(stats.HighestGrade);
            Console.WriteLine(stats.LowestGrade);

            //StringCompare();
            //Immutable();
            //Arrays1();
            //Arrays2();   

            //Adding a new reference, System.speech I was able to use speech synthesizer that 
            //says things!
            SpeechSynthesizer talk = new SpeechSynthesizer();
            talk.Speak("Hello, Bozica");

            //Size of array must be a constant integer value
            //An array is a reference type... unlike a struct or enum which are value types
            const int numberOfStudents = 4;
            int[] scores = new int[numberOfStudents];

            int totalScore = 0;
            foreach (int score in scores)
            {
                totalScore += score;
            }
        }

        public static IGradeTracker CreateGradebook()
        {
            IGradeTracker book = new ThrowAwayGradebook("Scott's book");
            return book;
        }

        private static void OnNameChanged2(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("****");
        }

        private static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("Name changed from {0} to {1}", args.OldValue, args.NewValue);
        }

        private static void WriteNames(params string[] names)
        {
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }

        private static void Immutable()
        {
            //Value types such as string are immutable, meaning that their value cannot be changed
            //due to this fact I cannot trim the name directly I must assign it again to a variable
            //"name" after trimming it
            string name = " Scott ";
            name = name.Trim();
            Console.WriteLine(name);

        }

        private static void StringCompare()
        {
            //I'm having fun
            string name1 = "Scott";
            string name2 = "scott";

            //Comparing 2 strings without worrying about case sensitivity
            bool areEqual = name1.Equals(name2, StringComparison.CurrentCultureIgnoreCase);

            Console.WriteLine(areEqual);
        }

        private static void Arrays2()
        {
            //an array of floats
            float[] grades;
            grades = new float[3];

            AddGrades(grades);

            foreach (float grade in grades)
            {
                Console.WriteLine(grade);
            }
        }
        private static void AddGrades(float[] grades)
        {

            if (grades.Length >= 3)
            {
                grades[0] = 91f;
                grades[1] = 89.1f;
                grades[2] = 75f;
            }
        }


    }

}
    

       
// Objects are nouns
// Methods are verbs
// Objects encapsulate functionality
