using Client.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Client.Controls
{
    public partial class MainUserControl : UserControl
    {
        bool RecordToDB = false;
        public RecordList recordList;
        Point lastPosition;
        int recordsAmount = 0;
        int numberToSendMail = 50;

        public MainUserControl()
        {
            InitializeComponent();
            recordList = new RecordList();
            recordListView.ItemsSource = recordList.Records;
            recordsNumber.Text = recordsAmount.ToString();
        }

        private void StartRecord_OnClick(object sender, RoutedEventArgs e)
        {
            RecordToDB = true;
            lastPosition = Mouse.GetPosition(this);             
        }

        private void StopRecord_OnClick(object sender, RoutedEventArgs e)
        {
            RecordToDB = false;
        }

        private void CleanListView_OnClick(object sender, RoutedEventArgs e)
        {
            CleanListView();
        }

        private void TypeColumnHeader_OnClick(object sender, RoutedEventArgs e)
        {
            recordListView.ItemsSource = recordList.TypeSort();
        }

        private void TimeColumnHeader_OnClick(object sender, RoutedEventArgs e)
        {            
            recordListView.ItemsSource = recordList.TimeSort(); 
        }

        private void LeftClick(object sender, MouseButtonEventArgs e)
        {            
            AddRecordToTable("Левый клик", e);
        }

        private void CenterClick(object sender, MouseWheelEventArgs e)
        {
            var pos = e.GetPosition(null);
            var record = new Record("Центральный клик", (int)pos.X, (int)pos.Y, DateTime.Now);
            recordList.Records.Add(record);
            recordsAmount++;
            recordsNumber.Text = recordsAmount.ToString();
            if (RecordToDB)
            {
                RecordDb(record);
            }
        }

        private void RightClick(object sender, MouseButtonEventArgs e)
        {
            AddRecordToTable("Правый клик", e);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            var currentPosition = e.GetPosition(null);
            if (CursorIsMove(lastPosition, currentPosition))
            {
                lastPosition = currentPosition;
                var pos = e.GetPosition(null);
                var record = new Record("Сдвиг на 10 пикселей", (int)pos.X, (int)pos.Y, DateTime.Now);
                recordList.Records.Add(record);
                recordsAmount++;
                recordsNumber.Text = recordsAmount.ToString();
                if (RecordToDB)
                {
                    RecordDb(record);
                }
            }            
        }

        private bool CursorIsMove(Point p1, Point p2)
        {
            var result = Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.X - p2.X));
            return result > 10;
        }

        //Отправляет события мыши на сервер
        private void RecordDb(Record record)
        {           
            try
            {
                var clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var client = new HttpClient(clientHandler);
                var requestUrl = $"https://localhost:5001/Record/Create";
                var A = JsonConvert.SerializeObject(record);
                var response = client.PostAsync(requestUrl, new StringContent(JsonConvert.SerializeObject(record), Encoding.UTF8, "application/json"));             
            }
            catch (Exception e)
            {
                
            }
        }

        //Отображает события мыши в таблице 
        void AddRecordToTable(string type, MouseButtonEventArgs e)
        {
            var pos = e.GetPosition(null);
            var record = new Record(type, (int)pos.X, (int)pos.Y, DateTime.Now);
            recordList.Records.Add(record);
            recordsAmount++;
            recordsNumber.Text = recordsAmount.ToString();
            CheckRecordAmount();
            if (RecordToDB)
            {
                RecordDb(record);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ControlsMethods.SwitchControls(Window.GetWindow(this), "MainUserControl", "AuthorizationControl");           
            CleanListView();
        }

        //Посылает сообщение с количеством записей на почту 
        private void SendMail(string emailToSend, int recordAmount)
        {
            try
            {
                MailAddress from = new MailAddress("test@gmail.com", "Tom");
                MailAddress to = new MailAddress(emailToSend);
                MailMessage m = new MailMessage(from, to);
                m.Subject = "Программа для компьютерной мыши";
                m.Body = $"Количество сделанных вами записей равно {recordAmount}";
                m.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient("test@gmail.com", 587);
                smtp.Credentials = new NetworkCredential("test@gmail.com", "testpassword");
                smtp.EnableSsl = true;
                smtp.Send(m);
            }
            catch(Exception e)
            {

            }            
        }
        
        //Проверяет количество записей
        private void CheckRecordAmount()
        {
            if(recordsAmount >= numberToSendMail)
            {
                numberToSendMail += 50;
                SendMail(AuthentificatedUser.Email, recordsAmount);
            }
        }

        //Очищает таблицу
        private void CleanListView()
        {
            recordList.ClearRecords();
            recordsAmount = 0;
            recordsNumber.Text = "0";
        }
    }
}
