using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BattleShips
{
    /// <summary>
    /// Класс для логирования игры в текстовый документ 
    /// </summary>
    class Logger
    {
        /// <summary>
        /// имя файла в который будет происходить запись игры 
        /// </summary>
        private string fileName;
        /// <summary>
        /// Во время партии в поле text происходит запись ходов  и результатов попаданий метод WriteShot
        /// а затем по окончанию партии из text данные записываются в файл WriteInFile()
        /// </summary>
        private string text;
        
        public Logger(string filename)
        {
            this.fileName = filename;
        }

        /// <summary>
        /// метод записывает в поле text ход игрока 
        /// </summary>
        /// <param name="cell">координаты клетки в которую стреляли</param>
        /// <param name="resultshot">результат выстрела </param>
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
            text += "------\r\n";
            text += "------\r\n";
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
        


           
         

