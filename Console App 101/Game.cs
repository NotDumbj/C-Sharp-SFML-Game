using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_101
{
    class Game
    {
        public RenderWindow screen;
        static int c = 0;

        uint window_width = 800;
        uint window_height = 600;

        Vector2f player_start;
        Vector2f player_new_pos;

        int player_X = 10;
        int player_Y;
        float player_speed = 3.5f;

        int player_sq_len = 128;

        int ground_size = 45;


        Texture t_hero_std;

        Texture t_hero_wlk;
        int i_walk = 0;

        Texture t_hero_spr;

        Sprite hero_std;
        Sprite hero_wlk;
        Sprite hero_spr;

        VertexArray ground;


        public Game()
        {
            screen = new(new(window_width, window_height), "Gamion");
            screen.Closed += (sender, e) => screen.Close();

            //Character
            t_hero_std = new("Idle.png");
            t_hero_wlk = new("Walk.png");
            //Texture t_hero_spr = new("Run.png");

            player_Y = (int)(window_height - ground_size - player_sq_len);

            player_start = new Vector2f(player_X, player_Y);

            player_new_pos = player_start;


            hero_std = new Sprite(t_hero_std)
            {
                Position = player_start
            };

            hero_wlk = new Sprite(t_hero_wlk)
            {
                Position = player_start
            };
            //Sprite hero_spr = new(t_hero_spr);

            ground = new VertexArray(PrimitiveType.Quads, 4);

            ground[0] = new Vertex(new Vector2f(0, window_height - ground_size), Color.Black);
            ground[1] = new Vertex(new Vector2f(window_width, window_height - ground_size), Color.Black);
            ground[2] = new Vertex(new Vector2f(window_width, window_height - 0), Color.Black);
            ground[3] = new Vertex(new Vector2f(0, window_height - 0), Color.Black);

            hero_std.TextureRect = new IntRect(0, 0, player_sq_len, player_sq_len);

            hero_wlk.TextureRect = new IntRect(i_walk, 0 , player_sq_len , player_sq_len);

            run();

        }




        public void run()
        {
            Console.WriteLine("Game Render : " + c);
            c++;

            screen.DispatchEvents();
            screen.Clear(Color.Cyan);

            if(Keyboard.IsKeyPressed(Keyboard.Key.D) || Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                while (i_walk < 896)
                {
                    hero_wlk.TextureRect = new IntRect(i_walk, 0, player_sq_len, player_sq_len);
                    i_walk += player_sq_len;
                    screen.Clear(Color.Cyan);
                    screen.Draw(ground);
                    screen.Draw(hero_wlk);
                    screen.Display();

                    player_start.X += player_speed;

                }
                i_walk = 0;
            }


            screen.Draw(hero_std);
            screen.Draw(ground);
            screen.Display();
        }

    }
}
