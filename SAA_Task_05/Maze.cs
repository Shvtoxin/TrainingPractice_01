using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace SAA_Task_05
{
   
    internal class Maze
    {
        private Map MyMap;
        private Player CurrentPlayer;

        public void Start()
        {
            Title = "Лабиринт Шатохин Ип-20-3";

            CursorVisible = false;

            string[,] grid =
            {
                {"╔","═","╦","═","╦","═","═","═","╦","═","═","═","═","╦","═","═","═","╦","═","═","═","╗" },
                {"╩"," ","║"," ","║"," "," "," ","║"," "," "," "," ","╩"," "," "," ","╩"," "," "," ","╩" },
                {" "," ","║"," ","║"," ","╦"," ","║"," ","╔","╗"," "," "," ","╦"," "," "," ","╦"," ","█" },
                {"╦"," ","║"," ","╩"," ","║"," ","║"," ","║","║"," ","╦"," ","║"," ","╦"," ","║"," ","╦" },
                {"║"," ","║"," "," "," ","║"," ","╩"," ","║","║"," ","║"," ","║"," ","║"," ","║"," ","║" },
                {"║"," ","║"," ","╦"," ","║"," "," "," ","║","║"," ","║"," ","║"," ","╩"," ","║"," ","║" },
                {"║"," ","║"," ","║"," ","║"," ","╦"," ","╚","╝"," ","║"," ","║"," "," "," "," "," ","║" },
                {"║"," ","║"," ","║"," ","║"," ","║"," "," "," "," ","║"," ","║"," ","╦"," ","╦"," ","║" },
                {"║"," ","╩"," ","║"," ","║"," ","║"," ","╔","╗"," ","║"," ","╩"," ","║"," ","║"," ","║" },
                {"║"," "," "," ","║"," ","║"," ","║"," ","║","║"," ","║"," "," "," ","║"," ","║"," ","║" },
                {"║"," ","╦"," ","║"," ","║"," ","║"," ","║","║"," ","║"," ","╦"," ","║"," ","║"," ","║" },
                {"║"," ","║"," ","║"," ","║"," ","║"," ","║","║"," ","║"," ","║"," ","║"," ","║"," ","║" },
                {"║"," ","║"," ","║"," ","║"," ","║"," ","║","║"," ","║"," ","║"," "," "," ","║"," ","║" },
                {"║"," ","║"," ","║"," ","╩"," ","║"," ","║","║"," ","╩"," ","║"," ","╦"," ","╩"," ","║" },
                {"║"," ","║"," ","║"," "," "," ","║"," ","║","║"," "," "," ","║"," ","║"," "," "," ","║" },
                {"║"," ","╩"," ","╩"," ","╦"," ","╩"," ","╚","╣"," ","╦"," ","║"," ","╩"," ","╦"," ","║" },
                {"║"," "," "," "," "," ","║"," "," "," "," ","║"," ","║"," ","║"," "," "," ","║"," ","║" },
                {"╚","═","═","═","═","═","╩","═","═","═","═","╩","═","╩","═","╩","═","═","═","╩","═","╝" },
            };
            MyMap = new Map(grid);
            CurrentPlayer = new Player(0, 2);

            Telo();
        }

        private void Nachalo()
        {
            WriteLine("\n\n\n\n\n");
            WriteLine(@"                                    Добро пожаловать в лабиринт!");
            WriteLine("\n\n");
            WriteLine(@"
                       >                      Инструкция:
                                     +-------------------------+
                                     |        Используте:      |
                                     | W-для перемещения вверх |
                                     | A-для перемещения влево |
                                     | S-для перемещения вниз  |
                                     | D-для перемещения вправо|
                                     +-------------------------+
                       ");
            Write(@"                       > Вам нужно добраться до выхода, он выглядит так: ");

            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("█");
            ResetColor();
            WriteLine(@"                       >       Нажмите любую клавишу для начала игры");
            ReadKey(true);
        }

        private void Konec()
        {
            Clear();
            WriteLine(@"                                  Вы прошли Лабиринт!");
            WriteLine(@"                                   Спасибо за игру!");
            WriteLine(@"                         Нажмите любую клавишу для завершения игры...");
            ReadKey(true);
        }

        private void DrawMap()
        {
            Clear();
            MyMap.Draw();
            CurrentPlayer.Draw();
        }

        private void Ypravlenie()
        {
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                case ConsoleKey.W:
                    if (MyMap.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.S:
                    if (MyMap.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Y += 1;
                    }

                    break;
                case ConsoleKey.A:
                    if (MyMap.IsPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.X -= 1;
                    }

                    break;
                case ConsoleKey.D:
                    if (MyMap.IsPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X += 1;
                    }

                    break;
                default:
                    break;
            }
        }
        private void Telo()
        {
            Nachalo();
            while (true)
            {
                DrawMap();

                Ypravlenie();

                string elementAtPlayerPos = MyMap.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (elementAtPlayerPos == "█")
                {
                    break;
                }

                System.Threading.Thread.Sleep(20);

            }
            Konec();
        }

    }
}
