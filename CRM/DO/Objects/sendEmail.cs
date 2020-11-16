using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DO.Objects
{
	public static class sendEmail
	{

		//send email with Outlook
		public static void sendEmailOutlook(String from,String password,String to, String cc, String subject, String mjs)
		{
			var toAddress = new MailAddress(to, subject);
			var fromAddress = new MailAddress(from, subject);

			SmtpClient client = new SmtpClient("smtp.outlook.com", 587);
			client.EnableSsl = true;
			client.UseDefaultCredentials = false;
			client.Credentials = new NetworkCredential(fromAddress.Address, password);

			try
			{
				using (var message = new MailMessage(fromAddress, toAddress))
				{
					foreach (var address in cc.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries))
						message.To.Add(address);
					//if (File.Exists(attachmentTxt.Text))//ARCHIVOS
					//{
					//    Attachment attachment = new Attachment(attachmentTxt.Text);
					//    message.Attachments.Add(attachment);
					//}
					message.IsBodyHtml = Regex.IsMatch(mjs, @"<\s*([^ >]+)[^>]*>.*?<\s*/\s*\1\s*>");
					message.Subject = subject;
					message.Body = mjs;
					client.Send(message);
				}
			}
			catch (Exception ex)
			{

			}
		}

		//send email with Gmail
		public static void sendEmailGmail(String from, String password, String to, String cc, String subject, String mjs)
		{
			var toAddress = new MailAddress(to, subject);
			var fromAddress = new MailAddress(from, subject);

			var smtp = new SmtpClient
			{
				Host = "smtp.gmail.com",
				Port = 587,
				EnableSsl = true,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(fromAddress.Address, password)
			};
			try
			{
				using (var message = new MailMessage(fromAddress, toAddress))
				{
					foreach (var address in cc.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries))
						message.To.Add(address);
					//if (File.Exists(attachmentTxt.Text))//ARCHIVOS
					//{
					//    Attachment attachment = new Attachment(attachmentTxt.Text);
					//    message.Attachments.Add(attachment);
					//}
					message.IsBodyHtml = Regex.IsMatch(mjs, @"<\s*([^ >]+)[^>]*>.*?<\s*/\s*\1\s*>");
					message.Subject = subject;
					message.Body = mjs;
					smtp.Send(message);
				}
			}
			catch (Exception ex)
			{

			}
		}
	}
}

