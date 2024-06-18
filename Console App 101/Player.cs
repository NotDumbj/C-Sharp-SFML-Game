using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_101
{
    class Player
    {
        List<Body> states;
        Vector2f position;
        int health;
        float walking_speed;
        float running_speed;

        Player()
        {
            states = new List<Body>();
            health = 100;
            walking_speed = 0.05f;
            running_speed = 0.109f;
            position = new Vector2f(10, 427); //calculated player_Y
            foreach (Body b in states)
            {
                b.sprite.Position = position;
            }
        }

        Player(int health)
        {
            this.health = health;
        }

        Player(List<Body> states, int health)
        {
            this.states = states;
            this.health = health;
        }

        public void addSprite(Body s)
        {
            states.Add(s);
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
    }

    class Body
    {
        public Sprite sprite { set; get; }
        public String texture { set; get; }

        Body()
        {
            setTexturetoSprite();
        }

        Body(Sprite sprite, Texture texture)
        {
            this.sprite = sprite;
            this.sprite.Texture = texture;
        }

        Body(Sprite sprite, string texture)
        {
            this.sprite = sprite;
            this.texture = texture;

            setTexturetoSprite(sprite, texture);
        }

        public void setTexturetoSprite()
        {
            Sprite sprite = new Sprite();
            Texture texture = new(this.texture);
            sprite.Texture = texture;
        }

        public void setTexturetoSprite(Sprite s, String t)
        { 
            Texture texture = new(t);
            s.Texture = texture;
        }

        public void addSprite(Sprite s)
        {

        }

    }
}