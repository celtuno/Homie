using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homie.Models
{
    class FileHandling
    {
        
        private string fileName = Directory.GetCurrentDirectory() + "\\Parameters.txt";
        
        public string sqlCon;

        
        public void FileReader()
        {
            
                FileStream fS = new FileStream(fileName, FileMode.OpenOrCreate);
                fS.Close();
                StreamReader SR = new StreamReader(fileName);
            try
            {
                sqlCon = SR.ReadLine().ToString();
               
                
                

            }
            catch (Exception e)
            {

            }
            SR.Close();
        }

        public void FileWriter(string tmpSqlCon)
        {
            File.Delete(fileName);

            FileStream fS = new FileStream(fileName, FileMode.OpenOrCreate);
            fS.Close();
            StreamWriter SW = new StreamWriter(fileName);

            SW.WriteLine(tmpSqlCon);
           // SW.WriteLine(readInterval);
            //SW.WriteLine(delayAfterAlarmTrigger);
            

            SW.Close();
        }
        
    }
}
