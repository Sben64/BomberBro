using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BomberBros
{
    class Player
    {

        #region Player Attribut
        //Variables Player
        Texture2D _texturePlayer;
        Vector2 _positionPlayers;
        public double _poid;
        public bool _jump;
        //Variables Bombe
        Texture2D _bombe;
        Vector2 _positionBombe;
        bool _posed;


        #endregion

        #region Method Class
        public Player()
        {
            _posed = false;
            _jump = false;
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            Move(graphics);
            if (_posed)
            {
                _posed = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                PoserBombe();
            }
        }

        public void LoadContent(ContentManager content, Vector2 newPositionPlayer, string assetName, string bombAssetName)
        {
            _texturePlayer = content.Load<Texture2D>(assetName);
            _positionPlayers = newPositionPlayer;
            _bombe = content.Load<Texture2D>(bombAssetName);
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(_texturePlayer, _positionPlayers, Color.White);
            if (_posed)
            {
                sprite.Draw(_bombe, _positionBombe, Color.White);
            }
        }

        public void Move(GraphicsDeviceManager graphics)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && _jump == false)
            {
                _jump = true;
                _positionPlayers.Y -= 6f;
                if (_positionPlayers.Y < 0)
                    _positionPlayers.Y = graphics.PreferredBackBufferHeight;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                _positionPlayers.Y += 6f;
                if (_positionPlayers.Y > graphics.PreferredBackBufferHeight)
                    _positionPlayers.Y = 0;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                _positionPlayers.X -= 6f;
                if (_positionPlayers.X < 0)
                    _positionPlayers.X = graphics.PreferredBackBufferWidth;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                _positionPlayers.X += 6f;
                if (_positionPlayers.X > graphics.PreferredBackBufferWidth)
                    _positionPlayers.X = 0;
            }
        }

        public void PoserBombe()
        {
            if (!_posed)
            {
                _positionBombe = new Vector2(
                    (_positionPlayers.X + (_texturePlayer.Width / 2)) - _bombe.Width / 2,
                    _positionPlayers.Y);
                _posed = true;
            }
        }
        #endregion

    }
}
