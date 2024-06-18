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
    class Player
    {
        public List<Body> states;
        public Vector2f position;
        public Vector2f nxt_position;
        public int health;
        public float walking_speed;
        public float running_speed;
        public int ani_int = 0;
        public int box_lenght = 128;
        public int animationDelay = 215;


        public Player()
        {
            states = new List<Body>();
            health = 100;
            walking_speed = 0.05f;
            running_speed = 0.109f;
            position = new Vector2f(10, 427); //calculated player_Y
            nxt_position = new Vector2f();
            foreach (Body b in states)
            {
                b.sprite.Position = position;
            }
        }

        public Player(List<Body> states, int health)
        {
            this.states = states;
            this.health = health;
            walking_speed = 0.05f;
            running_speed = 0.109f;
            position = new Vector2f(10, 427); //calculated player_Y
            nxt_position = new Vector2f();
            foreach (Body b in states)
            {
                b.sprite.Position = position;
            }

        }

        bool movingRight = !(Keyboard.IsKeyPressed(Keyboard.Key.LShift)) && Keyboard.IsKeyPressed(Keyboard.Key.D) || Keyboard.IsKeyPressed(Keyboard.Key.Right);
        bool movingLeft = !(Keyboard.IsKeyPressed(Keyboard.Key.LShift)) && Keyboard.IsKeyPressed(Keyboard.Key.A) || Keyboard.IsKeyPressed(Keyboard.Key.Left);

        bool sprintRight = Keyboard.IsKeyPressed(Keyboard.Key.LShift) && Keyboard.IsKeyPressed(Keyboard.Key.D) || Keyboard.IsKeyPressed(Keyboard.Key.Right);
        bool sprintLeft = Keyboard.IsKeyPressed(Keyboard.Key.LShift) && Keyboard.IsKeyPressed(Keyboard.Key.A) || Keyboard.IsKeyPressed(Keyboard.Key.Left);


        public void addSprite(Sprite s)
        {
            states.Add(new Body(s));
        }

        public void setSpeed(float wS, float rS)
        {
            walking_speed = wS;
            running_speed = rS;
        }

        public void setPosition(float X, float Y = 427)
        {
            Vector2f p = new(X, Y);
            position = p;
            foreach (Body b in states) {
                b.sprite.Position = position;
            }
        }

        public void moveRight(Body sp, VertexArray ground, RenderWindow screen)
        {
            int counter = 0;
            updateOriginR();
            while (ani_int < sp.sheet_size)
            {
                screen.DispatchEvents();
                sp.sprite.TextureRect = new IntRect(ani_int, 0, box_lenght, box_lenght);
                screen.Clear(Color.Cyan);
                screen.Draw(ground);
                screen.Draw(sp.sprite);
                screen.Display();

                //thanks brain
                if (!(Keyboard.IsKeyPressed(Keyboard.Key.D) || Keyboard.IsKeyPressed(Keyboard.Key.Right)))
                {
                    break;
                }
                if (sprintRight || sprintLeft)
                {
                    break;
                }
                //bro i loved this, i don't know how unefficient it is, but it solved the problem
                counter++;
                if (counter == animationDelay)
                {
                    ani_int += box_lenght;
                    counter = 0;
                }
                position.X += walking_speed;
                sp.sprite.Position = position;

            }
            ani_int = 0;
        }

        public void moveLeft(Body sp, VertexArray ground, RenderWindow screen)
        {
            int counter = 0;
            updateOriginL();
            while (ani_int < sp.sheet_size)
            {
                screen.DispatchEvents();
                sp.sprite.TextureRect = new IntRect(ani_int, 0, box_lenght, box_lenght);
                screen.Clear(Color.Cyan);
                screen.Draw(ground);
                screen.Draw(sp.sprite);
                screen.Display();


                if (!(Keyboard.IsKeyPressed(Keyboard.Key.A) || Keyboard.IsKeyPressed(Keyboard.Key.Left)))
                {
                    break;
                }
                if (sprintRight || sprintLeft)
                {
                    break;
                }
                counter++;
                if (counter == animationDelay)
                {
                    ani_int += box_lenght;
                    counter = 0;
                }
                position.X -= walking_speed;
                sp.sprite.Position = position;


            }
            ani_int = 0;
        }

        public void runRight(Body sp, VertexArray ground, RenderWindow screen)
        {
            int counter = 0;
            updateOriginR();
            while (ani_int < sp.sheet_size)
            {
                screen.DispatchEvents();
                sp.sprite.TextureRect = new IntRect(ani_int, 0, box_lenght, box_lenght);
                screen.Clear(Color.Cyan);
                screen.Draw(ground);
                screen.Draw(sp.sprite);
                screen.Display();

                if (!(Keyboard.IsKeyPressed(Keyboard.Key.LShift) && Keyboard.IsKeyPressed(Keyboard.Key.D) || Keyboard.IsKeyPressed(Keyboard.Key.Right)))
                {
                    break;
                }

                counter++;
                if (counter == animationDelay - 15)
                {
                    ani_int += box_lenght;
                    counter = 0;
                }
                position.X += running_speed;
                sp.sprite.Position = position;
            }
            ani_int = 0;

        }

        public void runLeft(Body sp, VertexArray ground, RenderWindow screen)
        {
            int counter = 0;
            updateOriginL();
            while (ani_int < sp.sheet_size)
            {
                screen.DispatchEvents();
                sp.sprite.TextureRect = new IntRect(ani_int, 0, box_lenght, box_lenght);
                screen.Clear(Color.Cyan);
                screen.Draw(ground);
                screen.Draw(sp.sprite);
                screen.Display();

                if (!(Keyboard.IsKeyPressed(Keyboard.Key.LShift) && Keyboard.IsKeyPressed(Keyboard.Key.A) || Keyboard.IsKeyPressed(Keyboard.Key.Left)))
                {
                    break;
                }

                counter++;
                if (counter == animationDelay - 15)
                {
                    ani_int += box_lenght;
                    counter = 0;
                }
                position.X -= running_speed;
                sp.sprite.Position = position;


            }
            ani_int = 0;
        }

        public void resetCharacter()
        {
            setPosition(10);
        }

        private void updateOriginR()
        {
            foreach (Body b in states)
            {
                b.sprite.Scale = new Vector2f(1, 1);
                b.sprite.Origin = nxt_position;
            }
        }

        private void updateOriginL()
        {
            foreach (Body b in states)
            {
                b.sprite.Scale = new Vector2f(-1, 1);
                b.sprite.Origin = new Vector2f(b.sprite.GetLocalBounds().Width, 0);
            }
        }


    }

    class Body
    {
        public Sprite sprite { set; get; }
        public int sheet_size = 0;

        Body(Sprite sprite, Texture texture)
        {
            this.sprite = sprite;
            this.sprite.Texture = texture;
        }

        public Body(Sprite sprite, int sS)
        {
            this.sprite = sprite;
            this.sheet_size = sS;
        }

        public Body(Sprite sprite)
        {
            this.sprite = sprite;
        }

    }
}