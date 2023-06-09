using CrudMaui.Model;
using CrudMaui.Services;
using CrudMaui.Views;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudMaui.ViewModel
{
    public partial class StudentListPageVIewModel : ObservableObject
    {
        public ObservableCollection<StudentModel> Students { get; set; } = new ObservableCollection<StudentModel>();

        private readonly IStudentService _studentService;
        public StudentListPageVIewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }


        [ICommand]
        public async void GetStudentsList()
        {
            var studentList = await _studentService.GetStudentList();
            if (studentList?.Count > 0)
            {
                Students.Clear();
                foreach (var student in studentList)
                {
                    Students.Add(student);
                }
            }
        }

        [ICommand]
        public async void AddUpdateStudante()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateStudent));
        }

        [ICommand]
        public async void DisplayAction(StudentModel studentModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "Ok", null, "Edit","Delete");
            if(response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("StudentDetail", studentModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateStudent),navParam);
            }
            else if(response == "Delete")
            {
               var delResponse = await _studentService.DeleteStudent(studentModel);
                if(delResponse > 0)
                {
                    GetStudentsList();
                }
            }
        }
    }
}
