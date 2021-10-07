using Client.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;

namespace Client.Controls
{
    public partial class AuthorizationUserControl : UserControl
    {
        public AuthorizationUserControl()
        {
            InitializeComponent();            
        }

        private void SignInButton_OnClick(object sender, RoutedEventArgs e)
        {
            var serverAnswer = IsValidUser();
            ControlNavigation(serverAnswer);
        }

        //Отправляет логин и пароль на сервер, для проверки на существование в бд
        private string IsValidUser()
        {
            var result = string.Empty;
            try 
            {
                var clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var client = new HttpClient(clientHandler);
                var requestUrl = $"https://localhost:5001/Login/Get?login={Login.Text}&password={Password.Text}";
                var response = client.GetAsync(requestUrl).Result;                

                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                    AuthentificatedUser.Id = JsonConvert.DeserializeObject<User>(result).Id;
                    AuthentificatedUser.Email = JsonConvert.DeserializeObject<User>(result).Email;
                }
                else
                {
                    result = "BadUser";
                }
            }
            catch(Exception e)
            {
                result = "BadServer";
            }

            return result;                  
        }

        //Переходи на соответствующий контрол, в зависимости от ответа сервера
        private void ControlNavigation(string responseContent)
        {
            if (responseContent == "BadUser")
            {
                ControlsMethods.SwitchControls(Window.GetWindow(this), "AuthorizationControl", "ErrorCredentialControl");
            }
            else if(responseContent == "BadServer")
            {
                ControlsMethods.SwitchControls(Window.GetWindow(this), "AuthorizationControl", "ErrorServerControl");
            }
            else
            {
                ControlsMethods.SwitchControls(Window.GetWindow(this), "AuthorizationControl", "MainUserControl");
            }
        }

        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            ControlsMethods.SwitchControls(Window.GetWindow(this), "AuthorizationControl", "StartPageControl");
        }
    }
}
