using System;
using System.Net;
using System.Net.Mail;

namespace TestConsole
{
    class Program
    {
        // Для провеки кода для отправки письма 
        static void Main(string[] args)
        {
            var _to = new MailAddress("sadasd@mail.ru","Станислав");
            var _from = new MailAddress("asdasd@mail.ru","Стас");


            MailMessage mailMessage = new MailMessage(_from, _to)
            {
                Body = "Тело письма",
                Subject = $"Заголовок Письма: {DateTime.Now}",
            };

            using (var client = new SmtpClient("smtp.mail.ru", 2525))
            {
                const string login = "adasdad@mail.ru";
                const string Password = "sfsfdssf";

                client.Credentials = new NetworkCredential(login, Password); // создаем клиента водим логин пороль
                client.EnableSsl = true; // открываем канал с сервером

                try
                {
                    client.Send(mailMessage); // отправляем почту 
                    Console.WriteLine("Писмо отправленно");
                    Console.ReadLine();
                }
                catch (SmtpException )
                {
                    Console.WriteLine("Ошибка авторизацыи ");
                    Console.ReadLine();
                }
                catch(TimeoutException )
                {
                    Console.WriteLine("Время отправки вышло ");
                    Console.ReadLine();
                }
            }

          

        }
    }
}
