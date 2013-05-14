using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SkypeAndTwitter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TimerCallBack(object state)

        {
            FileForLocationUpdate File = new FileForLocationUpdate();
            bool check = File.LocationUpdate();
            TwitterRSSFeed Temp = new TwitterRSSFeed();
            SkypeUpdate SkypeUp = new SkypeUpdate();
            SkypeUp.StatusUpdate(Temp.LatestTweet(UserName.Text.ToString().Trim()));
            SkypeUp.LocationUpdate();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool CheckFields()
        {
            if (UserName.Text.Length == 0 || Time.Text.Length == 0 || Location.Text.Length == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            
            if (CheckFields())
            {
                Int64 Timer = 0;

                if (Time.SelectedIndex == 0)
                {
                    Timer = 60000;
                }
                else if (Time.SelectedIndex == 1)
                {
                    Timer = 2*60000;
                }
                else if (Time.SelectedIndex == 2)
                {
                    Timer = 5*60000;
                }
                else if (Time.SelectedIndex == 3)
                {
                    Timer = 10*60000;
                }
                else if (Time.SelectedIndex == 4)
                {
                    Timer =  60 * 60000;
                }
            
                
                new System.Threading.Timer(TimerCallBack, null, 0, Timer);
               
            }
            else
            {
                MessageBox.Show("Please fill all the form fields.", "Ok");
            }
        }
    }
}
