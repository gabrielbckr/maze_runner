using System.Threading;
using mazeRunner.Field;

namespace mazeRunner.Explorer {
    class Walker {
        public static void Walk( Position actualPosition ) {
            Thread.Sleep(50);
            Position temp = new Position();
            var pos_i = actualPosition.x_pos;
            var pos_j = actualPosition.y_pos;
            
            if (Program.maze.positions[pos_i, pos_j] != 's')
            {
                Program.maze.positions[pos_i, pos_j] = 'o';
                int[] movingOptions = new int[4];
                movingOptions[0] = ValidatePosition(actualPosition.RightNeighbour());  //Right
                movingOptions[1] = ValidatePosition(actualPosition.UpNeighbour());     //Up
                movingOptions[2] = ValidatePosition(actualPosition.DownNeighbour());   //Down
                movingOptions[3] = ValidatePosition(actualPosition.LeftNeighbour());   //Left

                int soma = movingOptions[0] + movingOptions[1]
                    + movingOptions[2] + movingOptions[3];

                if (movingOptions[0] == 1)
                {
                    Program.numberOfThreads++;
                    Position nextPosition = new Position(pos_i ,  pos_j + 1);
                    // Position temp = actualPosition.Right();
                    if (soma > 1)
                    {
                        Thread right = new Thread(() => Walk(nextPosition));
                        right.Start();
                    }
                    else
                    {
                        Program.maze.positions[pos_i , pos_j] = ' ';
                        Walk(nextPosition);
                    }
                    soma--;
                }
                if (movingOptions[1] == 1)
                {
                    Program.numberOfThreads++;
                    Position nextPosition = new Position(pos_i + 1, pos_j );
                    // Position temp = actualPosition.Right();
                    if (soma > 1)
                    {
                        Thread up = new Thread(() => Walk(nextPosition));
                        up.Start();
                    }
                    else
                    {
                        Program.maze.positions[pos_i, pos_j] = ' ';
                        Walk(nextPosition);
                    }
                    soma--;
                }
                if (movingOptions[2] == 1)
                {
                    Program.numberOfThreads++;
                    Position nextPosition = new Position(pos_i - 1, pos_j);
                    // Position temp = actualPosition.Right();
                    if (soma > 1)
                    {
                        Thread down = new Thread(() => Walk(nextPosition));
                        down.Start();
                    }
                    else
                    {
                        Program.maze.positions[pos_i, pos_j] = ' ';
                        Walk(nextPosition);
                    }
                    soma--;
                }
                if (movingOptions[3] == 1)
                {
                    Program.numberOfThreads++;
                    Position nextPosition = new Position(pos_i, pos_j - 1);
                    // Position temp = actualPosition.Right();
                    if (soma > 1)
                    {
                        Thread left = new Thread(() => Walk(nextPosition));
                        left.Start();
                    }
                    else
                    {
                        Program.maze.positions[pos_i, pos_j] = ' ';
                        Walk(nextPosition);
                    }
                    soma--;
                }


            }
            else
            {
                Program.exitAllThreads = true;
            }
        }
            
        public static int ValidatePosition(Position actualPosition){
            var pos_i = actualPosition.x_pos;
            var pos_j = actualPosition.y_pos;
            var num_rows = Program.maze.length_x;
            var num_cols = Program.maze.length_y;
            if (    pos_i >= 0 && pos_i < num_rows 
                &&  pos_j >= 0 && pos_j < num_cols  )
            { // e existe (esta dentro do labirinto)
                if (Program.maze.positions[pos_i , pos_j] != '#')
                {       // Se o espaço de baixo esta vazio
                    if (    Program.maze.positions[pos_i , pos_j] == 'x' 
                         || Program.maze.positions[pos_i , pos_j] == 's') //pode ser visitado
                    {       
                        return 1;
                    }
                }
            }
            return 0;
        }
        public static int ValidatePosition(int x, int y)
        {
            Position newPos = new Position();
            newPos.x_pos = x;
            newPos.y_pos = y;
            return ValidatePosition(newPos);
        }
    }
}
