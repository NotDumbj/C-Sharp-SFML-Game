// See https://aka.ms/new-console-template for more information

using Console_App_101;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;

class Program
{
    //private struct TrailSegment
    //{
    //    public Vector2f Position;
    //    public float Timestamp;
    //}

    static void Main(string[] args)
    {
        //// Create the main window
        //RenderWindow window = new RenderWindow(new VideoMode(800, 600), "SFML.Net Trail Effect");
        //window.Closed += (sender, e) => window.Close();

        //// Load a texture and create a sprite
        //Texture texture = new Texture("character.png");
        //Sprite sprite = new Sprite(texture)
        //{
        //    Position = new Vector2f(400, 300)
        //};

        //// Trail segments list
        //List<TrailSegment> trailSegments = new List<TrailSegment>();
        //int maxTrailSegments = 50; // Limit the number of trail segments

        //// Define movement speed
        //float speed = 5.0f;
        //float trailDuration = 1.0f; // 1 second

        //// Start the game loop
        //Clock clock = new Clock();
        //while (window.IsOpen)
        //{
        //    // Process events
        //    window.DispatchEvents();

        //    // Handle input and move sprite
        //    Vector2f movement = new Vector2f(0, 0);
        //    if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
        //    {
        //        movement.X -= speed;
        //        sprite.Scale = new Vector2f(-1, 1);
        //    }
        //    if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
        //    {
        //        movement.X += speed;
        //        sprite.Scale = new Vector2f(1, 1);
        //    }
        //    if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
        //        movement.Y -= speed;
        //    if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
        //        movement.Y += speed;

        //    // Calculate new position
        //    Vector2f newPosition = sprite.Position + movement;

        //    // Update sprite position
        //    sprite.Position = newPosition;

        //    // Add new trail segment
        //    trailSegments.Add(new TrailSegment { Position = newPosition, Timestamp = clock.ElapsedTime.AsSeconds() });

        //    // Remove old trail segments
        //    trailSegments.RemoveAll(segment => clock.ElapsedTime.AsSeconds() - segment.Timestamp > trailDuration);

        //    // Limit the number of trail segments
        //    if (trailSegments.Count > maxTrailSegments)
        //    {
        //        trailSegments.RemoveAt(0);
        //    }

        //    // Clear trail when 'R' key is pressed
        //    if (Keyboard.IsKeyPressed(Keyboard.Key.R))
        //    {
        //        sprite.Position = new Vector2f(400, 300);
        //        trailSegments.Clear();
        //    }

        //    // Clear screen
        //    window.Clear(Color.Black);

        //    // Draw the trail
        //    float currentTime = clock.ElapsedTime.AsSeconds();
        //    foreach (var segment in trailSegments)
        //    {
        //        float age = currentTime - segment.Timestamp;
        //        float alpha = 255 * (1 - age / trailDuration); // Fade out over time
        //        Color trailColor = new Color(255, 105, 180, (byte)alpha); // Pink color
        //        CircleShape trailCircle = new CircleShape(5)
        //        {
        //            Position = segment.Position,
        //            FillColor = trailColor
        //        };
        //        window.Draw(trailCircle);
        //    }

        //    // Draw the sprite
        //    window.Draw(sprite);

        //    // Update the window
        //    window.Display();


        Game game = new();
        while(game.screen.IsOpen)
        {
            game.run();
        }
    }
}

