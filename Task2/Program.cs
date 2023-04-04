using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;

namespace JsonParsingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Чтение файла
            string jsonFilePath = "C:\\Users\\kvere\\source\\repos\\TsGmEnrg\\TsGmEnrg\\outages.json";
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Десериализация JSON
            OutageData outageData = JsonConvert.DeserializeObject<OutageData>(jsonContent);

            // Формирование сообщения для отправки
            string messageBody = $"Outage Start: {outageData.OutageStart}\n\nAffected Areas:\n";
            foreach (AffectedArea area in outageData.AffectedAreas)
            {
                messageBody += $"{area.AreaName} - Affected Customers: {area.AffectedCustomers}, Estimated Recovery Time: {area.EstimatedRecoveryTime}\n";
            }

            // Отправка сообщения на email
            string toEmail = "s.yurkova@gomel.energo.net.by";
            string fromEmail = "misterveremeev@mail.ru";
            string subject = "Outage Information";
            string smtpServer = "smtp.mail.ru";
            int smtpPort = 587;
            string smtpUsername = "misterveremeev@mail.ru";
            string smtpPassword = "cVRytMRKiXB9Njz8habx";

            SendMail(toEmail, fromEmail, subject, messageBody, smtpServer, smtpPort, smtpUsername, smtpPassword);

            Console.WriteLine("Email sent successfully");
        }

        static void SendMail(string to, string from, string subject, string body, string smtpServer, int smtpPort, string smtpUsername, string smtpPassword)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(to);
            mailMessage.From = new MailAddress(from);
            mailMessage.Subject = subject;
            mailMessage.Body = body;

            SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            Console.WriteLine("Sending...");
            smtpClient.Send(mailMessage);
            Console.WriteLine("Sended");
        }
    }

    public class OutageData
    {
        [JsonProperty("outage_id")]
        public string OutageId { get; set; }

        [JsonProperty("outage_start")]
        public DateTime OutageStart { get; set; }

        [JsonProperty("outage_end")]
        public DateTime OutageEnd { get; set; }

        [JsonProperty("affected_areas")]
        public AffectedArea[] AffectedAreas { get; set; }

        [JsonProperty("outage_status")]
        public string OutageStatus { get; set; }

        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    public class AffectedArea
    {
        [JsonProperty("area_id")]
        public string AreaId { get; set; }

        [JsonProperty("area_name")]
        public string AreaName { get; set; }

        [JsonProperty("total_customers")]
        public int TotalCustomers { get; set; }

        [JsonProperty("affected_customers")]
        public int AffectedCustomers { get; set; }

        [JsonProperty("estimated_recovery_time")]
        public DateTime EstimatedRecoveryTime { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}