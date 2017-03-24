using ActiveStore.Domain.Abstract;
using ActiveStore.Domain.Entities;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ActiveStore.Domain.Concrete
{


    public class EmailSettings
    {
        public bool UseSsl = true;
        public int ServerPort = 587;
        public bool WriteAsFile = true;
        public string FileLocation = @"D:\Заказы";
    }

    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;

        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shippingInfo)
        {



            StringBuilder body = new StringBuilder()
                .AppendLine("Новый заказ обработан")
                .AppendLine("---")
                .AppendLine("Товары:");

            foreach (var line in cart.Lines)
            {
                var subtotal = line.Product.Price * line.Quantity;
                body.AppendFormat("{0} x {1} (итого: {2} грн)\n",
                    line.Quantity, line.Product.Name, subtotal);
            }

            body.AppendFormat("Общая стоимость: {0} грн", cart.ComputeTotalValue())
                .AppendLine("---")
                .AppendLine("Доставка:")
                .AppendLine(shippingInfo.Name)
                .AppendLine(shippingInfo.Line1)
                .AppendLine(shippingInfo.Line2 ?? "")
                .AppendLine(shippingInfo.Line3 ?? "")
                .AppendLine(shippingInfo.City)
                .AppendLine(shippingInfo.Country)
                .AppendLine("---")
                .AppendFormat("Подарочная упаковка: {0}",
                    shippingInfo.GiftWrap ? "Да" : "Нет");


            string smtpServer = "smtp.gmail.com";
            string from = "gorant94@gmail.com";
            string password = "ischgl2012";
            string mailto = "gorant94@mail.ru";
            string caption = "Новый заказ";
            string attachFile = null;
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = body.ToString();
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient();
                client.Host = smtpServer;
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
            }
        }
    }
}