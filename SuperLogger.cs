using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BattleShips
{
    class SuperLogger
    {
        private string fileName;
        private string text;
        
        public SuperLogger(string filename)
        {
            this.fileName = filename;
        }
        public void WriteShot(СellCoordinates cell, ResultShot resultshot)
        {
            text += "horizontal:";
            text += cell.Horizontal.ToString();
            text += "  vertical:";
            text += cell.Vertical.ToString();
            switch (resultshot)
            {
                case ResultShot.Miss:
                    text+=" Miss";
                    break;
                case ResultShot.Damage:
                    text += " Damage";
                    break;
                case ResultShot.Kill:
                    text += " Kill";
                    break;
                default:
                    break;
            }
            text += "\r\n";
        }
        public void WriteGamer(string strnamegamer)
        {
            text += strnamegamer += " Move:";
            text += "\r\n";
        }
            


        public void WriteWinner(string strnamegamer)
        {
            text += strnamegamer += " is winner";
            text += "\r\n";
            text += "\r\n";
            text += "\r\n";
        }

        public void WriteInFile()
        {
            using (var sw = new StreamWriter(this.fileName , true, Encoding.UTF8))
            {
                sw.Write(this.text);
            
            }
        }
           
         

    }
}

