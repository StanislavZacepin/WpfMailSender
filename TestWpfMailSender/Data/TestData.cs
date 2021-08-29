using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWpfMailSender.Models;

namespace TestWpfMailSender.Data
{
   internal class TestData
    {
        static Random random = new Random();
        public static List<Server> Servers { get; } = Enumerable.Range(1, 10)
            .Select(i => new Server 
            {
                Name=$"Сервер-{i}",
                Addres=$"smtp.server{i}.com",
                Port=i % 2==0? 25:2525,
                UseSSL= i % 2==0,
                Login=$"Login-{i}",
                Password=$"{(char)i + random.Next(0, 37)}" +
                $"{(char)i+random.Next(0,37)}" +
                $"{(char)i + random.Next(0, 37)}" +
                $"{(char)i + random.Next(0, 37)}" +
                $"{(char)i + random.Next(0, 37)}" +
                $"{(char)i + random.Next(0, 37)}" +
                $"{(char)i + random.Next(0, 37)}" +
                $"{(char)i + random.Next(0, 37)}",

            })
            .ToList();

        public static List<Sender> Senders { get; }
            = Enumerable.Range(1, 100)
            .Select(i => new Sender 
            {
                Name=$"Отправитель-{i}",
                SenderAdress=$"SendAdress-{i}",

            })
            .ToList();
        public static List<Recipient> Recipients { get; }
           = Enumerable.Range(1, 100)
           .Select(i => new Recipient
           {
               Name = $"Получатель-{i}",
               RecipientAdress = $"RecipientAdress-{i}",

           })
           .ToList();

        public static List<Message> Messages { get; } 
            = Enumerable.Range(0, 10)
            .Select(i => new Message 
            {
                Title=$"Тема-{i}",
                Text=$"Сообщения-{i}",
            })
            .ToList();
    }
}
