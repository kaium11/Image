using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EASendMail;
using EAGetMail;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EAGetMail;
namespace Image_Crypto_System
{
    class SendAndRec
    {
        public string sendData(string from,string to,string pass,string mess)
        {
            SmtpMail oMail = new SmtpMail("TryIt");
            SmtpClient oSmtp = new SmtpClient();

            // Set sender email address, please change it to yours
            oMail.From = "imagecryptography@gmail.com";

            // Set recipient email address, please change it to yours
            oMail.To = "imagecryptographyreceive@gmail.com";

            // Set email subject
            oMail.Subject = "test email from c# project";

            // Set email body
            oMail.TextBody = mess;

            // Your SMTP server address
            SmtpServer oServer = new SmtpServer("smtp.gmail.com");

            // User and password for ESMTP authentication, if your server doesn't require
            // User authentication, please remove the following codes.            
            oServer.User = "imagecryptography@gmail.com";
            oServer.Password = "11041191104091";

            // If your smtp server requires TLS connection, please add this line
            oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

            // If your smtp server requires implicit SSL connection on 465 port, please add this line
            oServer.Port = 465;
            oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

            try
            {
                //Console.WriteLine("start to send email ...");
                oSmtp.SendMail(oServer, oMail);
                return "email was sent successfully!";
            }
            catch (Exception ep)
            {
                //Console.WriteLine("failed to send email with the following error:");
                return ep.Message;
                 
            }
            //Console.ReadLine();
        }
        public string Rec()
        {

            // Create a folder named "inbox" under current directory
            // to save the email retrieved.
            string curpath = Directory.GetCurrentDirectory();
            string mailbox = String.Format("{0}\\inbox", curpath);

            // If the folder is not existed, create it.
            if (!Directory.Exists(mailbox))
            {
                Directory.CreateDirectory(mailbox);
            }

            MailServer oServer = new MailServer("pop.gmail.com",
                        "imagecryptographyreceive@gmail.com", "11041191104091", EAGetMail.ServerProtocol.Pop3);
            MailClient oClient = new MailClient("TryIt");

            // If your POP3 server requires SSL connection,
            // Please add the following codes:
            oServer.SSLConnection = true;
            oServer.Port = 995;
          //  Console.WriteLine("connection");

            try
            {
                oClient.Connect(oServer);
                MailInfo[] infos = oClient.GetMailInfos();
                string tx = "";
              //  Console.WriteLine("connection2");
                for (int i = 0; i < infos.Length; i++)
                {
                    MailInfo info = infos[i];
                    //Console.WriteLine("Index: {0}; Size: {1}; UIDL: {2}",
                    //  info.Index, info.Size, info.UIDL);

                    // Receive email from POP3 server
                    Mail oMail = oClient.GetMail(info);

                    // Console.WriteLine("From: {0}", oMail.From.ToString());
                    //   Console.WriteLine("Subject: {0}\r\n", oMail.Subject);
                //    Console.WriteLine("Text: {0}\n", oMail.TextBody);
                    // Generate an email file name based on date time.
                    System.DateTime d = System.DateTime.Now;
                    System.Globalization.CultureInfo cur = new
                        System.Globalization.CultureInfo("en-US");
                    string sdate = d.ToString("yyyyMMddHHmmss", cur);
                    string fileName = String.Format("{0}\\{1}{2}{3}.eml",
                        mailbox, sdate, d.Millisecond.ToString("d3"), i);

                    // Save email to local disk
                    oMail.SaveAs(fileName, true);
                    string text = System.IO.File.ReadAllText(fileName);
                    //  Console.WriteLine(text);
                    string sub = oMail.Subject;
                    
                    // Mark email as deleted from POP3 server.
                    oClient.Delete(info);
                    if (sub == "test email from c# project") ;  tx=oMail.TextBody;
                }

                // Quit and pure emails marked as deleted from POP3 server.
                oClient.Quit();
                return tx; ;
            }
            catch (Exception ep)
            {
                //Console.WriteLine(ep.Message);
                return ep.Message;
            }
            //Console.ReadLine();
        }
    }
}
