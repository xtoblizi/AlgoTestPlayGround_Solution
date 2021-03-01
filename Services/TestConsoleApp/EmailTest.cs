using System;
using System.Net;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Linq;
using MimeKit;
using System.IO;
using System.Threading.Tasks;
using MailKit.Security;

namespace TestConsoleApp
{
	public class EmailTest
	{
		public string host { get; set; }
		public int port { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }

		public string Sender { get; set; }
		public string SenderPass { get; set; }
		public bool IsSSL { get; set; }

		public string Subject { get; set; }
		public string Body { get; set; }
		public List<string> Receipients { get; set; }
		public List<string> AttachmentFilesPath { get; set; }

		/// <summary>
		/// Send via microsoft .net.mail mamespace
		/// </summary>
		/// <param name="model"></param>
		public static void SendMailViaDonetSmtp(EmailTest model)
		{
			try
			{
				var fromAddress = new MailAddress(model.Sender, "Xtoblizi");
				var toAddress = new MailAddress(model.Receipients.FirstOrDefault(), "Ogbosuka Chris Biz");
				string fromPAssword = model.SenderPass;
				string subject = model.Subject;

				string body = model.Body;

				using (var smtp = new SmtpClient())
				{
					smtp.Host = "smtp.gmail.com";
					smtp.Port = 587;
					smtp.EnableSsl = true;
					smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
					smtp.Credentials = new NetworkCredential(fromAddress.Address, fromPAssword);
					smtp.Timeout = 10000;

					using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body, IsBodyHtml = true })
					{

						smtp.Send(message);
					}

				}

			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		/// <summary>
		/// Send via mail kit
		/// </summary>
		/// <param name="mail"></param>
		/// <returns></returns>
		public async Task  SendViaMailKit(EmailTest mail)
		{
			try
			{
				var mailMessage = new MimeMessage
				{
					Subject = mail.Subject
					//Body = new TextPart(TextFormat.Html) { Text = mail.Body } // _shapeDisplay.Display(template),
				};
				#region Body Section of the Mail

				var bodyBuilder = new BodyBuilder();
				// { TextBody = new TextPart(TextFormat.Html) { Text = mail.Body } };
				bodyBuilder.HtmlBody = mail.Body;

				mailMessage.Body = bodyBuilder.ToMessageBody();

				#endregion

				#region Compulsory Addresses  (From and To Addresses)

				foreach (var recipient in (mail.Receipients))
				{
					// mailMessage.To.Add(new MailboxAddress(recipient));
					mailMessage.To.Add(MailboxAddress.Parse(recipient));
				}


				// from address. Email must contain atleast one originating email address
				if (!string.IsNullOrWhiteSpace(mail.Sender))
				{
					// mailMessage.From.Add(new MailboxAddress(mail.From));
					mailMessage.From.Add(MailboxAddress.Parse(mail.Sender));
				}

				#endregion

				#region Sending Section
				var _smtpClientField = await CreateSenderSmtpClient(mail);

				await _smtpClientField.SendAsync(mailMessage);
				_smtpClientField.Disconnect(true);
				#endregion
			}
			catch (Exception ex)
			{

				throw ex;
			}

		
		}

		private async Task<MailKit.Net.Smtp.SmtpClient> CreateSenderSmtpClient(EmailTest _smtpSetting)
		{
			try
			{
				var smtpClient = new MailKit.Net.Smtp.SmtpClient()
				{
					// For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
					ServerCertificateValidationCallback = (s, c, h, e) => true
				};

				// author: added by Chris
				//if ssl is enabled then the secured layer options should be set enable else it should be set to none
				var optionsValue = _smtpSetting.IsSSL == true ? SecureSocketOptions.SslOnConnect : SecureSocketOptions.None;

				// author: added by Chris
				// decription : This would start TLS if port is 587 this would start when it sis available

				if (_smtpSetting.port == (int)SmptSettingsPortEnum.Port587)
				{
					optionsValue = SecureSocketOptions.StartTlsWhenAvailable;
				}
				else if (_smtpSetting.port == (int)SmptSettingsPortEnum.Port2 || _smtpSetting.port == (int)SmptSettingsPortEnum.Port465)
				{
					optionsValue = SecureSocketOptions.SslOnConnect;
				}

				smtpClient.Connect(
					   host: _smtpSetting.host,
					   port: _smtpSetting.port,
					   options: optionsValue
					   );

				// Note: since we don't have an OAuth2 token, disable
				// the XOAUTH2 authentication mechanism.
				smtpClient.AuthenticationMechanisms.Remove("XOAUTH2");
				
				smtpClient.Authenticate(_smtpSetting.Sender, _smtpSetting.Password);
				

				smtpClient.CheckCertificateRevocation = false;

				return smtpClient;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		private IEnumerable<string> ParseRecipients(string recipients)
		{
			return recipients.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
		}


		private enum SmptSettingsPortEnum
		{
			Port587 = 587,
			Port25 = 25,
			Port2 = 2,
			Port465 = 465
		}
	}
}
