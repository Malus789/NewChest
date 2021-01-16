using System;

namespace Chess
{
    class Program
    {

        class Piece
        {
            public string data;
            public string player;
            public string type;
            private Piece player2;
            private Piece type2;

            public string Data
            {
                get { return data; }
                set { data = value; }
            }

            public Piece Player2
            {
                get { return player2; }
                set { player2 = value; }
            }

            public Piece Type2
            {
                get { return type2; }
                set { type2 = value; }
            }

        }


        class Board
        {
            public Piece head = null;
            String[,] ChessBoard = new String[8, 8];

            void FillBoard()
            {
                for (int rows = 0; rows < ChessBoard.GetLength(0); rows++)
                {
                    for (int columns = 0; columns < ChessBoard.GetLength(1); columns++)
                    {
                        ChessBoard[rows, columns] = "[   ]";
                    }
                }
            }

            void ReadBoard()
            {

                for (int rows = 0; rows < ChessBoard.GetLength(0); rows++)
                {
                    for (int columns = 0; columns < ChessBoard.GetLength(1); columns++)
                    {
                        if (ChessBoard[rows, columns] != "[   ]") {
                            Console.Write(" " + ChessBoard[rows, columns] + " ");
                        } else {
                            Console.Write(ChessBoard[rows, columns]);
                        }

                        if (columns == 7)
                        {
                            Console.WriteLine("");
                        }
                    }
                }
            }

            public void insertPiece(int whereC, int whereR, string player, string type)
            {
                Piece NewPiece = new Piece();

                NewPiece.player = player;
                NewPiece.type = type;
                NewPiece.Data = type + player;
                ChessBoard[whereR, whereC] = NewPiece.data;
            }

            public void movePiece(int whichC, int whichR, int whereC, int whereR)
            {             
                WhichC = whichC;
                WhichR = whichR;
                WhereR = whereR;
                WhereC = whereC;
         
                if (ChessBoard[whichR, whichC] == "Pj1")
                {
                    PawnRule(whichR, whichC, "player1");
                }
                else
                if (ChessBoard[whichR, whichC] == "Rj1")
                {
                    RootRule(whichR, whichC, "player1");
                }
                else
                if (ChessBoard[whichR, whichC] == "Bj1")
                {
                    BishopRule(whichR, whichC, "player1");
                }
                else
                if (ChessBoard[whichR, whichC] == "Hj1")
                {
                    KnightRule(whichR, whichC, "player1");
                }
                else
                if (ChessBoard[whichR, whichC] == "Qj1")
                {
                    QueenRule(whichR, whichC, "player1");
                }
                else
                if (ChessBoard[whichR, whichC] == "Kj1")
                {
                    KingRule(whichR, whichC, "player1");
                }
                else

                if (ChessBoard[whichR, whichC] == "Pj2")
                {
                    PawnRule(whichR, whichC, "player2");
                }
                else
                if (ChessBoard[whichR, whichC] == "Rj2")
                {
                    RootRule(whichR, whichC, "player2");
                }
                else
                if (ChessBoard[whichR, whichC] == "Bj2")
                {
                    BishopRule(whichR, whichC, "player1");
                }
                else
               if (ChessBoard[whichR, whichC] == "Hj2")
                {
                    KnightRule(whichR, whichC, "player2");
                }
                else
               if (ChessBoard[whichR, whichC] == "Qj2")
                {
                    QueenRule(whichR, whichC, "player2");
                }
                else
               if (ChessBoard[whichR, whichC] == "Kj2")
                {
                    KingRule(whichR, whichC, "player2");
                }

            }

            int[] valoresMoveR = new int[30];
            int[] valoresMoveC = new int[30];

            int WhereR;
            int WhereC;
            int WhichR;
            int WhichC;

            void PawnRule(int whereR, int whereC, string player)
            {
                if (player == "player1")
                {
                    valoresMoveR[0] = whereR - 1;
                    valoresMoveC[0] = whereC;
                    MovingCalculator(WhereR, WhereC, "player 1");
                }
                else
                if (player == "player2")
                {                 
                    valoresMoveR[0] = whereR + 1;
                    valoresMoveC[0] = whereC;
                    MovingCalculator(WhereR, WhereC, "player 2");
                }
               
            }


