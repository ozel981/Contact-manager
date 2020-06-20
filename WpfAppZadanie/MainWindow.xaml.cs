using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using ValidationInterface;

namespace WpfAppZadanie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public enum GENDER { MAN, WOMAN}
    public class Contact
    {
       
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public GENDER Gender { get; set; }

        public Contact() { Name = ""; Surname = ""; Email = ""; Phone = ""; Gender = GENDER.MAN; }     
    }

    public class DataValues : INotifyPropertyChanged
    {
        private ObservableCollection<Contact> contacts;
        private bool lockContetntVisibility;
        private bool unlockContetntVisibility;
        List<(ValidationRule, IValidation)> validationRules;
        public ObservableCollection<Contact> Contacts { get { return contacts; } set { contacts = value; OnPropertyRaised("Contacts"); } }
        public bool LockContetntVisibility { get { return lockContetntVisibility; } set { lockContetntVisibility = value; OnPropertyRaised("LockContetntVisibility"); } }
        public bool UnlockContetntVisibility { get { return unlockContetntVisibility; } set { unlockContetntVisibility = value; OnPropertyRaised("UnlockContetntVisibility"); } }
        public List<(ValidationRule, IValidation)> ValidationRules { get { return validationRules; } set { validationRules = value; OnPropertyRaised("ValidationRules"); } }
        public DataValues()
        {
            lockContetntVisibility = true;
            unlockContetntVisibility = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyRaised(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }

    partial class MainWindow : Window
    {
        public DataValues dataValues = new DataValues();
        //public ContactList contactList;
        public MainWindow()
        {
            InitializeComponent();
            dataValues.Contacts = new ObservableCollection<Contact>();
            dataValues.ValidationRules = CreateValidationRules("../../Validations/");
            this.DataContext = dataValues;
        }

        public ValidationRule GetNameValidationRule()
        {
            var showContent = this.Resources["showContent"] as UserControl;
            ComboBox comboBox = ((ComboBox)LogicalTreeHelper.FindLogicalNode(showContent, "NameValidationComboBox"));
            if (comboBox.SelectedIndex < 0) return null;
            return (((ValidationRule, IValidation))comboBox.SelectedItem).Item1;
        }

        public ValidationRule GetSurnameValidationRule()
        {
            var showContent = this.Resources["showContent"] as UserControl;
            ComboBox comboBox = ((ComboBox)LogicalTreeHelper.FindLogicalNode(showContent, "SurnameValidationComboBox"));
            if (comboBox.SelectedIndex < 0) return null;
            return (((ValidationRule, IValidation))comboBox.SelectedItem).Item1;
        }

        public ValidationRule GetEmailValidationRule()
        {
            var showContent = this.Resources["showContent"] as UserControl;
            ComboBox comboBox = ((ComboBox)LogicalTreeHelper.FindLogicalNode(showContent, "EmailValidationComboBox"));
            if (comboBox.SelectedIndex < 0) return null;
            return (((ValidationRule, IValidation))comboBox.SelectedItem).Item1;
        }
        

        public ValidationRule GetPhoneValidationRule()
        {
            var showContent = this.Resources["showContent"] as UserControl;
            ComboBox comboBox = ((ComboBox)LogicalTreeHelper.FindLogicalNode(showContent, "PhoneValidationComboBox"));
            if (comboBox.SelectedIndex < 0) return null;
            return (((ValidationRule, IValidation))comboBox.SelectedItem).Item1;
        }

        private List<(ValidationRule, IValidation)> CreateValidationRules(string path)
        {
            List<(ValidationRule, IValidation)> validationRules = new List<(ValidationRule, IValidation)>();
            foreach (string dll in Directory.GetFiles(path, "*.dll"))
            {
                Assembly assembly = Assembly.LoadFrom(dll);
                AppDomain.CurrentDomain.Load(assembly.GetName());
                Type type = assembly.GetExportedTypes()[0];
                if (type.Name == "IValidation") continue;
                validationRules.Add(((ValidationRule)Activator.CreateInstance(type),(IValidation)Activator.CreateInstance(type)));
            }
            return validationRules;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is simple contack manager", "Contact Manager", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void MenuItem_Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_ClearContacts(object sender, RoutedEventArgs e)
        {
            dataValues.Contacts = new ObservableCollection<Contact>();
        }

        private void MenuItem_AddContact(object sender, RoutedEventArgs e)
        {
            NewContact newContactWindow = new NewContact(this);
            newContactWindow.ShowDialog();
        }

        public void SetOpacity(double opacity)
        {
            this.Opacity = opacity;
        }

        private void MenuItem_Import(object sender, RoutedEventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "xml files (*.xml)|*.xml";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            try
            {
                openFileDialog.ShowDialog();
                var fileStream = openFileDialog.OpenFile();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Contact>));
                if (fileStream != null)
                {
                    dataValues.Contacts = (ObservableCollection<Contact>)xmlSerializer.Deserialize(fileStream);
                    this.DataContext = dataValues;
                }
            }
            catch
            {

            }
        }

        private void MenuItem_Export(object sender, RoutedEventArgs e)
        {
            Stream fileStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "xml files (*.xml)|*.xml";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            try
            {
                saveFileDialog1.ShowDialog();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Contact>));
                if ((fileStream = saveFileDialog1.OpenFile()) != null)
                {
                    xmlSerializer.Serialize(fileStream, dataValues.Contacts);
                    fileStream.Close();
                }
            }
            catch
            {

            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (MainListBox.SelectedIndex == -1) return;

            dataValues.Contacts.RemoveAt(MainListBox.SelectedIndex);
        }

        private void ShowValidationSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            dataValues.LockContetntVisibility = false;
            dataValues.UnlockContetntVisibility = true;
        }

        private void HideValidationSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            dataValues.LockContetntVisibility = true;
            dataValues.UnlockContetntVisibility = false;
        }
    }

    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((GENDER)value == GENDER.MAN) return "Resources/man.png";
            else return "Resources/woman.jpg";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value) return Visibility.Visible;
            else return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class NameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (((ValidationRule, IValidation))value).Item2.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
