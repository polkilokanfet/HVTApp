using HVTApp.Infrastructure.Services;
using OpenMcdf;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Interop;

namespace HVTApp.Services.MessagesOutlookService
{
    public class MessagesOutlookService1 : IMessagesOutlookService
    {
        public MessageOutlook GetOutlookMessage(string path)
        {
            MessageOutlook message = new MessageOutlook
            {
                FilePath = path,
            };

            try
            {
                using (var msg = new MsgReader.Outlook.Storage.Message(path, FileAccess.Read))
                {
                    message.Subject = msg.Subject;
                    message.BodyText = msg.BodyText;
                    message.BodyHtml = msg.BodyHtml;
                    message.SentOnDate = msg.SentOn?.DateTime;
                    message.Sender = new UserOutlook(msg.Sender.Email, msg.Sender.DisplayName);
                    message.Recipients = msg.Recipients
                        .Select(recipient => new UserOutlook(recipient.Email, recipient.DisplayName)).ToList();
                    message.HasAttachments = msg.Attachments.Any();

                    //var recipientsTo = msg.GetEmailRecipients(MsgReader.Outlook.RecipientType.To, false, false);
                    //var recipientsCc = msg.GetEmailRecipients(MsgReader.Outlook.RecipientType.Cc, false, false);
                    //var subject = msg.Subject;
                    //var htmlBody = msg.BodyHtml;
                    // etc...
                }

                return message;
            }
            catch (System.IO.IOException exception)
            {
                //копирование во временную папку — самое устойчивое решение в сценариях, где файлы могут быть заняты Outlook или синхронизацией.
                //но нет желания это реализовывать

                message.Subject = "Заблокировано процессом";
                message.BodyText = exception.Message;
                message.BodyHtml = exception.Message;

                return message;
            }
            catch (OpenMcdf.FileFormatException e)
            {
                throw;
            }
        }

        public IEnumerable<MessageOutlook> GetOutlookMessages(string path)
        {
            var result = new List<MessageOutlook>();

            var fileNames = System.IO.Directory.GetFiles(path, "*.msg");

            foreach (var fileName in fileNames)
            {
                var filePath = Path.Combine(path, fileName);
                try
                {
                    result.Add(this.GetOutlookMessage(filePath));
                }
                catch (OpenMcdf.FileFormatException e)
                {
                }
            }

            return result;
        }
    }
}
