using System;
using System.Collections.Generic;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.IO;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Concurrent;
using System.Net.Mail;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace AutoSQL
{
    class Program
    {
        private static ConcurrentDictionary<string, string> _dic = new ConcurrentDictionary<string, string>();
        static void Main(string[] args)
        {
            ProcessSqlFiles();
            SendErrorMail();
        }
        #region Sql execution

        private static void ProcessSqlFiles()
        {
            string sqlConnectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MasterData;Data Source=pankajd7";
            SqlConnection conn = new SqlConnection(sqlConnectionString);
            Server server = new Server(new ServerConnection(conn));
            //    var files = GetFiles(@"Z:\cl\OurClysar\ClysarWeb\DB Scripts\Clysar\Schema\Alter\StoredProcedure\");
            ProcessLog log;
            var DateOfProcess = DateTime.Now;
            var filePathLog = @"Z:\MyProjects\MYRND\CodeTests\CodetTests\AutoSQL\" + string.Format("sql_mergeLog.jlog", DateOfProcess.Year, DateOfProcess.Month, DateOfProcess.Day);

            var filePath = @"Z:\MyProjects\MYRND\CodeTests\CodetTests\AutoSQL\" + string.Format("{0}-{1}-{2}#sql_mergeLog.jlog", DateOfProcess.Year, DateOfProcess.Month, DateOfProcess.Day);
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(ProcessLog));
            DirectoryInfo dinfo = new DirectoryInfo(@"Z:\MyProjects\MYRND\CodeTests\CodetTests\AutoSQL\");
            var lastExecutionDate = DateTime.Now.AddDays(-2);
            //var dtObj = (from v in dinfo.GetFiles()
            //             let dt = v.Name.Split('#').Take(3).ToList()

            //             select new
            //             {
            //                 DateCreated = dt.Count > 1 ? FormatDate(dt[0], false) : DateTime.MinValue
            //             }).OrderBy(p => p.DateCreated).LastOrDefault();
            //if (dtObj != null)
            //{
            //    lastExecutionDate = dtObj.DateCreated;
            //}
            if (File.Exists(@filePath))
            {
                var text = File.ReadAllText(@filePath);
                if (!string.IsNullOrEmpty(text))
                {
                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(text));
                    log = jsonSerializer.ReadObject(ms) as ProcessLog;
                }
                else
                //if (log == null)
                {

                    log = new ProcessLog();
                    log.DateOfProcess = DateTime.Now;
                }
            }
            else
            {
                log = new ProcessLog();
                log.DateOfProcess = DateTime.Now;
            }

            using (var stream = File.Open(@filePath, FileMode.OpenOrCreate))
            {
                var stngs = GetExecutionSettings().OrderBy(v => v.order);
                foreach (var settings in stngs)
                {
                    if (Directory.Exists(settings.folderPath))
                    {
                        var fls = GetFiles(settings.folderPath, lastExecutionDate);
                        ProcessFile(server, fls, log);
                    }

                }

                jsonSerializer.WriteObject(stream, log);
            }
            using (var stream = File.Open(@filePathLog, FileMode.OpenOrCreate))
            {
                var logs = from v in log.Files
                           where v.IsSuccess == true
                           select new SqlFileProcessed
                           {
                               FilePath = v.FilePath,
                               ProcessingTime = v.ProcessingTime,
                               IsSuccess = v.IsSuccess
                           };
                ProcessLog lg = new ProcessLog()
                {
                    Files = logs.ToList()
                };
                jsonSerializer.WriteObject(stream, log);
            }

        }

        private static void ProcessFile(Server server, SqlFileInfo[] files, ProcessLog log)
        {
            foreach (var inf in files)
            {
                if (!log.Files.Any(v => v.FilePath == inf.FullName && v.IsSuccess == true))
                    ExecuteScript(server, inf, log);
            }
        }
        private static bool ExecuteScript(Server srv, string file)
        {
            string script = File.ReadAllText(file);
            srv.ConnectionContext.ExecuteNonQuery(script);
            return true;

        }

        private static bool ExecuteScript(Server srv, SqlFileInfo file, ProcessLog log)
        {
            SqlFileProcessed xFile = log.Files.FirstOrDefault(v => v.FilePath == file.FullName);
            bool isNew = false;
            if (xFile == null)
            {
                xFile = new SqlFileProcessed()
                {
                    FilePath = file.FullName,
                    ProcessingTime = DateTime.Now,
                };
                isNew = true;
            }

            try
            {
                if (string.IsNullOrWhiteSpace(file.FormatError))
                {
                    var success = ExecuteScript(srv, file.FullName);

                    xFile.RefMessage.Add("succes");
                    xFile.IsSuccess = success;
                    return success;
                }
                else
                {
                    xFile.RefMessage.Add(file.FormatError);
                    xFile.IsSuccess = false;
                    _dic.TryAdd(file.FullName, file.FormatError);
                    return false;
                }
            }
            catch (Exception ex)
            {
                xFile.RefMessage.Add(ex.ToString());
                xFile.IsSuccess = false;
                _dic.TryAdd(file.FullName, ex.ToString());
                return false;
            }
            finally
            {
                if (isNew)
                    log.Files.Add(xFile);
            }
        }
        private static SqlFileInfo[] GetFiles(string dir, DateTime lastAccessTime)
        {
            DirectoryInfo info = new DirectoryInfo(dir);
            var fls = info.GetFiles("*.sql", SearchOption.TopDirectoryOnly);//.Where(p => p.Name.Contains('#'));
            var res = (from v in fls
                       let dt = v.Name.Split('#').Take(3).ToList()
                       let ord = v.Name.Substring(v.Name.IndexOf('.') - 1, 1)
                       select new SqlFileInfo
                       {
                           FullName = v.FullName,
                           Date = dt.Count > 1 ? FormatDate(dt[0]) : DateTime.MinValue,
                           Order = FormatOrder(ord),
                           FormatError = (dt.Count <= 1 ? "invalid date format " : string.Empty),
                           CreationTime = v.CreationTime
                       }).Where(p => p.CreationTime.Date >= lastExecutionDate.Date);
            return res.ToArray();
        }
        //private static string[] GetFiles(string dir)
        //{
        //    DirectoryInfo info = new DirectoryInfo(dir);
        //    var fls= info.GetFiles("*.sql", SearchOption.TopDirectoryOnly);
        //    var res = from v in fls
        //              select new
        //                  {
        //                      Path = v.FullName,
        //                      Date = v.FullName.Substring(0, 11),
        //                      Order = v.FullName.Substring(v.FullName.LastIndexOf('-'), v.FullName.LastIndexOf('.'))
        //                  };
        //    return null;
        //}

        private static DateTime FormatDate(string date, bool isMonthString = true)
        {
            string[] datePart = date.Split('-');

            var t = isMonthString == true ? (int)GetMonth(datePart[1]) : Convert.ToInt32(datePart[1]);
            return new DateTime(Convert.ToInt32(datePart[0]), t, Convert.ToInt32(datePart[2]));

        }
        private static int FormatOrder(string ord)
        {
            int order = 0;
            int.TryParse(ord, out order);
            return order;
        }
        private static Month GetMonth(string month)
        {
            switch (month)
            {
                case "JAN":
                    {
                        return Month.January;

                    }
                case "FRB":
                    {
                        return Month.February;

                    }
                case "MAR":
                    {
                        return Month.March;

                    }
                case "APRIL":
                    {
                        return Month.April;

                    }
                case "MAY":
                    {
                        return Month.May;

                    }
                case "JUN":
                    {
                        return Month.June;

                    }
                case "JUL":
                    {
                        return Month.July;

                    }
                case "AUG":
                    {
                        return Month.August;

                    }
                case "SEP":
                    {
                        return Month.September;

                    }
                case "OCT":
                    {
                        return Month.October;

                    }
                case "NOV":
                    {
                        return Month.November;

                    }
                case "DEC":
                    {
                        return Month.December;

                    }
                default:
                    {
                        return Month.January;
                    }

            }
        }
        private static ExecutionSettings[] GetExecutionSettings()
        {
            var filePath = @"Z:\MyProjects\MYRND\CodeTests\CodetTests\AutoSQL\ExecutionSettings.json";
            if (File.Exists(@filePath))
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<ExecutionSettings>));
                var s = File.ReadAllText(@filePath);
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(s));
                var config = jsonSerializer.ReadObject(ms) as List<ExecutionSettings>;
                return config.ToArray();
            }

            return null;
        }
        #endregion

        #region error Mail

        public static string CommonSmtpConfigurations(out int port, out string server, out string pass)
        {
            var smtpUser = System.Configuration.ConfigurationManager.AppSettings["SMTPServerUserName"];
            port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SMTPServerPort"]);
            server = System.Configuration.ConfigurationManager.AppSettings["SMTPServer"];
            pass = System.Configuration.ConfigurationManager.AppSettings["SMTPServerPassword"];
            return smtpUser;
        }
        private static bool SendEmail(string fromAddress, string[] toAddr, string subject, string body, string server, int port, string user, string pass)
        {
            var isSuccessful = false;

            try
            {
                using (var client = new SmtpClient(server, port))
                {
                    var from = new MailAddress(fromAddress, String.Empty, System.Text.Encoding.UTF8);
                    using (var message = new MailMessage())
                    {
                        message.From = from;
                        foreach (var to in toAddr)
                        {
                            message.To.Add(new MailAddress(to));
                        }
                        message.Body = body;
                        message.Subject = subject;
                        message.IsBodyHtml = true;
                        message.BodyEncoding = System.Text.Encoding.UTF8;
                        message.SubjectEncoding = System.Text.Encoding.UTF8;
                        client.EnableSsl = true;
                        client.Credentials = new System.Net.NetworkCredential(user, pass);
                        client.Send(message);
                    }
                }
            }
            catch
            {
                //logger.Error(exception);
            }
            return isSuccessful;
        }
        private static void SendErrorMail()
        {
            if (_dic.Count > 0)
            {
                var smtpUser = System.Configuration.ConfigurationManager.AppSettings["SMTPServerUserName"];
                var port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SMTPServerPort"]);
                var server = System.Configuration.ConfigurationManager.AppSettings["SMTPServer"];
                var pass = System.Configuration.ConfigurationManager.AppSettings["SMTPServerPassword"];
                StringBuilder sb = new StringBuilder();
                foreach (var error in _dic)
                {
                    sb.AppendLine(error.Key + "::" + error.Value);
                }
                string body = "Hello All<br/> following error occured while executing sql file\n\r<br/> " + sb.ToString();
                // SendEmail("admin@clysar.com", GetReceipient(), "Error in Sql merge" + DateTime.Now.ToString(), body, server, port, smtpUser, pass);
            }
        }
        private static string[] GetReceipient()
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(EmailConfig));
            string filePath = System.Configuration.ConfigurationManager.AppSettings["FilePath"];

            if (File.Exists(@filePath))
            {
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(File.ReadAllText(@filePath)));

                var objResponse = jsonSerializer.ReadObject(ms) as EmailConfig;
                if (objResponse != null)
                {
                    return objResponse.recipient.Select(p => p.Email).ToArray();
                }
            }

            return new string[] { "pankaj.dey198320@gmail.com" };
        }
        #endregion
    }
    #region MailConfig
    [DataContract]
    class EmailConfig
    {
        [DataMember]
        public string SMTP { get; set; }
        [DataMember]
        public string User { get; set; }
        [DataMember]
        public string Pass { get; set; }
        [DataMember]
        public int Port { get; set; }
        [DataMember]
        public List<recipient> recipient { get; set; }
    }
    [DataContract]
    class recipient
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
    #endregion
    #region ProcessLog
    [DataContract]
    class ProcessLog
    {
        public ProcessLog()
        {
            Files = new List<SqlFileProcessed>();
        }
        [DataMember]
        public DateTime DateOfProcess { get; set; }
        [DataMember]
        public List<SqlFileProcessed> Files { get; set; }
    }
    [DataContract]
    class SqlFileProcessed
    {
        public SqlFileProcessed()
        {
            RefMessage = new List<string>();
        }
        [DataMember]
        public string FilePath { get; set; }
        [DataMember]
        public DateTime ProcessingTime { get; set; }
        [DataMember]
        public bool IsSuccess { get; set; }
        [DataMember]
        public List<string> RefMessage { get; set; }
    }
    #endregion
    #region Execution Settings
    [DataContract]
    class ExecutionSettings
    {
        [DataMember]
        public int order { get; set; }
        [DataMember]
        public string folderPath { get; set; }
    }
    #endregion

    class SqlFileInfo
    {
        public string FullName { get; set; }
        public DateTime Date { get; set; }
        public int Order { get; set; }
        public string FormatError { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
