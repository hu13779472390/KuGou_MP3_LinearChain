using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;//这个命名空间是微软提供 
using System.IO;//这个是流(不太懂)
using System.Collections;
using System.Text.RegularExpressions;

public struct MusicType
{
    public string songName;
    public string bitRate;
    public string singerName;
    public string url;
    public string fileName;
    public string timeLength;
}

namespace KuGou_MP3_LinearChain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string url;
            if (TXT_音乐名.Text == "")
            {
                MessageBox.Show("请输入音乐名字");

            }else
            {
                //把音乐名字加到网址里面
                url = "http://mobilecdn.kugou.com/api/v3/search/song?format=jsonp&keyword=" + TXT_音乐名.Text + "&page=1&pagesize=10&showtype=1";
                string HttpText=GetHttpText(url,"UTF-8");//第一个参数是网页 第二个参数是编码格式
                //用List 保存Hash值
                List<string> val = GetHashByText(HttpText);
                GetMP3Information(val);
            }
            
        }

        public string GetHttpText(string url,string HttpEncoding)
        {
            //WebRequest类
            //首先先建立一个HttpWebRequest实例
            //使用WebRequest类提供的静态方法Create()
            //原型如下
            //public static WebRequest Create(string);
            //public static WebRequest Create(uri);
            //返回的实例类型是WebRequest 需要强制转换为HttpWebRequest
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            //webResponse类
            //建立一个HttpWebResponse实例 用来接收服务器发的消息
            //它是调用HttpWebRequest.GetResponse来获取的
            //也需要强制转换
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            //下面是用来检测成功
            if (webResponse.StatusCode == HttpStatusCode.OK)
            {
                Stream stream = webResponse.GetResponseStream(); // 获取接收到的流
                StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding(HttpEncoding));
                // 建立一个流读取器，可以设置流编码，不设置则默认为UTF-8
                string content = streamReader.ReadToEnd();
                // 读取流字符串内容
                return content;
            }
            return null;
        }
        public List<string> GetHashByText(string httpText)
        {
            List<string> val = new List<string>();
            int leftPosition = 0, rightPosition = 0;//声明两个整数变量 分别保存hash值左右位置
            do {
                leftPosition = httpText.IndexOf(KugouConstant.HashLeft,leftPosition);//搜索左右位置
                rightPosition = httpText.IndexOf(KugouConstant.HashRight,rightPosition);
                string temp;//临时保存哈希值
                if (leftPosition != -1)
                {
                    temp = httpText.Substring(leftPosition + KugouConstant.HashLeft.Length, rightPosition - leftPosition - KugouConstant.HashLeft.Length);
                    if (temp !="")
                    {
                        val.Add(temp);//加入哈希值
                    }
                    leftPosition++;//自加是为了从下一个位置
                    rightPosition++;
                }
                
            } while (leftPosition!=-1);//失败返回的是-1  所以判断是否为0
            return val;
        }
        public void GetMP3Information(List<string> hash)
        {
            for(int x = 0; x < hash.Count; x++)
            {
                string httpText = GetHttpText("http://m.kugou.com/app/i/getSongInfo.php?hash=" + hash[x] + "&cmd=playInfo", "UTF-8");
                int leftPosition = 0, rightPosition = 0;//声明两个整数变量 分别保存左右位置
                MusicType musictype;
                //歌曲名
                leftPosition = httpText.IndexOf(KugouConstant.SongLeft);
                rightPosition = httpText.IndexOf(KugouConstant.SongRight);
                if (rightPosition > leftPosition)
                {
                    musictype.songName = httpText.Substring(leftPosition + KugouConstant.SongLeft.Length, rightPosition - leftPosition - KugouConstant.SongLeft.Length);
                }else
                {
                    musictype.songName = "";
                }
                //歌手名
                leftPosition = httpText.IndexOf(KugouConstant.SingNameLeft);
                rightPosition = httpText.IndexOf(KugouConstant.SingNameRight);
                if (rightPosition > leftPosition)
                {
                    musictype.singerName = httpText.Substring(leftPosition + KugouConstant.SingNameLeft.Length, rightPosition - leftPosition - KugouConstant.SingNameLeft.Length);
                }else
                {
                    musictype.singerName = "";
                }
                //文件名
                leftPosition = httpText.IndexOf(KugouConstant.FileNameLeft);
                rightPosition = httpText.IndexOf(KugouConstant.FileNameRight);
                if (rightPosition > leftPosition)
                {
                    musictype.fileName = httpText.Substring(leftPosition + KugouConstant.FileNameLeft.Length, rightPosition - leftPosition - KugouConstant.FileNameLeft.Length);
                }else
                {
                    musictype.fileName = "";
                }
                //比特率
                leftPosition = httpText.IndexOf(KugouConstant.BitRateLeft);
                rightPosition = httpText.IndexOf(KugouConstant.BitRateRight);
                if (rightPosition > leftPosition)
                {
                    musictype.bitRate = httpText.Substring(leftPosition + KugouConstant.BitRateLeft.Length, rightPosition - leftPosition - KugouConstant.BitRateLeft.Length);
                }else
                {
                    musictype.bitRate = "";
                }
                //直链地址
                leftPosition = httpText.IndexOf(KugouConstant.UrlLeft);
                rightPosition = httpText.IndexOf(KugouConstant.UrlRight);
                if (rightPosition > leftPosition)
                {
                    musictype.url = httpText.Substring(leftPosition + KugouConstant.UrlLeft.Length, rightPosition - leftPosition - KugouConstant.UrlLeft.Length);
                    musictype.url=musictype.url.Replace("\\","");
                }else
                {
                    musictype.url = "";
                }
                //时长 因为是整数类型 需要转换一下
                leftPosition = httpText.IndexOf(KugouConstant.TimeLengthLeft);
                if (leftPosition>0)
                {
                    string str = httpText.Substring(leftPosition + KugouConstant.TimeLengthLeft.Length, 3);
                    str = IsNum(str);//
                    int temp = Convert.ToInt32(str);
                    musictype.timeLength = Convert.ToString(temp / 60) + "分" + Convert.ToString(temp % 60) + "秒";
                }
                else
                {
                    musictype.timeLength = "";
                }
                listView1.Items.Add(musictype.fileName);
                listView1.Items[x].SubItems.Add(musictype.songName);
                listView1.Items[x].SubItems.Add(musictype.singerName);
                listView1.Items[x].SubItems.Add(musictype.bitRate);
                listView1.Items[x].SubItems.Add(musictype.timeLength);
                listView1.Items[x].SubItems.Add(musictype.url);
            }
        }

        public string IsNum(String str)
    {
        string ss = "";
        for (int i = 0; i<str.Length; i++)
        {
            if (Char.IsNumber(str, i) == true)
            {
                ss += str.Substring(i, 1);
            }
            else
            {
                if (str.Substring(i, 1) == ",")
                {
                    ss += str.Substring(i, 1);
                }
            }
                
        }
        return ss;
    }//专门从字符串中提取数字的

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TXT_url.Text= listView1.FocusedItem.SubItems[5].Text;

        }
    }
}
