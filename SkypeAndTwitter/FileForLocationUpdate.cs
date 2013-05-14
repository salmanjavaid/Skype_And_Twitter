using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SkypeAndTwitter
{
    class FileForLocationUpdate
    {

        public bool FileExist()
        {
            if (File.Exists("LocationUpdate.txt"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LocationUpdate()
        {
            try
            {
                if (FileExist())
                {
                    using (StreamReader Reader = new StreamReader("LocationUpdate.txt"))
                    {
                        string temp = Reader.ReadLine().ToString();
                        DateTime Temp = Convert.ToDateTime(temp);
                        TimeSpan check = DateTime.Today - Temp;
                        if (DateTime.Today > Temp)
                        {
                            Reader.Close();
                            using (StreamWriter writer = new StreamWriter("LocationUpdate.txt"))
                            {
                                writer.Write(DateTime.Today.ToShortDateString());
                            }
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter("LocationUpdate.txt"))
                    {
                        writer.Write(DateTime.Today.ToShortDateString());
                        writer.Close();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

    }
}
