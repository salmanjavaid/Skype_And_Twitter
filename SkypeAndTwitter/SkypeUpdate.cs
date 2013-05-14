using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SKYPE4COMLib;
using System.Xml;


namespace SkypeAndTwitter
{
    class SkypeUpdate
    {
        Skype SkypeClient = new Skype();
        
        public bool StatusUpdate(string Status)
        {
            
                SkypeClient.Attach(7, false);
                if (ClientRunning() && ClientSignedIn())
                {
                    SkypeClient.CurrentUserProfile.MoodText = Status;
                    return true;
                }
                else
                {   
                    MessageBox.Show("Please make sure Skype is running and you are signed in.", "Ok");
                    return false;
                }
        }

        public bool LocationUpdate()
        {
            try
            {
                SKYPE4COMLib.IUserCollection user = null;
              
            //    SkypeClient.CurrentUserProfile.Country = "+93";
           //     FileForLocationUpdate File = new FileForLocationUpdate();
             //   File.LocationUpdate();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        
        private bool ClientRunning()
        {
          
            if(SkypeClient.Client.IsRunning)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
 
        private bool ClientSignedIn()
        {
            try
            {
                if (SkypeClient.CurrentUserStatus == TUserStatus.cusLoggedOut)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
