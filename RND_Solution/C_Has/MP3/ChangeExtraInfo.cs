using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using HundredMilesSoftware.UltraID3Lib;

namespace C_Has.MP3
{
    public class ChangeExtraInfo
    {

        public static void Main(string[] args)
        {
            WriteLog("***** New Session Start On " + DateTime.Now + " *****");
            Console.WriteLine("What Action You Want To Perform ?");
            Console.WriteLine("Press 1 : To Change Title With FileName");
            Console.WriteLine("Press 2 : To Change Album name With Parent Folder Name");
            Console.WriteLine("Press 3 : To Change Track Number With The Number In FileName (Last 3 Digit)");
            Console.WriteLine("Press 4 : To Compare Title With FileName");
            Console.WriteLine("Press 5 : To Exit");
            string actionValue = Console.ReadLine();

            switch (actionValue)
            {
                case "1":
                    ChangeTitleWithFileName();
                    break;
                case "2":
                    ChangeAlbumWithParentFolder();
                    break;
                case"3":
                    SetTrackNumber();
                    break;
                case"4":
                    CompareFileNameWithTitle();
                    break;
                case "5":
                    return;
                    break;
                default:
                    Console.WriteLine("Invalid Value");
                    break;
            }

            WriteLog("***** Session End At " + DateTime.Now + " *****");
            Main(null);
        }

        public static void SetTrackNumber()
        {
            
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;

            foreach (
                string file in
                    Directory.EnumerateFiles(exePath.Substring(0, exePath.LastIndexOf("\\") + 1), "*.mp3",
                        SearchOption.AllDirectories))
            {
                UltraID3 u = new UltraID3();
                u.Read(file);
                string OnlyFileName = u.FileName.Substring(u.FileName.LastIndexOf("\\") + 1).Replace(".mp3", "");

                OnlyFileName = OnlyFileName.Substring(OnlyFileName.Length - 3, 3);

                short trackNumber = Convert.ToInt16(OnlyFileName);

                if (trackNumber <= 255)
                {
                    u.TrackNum = trackNumber;
                    u.Write();
                }
                else
                {
                    WriteLog("Track Length More Than 255 For File Name : " + u.FileName);
                }
                
            }

            WriteLog("Track Changed");
        }

        public static void CompareFileNameWithTitle()
        {

            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;

            int maxFileName = 0;

            foreach (string file in Directory.EnumerateFiles(exePath.Substring(0, exePath.LastIndexOf("\\") + 1), "*.mp3", SearchOption.AllDirectories))
            {
                UltraID3 u = new UltraID3();
                u.Read(file);
                string OnlyFileName = u.FileName.Substring(u.FileName.LastIndexOf("\\") + 1).Replace(".mp3", "");

                maxFileName = maxFileName < OnlyFileName.Length ? OnlyFileName.Length : maxFileName;

                WriteLog(string.Format("{0}\t{1}", OnlyFileName, u.Title));
            }

            WriteLog(maxFileName.ToString());

            WriteLog("Comparation Done");
        }

        public static void ChangeTitleWithFileName()
        {
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;

            int fileCount = 0;
            foreach (string file in Directory.EnumerateFiles(exePath.Substring(0, exePath.LastIndexOf("\\") + 1), "*.mp3", SearchOption.AllDirectories))
            {
                UltraID3 u = new UltraID3();
                u.Read(file);
                string OnlyFileName = u.FileName.Substring(u.FileName.LastIndexOf("\\") + 1).Replace(".mp3", "");
                try
                {
                    if (OnlyFileName.Length >= 30)
                    {
                        WriteLog("Length More Than 30 For File Name : " + u.FileName);
                        u.Title = OnlyFileName.Substring(0, 30);
                    }
                    else
                    {
                        u.Title = OnlyFileName;
                    }

                    u.Write();
                    WriteLog("Done For File Name : " + u.FileName);

                    fileCount++;
                }
                catch (Exception e)
                {
                    WriteLog("Following Error For File : " + u.FileName);
                    WriteLog(e.Message);
                }

            }
            Console.WriteLine("All Done For File Number : " + fileCount);
        }

        public static void ChangeAlbumWithParentFolder()
        {
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;

            int fileCount = 0;
            foreach (string file in Directory.EnumerateFiles(exePath.Substring(0, exePath.LastIndexOf("\\") + 1), "*.mp3", SearchOption.AllDirectories))
            {
                UltraID3 u = new UltraID3();
                u.Read(file);

                string ParentFolderName =
                    u.FileName.Substring(u.FileName.LastIndexOf("\\", u.FileName.LastIndexOf("\\") - 1) + 1,
                        u.FileName.LastIndexOf("\\", u.FileName.LastIndexOf("\\")) -
                        u.FileName.LastIndexOf("\\", u.FileName.LastIndexOf("\\") - 1) - 1);

                try
                {
                    if (ParentFolderName.Length >= 30)
                    {
                        WriteLog("Length More Than 30 For Album Name : " + ParentFolderName);
                        u.Album = ParentFolderName.Substring(0, 30);
                    }
                    else
                    {
                        u.Album = ParentFolderName;
                    }

                    u.Write();
                    WriteLog("Done For File Name : " + u.FileName);

                    fileCount++;
                }
                catch (Exception e)
                {
                    WriteLog("Following Error For File : " + u.FileName);
                    WriteLog(e.Message);
                }

            }
        }

        private static void WriteLog(string Message)
        {
            Console.WriteLine(Message);
            using (StreamWriter writer = new StreamWriter("Log.txt", true))
            {
                writer.WriteLine(Message);
            }
        }
    }
}
