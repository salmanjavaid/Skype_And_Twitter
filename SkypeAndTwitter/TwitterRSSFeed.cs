using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Net;
using System.IO;
using System.Linq;
using System.IO;
using System.Windows.Forms;



namespace SkypeAndTwitter
{
    class TwitterRSSFeed
    {
        public string LatestTweet(string userName)
        {
            try
            {
                string url = "https://api.twitter.com/1/statuses/user_timeline.rss?screen_name=";
                url = url + userName;
                try
                {
                    var rssFeed = XDocument.Load(url);
                    var test = from description in rssFeed.Descendants("title")
                               select (string)description;
                    string[] temp = test.ToArray();

                    string check = temp[1].Remove(0, userName.Length + 1).Trim();
                    return check;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return userName;
                }

                
            }
            catch (Exception e)
            { 
               MessageBox.Show(e.Message, "Ok");
               return userName;
            }
        }
   }
}

