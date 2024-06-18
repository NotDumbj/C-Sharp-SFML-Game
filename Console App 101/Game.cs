using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
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
        float wlk_player_speed = 0.05f;
        float spr_player_speed = 0.109f;

        int player_sq_len = 128;

        int ground_size = 45;
        int wlk_sheet_size = 896;
        int spr_sheet_size = 1024;


        Texture t_hero_std;

        Texture t_hero_wlk;
        int i_walk = 0;

        Texture t_hero_spr;

        Sprite hero_std;
        Sprite hero_wlk;
        Sprite hero_spr;

        VertexArray ground;

        int animationDelay = 215;

        public Game()
        {
            //Console.WriteLine("Initializing game...");

            screen = new(new(window_width, window_height), "Gamion");
            screen.Closed += (sender, e) => screen.Close();

            //Character
            t_hero_std = new("Idle.png");
            t_hero_wlk = new("Walk.png");
            t_hero_spr = new("Run.png");

            player_Y = (int)(window_height - ground_size - player_sq_len);

            player_start = new Vector2f(player_X, player_Y);

            hero_std = new Sprite(t_hero_std)
            {
                Position = player_start
            };

            hero_wlk = new Sprite(t_hero_wlk)
            {
                Position = player_start
            };

            player_new_pos = hero_wlk.Origin;

            hero_spr = new(t_hero_spr)
            {
                Position = player_start
            };

            ground = new VertexArray(PrimitiveType.Quads, 4);

            ground[0] = new Vertex(new Vector2f(0, window_height - ground_size), Color.Black);
            ground[1] = new Vertex(new Vector2f(window_width, window_height - ground_size), Color.Black);
            ground[2] = new Vertex(new Vector2f(window_width, window_height - 0), Color.Black);
            ground[3] = new Vertex(new Vector2f(0, window_height - 0), Color.Black);

            hero_std.TextureRect = new IntRect(0, 0, player_sq_len, player_sq_len);

            hero_wlk.TextureRect = new IntRect(i_walk, 0, player_sq_len, player_sq_len);

            run();

        }


        int i = 1;
        public void run()
        {
            //Console.WriteLine("Game Render : " + c);
            c++;

            bool movingRight = !(Keyboard.IsKeyPressed(Keyboard.Key.LShift)) && Keyboard.IsKeyPressed(Keyboard.Key.D) || Keyboard.IsKeyPressed(Keyboard.Key.Right);
            bool movingLeft = !(Keyboard.IsKeyPressed(Keyboard.Key.LShift)) && Keyboard.IsKeyPressed(Keyboard.Key.A) || Keyboard.IsKeyPressed(Keyboard.Key.Left);

            bool sprintRight = Keyboard.IsKeyPressed(Keyboard.Key.LShift) && Keyboard.IsKeyPressed(Keyboard.Key.D) || Keyboard.IsKeyPressed(Keyboard.Key.Right);
            bool sprintLeft = Keyboard.IsKeyPressed(Keyboard.Key.LShift) && Keyboard.IsKeyPressed(Keyboard.Key.A) || Keyboard.IsKeyPressed(Keyboard.Key.Left);

            if (sprintRight)
            {
                int counter = 0;
                updateOriginR();
                while (i_walk < spr_sheet_size)
                {
                    screen.DispatchEvents();
                    hero_spr.TextureRect = new IntRect(i_walk, 0, player_sq_len, player_sq_len);
                    screen.Clear(Color.Cyan);
                    screen.Draw(ground);
                    screen.Draw(hero_spr);
                    screen.Display();

                    if (!(sprintRight))
                    {
                        break;
                    }

                    counter++;
                    if (counter == animationDelay - 15)
                    {
                        i_walk += player_sq_len;
                        counter = 0;
                    }
                    player_start.X += spr_player_speed;
                    hero_spr.Position = player_start;


                }
                i_walk = 0;
            }

            if (sprintLeft)
            {
                int counter = 0;
                updateOriginL();
                while (i_walk < spr_sheet_size)
                {
                    screen.DispatchEvents();
                    hero_spr.TextureRect = new IntRect(i_walk, 0, player_sq_len, player_sq_len);
                    screen.Clear(Color.Cyan);
                    screen.Draw(ground);
                    screen.Draw(hero_spr);
                    screen.Display();

                    if (!(sprintLeft))
                    {
                        break;
                    }

                    counter++;
                    if (counter == animationDelay - 15)
                    {
                        i_walk += player_sq_len;
                        counter = 0;
                    }
                    player_start.X -= spr_player_speed;
                    hero_spr.Position = player_start;


                }
                i_walk = 0;
            }

            if (movingRight)
            {
                int counter = 0;
                updateOriginR();
                while (i_walk < wlk_sheet_size)
                {
                    screen.DispatchEvents();
                    hero_wlk.TextureRect = new IntRect(i_walk, 0, player_sq_len, player_sq_len);
                    screen.Clear(Color.Cyan);
                    screen.Draw(ground);
                    screen.Draw(hero_wlk);
                    screen.Display();

                    //thanks brain
                    if (!(Keyboard.IsKeyPressed(Keyboard.Key.D) || Keyboard.IsKeyPressed(Keyboard.Key.Right)))
                    {
                        break;
                    }

                    //bro i loved this, i don't know how unefficient it is, but it solved the problem
                    counter++;
                    if (counter == animationDelay)
                    {
                        i_walk += player_sq_len;
                        counter = 0;
                    }
                    player_start.X += wlk_player_speed;
                    hero_wlk.Position = player_start;

                }
                i_walk = 0;
            }

            if (movingLeft)
            {
                int counter = 0;
                updateOriginL();
                while (i_walk < wlk_sheet_size)
                {
                    screen.DispatchEvents();
                    hero_wlk.TextureRect = new IntRect(i_walk, 0, player_sq_len, player_sq_len);
                    screen.Clear(Color.Cyan);
                    screen.Draw(ground);
                    screen.Draw(hero_wlk);
                    screen.Display();


                    if (!(Keyboard.IsKeyPressed(Keyboard.Key.A) || Keyboard.IsKeyPressed(Keyboard.Key.Left)))
                    {
                        break;
                    }

                    counter++;
                    if (counter == animationDelay)
                    {
                        i_walk += player_sq_len;
                        counter = 0;
                    }
                    player_start.X -= wlk_player_speed;
                    hero_wlk.Position = player_start;


                }
                i_walk = 0;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.R))
            {

                player_start.X = 10;
                hero_wlk.Position = player_start;

            }


            screen.DispatchEvents();
            screen.Clear(Color.Cyan);

            hero_std.Position = player_start;
            screen.Draw(hero_std);
            screen.Draw(ground);
            screen.Display();
        }


        private void updateOriginR()
        {
            hero_spr.Scale = new Vector2f(1, 1);
            hero_spr.Origin = player_new_pos;
            hero_wlk.Scale = new Vector2f(1, 1);
            hero_wlk.Origin = player_new_pos;
            hero_std.Scale = new Vector2f(1, 1);
            hero_std.Origin = player_new_pos;
        }
        private void updateOriginL() {
            hero_spr.Origin = new Vector2f(hero_spr.GetLocalBounds().Width, 0);
            hero_spr.Scale = new Vector2f(-1, 1);
            hero_wlk.Origin = new Vector2f(hero_wlk.GetLocalBounds().Width, 0);
            hero_wlk.Scale = new Vector2f(-1, 1);
            hero_std.Origin = new Vector2f(hero_wlk.GetLocalBounds().Width, 0);
            hero_std.Scale = new Vector2f(-1, 1);
        }
    }

    
}
