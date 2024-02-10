using System.Collections.ObjectModel;
using System.Security.Principal;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mercurial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ObservableCollection<Account> accounts = new ObservableCollection<Account>();
        public MainWindow()
        {
            InitializeComponent();

            // Пример заполнения данных (вам нужно заменить это вашей бизнес-логикой)
            accounts.Add(new Account { AccountNumber = "123", Balance = 1000 });
            accounts.Add(new Account { AccountNumber = "456", Balance = 2000 });

            // Привязка данных к ListView
            accountListView.ItemsSource = accounts;
        }

        private void AddAccount_Click(object sender, RoutedEventArgs e)
        {
            // Открываем окно для добавления нового счета
            AddAccountWindow addAccountWindow = new AddAccountWindow();
            addAccountWindow.Owner = this;

            // Если пользователь подтверждает добавление счета
            if (addAccountWindow.ShowDialog() == true)
            {
                // Добавляем новый счет в коллекцию
                accounts.Add(addAccountWindow.NewAccount);
            }
        }
    }
    // Account.cs
    public class Account
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }

        // Дополнительные свойства и методы, если необходимо

        public override string ToString()
        {
            return $"Счет № {AccountNumber}, Баланс: {Balance:C}";
        }
    }

}