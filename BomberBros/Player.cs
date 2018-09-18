using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BomberBros
{


    public class Player
    {
        Texture2D texture;

        Vector2 position;
        Vector2 velocity;



        bool jump;

        public Player(Texture2D newTexture, Vector2 newPosition)
        {
            texture = newTexture;
            position = newPosition;
            jump = true;
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                position.X += 6f;
                if (position.X > 480)
                {
                    position.X = 0;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                position.X -= 6f;
                if (position.X < 0)
                {
                    position.X = 480;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && jump == false)
            {
                position.Y -= 12f;
                velocity.Y = -6f;
                jump = true;
            }
            if (jump == true)
            {
                float i = 1;
                velocity.Y += 0.15f * i;
            }
            if (position.Y + texture.Height >= 640 - texture.Height)
            {
                jump = false;
            }
            if (jump == false)
            {
                velocity.Y = 0f;
            }
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(texture, position, Color.White);
        }
    }
}
