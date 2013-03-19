using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Drawing.Drawing2D;
using Matmaxx.Toolbox.StopWatch;
using System.IO;
using Amib.Threading;


namespace ThreadTest
{
  public class ThumbnailWorkerData
  {
    public string Path;
    public int Width;
    public int Height;
    public bool IsLastImage;
    public ThumbnailWorkerData(string path, int width, int height, bool isLastImage)
    {
      this.Path         = path;
      this.Width        = width;
      this.Height       = height;
      this.IsLastImage  = isLastImage;
    }      
  }

  class Program
  {
    const string DefaultPath = @"D:\work\code\butchr_data\testdata2\DCIM\";
    static DebugTimer dt;
    static List<string> jpgs = new List<string>();
    static SmartThreadPool stp = new SmartThreadPool();
    static void Main(string[] args)
    {
      //init the timer
      dt = new DebugTimer();
      dt.OutputToString();
      dt.Reset();
      dt.Start("Complete measurement");
      //read all files in the directory
      string[] files = Directory.GetFiles(DefaultPath);
      //loop all files and extract the jpg-images
      foreach (string file in files)
      {
        //check for jpgs before attempting to create a thumbnail
        if (IsDisplayableExtension(file))
        {
          //add it to the jpg collection
          jpgs.Add(file);
        }
      }
      //loop through all jpgs
      for (int i = 0; i < jpgs.Count; i++)
      {
        //create a thumbnail for this image and add it to the dictionary
        //thumbCache.Add(jpgs[i], CreateThumbnail(jpgs[i], width, height));
        //remember whether this is the last image
        bool isLastImage = (i == jpgs.Count-1) ? true : false;
        object threadData = (object)(new ThumbnailWorkerData(jpgs[i],100,100,isLastImage));
        
        //synced call
        //Worker(threadData);

        //standalone threads
        //Thread t = new Thread(new ParameterizedThreadStart(Worker));
        //t.Start(threadData);

        //smart threadpool
        //stp.QueueWorkItem(new WorkItemCallback(Worker),threadData);
        //add the job to the thread pool

        //.NET threadpool
        ThreadPool.QueueUserWorkItem(new WaitCallback(Worker),threadData); 
        Thread.Sleep(100);
      }
      Console.WriteLine("Press any key to exit");
      Console.ReadKey();
    }

    public static bool IsDisplayableExtension(string path)
    {
      //local retval
      bool retval = false;
      //get the extension from the path, make it lowercase and remove the point
      string extension = Path.GetExtension(path).ToLower().Replace(".", "");
      //remove any points from the 
      if ((extension.Equals("jpg")) || (extension.Equals("jpeg")))
      {
        retval = true;
      }
      //finally return the result
      return retval;
    }

    public static void Worker(Object data)
    {
      DebugTimer t = new DebugTimer();
      t.OutputToString();
      t.Reset();
      ThumbnailWorkerData bitmap = (ThumbnailWorkerData)data;
      string workerIdent = string.Format("Worker: {0}",bitmap.Path);
      t.Start(workerIdent);
      Console.WriteLine(workerIdent);
      Image bitmapFromFile = (Image)Bitmap.FromFile(((ThumbnailWorkerData)data).Path);
      t.Stop();
      Console.WriteLine(t.Output);
      if(bitmap.IsLastImage)
      {
        dt.Stop();
        Console.WriteLine(dt.Output);
      }
//      return null;
    }

  }
}
