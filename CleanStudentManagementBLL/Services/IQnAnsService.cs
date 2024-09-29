using CleanStudentManagementModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagementBLL.Services
{
    public interface IQnAnsService
    {
        void Add(QAnsViewModel createQAnsView);
        PageResult<QAnsViewModel> GetAllQans(int pagenumber,int pagesize);
        bool IsAttendExam(int ExamId, int Studentid);
        IEnumerable<QAnsViewModel> GetAllByExamId(int examid);
        bool SetExamResult(StudentAttendanceViewModel studentAttendance);
    }
}
