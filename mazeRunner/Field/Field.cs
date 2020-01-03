using System;
using System.Linq;
using System.IO;

namespace mazeRunner.Field {
    public class Position {
        public int x_pos { get; set; }
        public int y_pos { get; set; }
        public Position(int x = 0, int y = 0)
        {
            x_pos = x;
            y_pos = y;
        }
        public Position RightNeighbour(){ return new Position(x_pos, y_pos + 1); }
        public Position UpNeighbour()   { return new Position(x_pos + 1, y_pos); }
        public Position DownNeighbour() { return new Position(x_pos - 1, y_pos); }
        public Position LeftNeighbour() { return new Position(x_pos, y_pos - 1); }

    }
    public class MazeField {
        public int length_x = 0;
        public int length_y = 0;
        public char[,] positions;
        public Position load(string fileName)
        {
            Position initialPosition = new Position();

            StreamReader file = new StreamReader( fileName );
            string textFromFile = file.ReadToEnd();
            var splittedFileText = textFromFile.Split().ToList();
            length_x = int.Parse(splittedFileText[0]);
            length_y = int.Parse(splittedFileText[1]);

            splittedFileText.RemoveAt(0);
            splittedFileText.RemoveAt(0);
            foreach (var item in splittedFileText)
            {
                Console.WriteLine(item);
            }

            positions = new char[length_x, length_y];
            for(int ii = 0; ii< length_x; ii++){
                char[] columItens = (splittedFileText[ii]).ToCharArray();
                for (int jj = 0; jj<length_y; jj++){
                    positions[ii, jj] = columItens[jj];
                    if(positions[ii, jj] == 'e'){
                        initialPosition.x_pos = ii;
                        initialPosition.y_pos = jj;
                    }
                }
            }

            return initialPosition;
        }
        public void Display()
        {
            Console.Clear();
            for (int ii = 0; ii < length_x; ii++)
            {
                for (int jj = 0; jj < length_y; jj++)
                {
                    Console.Write(positions[ii, jj]);
                }
                Console.Write("\n");
            }
        }
    }
}
