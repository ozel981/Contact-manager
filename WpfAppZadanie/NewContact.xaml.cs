using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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

namespace WpfAppZadanie
{
    /// <summary>
    /// Interaction logic for NewContact.xaml
    /// </summary>
  
    public partial class NewContact : Window
    {
        MainWindow mainWindow;
        public string ContactName { get; set; }
        public string ContactSurname { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }

        public GENDER Gender { get; set; }
        public NewContact(MainWindow mainWindow)
        {
           
            this.mainWindow = mainWindow;
            InitializeComponent();
            mainWindow.SetOpacity(0.2);
            this.DataContext = this;

            Binding bindingExpression;
            if (mainWindow.GetNameValidationRule()!=null)
            {
                bindingExpression = BindingOperations.GetBinding(name, TextBox.TextProperty);
                bindingExpression.ValidationRules.Add(mainWindow.GetNameValidationRule());
            }
            if (mainWindow.GetSurnameValidationRule() != null)
            {
                bindingExpression = BindingOperations.GetBinding(surname, TextBox.TextProperty);
                bindingExpression.ValidationRules.Add(mainWindow.GetSurnameValidationRule());
            }
            if (mainWindow.GetEmailValidationRule() != null)
            {
                bindingExpression = BindingOperations.GetBinding(mail, TextBox.TextProperty);
                bindingExpression.ValidationRules.Add(mainWindow.GetEmailValidationRule());
            }
            if (mainWindow.GetPhoneValidationRule() != null)
            {


                bindingExpression = BindingOperations.GetBinding(phone, TextBox.TextProperty);
                bindingExpression.ValidationRules.Add(mainWindow.GetPhoneValidationRule());
            }



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClodeWindow();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!Validation.GetErrors(name).Any() && !Validation.GetErrors(surname).Any() && !Validation.GetErrors(mail).Any() && !Validation.GetErrors(phone).Any() && name.Text.Any() && phone.Text.Any() && surname.Text.Any() && mail.Text.Any())
            {
                Contact contact = new Contact { Name = ContactName, Surname = ContactSurname, Email = ContactEmail, Phone = ContactPhone, Gender = (GENDER)gender.SelectedItem };
                ObservableCollection<Contact> newContacts = new ObservableCollection<Contact>(mainWindow.dataValues.Contacts);
                newContacts.Add(contact);
                mainWindow.dataValues.Contacts = newContacts;
                mainWindow.DataContext = mainWindow.dataValues;
                ClodeWindow();
            }
        }     
        
        private void ClodeWindow()
        {
            mainWindow.SetOpacity(1);
            Close();
        }
    }    
}