            void BishopRule(int whereR, int whereC, string player)
            {
                if (whereR - 1 >= 0)
                {
                    if (whereC - 1 >= 0)
                    {
                        valoresMoveR[0] = whereR - 1;
                        valoresMoveC[0] = whereC - 1;
                    }

                    if (whereC + 1 <= 7)
                    {
                        valoresMoveR[1] = whereR - 1;
                        valoresMoveC[1] = whereC + 1;
                    }

                }

                if (whereR + 1 <= 7)
                {
                    if (whereC - 1 >= 0)
                    {
                        valoresMoveR[2] = whereR + 1;
                        valoresMoveC[2] = whereC - 1;
                    }

                    if (whereC + 1 <= 7)
                    {
                        valoresMoveR[3] = whereR + 1;
                        valoresMoveC[3] = whereC + 1;
                    }                

                }

                if (whereR + 2 <= 7)
                {
                    if (whereC + 2 <= 7)
                    {
                        valoresMoveR[4] = whereR + 2;
                        valoresMoveC[4] = whereC + 2;
                    }
                    if (whereC - 2 >= 0)
                    {
                        valoresMoveR[5] = whereR - 2;
                        valoresMoveC[5] = whereC - 2;
                    }

                }

                if (whereR - 2 >= 0)
                {
                    if (whereC + 2 <= 7)
                    {
                        valoresMoveR[6] = whereR + 2;
                        valoresMoveC[6] = whereC - 2;
                    }
                    if (whereC - 2 >= 0)
                    {
                        valoresMoveR[7] = whereR - 2;
                        valoresMoveC[7] = whereC - 2;
                    }

                }

                if (player == "player1")
                {
                    MovingCalculator(WhereR, WhereC, "player 1");
                }
                else
                if (player == "player2")
                {
                    MovingCalculator(WhereR, WhereC, "player 2");
                }
            }

            void KnightRule(int whereR, int whereC, string player)
            {
                if (whereR - 2 >= 0)
                {
                    if (whereC + 1 <= 7)
                    {
                        valoresMoveR[0] = whereR - 2;
                        valoresMoveC[0] = whereC + 1;
                    }

                    if (whereC - 1 >= 0)
                    {
                        valoresMoveR[1] = whereR - 2;
                        valoresMoveC[1] = whereC - 1;
                    }

                }

                if (whereR + 2 <= 7)
                {
                    if (whereC + 1 <= 7)
                    {
                        valoresMoveR[2] = whereR + 2;
                        valoresMoveC[2] = whereC + 1;
                    }

                    if (whereC - 1 >= 0)
                    {
                        valoresMoveR[3] = whereR + 2;
                        valoresMoveC[3] = whereC - 1;
                    }
                }

                if (whereC + 2 <= 7)
                {
                    if (whereR + 1 <= 7)
                    {
                        valoresMoveR[2] = whereR + 1;
                        valoresMoveC[2] = whereC + 2;
                    }

                    if (whereC - 1 >= 0)
                    {
                        valoresMoveR[3] = whereR - 1;
                        valoresMoveC[3] = whereC + 2;
                    }

                }
                if (whereC - 2 >= 0)
                {
                    if (whereR + 1 <= 7)
                    {
                        valoresMoveR[2] = whereR + 1;
                        valoresMoveC[2] = whereC - 2;
                    }

                    if (whereR - 1 >= 0)
                    {
                        valoresMoveR[3] = whereR - 1;
                        valoresMoveC[3] = whereC - 2;
                    }
                }
          
        
                if (player == "player1")
                {
                    MovingCalculator(WhereR, WhereC, "player 1");
                }
                else
                if (player == "player2")
                {
                    MovingCalculator(WhereR, WhereC, "player 2");
                }
            }

