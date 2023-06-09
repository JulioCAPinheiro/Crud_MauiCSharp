﻿
using CrudMaui.Model;
using CrudMaui.Services;
using GalaSoft.MvvmLight.Command;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.ViewModels
{
    [QueryProperty(nameof(StudentDetail), "StudentDetail")]
    public partial class AddUpdateStudentDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private StudentModel _studentDetail = new StudentModel();

        private readonly IStudentService _studentService;
        public AddUpdateStudentDetailViewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [ICommand]
        public async void AddUpdateStudent()
        {
            int response = -1;
            if(StudentDetail.StudentID > 0)
            {
                response = await _studentService.UpdateStudent(StudentDetail);
            }
            else
            {
                response = await _studentService.AddStudent(new StudentModel
                {
                    Email = StudentDetail.Email,
                    FirstName = StudentDetail.FirstName,
                    LastName = StudentDetail.LastName,
                });
            }
           

            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Student Info Saved", "Record Saved", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding record", "OK");
            }
        }

    }
}