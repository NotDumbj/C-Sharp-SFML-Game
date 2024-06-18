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

        //// Trail segments list
        //List<TrailSegment> trailSegments = new List<TrailSegment>();
        //int maxTrailSegments = 50; // Limit the number of trail segments

        //// Define movement speed
        //float speed = 5.0f;
        //float trailDuration = 1.0f; // 1 second

  
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


        //    // Add new trail segment
        //    trailSegments.Add(new TrailSegment { Position = newPosition, Timestamp = clock.ElapsedTime.AsSeconds() });

        //    // Remove old trail segments
        //    trailSegments.RemoveAll(segment => clock.ElapsedTime.AsSeconds() - segment.Timestamp > trailDuration);

        //    // Limit the number of trail segments
        //    if (trailSegments.Count > maxTrailSegments)
        //    {
        //        trailSegments.RemoveAt(0);
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



        Game game = new();
        while(game.screen.IsOpen)
        {
            game.run();
        }
    }
}