            void QueenRule(int whereR, int whereC, string player)
            {
                //Bishop
                if (whereR - 1 >= 0)
                {
                    if (whereC - 1 >= 0)
                    {
                        valoresMoveR[0] = whereR - 1;
                        valoresMoveC[0] = whereC - 1;
                    }

                    if (whereC + 1 <= 7)
                    {
                        valoresMoveR[1] = whereR - 1;
                        valoresMoveC[1] = whereC + 1;
                    }
                }

                if (whereR + 1 <= 7)
                {
                    if (whereC - 1 >= 0)
                    {
                        valoresMoveR[2] = whereR + 1;
                        valoresMoveC[2] = whereC - 1;
                    }

                    if (whereC + 1 <= 7)
                    {
                        valoresMoveR[3] = whereR + 1;
                        valoresMoveC[3] = whereC + 1;
                    }

                    if (whereR + 2 <= 7)
                    {
                        if (whereC + 2 <= 7)
                        {
                            valoresMoveR[4] = whereR + 2;
                            valoresMoveC[4] = whereC + 2;
                        }

                    }

                }
                //king
                if (whereR - 1 >= 0)
                {
                    valoresMoveR[5] = whereR - 1;
                    valoresMoveC[5] = whereC;
                }
                if (whereR + 1 <= 7)
                {
                    valoresMoveR[6] = whereR + 1;
                    valoresMoveC[6] = whereC;
                }
                if (whereC + 1 <= 7)
                {
                    valoresMoveR[7] = whereR;
                    valoresMoveC[7] = whereC + 1;
                }
                if (whereC - 1 >= 0)
                {
                    valoresMoveR[8] = whereR;
                    valoresMoveC[8] = whereC - 1;
                }

                if (player == "player1")
                {
                    MovingCalculator(WhereR, WhereC, "player 1");
                }
                else
                if (player == "player2")
                {
                    MovingCalculator(WhereR, WhereC, "player 2");
                }
            }

            void KingRule(int whereR, int whereC, string player)
            {                    
                    if (whereR - 1 >= 0)
                    {
                        valoresMoveR[0] = whereR - 1;
                        valoresMoveC[0] = whereC;
                    }
                    
                    if (whereR + 1 <= 7)
                    {
                        valoresMoveR[1] = whereR + 1;
                        valoresMoveC[1] = whereC;
                    }
                    
                    if (whereC + 1 <= 7)
                    {
                        valoresMoveR[2] = whereR;
                        valoresMoveC[2] = whereC + 1;
                    }
                    
                    if (whereC - 1 >= 0)
                    {
                        valoresMoveR[3] = whereR;
                        valoresMoveC[3] = whereC - 1;
                    }

                        if (player == "player1")
                        {
                            MovingCalculator(WhereR, WhereC, "player 1");
                        }
                        else
                        if (player == "player2")
                        {
                            MovingCalculator(WhereR, WhereC, "player 2");
                        }
                    }

            void RootRule(int whereR, int whereC, string player)
            {
                //fila actual con todas las combinaciones de columnas
                valoresMoveR[0] = whereR;
                valoresMoveC[0] = 0;

                valoresMoveR[1] = whereR;
                valoresMoveC[1] = 1;

                valoresMoveR[2] = whereR;
                valoresMoveC[2] = 2;

                valoresMoveR[3] = whereR;
                valoresMoveC[3] = 3;

                valoresMoveR[4] = whereR;
                valoresMoveC[4] = 4;

                valoresMoveR[5] = whereR;
                valoresMoveC[5] = 5;

                valoresMoveR[6] = whereR;
                valoresMoveC[6] = 6;

                valoresMoveR[7] = whereR;
                valoresMoveC[7] = 7;
                //columna actual con todas las combinaciones de filas

                valoresMoveR[8] = 0;
                valoresMoveC[8] = whereC;

                valoresMoveR[9] = 1;
                valoresMoveC[9] = whereC;

                valoresMoveR[10] = 2;
                valoresMoveC[10] = whereC;

                valoresMoveR[11] = 3;
                valoresMoveC[11] = whereC;

                valoresMoveR[12] = 4;
                valoresMoveC[12] = whereC;

                valoresMoveR[13] = 5;
                valoresMoveC[13] = whereC;

                valoresMoveR[14] = 6;
                valoresMoveC[14] = whereC;

                valoresMoveR[15] = 7;
                valoresMoveC[15] = whereC;

              /*  for (int n = 0; n < 16; n++)
                {
                    Console.WriteLine("Column: " + valoresMoveC[n]);
                    Console.WriteLine("Row: " + valoresMoveR[n]);
                }*/

                if (player == "player1")
                {
                    MovingCalculator(WhereR, WhereC, "player 1");
                }
                else
                if (player == "player2")
                {
                    MovingCalculator(WhereR, WhereC, "player 2");
                }
            }

