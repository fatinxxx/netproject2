using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using global::netproject2.Commands;
using global::netproject2.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace netproject2.ViewModels
{


    public class SubjectDashboardViewModel : INotifyPropertyChanged
    {
        public Subject SelectedSubject { get; set; } // The selected subject passed from the previous window

        public ICommand ModifyCommand { get; }
        public ICommand CalculateGradeCommand { get; }

        public SubjectDashboardViewModel(Subject selectedSubject)
        {
            SelectedSubject = selectedSubject;
            ModifyCommand = new RelayCommand(ModifySubjectDetails);
            CalculateGradeCommand = new RelayCommand(CalculateGrade);
        }

        // Modify the subject details (accepts object as parameter)
        private void ModifySubjectDetails(object parameter)
        {
            // Logic to modify the subject
        }

        // Calculate final grade for the assignments (accepts object as parameter)
        private void CalculateGrade(object parameter)
        {
            // Logic to calculate final grade based on assignment grades
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}