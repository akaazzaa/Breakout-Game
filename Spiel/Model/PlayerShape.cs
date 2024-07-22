using SFML.Graphics;
using SFML.System;
using Spiel.Components;
namespace Spiel.Model
{
    public class PlayerShape
    {
       public RectangleShape PlayerStone = new RectangleShape();
       public Components.Transform Transform {  get; set; }
       public Components.Collision Collision { get; set; }
       public Components.Input Input { get; set; }
        public Components.Score Score { get; set; }

        public PlayerShape(Vector2f size, Color color)
        {
            PlayerStone.Size = size;
            PlayerStone.FillColor = color;
        }
    }
}