            void MovingCalculator(int whereR, int whereC, string player)
            {
                //player 1
                string[] player1Empire = new string[10];

                //player 2
                string[] player2Empire = new string[10];

                //fichas jugador 1
                player1Empire[0] = "Pj1";
                player1Empire[1] = "Pvj1";
                player1Empire[2] = "Rj1";
                player1Empire[3] = "Bj1";
                player1Empire[4] = "Hj1";
                player1Empire[5] = "Qj1";
                player1Empire[6] = "Kj1";

                //fichas jugador 2
                player2Empire[0] = "Pj2";
                player2Empire[1] = "Pvj2";
                player2Empire[2] = "Rj2";
                player2Empire[3] = "Bj2";
                player2Empire[4] = "Hj2";
                player2Empire[5] = "Qj2";
                player2Empire[6] = "Kj2";

                //The arrays to collect data
                //Enemy
                int[] EnemyPiecesC;
                EnemyPiecesC = new int[10];
                int[] EnemyPiecesR;
                EnemyPiecesR = new int[10];
                //Friends
                int[] FriendsPiecesC;
                FriendsPiecesC = new int[10];
                int[] FriendsPiecesR;
                FriendsPiecesR = new int[10];

                int counterEnemy = 0;
                int counterFriend = 0;

                //primer obstaculo
                int firstBlockC = 0;
                int firstBlockR = 0;
                int firstBlockCounter = 0;

                //IDENTIFICAR player 1 y sus amigos o player 2 y sus amigos y enemigos
                bool eat = false;

                if (player == "player 1")
                {
                    for (int n = 0; n < 20; n++)
                    {
                       
                        for (int np = 0; np < 8; np++)
                        {
                            if (ChessBoard[valoresMoveR[n], valoresMoveC[n]] == player1Empire[np])
                            {                            
                                if (ChessBoard[WhichR, WhichC] != ChessBoard[valoresMoveR[n], valoresMoveC[n]])
                                {
                                    FriendsPiecesC[counterFriend] = valoresMoveC[n];
                                    FriendsPiecesR[counterFriend] = valoresMoveR[n];
                                    counterFriend = counterFriend + 1;
                                }
                            }

                            if (ChessBoard[valoresMoveR[n], valoresMoveC[n]] == player2Empire[np])
                            {
                               // Console.WriteLine("We found an enemy piece");
                               // Console.WriteLine("We found " + player2Empire[np] + " Row: " + valoresMoveR[n] + " Column: " + valoresMoveC[n]);
                                EnemyPiecesC[counterEnemy] = valoresMoveC[n];
                                EnemyPiecesR[counterEnemy] = valoresMoveR[n];
                                counterEnemy = counterEnemy + 1;
                            }
                        }
                        //Console.WriteLine("Friends found: " + counterFriend);
                        //Console.WriteLine("Enemys found: " + counterEnemy);
                    }

                    //Console.WriteLine("I will identifyyy if there is an enemy to eat at the destination");
                    for (int ne = 0; ne < 10; ne++)
                    {
                        
                        if (WhereC == EnemyPiecesC[ne])
                        {
                            if (WhereR == EnemyPiecesR[ne])
                            {
                                Console.WriteLine("In the destination space there is an enemy. Let's eat...");
                                
                                Eater(WhichC, WhichR, EnemyPiecesC[ne], EnemyPiecesR[ne],player);
                                eat = true;
                            }
                        }
                    }

                    if (eat == false)
                    {
                        FirstObstacle(valoresMoveR, valoresMoveC, whereR, whereC);
                    }

                }
                else if (player == "player 2")
                {
                    for (int n = 0; n < 20; n++)
                    {                       
                        for (int np = 0; np < 8; np++)
                        {
                            if (ChessBoard[valoresMoveR[n], valoresMoveC[n]] == player2Empire[np])
                            {
                                if (ChessBoard[WhichR, WhichC] != ChessBoard[valoresMoveR[n], valoresMoveC[n]])
                                {
                                    FriendsPiecesC[counterFriend] = valoresMoveC[n];
                                    FriendsPiecesR[counterFriend] = valoresMoveR[n];
                                    counterFriend = counterFriend + 1;
                                }
                            }

                            if (ChessBoard[valoresMoveR[n], valoresMoveC[n]] == player1Empire[np])
                            {
                                EnemyPiecesC[counterEnemy] = valoresMoveC[n];
                                EnemyPiecesR[counterEnemy] = valoresMoveR[n];
                                counterEnemy = counterEnemy + 1;
                            }
                        }
                    
                    }
                    
                    for (int ne = 0; ne < 10; ne++)
                    {
                        if (WhereC == EnemyPiecesC[ne])
                        {
                            if (WhereR == EnemyPiecesR[ne])
                            {
                                Console.WriteLine("In the destination space there is an enemy. Let's eat...");
                                
                                Eater(WhichC, WhichR, EnemyPiecesC[ne], EnemyPiecesR[ne],player);
                                eat = true;
                            }
                        }
                    }

                    if (eat == false)
                    {
                        FirstObstacle(valoresMoveR, valoresMoveC, whereR, whereC);
                    }
                }
            }

