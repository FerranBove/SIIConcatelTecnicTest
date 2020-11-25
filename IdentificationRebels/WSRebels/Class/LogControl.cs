using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WSRebels.Class
{
    public static class LogControl
    {
        public static void SaveLog(string error)
        {
            string path = Class.ConfigApp.LogPath;
            //if (!File.Exists(path))
            //{
            //    File.Create(path);
            //    File.AppendAllText(path, error + Environment.NewLine);
            //}
            //else
            //{
                File.AppendAllText(path, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+" -> "+ error + Environment.NewLine);
            //}
        }
    }
}