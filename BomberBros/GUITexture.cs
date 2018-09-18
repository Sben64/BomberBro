using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberBros
{
    class GUITexture
    {
        Texture2D guiTex;
        Vector2 _position;
        Rectangle rectangle;
       
        string _assetName;

        public string AssetName { get => _assetName; set => _assetName = value; }

        public delegate void ElementClicked(string element);

        public event ElementClicked clickEvent;

        public GUITexture(string assetName)
        {
            AssetName = assetName;
        }
        public void Update()
        {
            if(rectangle.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y ) ) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                clickEvent(AssetName);
            }
        }

        public void LoadContent(ContentManager content)
        {
            guiTex = content.Load<Texture2D>(AssetName);
            rectangle = new Rectangle((int)_position.X, (int)_position.Y, guiTex.Width, guiTex.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(guiTex, rectangle, Color.AliceBlue);
        }

        public void MoveElement(int x, int y)
        {
            rectangle = new Rectangle(rectangle.X += x, rectangle.Y += y, guiTex.Width, guiTex.Height);
        }        

    }
}
