using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Mercurial
{
    /// <summary>
    /// Логика взаимодействия для Employ.xaml
    /// </summary>
    public partial class Employ : Window
    {
        private EmployeeManager employeeManager = new EmployeeManager();
        public Employ()
        {
            InitializeComponent();
            employeeManager.AddEmployee("Иванов Иван", "Разработчик", 50000);
            employeeManager.AddEmployee("Петров Петр", "Дизайнер", 45000);
            employeeManager.AddEmployee("Сидоров Сидор", "Тестировщик", 48000);
            employeeManager.AddEmployee("Козлов Николай", "Менеджер", 55000);
            employeeManager.AddEmployee("Новиков Андрей", "Аналитик", 52000);
            employeesListView.ItemsSource = employeeManager.GetEmployees();
        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем данные о сотруднике
            string name = nameTextBox.Text;
            string position = positionTextBox.Text;
            decimal salary;

            // Проверка ввода зарплаты
            if (!decimal.TryParse(salaryTextBox.Text, out salary))
            {
                MessageBox.Show("Пожалуйста, введите корректную зарплату.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Добавляем нового сотрудника
            employeeManager.AddEmployee(name, position, salary);
        }
    }
    public class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
    }
    public class EmployeeManager
    {
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

        public void AddEmployee(string name, string position, decimal salary)
        {
            employees.Add(new Employee { Name = name, Position = position, Salary = salary });
        }

        public ObservableCollection<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
