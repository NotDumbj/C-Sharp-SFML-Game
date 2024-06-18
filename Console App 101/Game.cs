using Console_App_101;
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

        Player player;

        uint window_width = 800;
        uint window_height = 600;

        int ground_size = 45;
        VertexArray ground;

        public Game()
        {
            player = new Player(new List<Body>
            {
                new Body(new Sprite(new Texture("Idle.png")), 128),
                new Body(new Sprite(new Texture("Walk.png")), 896),
                new Body(new Sprite(new Texture("Run.png")), 1024)
            }, 100);

            screen = new(new(window_width, window_height), "Gamion");
            screen.Closed += (sender, e) => screen.Close();

            player.nxt_position = player.states[1].sprite.Origin;

            ground = new VertexArray(PrimitiveType.Quads, 4);

            ground[0] = new Vertex(new Vector2f(0, window_height - ground_size), Color.Black);
            ground[1] = new Vertex(new Vector2f(window_width, window_height - ground_size), Color.Black);
            ground[2] = new Vertex(new Vector2f(window_width, window_height - 0), Color.Black);
            ground[3] = new Vertex(new Vector2f(0, window_height - 0), Color.Black);

            player.states[0].sprite.TextureRect = new IntRect(player.ani_int, 0, player.box_lenght, player.box_lenght);
            player.states[1].sprite.TextureRect = new IntRect(player.ani_int, 0, player.box_lenght, player.box_lenght);
            player.states[2].sprite.TextureRect = new IntRect(player.ani_int, 0, player.box_lenght, player.box_lenght);

            run();

        }

        public void run()
        {

            bool movingRight = !(Keyboard.IsKeyPressed(Keyboard.Key.LShift)) && Keyboard.IsKeyPressed(Keyboard.Key.D) || Keyboard.IsKeyPressed(Keyboard.Key.Right);
            bool movingLeft = !(Keyboard.IsKeyPressed(Keyboard.Key.LShift)) && Keyboard.IsKeyPressed(Keyboard.Key.A) || Keyboard.IsKeyPressed(Keyboard.Key.Left);

            bool sprintRight = Keyboard.IsKeyPressed(Keyboard.Key.LShift) && Keyboard.IsKeyPressed(Keyboard.Key.D) || Keyboard.IsKeyPressed(Keyboard.Key.Right);
            bool sprintLeft = Keyboard.IsKeyPressed(Keyboard.Key.LShift) && Keyboard.IsKeyPressed(Keyboard.Key.A) || Keyboard.IsKeyPressed(Keyboard.Key.Left);

            if (sprintRight)
            {
                player.runRight(player.states[2], ground, screen);
            }

            if (sprintLeft)
            {
                player.runLeft(player.states[2], ground, screen);
            }

            if (movingRight)
            {
                player.moveRight(player.states[1], ground, screen);
            }

            if (movingLeft)
            {
                player.moveLeft(player.states[1], ground, screen);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.R))
            {
                player.resetCharacter();
            }


            screen.DispatchEvents();
            screen.Clear(Color.Cyan);

            player.setPosition(player.position.X);
            screen.Draw(player.states[0].sprite);
            screen.Draw(ground);
            screen.Display();
        }

    }
    
    internal class GMain
    {
        static void Main(string[] args)
        {
            Game game = new();
            while (game.screen.IsOpen)
            {
                game.run();
            }
        }
    }

}

