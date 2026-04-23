using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Single_responsibility_principe
{
    public class StudentRepository
    {
        private readonly AppDbContext _appDbContext;
        public StudentRepository(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }


        public void AddStudent(string name, int age, string favoriteSubject) {
            var newStudent = new Student
            {
                Name = name,
                Age = age,
                FavoriteSubject = favoriteSubject
            };
            _appDbContext.Students.Add(newStudent);
            _appDbContext.SaveChanges();
            
        }
        public bool DeleteStudent(int id) {
            var deleteStudent = _appDbContext.Students.Find(id);

            if(deleteStudent != null)
            {
                _appDbContext.Students.Remove(deleteStudent);
                _appDbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public List<Student> GetAllStudents() {
            return _appDbContext.Students.ToList();
        }
    }
}
