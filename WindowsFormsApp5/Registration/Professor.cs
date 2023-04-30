using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApp5.Registration
{
    public class Professor : User
    {
        private List<Subject> Subjects { get; } = new List<Subject>();
        
        public Professor(string name, string surname) : base(name, surname)
        {
        }


        public void AddSubject(string subName)
        {
            if (Subjects.Any(subject => subject.Name == subName)) return;
            Subjects.Add(new Subject(){Name = subName});
        }

        public Subject GetSubject(string subName)
        {
            var subj = Subjects.Find(subject => subject.Name == subName);
            if (String.IsNullOrEmpty(subj.Name)) return null;
            return subj;
        }
        
        public List<string> GetAllowedSubjects()
        {
            return Subjects.ConvertAll(input => input.Name);
        }
        
    }
}