using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace CheckDomainName
{
    public partial class Main : Form
    {
        public List<string> lstResult;
        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            IList<DoMailType> list = new List<DoMailType>();
            list.Add(new DoMailType() { TID = 1, TName = "数字", TDescription = "纯数字" });
            list.Add(new DoMailType() { TID = 2, TName = "字母", TDescription = "纯字母" });
            list.Add(new DoMailType() { TID = 3, TName = "混合", TDescription = "字母和数字混合" });

            cmbDoMailType.DataSource = list;

            cmbDoMailType.ValueMember = "TID";
            cmbDoMailType.DisplayMember = "TName";

            GetUsedDomain();
        }

        private void GetUsedDomain()
        {
            string currentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string logfilename = currentPath + "不可用" + ".log";

             lstResult = ReadFileLine(logfilename); 
        }
        /// <summary>
        /// 读取文件的内容到List中
        /// </summary>
        /// <param name="fileName">文件名+文件路径</param>
        /// <returns></returns>
        public static List<string> ReadFileLine(string fileName)
        {
            List<string> lst = new List<string>();
            if (string.IsNullOrEmpty(fileName))
                return lst;

            StreamReader sr = new StreamReader(fileName, Encoding.Default);

            string content = string.Empty;

            while (content != null)
            {
                content = sr.ReadLine();

                if (content != null)
                { 
                    lst.Add(content);
                }
            }

            sr.Close();

            return lst;
        }

        private void CheckResult()
        {
            try
            {
                string lastStr;
                string url;
                string webUrl;
                string validateCode;

                GetUrl(out lastStr, out url, out validateCode);

                webUrl = "www." + validateCode + lastStr;

                //var b = lstResult.Find(f => f == webUrl);
                //if (b != null)
                //    return;

                while(lstResult.Find(f => f == webUrl) != null)
                {
                    GetUrl(out lastStr, out url, out validateCode);

                    webUrl = "www." + validateCode + lastStr;
                     
                }


                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Timeout = 2000;
                httpRequest.Method = "GET";
                HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                StreamReader sr = new StreamReader(httpResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("gb2312"));
                string result = sr.ReadToEnd();

                if (!result.Contains("(已被注册)"))
                {
                    Log.WriteLog("可以注册的",webUrl);
                    if (this.textBox1.Text != "")
                    {
                        this.textBox1.Text += "\r\n";
                    }
                    this.textBox1.Text += webUrl; 
                }
                else
                {
                    Log.WriteLogUsed(webUrl);
                    lstResult.Add(webUrl);
                }

                textBox1.Focus();
                textBox1.Select(textBox1.Text.Length, 0);
                textBox1.ScrollToCaret();

                sr.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                this.timer1.Enabled = false;
            }
        }

        private void GetUrl(out string lastStr, out string url, out string validateCode)
        {
            int type = Convert.ToInt32(cmbDoMailType.SelectedValue);
            int size = Convert.ToInt32(this.txtSize.Text.Trim());
            lastStr = this.txtLastStr.Text.Trim();
            //string url = "http://www.now.cn/whois/nowcheck.net?query={0}&Submit22=%D4%D9%B4%CE%B2%E9%D1%AF&blog=&domain%5B%5D=.com&domain%5B%5D=.net&domain%5B%5D=.cn&domain%5B%5D=.com.cn&domain%5B%5D=.net.cn";
            url = "http://www.now.cn/whois/nowcheck.net?query={0}&Submit22=%D4%D9%B4%CE%B2%E9%D1%AF&blog=&domain%5B%5D={1}";
            switch (type)
            {
                case 1://数字
                    validateCode = CrateNumber(size);
                    break;
                case 2://字母
                    validateCode = CrateLetter(size);
                    break;
                case 3:
                    validateCode = CreateLetterAndNumber(size);
                    break;
                default:
                    //1
                    validateCode = CrateNumber(size);
                    break;
            }
            //validateCode = "269";
            url = string.Format(url, validateCode, lastStr);
        }
        /// <summary>
        /// 创建随机数字
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private static string CrateNumber(int size)
        {
            string validateCode;
            char[] chars = "023456789".ToCharArray();
            Random random = new Random();
            validateCode = string.Empty;
            for (int i = 0; i < size; i++)
            {
                char rc = chars[random.Next(0, chars.Length)];
                if (validateCode.IndexOf(rc) > -1)
                {
                    i--;
                    continue;
                }
                validateCode += rc;
            }
            return validateCode;
        }
        /// <summary>
        /// 创建随机字母
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private static string CrateLetter(int size)
        {
            string validateCode;
            char[] chars = "abcdefghighlmnopqrstuvwxyz".ToCharArray();
            Random random = new Random();
            validateCode = string.Empty;
            for (int i = 0; i < size; i++)
            {
                char rc = chars[random.Next(0, chars.Length)];
                if (validateCode.IndexOf(rc) > -1)
                {
                    i--;
                    continue;
                }
                validateCode += rc;
            }
            return validateCode;
        }
        /// <summary>
        /// 创建随机混合字符串
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private static string CreateLetterAndNumber(int size)
        {
            string validateCode;
            char[] chars = "abcdefghighlmnopqrstuvwxyz023456789".ToCharArray();
            Random random = new Random();
            validateCode = string.Empty;
            for (int i = 0; i < size; i++)
            {
                char rc = chars[random.Next(0, chars.Length)];
                if (validateCode.IndexOf(rc) > -1)
                {
                    i--;
                    continue;
                }
                validateCode += rc;
            }
            return validateCode;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            CheckResult();
            timer1.Enabled = true;
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            btnStart.Enabled = true;
            btnEnd.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            btnStart.Enabled = false;
            btnEnd.Enabled = true;
        }


    }
    /// <summary>
    /// 域名类别
    /// </summary>
    public class DoMailType
    {
        /// <summary>
        /// 类别ID
        /// </summary>
        public int TID { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string TName { get; set; }
        /// <summary>
        /// 类别说明
        /// </summary>
        public string TDescription { get; set; }
    }

}
