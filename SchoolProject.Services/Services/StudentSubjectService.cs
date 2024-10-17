using SchoolProject.Data.Entities;
using SchoolProject.Infrustructure.StudentSubjectRepositories;
using SchoolProject.Services.AbstractionServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Services
{
    public class StudentSubjectservice(IStudentSubjectRepository studentSubjectRepository) : IStudentSubjectservice
    {
        public async Task<StudentSubject> AddAsync(StudentSubject Entity)
        {
           var IsExsist = await studentSubjectRepository.GetOneAsync(x => x.SubId == Entity.SubId &&
           x.StuId == Entity.StuId);
            if(IsExsist == null) 
            {
                return null!;
            }
           var studentSubject =  await studentSubjectRepository.AddAsync(Entity);
           return studentSubject;
        }

        public async Task<ICollection<StudentSubject>> AddRangeAsync(ICollection<StudentSubject> Entities)
        {
            var studentSubjectList = await studentSubjectRepository.AddRangeAsync(Entities);
            return studentSubjectList;
        }
    }
}
