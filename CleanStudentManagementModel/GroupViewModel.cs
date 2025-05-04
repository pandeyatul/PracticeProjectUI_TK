using CleanArchitectureStudentData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagementModel
{
    public class GroupViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; } = string.Empty;
        public GroupViewModel()
        {
            
        }
        public GroupViewModel(Groups groups)
        {
            Id = groups.Id;
            Name= groups.Name;
            Description= groups.Description;
        }
        public Groups ConvertToGroup(GroupViewModel groupView)
        {
            return new Groups
            {
                Id= groupView.Id,
                Name= groupView.Name,
                Description= groupView.Description,
            };
        }
    }
}
