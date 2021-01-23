using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BattleShips
{
    class Logger
    {
        /// <summary>
        /// имя файла для записи игры 
        /// </summary>
        private string fileName;
        
        public Logger(string filename)
        {
            this.fileName = filename;
             
        }

        public void  WriteShot(СellCoordinates cell, ResultShot resultshot)
        {
            using(var sw = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                sw.Write("horizontal:{0} , vertical:{1} : ", cell.Horizontal, cell.Vertical);
                switch (resultshot)
                {
                    case ResultShot.Miss:
                        sw.Write("Miss");
                        break;
                    case ResultShot.Damage:
                        sw.Write("Damage");
                        break;
                    case ResultShot.Kill:
                        sw.Write("Kill");
                        break;
                    default:
                        break;
                }
                sw.WriteLine();
            }

          
        }
        public void WriteGamer(string strnamegamer)
        {
            using (var sw = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                sw.Write("{0} Move:",strnamegamer);
                sw.WriteLine();
            
            }   

        }

        public void WriteWinner(string strnamegamer)
        {
            using (var sw = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                sw.Write("{0} is winner", strnamegamer);
                sw.WriteLine();
                sw.WriteLine();
                sw.WriteLine();
                sw.WriteLine();

            }

        }
    }
            
}
