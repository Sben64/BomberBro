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
    class GUIMainMenu
    {
        List<GUITexture> mainGUI = new List<GUITexture>();
        List<GUITexture> createUsernameGUI = new List<GUITexture>();
        Player joueur;
        enum GameState { mainMenu, enterNameMenun, inGame }
        GameState gameState;

        Keys[] lastPressedKeys = new Keys[5];

        string myName = "";

        SpriteFont sf;

        public GUIMainMenu()
        {
            mainGUI.Add(new GUITexture("Heptagon"));
            mainGUI.Add(new GUITexture("PlayButton"));
            mainGUI.Add(new GUITexture("Button2"));
            joueur = new Player();

            createUsernameGUI.Add(new GUITexture("Button2"));
            createUsernameGUI.Add(new GUITexture("textbox"));

        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            switch (gameState)
            {
                case GameState.mainMenu:
                    foreach (var tex in mainGUI)
                    {
                        tex.Update();
                    }
                    break;
                case GameState.enterNameMenun:
                    foreach (var tex in createUsernameGUI)
                    {
                        tex.Update();
                    }
                    GetKeys();
                    break;
                case GameState.inGame:
                    //Faire une classe InGame avec une méthode Update();
                    joueur.Update(gameTime, graphics);
                    break;
                default:
                    break;
            }
        }

        public void LoadContent(ContentManager content)
        {
            //Faire une classe InGame avec une méthode LoadContent();
            joueur.LoadContent(content, new Vector2(100, 100), "Mario", "bombe2");
            sf = content.Load<SpriteFont>("fontName");
            foreach (var tex in mainGUI)
            {
                tex.LoadContent(content);
                tex.clickEvent += OnClick;
            }
            mainGUI.Find(x => x.AssetName == "PlayButton").MoveElement(92, 100);

            foreach (var tex in createUsernameGUI)
            {
                tex.LoadContent(content);
                tex.clickEvent += OnClick;
            }

            createUsernameGUI.Find(x => x.AssetName == "Button2").MoveElement(50, 50);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (gameState)
            {
                case GameState.mainMenu:
                    foreach (var tex in mainGUI)
                    {
                        tex.Draw(spriteBatch);
                    }
                    break;
                case GameState.enterNameMenun:
                    foreach (var tex in createUsernameGUI)
                    {
                        tex.Draw(spriteBatch);
                    }
                    spriteBatch.DrawString(sf, myName, new Vector2(10, 10), Color.Black);
                    break;
                case GameState.inGame:
                    //Faire une classe InGame avec une méthode Draw();
                    joueur.Draw(spriteBatch);
                    break;
                default:
                    break;
            }
        }

        public void OnClick(string element)
        {
            if (element == "PlayButton")
            {
                gameState = GameState.inGame;
            }
            else if (element == "Button2")
            {
                if (gameState == GameState.mainMenu)
                {
                    gameState = GameState.enterNameMenun;
                }
                else
                {
                    gameState = GameState.mainMenu;
                }
            }
        }

        public void GetKeys()
        {
            KeyboardState kbState = Keyboard.GetState();

            Keys[] pressedKeys = kbState.GetPressedKeys();
            foreach (var k in lastPressedKeys)
            {
                if (!pressedKeys.Contains(k))
                {
                    //Key is no longer pressed
                    OnKeyUp(k);
                }
            }
            foreach (Keys k in pressedKeys)
            {
                if (!lastPressedKeys.Contains(k))
                {
                    OnKeyDown(k);
                }
            }
            lastPressedKeys = pressedKeys;
        }

        public void OnKeyUp(Keys key)
        {

        }

        public void OnKeyDown(Keys key)
        {
            if (myName.Length < 13)
            {

                if (key == Keys.Space)
                {
                    myName += " ";
                }
                else
                {
                    if (!Keyboard.GetState().CapsLock)
                    {
                        switch (key)
                        {
                            case Keys.Enter:
                                OnClick("Button2");
                                break;
                            case Keys.D0:
                                myName += "0";
                                break;
                            case Keys.D1:
                                myName += "1";
                                break;
                            case Keys.D2:
                                myName += "2";
                                break;
                            case Keys.D3:
                                myName += "3";
                                break;
                            case Keys.D4:
                                myName += "4";
                                break;
                            case Keys.D5:
                                myName += "5";
                                break;
                            case Keys.D6:
                                myName += "6";
                                break;
                            case Keys.D7:
                                myName += "7";
                                break;
                            case Keys.D8:
                                myName += "8";
                                break;
                            case Keys.D9:
                                myName += "9";
                                break;
                            case Keys.A:
                                myName += "a";
                                break;
                            case Keys.B:
                                myName += "b";
                                break;
                            case Keys.C:
                                myName += "c";
                                break;
                            case Keys.D:
                                myName += "d";
                                break;
                            case Keys.E:
                                myName += "e";
                                break;
                            case Keys.F:
                                myName += "f";
                                break;
                            case Keys.G:
                                myName += "g";
                                break;
                            case Keys.H:
                                myName += "h";
                                break;
                            case Keys.I:
                                myName += "i";
                                break;
                            case Keys.J:
                                myName += "j";
                                break;
                            case Keys.K:
                                myName += "k";
                                break;
                            case Keys.L:
                                myName += "l";
                                break;
                            case Keys.M:
                                myName += "m";
                                break;
                            case Keys.N:
                                myName += "n";
                                break;
                            case Keys.O:
                                myName += "o";
                                break;
                            case Keys.P:
                                myName += "p";
                                break;
                            case Keys.Q:
                                myName += "q";
                                break;
                            case Keys.R:
                                myName += "r";
                                break;
                            case Keys.S:
                                myName += "s";
                                break;
                            case Keys.T:
                                myName += "t";
                                break;
                            case Keys.U:
                                myName += "u";
                                break;
                            case Keys.V:
                                myName += "v";
                                break;
                            case Keys.W:
                                myName += "w";
                                break;
                            case Keys.X:
                                myName += "x";
                                break;
                            case Keys.Y:
                                myName += "y";
                                break;
                            case Keys.Z:
                                myName += "z";
                                break;
                            case Keys.NumPad0:
                                myName += "0";
                                break;
                            case Keys.NumPad1:
                                myName += "1";
                                break;
                            case Keys.NumPad2:
                                myName += "2";
                                break;
                            case Keys.NumPad3:
                                myName += "3";
                                break;
                            case Keys.NumPad4:
                                myName += "4";
                                break;
                            case Keys.NumPad5:
                                myName += "5";
                                break;
                            case Keys.NumPad6:
                                myName += "6";
                                break;
                            case Keys.NumPad7:
                                myName += "7";
                                break;
                            case Keys.NumPad8:
                                myName += "8";
                                break;
                            case Keys.NumPad9:
                                myName += "9";
                                break;
                            case Keys.Multiply:
                                myName += "*";
                                break;
                            case Keys.Add:
                                myName += "+";
                                break;
                            case Keys.Separator:
                                myName += "";
                                break;
                            case Keys.Subtract:
                                myName += "-";
                                break;
                            case Keys.Decimal:
                                myName += ".";
                                break;
                            case Keys.Divide:
                                myName += "/";
                                break;
                            case Keys.OemSemicolon:
                                myName += "0";
                                break;
                            case Keys.OemPlus:
                                myName += "0";
                                break;
                            case Keys.OemComma:
                                myName += "0";
                                break;
                            case Keys.OemMinus:
                                myName += "0";
                                break;
                            case Keys.OemPeriod:
                                myName += "0";
                                break;
                            case Keys.OemQuestion:
                                myName += "0";
                                break;
                            case Keys.OemTilde:
                                myName += "0";
                                break;
                            case Keys.OemOpenBrackets:
                                myName += "0";
                                break;
                            case Keys.OemPipe:
                                myName += "0";
                                break;
                            case Keys.OemCloseBrackets:
                                myName += "0";
                                break;
                            case Keys.OemQuotes:
                                myName += "0";
                                break;
                            case Keys.Oem8:
                                myName += "0";
                                break;
                            case Keys.OemBackslash:
                                myName += "0";
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (key)
                        {
                            case Keys.Enter:
                                OnClick("Button2");
                                break;
                            case Keys.D0:
                                myName += "0";
                                break;
                            case Keys.D1:
                                myName += "1";
                                break;
                            case Keys.D2:
                                myName += "2";
                                break;
                            case Keys.D3:
                                myName += "3";
                                break;
                            case Keys.D4:
                                myName += "4";
                                break;
                            case Keys.D5:
                                myName += "5";
                                break;
                            case Keys.D6:
                                myName += "6";
                                break;
                            case Keys.D7:
                                myName += "7";
                                break;
                            case Keys.D8:
                                myName += "8";
                                break;
                            case Keys.D9:
                                myName += "9";
                                break;
                            case Keys.A:
                                myName += key.ToString();
                                break;
                            case Keys.B:
                                myName += key.ToString();
                                break;
                            case Keys.C:
                                myName += key.ToString();
                                break;
                            case Keys.D:
                                myName += key.ToString();
                                break;
                            case Keys.E:
                                myName += key.ToString();
                                break;
                            case Keys.F:
                                myName += key.ToString();
                                break;
                            case Keys.G:
                                myName += key.ToString();
                                break;
                            case Keys.H:
                                myName += key.ToString();
                                break;
                            case Keys.I:
                                myName += key.ToString();
                                break;
                            case Keys.J:
                                myName += key.ToString();
                                break;
                            case Keys.K:
                                myName += key.ToString();
                                break;
                            case Keys.L:
                                myName += key.ToString();
                                break;
                            case Keys.M:
                                myName += key.ToString();
                                break;
                            case Keys.N:
                                myName += key.ToString();
                                break;
                            case Keys.O:
                                myName += key.ToString();
                                break;
                            case Keys.P:
                                myName += key.ToString();
                                break;
                            case Keys.Q:
                                myName += key.ToString();
                                break;
                            case Keys.R:
                                myName += key.ToString();
                                break;
                            case Keys.S:
                                myName += key.ToString();
                                break;
                            case Keys.T:
                                myName += key.ToString();
                                break;
                            case Keys.U:
                                myName += key.ToString();
                                break;
                            case Keys.V:
                                myName += key.ToString();
                                break;
                            case Keys.W:
                                myName += key.ToString();
                                break;
                            case Keys.X:
                                myName += key.ToString();
                                break;
                            case Keys.Y:
                                myName += key.ToString();
                                break;
                            case Keys.Z:
                                myName += key.ToString();
                                break;
                            case Keys.NumPad0:
                                myName += "0";
                                break;
                            case Keys.NumPad1:
                                myName += "1";
                                break;
                            case Keys.NumPad2:
                                myName += "2";
                                break;
                            case Keys.NumPad3:
                                myName += "3";
                                break;
                            case Keys.NumPad4:
                                myName += "4";
                                break;
                            case Keys.NumPad5:
                                myName += "5";
                                break;
                            case Keys.NumPad6:
                                myName += "6";
                                break;
                            case Keys.NumPad7:
                                myName += "7";
                                break;
                            case Keys.NumPad8:
                                myName += "8";
                                break;
                            case Keys.NumPad9:
                                myName += "9";
                                break;
                            case Keys.Multiply:
                                myName += "*";
                                break;
                            case Keys.Add:
                                myName += "+";
                                break;
                            case Keys.Separator:
                                myName += "";
                                break;
                            case Keys.Subtract:
                                myName += "-";
                                break;
                            case Keys.Decimal:
                                myName += ".";
                                break;
                            case Keys.Divide:
                                myName += "/";
                                break;
                            case Keys.OemSemicolon:
                                myName += "0";
                                break;
                            case Keys.OemPlus:
                                myName += "0";
                                break;
                            case Keys.OemComma:
                                myName += "0";
                                break;
                            case Keys.OemMinus:
                                myName += "0";
                                break;
                            case Keys.OemPeriod:
                                myName += "0";
                                break;
                            case Keys.OemQuestion:
                                myName += "0";
                                break;
                            case Keys.OemTilde:
                                myName += "0";
                                break;
                            case Keys.OemOpenBrackets:
                                myName += "0";
                                break;
                            case Keys.OemPipe:
                                myName += "0";
                                break;
                            case Keys.OemCloseBrackets:
                                myName += "0";
                                break;
                            case Keys.OemQuotes:
                                myName += "0";
                                break;
                            case Keys.Oem8:
                                myName += "0";
                                break;
                            case Keys.OemBackslash:
                                myName += "0";
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            if (key == Keys.Back && myName.Length > 0)
            {
                myName = myName.Remove((myName.Length - 1));
            }
        }
    }
}

