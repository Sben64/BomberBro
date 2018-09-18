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
        public Vector2 _positionPlayers;
        public double _poid;
        public bool _jump;
        //Variables Bombe
        Bombe bombe;
        public bool poser_bombe = false;

        #endregion

        #region Method Class
        public Player()
        {
            _jump = false;
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            Move(graphics);
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && poser_bombe == false)
            {
                PoserBombe();
            }
            //if(bombe != null)
            //    bombe.Update(gameTime, graphics, _positionPlayers);
            //poser_bombe = false;

            //If timer  > 3 sec
            // bombe.isalive = false;
        }

        public void LoadContent(ContentManager content, Vector2 newPositionPlayer, string playerName)
        {
            _texturePlayer = content.Load<Texture2D>(playerName);
            _positionPlayers = newPositionPlayer;
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(_texturePlayer, _positionPlayers, Color.White);
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
            bombe = new Bombe();

            //bombe._positionBombe = new Vector2((_positionPlayers.X + (_texturePlayer.Width / 2)) /*- bombe._textureBombe.Width / 2*/, _positionPlayers.Y);
            poser_bombe = true;
        }
        #endregion

    }
}
