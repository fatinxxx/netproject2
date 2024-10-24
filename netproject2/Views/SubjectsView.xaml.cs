using netproject2.Models;
using netproject2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace netproject2.Views
{
    /// <summary>
    /// Interaction logic for SubjectsView.xaml
    /// </summary>
    public partial class SubjectsView : Window
    {
        private User _loggedInUser;

        public SubjectsView(User loggedInUser)
        {
            InitializeComponent();
            _loggedInUser = loggedInUser;

            // Pass the logged-in user to the ViewModel
            DataContext = new SubjectsViewModel(_loggedInUser);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lstSubjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstSubjects.SelectedItem is Subject selectedSubject)
            {
                // Open the SubjectDashboard window and pass the selected subject
                var subjectDashboard = new SubjectDashboard
                {
                    DataContext = new SubjectDashboardViewModel(selectedSubject) // Pass the selected subject
                };
                subjectDashboard.Show();
            }
        }
        private void lstSubjects_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstSubjects.SelectedItem is Subject selectedSubject)
            {
                // Open the SubjectDashboard window and pass the selected subject
                var subjectDashboard = new SubjectDashboard
                {
                    DataContext = new SubjectDashboardViewModel(selectedSubject) // Pass the selected subject
                };
                subjectDashboard.Show();
            }
        }
    }
}