            string Eater(int whereC, int whereR, int foodC, int foodR,string player)
            {           
                Console.WriteLine("This piece: " + ChessBoard[whereR, whereC] + " is going to eat this: " + ChessBoard[foodR, foodC]);
                string dataPiece = ChessBoard[whereR, whereC];
                ChessBoard[whereR, whereC] = "[   ]";
                ChessBoard[foodR, foodC] = dataPiece;
                Victory = 1;
                return player;
                
            }

            void FirstObstacle(int[] whichR, int[] whichC, int whereR, int whereC)
            {
                for (int n = 0; n < 15; n++)
                {
                    if (ChessBoard[whichR[n], whichC[n]] == "[   ]")
                    {
                       // Console.WriteLine("a blank space");
                      //  Console.WriteLine("Row: " + whichR[n] + " Column: " + whichC[n]);
                    }
                }

                Moving(WhereR, WhereC, "player 1");
            }

            void Moving(int whereR, int whereC, string player)
            {
                bool ValidMove = false;
                for (int n = 0; n < valoresMoveC.Length; n++)
                {
                    if (valoresMoveC[n] == WhereC)
                    {
                       // Console.WriteLine("target columns match...");
                       // Console.WriteLine(valoresMoveC[n]);
                        if (valoresMoveR[n] == WhereR)
                        {
                           // Console.WriteLine("target row match");
                           // Console.WriteLine(valoresMoveR[n]);
                            Console.WriteLine("Valid movement");
                           // Console.WriteLine("Want to move to:");
                           //Console.WriteLine("Column: " + WhichC + " Row: " + WhichR);
                           //Console.WriteLine("You want to move to the destination:");
                           //Console.WriteLine("Column: " + WhereC + " Row: " + WhereR);
                         
                            MovePieceEnd(WhichR, WhichC, WhereR, WhereC, ChessBoard[WhichR, WhichC]);

                            ValidMove = true;
                            break;
                        } else
                        {
                            
                        }
                    }
                } 
                
                if (ValidMove == false)
                {
                    Console.WriteLine("Invalid Movement 2");                 
                }
            }

            void MovePieceEnd(int whichR, int whichC, int whereR, int whereC, string dataPiece)
            {
                ChessBoard[whichR, whichC] = "[   ]";
                ChessBoard[whereR, whereC] = dataPiece;                       
            }

            int Victory = 0;

            void Game(string player)
            {
                Board board = new Board();
                int whereCC = 0;
                int whereRC = 0;

                int whichCC = 0;
                int whichRC = 0;
                
                if (Victory == 0)
                {
                        Console.WriteLine(player+"s turn");
                        Console.WriteLine("Which one do you want to move?");
                        Console.WriteLine("column?");
                        whichCC = int.Parse(Console.ReadLine());
                        Console.WriteLine("row?");
                        whichRC = int.Parse(Console.ReadLine());

                        Console.WriteLine("Where do you want to move it?");
                        Console.WriteLine("column?");
                        whereCC = int.Parse(Console.ReadLine());
                        Console.WriteLine("row?");
                        whereRC = int.Parse(Console.ReadLine());

                        movePiece(whichCC, whichRC, whereCC, whereRC);
                  
                        ReadBoard();
                    if (player == "Player 1")
                    {
                        Game("Player 2");
                    } else if (player == "Player 2")
                    { 
                        Game("Player 1");
                    }

                }

            }

            static void Main(string[] args)
            {
                Console.WriteLine("Chess Demo");
                Board board = new Board();
                board.FillBoard();

                board.insertPiece(2, 0, "j2", "B");
                board.insertPiece(4, 0, "j2", "Q");
                board.insertPiece(3, 0, "j2", "K");
                board.insertPiece(5, 0, "j2", "R");
                board.insertPiece(6, 0, "j2", "H");
                board.insertPiece(7, 0, "j2", "P");

                board.insertPiece(2, 7, "j1", "B");
                board.insertPiece(4, 7, "j1", "Q");
                board.insertPiece(3, 7, "j1", "K");
                board.insertPiece(5, 7, "j1", "R");
                board.insertPiece(6, 7, "j1", "H");
                board.insertPiece(7, 7, "j1", "P");

                board.ReadBoard();

                board.Game("Player 1");
            }
        }
    } 

}


                