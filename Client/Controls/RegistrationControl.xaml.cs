using Client.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Client.Controls
{
    public partial class RegistrationControl : UserControl
    {
        public RegistrationControl()
        {
            InitializeComponent();
        }

        //Отправляет запрос на добавление пользователя на сервер
        private void CreateUser(object sender, RoutedEventArgs e)
        {
            try
            {
                var clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var client = new HttpClient(clientHandler);
                var requestUrl = $"https://localhost:5001/Login/Create";

                if(CredentialIsValid())
                {
                    var user = new User { Name = UserName.Text, Login = Login.Text, Password = Password.Text, Role = "User", Email = Email.Text };
                    var response = client.PostAsync(requestUrl, new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json")).Result;
                    ControlsMethods.SwitchControls(Window.GetWindow(this), "RegistrationControl", "SuccessRegistrationControl");
                }
                else
                {
                    ControlsMethods.SwitchControls(Window.GetWindow(this), "RegistrationControl", "ErrorCredentialControl");
                }               
            }
            catch (Exception m)
            {
                ControlsMethods.SwitchControls(Window.GetWindow(this), "RegistrationControl", "ErrorServerControl");
            }
        }

        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            ControlsMethods.SwitchControls(Window.GetWindow(this), "RegistrationControl", "StartPageControl");           
        }

        private bool IsValid(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }

        private bool CredentialIsValid()
        {
            return UserName.Text != "" && Password.Text != "" && Login.Text != "" && Email.Text != "" && IsValid(Email.Text);
        }
    }
}
