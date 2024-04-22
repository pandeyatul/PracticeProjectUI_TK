using Entities_TK;
using Entities_TK.Interface;
using Microsoft.AspNetCore.Mvc;
using PracticeProjectUI_TK.Models.ViewModels;

namespace PracticeProjectUI_TK.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent _student;
        private readonly ISkill _skill;
        public StudentController(IStudent student, ISkill skill)
        {
            _student = student;
            _skill = skill;
        }

        public async Task<IActionResult> Index()
        {
            var studentlist = await _student.GetAllStudent();
            List<StudentViewModel> studentinfo = new List<StudentViewModel>();
            foreach (var item in studentlist)
            {
                var students = new StudentViewModel()
                {
                    ID = item.Id,
                    Student_Name = item.Name ?? string.Empty,
                };
                studentinfo.Add(students);
            }
            return View(studentinfo);
        }
        public async Task<IActionResult> StudentDetail(int id)
        {
            var students = await _student.GetStudentById(id);
            var skillitems = await _skill.GetAllSkills();
            var studentinfo = new CreateStudentViewModel()
            {
                Id = students.Id,
                Student_name = students.Name ?? string.Empty,
                Permanent_Address = students.PermanentAddress,
            };
            var selectedskillids = students.StudentSkills.Select(n => n.SkillId);
            foreach (var skl in selectedskillids)
            {
                List<string?> skillnames = skillitems.Where(y => y.Id == skl).Select(s => s.Name).ToList();
                foreach (var name in skillnames)
                {
                    var skillinfo = new CheckBoxTable()
                    {
                        SkillName = name ?? string.Empty
                    };
                    studentinfo.Skilllist.Add(skillinfo);
                }
            }
            return View(studentinfo);
        }
        public async Task<IActionResult> CreateStudent()
        {
            CreateStudentViewModel vm = new CreateStudentViewModel();
            var skills = await _skill.GetAllSkills();
            foreach (var item in skills)
            {
                vm.Skilllist.Add(new CheckBoxTable
                {
                    Skillid = item.Id,
                    SkillName = item.Name ?? string.Empty,
                    IsChecked = false
                });
            }
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentViewModel csvm)
        {
            if (ModelState.IsValid)
            {
                var studentdata = new Student()
                {
                    Name = csvm.Student_name,
                    PermanentAddress = csvm.Permanent_Address
                };
                var selectedSkillIds = csvm.Skilllist.Where(c => c.IsChecked == true).Select(s => s.Skillid);
                foreach (var ids in selectedSkillIds)
                {
                    studentdata.StudentSkills.Add(new StudentSkill
                    {
                        SkillId = ids
                    });
                }
                await _student.CreateStudent(studentdata);
                return RedirectToAction("index");
            }
            // return RedirectToAction("CreateStudent");
            return View(csvm);
        }
        [HttpGet]
        public async Task<IActionResult> EditStudent(int id)
        {
            CreateStudentViewModel csvm = new CreateStudentViewModel();
            var studentdata = await _student.GetStudentById(id);
            csvm.Student_name = studentdata.Name ?? string.Empty;
            csvm.Permanent_Address = studentdata.PermanentAddress;
            var skills = await _skill.GetAllSkills();
            var selectedskillIds = studentdata.StudentSkills.Select(s => s.SkillId).ToList();
            foreach (var item in skills)
            {
                var skillinfo = new CheckBoxTable()
                {
                    Skillid = item.Id,
                    SkillName = item.Name ?? string.Empty,
                    IsChecked = selectedskillIds.Contains(item.Id)
                };
                csvm.Skilllist.Add(skillinfo);
            }
            return View(csvm);
        }
        [HttpPost]
        public async Task<IActionResult> EditStudent(CreateStudentViewModel createStudent)
        {
            var student = await _student.GetStudentById(createStudent.Id);
            var existing_SkillId = student.StudentSkills.Select(s => s.SkillId).ToList();
            var selected_SkillId = createStudent.Skilllist.Where(c => c.IsChecked == true).Select(x => x.Skillid).ToList();
            student.Name = createStudent.Student_name;
            student.PermanentAddress = createStudent.Permanent_Address;
            var toRemove = existing_SkillId.Except(selected_SkillId).ToList();
            var toAdd = selected_SkillId.Except(existing_SkillId).ToList();
            foreach (var skillid in toRemove)
            {
                var studentdata = student.StudentSkills.FirstOrDefault(s => s.SkillId == skillid);
                if (studentdata != null)
                {
                    student.StudentSkills.Remove(studentdata);
                }
            }
            foreach (var skillids in toAdd)
            {
                student.StudentSkills.Add(new StudentSkill()
                {
                    SkillId = skillids,
                });
            }
            await _student.UpdateStudent(student);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Remove_Student(int id)
        {
            await _student.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}
