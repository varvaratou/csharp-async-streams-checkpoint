using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsharpAsyncStreamsCheckpoint
{
    [TestClass]
    public class TestsBefore
    {

        [TestMethod]
        public async Task Test1()
        {
            string result = "";
            await foreach (var student in GetStudentsAsync())
            {
                result = result + ($"{student.FirstName} {student.LastName} - ");
            }

            Assert.AreEqual("John Doe - Jane Doe - John Smith - ", result);
        }

        static async IAsyncEnumerable<Student> GetStudentsAsync()
        {
            var studentList = new List<Student>()
            {
                new Student() {FirstName = "John", LastName = "Doe", Email = "john.doe@gmail.com", Grade = 'A'},
                new Student() {FirstName = "Jane", LastName = "Doe", Email="jane.doe@galvanize.com", Grade = 'B'},
                new Student() {FirstName = "John", LastName = "Smith", Email = "john.smith@galvanize.com", Grade = 'C'}
            };
            foreach(var student in studentList)
            {
                await Task.Delay(300);
                yield return student;
            } 
        }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public char Grade { get; set; }
    }
}