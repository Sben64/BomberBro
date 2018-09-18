using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BomberBros
{
    public class Bombe
    {
        //Variables Bombe
        public Texture2D _textureBombe;
        public Vector2 _positionBombe;

        Vector2 _positionPlayer;

        public Bombe()
        {


        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(_textureBombe, _positionBombe, Color.White);
        }
        public void LoadContent(ContentManager content, string bombeName)
        {
            _textureBombe = content.Load<Texture2D>(bombeName);
            _positionBombe = new Vector2(100, 100);
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics, Vector2 _positionPlayers)
        {
            _positionBombe = new Vector2(_positionPlayers.X, _positionPlayers.Y);
        }
    }
}
