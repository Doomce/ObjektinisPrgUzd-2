using System;
using System.Collections.Generic;

namespace WindowsFormsApp5.Registration
{
    public class Student : User
    {
        public List<Subject> Subjects { get; } = new List<Subject>();

        public Student(string name, string surname) : base(name, surname) { }

        public void SetSubjectGrade(string subjectName, int grade)
        {
            Subjects.Add(new Subject()
            {
                Name = subjectName,
                Grade = grade
            });
        }
        
        public string GetGrades()
        {
            var messageText = String.Join("\n", Subjects.ConvertAll<string>(
                subject => $"{subject.Name} -> {subject.Grade}"));
            return messageText;
        }
        
    }
}