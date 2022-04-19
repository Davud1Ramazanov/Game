using System;
namespace Snake_Game
{
    class Program
    {
        bool GameOver;
        const int width = 20;
        const int height = 20;
        int x, y, fruitX, fruitY, score;
        enum MyDiraction { STOP = 0, LEFT, RIGHT, UP, DOWN};
        MyDiraction dir;
        void SetUp()
        {
            GameOver = false;
            dir = MyDiraction.STOP;
            Random rnd = new Random();
            x = width / 2 - 1;
            y = height / 2 - 1;
            fruitX = rnd.Next();
            fruitY = rnd.Next();
            score = 0;
        }
        void Draw()
        {
            for(int i = 0; i<width+1;i++)
            {
                Console.WriteLine("#");
            }
            Console.WriteLine("\n");
            for (int i = 0; i<height;i++)
            {
                for(int j = 0; j<width;j++)
                {
                    if (j == 0 || j == width - 1) 
                    {
                        Console.WriteLine("#");
                    }
                    if(i == y && j==x)
                    {
                        Console.WriteLine("0");
                    }
                    else if (i == fruitY && j == fruitX)
                    {
                        Console.WriteLine("F");
                    }
                    Console.WriteLine(" ");
                }   
            }
            Console.WriteLine("\n");
            for (int i = 0; i < width+1; i++)
            {
                Console.WriteLine("#");
            }
            Console.WriteLine("\n");
            Console.WriteLine($"Coins: {score}");
        }
        void Input()
        {
            if (Console.KeyAvailable)
            {
                var keyInfo= Console.ReadKey();
                switch (keyInfo.KeyChar)
                {
                    case 'a':
                        dir =  MyDiraction.LEFT;
                        break;
                    case 'd':
                        dir = MyDiraction.RIGHT;
                        break;
                    case 'w':
                        dir = MyDiraction.UP;
                        break;
                    case 's':
                        dir = MyDiraction.DOWN;
                        break;
                    case 'x':
                        GameOver = true;
                        break;
                }
            }
        }
        void Logic()
        {
            switch(dir)
            {
                case MyDiraction.LEFT:
                    x--;
                    break;
                case MyDiraction.RIGHT:
                    x++;
                    break;
                case MyDiraction.UP:
                    y--;
                    break;
                case MyDiraction.DOWN:
                    y++;
                    break;

             }
            if (x > width || x < 0 || y > height || y < 0) 
            {
                GameOver = true;
            }
            if (x == fruitX && y == fruitY) 
            {
                score = +10;
                fruitX = rnd.Next();
                fruitY = rnd.Next();
            }
        }
        static void Main(string[] args)
        {
            Program pg= new Program();
            pg.SetUp();
            while(!pg.GameOver)
            {
                pg.Draw();
                pg.Input();
                pg.Logic();
            }
        }
    }
}
