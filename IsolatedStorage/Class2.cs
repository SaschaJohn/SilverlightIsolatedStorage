using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace IsolatedStorage
{
    [PSerializable]
    public class MethodLogger : OnMethodBoundaryAspect
    {
        static String file = "sjh-userFile.txt";
        static String content = "Hallo";

        public override void OnEntry(MethodExecutionArgs args)
        {
            try
            {
                var store = IsolatedStorageFile.GetUserStoreForApplication();
                //store.IncreaseQuotaTo();
                IsolatedStorageFileStream isfs = store.OpenFile(file, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(isfs);
                sw.WriteLine(string.Format("{0}", content));
                sw.Flush();
                sw.Close();
            }
            catch (Exception)
            {

                throw;
            }
            base.OnEntry(args);
        }


        
    }
}
