/* AstroFrenzy
 * Developers: Nolan Chaves & Brittany Rogers 
 * Purpose: Astro Frenzy Final Project, design, develop, and implement a MonoGame game. 
 * Revision History: 
 *       Nolan Chaves Brittany Rogers, 2023.11.22:Created
 *       Nolan Chaves Brittany Rogers, 2023.12.10:Debugging Completed
 *       Nolan Chaves Brittany Rogers, 2023.12.10:Comments added
 */
using AstroFrenzy.Scenes;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AstroFrenzy
{
    /// <summary>
    ///  Astro Frenzy Final Project, Game1 class start scene logic and menu logic
    /// </summary>
    public class Game1 : Game
    {
        //Declare sounds
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        private Song menuBackSound;
        private Song aboutBackSound;
        private Song helpBackSound;
        private Song actionBackSound;
        private Song gameOverSound;
        private Song winnerSound;
        private Texture2D tex;

        //Declare all scenes here
        private StartScene startScene;
        private HelpScene helpScene;
        private ActionScene actionScene;
        private AboutScene aboutScene;
        private GameOverScene gameOverScene;
        private WinnerScene winnerScene;


        private KeyboardState oldState;

        /// <summary>
        /// Content Manager 
        /// </summary>
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Shared.stage = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            base.Initialize();
        }

        /// <summary>
        /// Loading components, scenes, sounds and images, showing the start scene once program is run 
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //Loading Menu background sound 

            menuBackSound = this.Content.Load<Song>("sounds/menuSound");
            aboutBackSound = this.Content.Load<Song>("sounds/fly");
            helpBackSound = this.Content.Load<Song>("sounds/fly");
            actionBackSound = this.Content.Load<Song>("sounds/actionBackSoundv3");
            gameOverSound = this.Content.Load<Song>("sounds/gameOverSound");
            winnerSound = this.Content.Load<Song>("sounds/winnerSound");

            //Main menu image
            tex = this.Content.Load<Texture2D>("images/AstroFrenzyV2");

            //Adding all the scenes to the components

            startScene = new StartScene(this);
            this.Components.Add(startScene);

            helpScene = new HelpScene(this);
            this.Components.Add(helpScene);

            actionScene = new ActionScene(this);
            this.Components.Add(actionScene);

            aboutScene = new AboutScene(this);
            this.Components.Add(aboutScene);

            gameOverScene = new GameOverScene(this);
            this.Components.Add(gameOverScene);

            winnerScene = new WinnerScene(this);
            this.Components.Add(winnerScene);

            //Show only Start Scene on load
            startScene.show();

        }

        /// <summary>
        /// Hide all the components unless show function is called for that scene
        /// </summary>
        private void hideAllScenes()
        {
            foreach (GameComponent item in Components)
            {
                if (item is GameScene)
                {
                    GameScene gameScene = (GameScene)item;
                    gameScene.hide();
                }
            }
        }

        /// <summary>
        /// Menu logic, can nav through all the scenes and plays certain sounds
        /// Winner and Game over checked
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            int selectedIndex = 0;
            KeyboardState keyboardState = Keyboard.GetState();


            if (startScene.Enabled)
            {
                //Play background music only on the menu, it will stop once click on another scene but will resume playing once return to menu
                if (MediaPlayer.State != MediaState.Playing)
                {
                    MediaPlayer.IsRepeating = true;
                    MediaPlayer.Play(menuBackSound);

                }

                selectedIndex = startScene.Menu.SelectedIndex;

                //Action Scene
                if (selectedIndex == 0 && keyboardState.IsKeyDown(Keys.Enter) && oldState != keyboardState)
                {
                    hideAllScenes();
                    MediaPlayer.IsRepeating = true;
                    MediaPlayer.Play(actionBackSound);
                    actionScene.show();
                }

                //Help Scene
                else if (selectedIndex == 1 && keyboardState.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    helpScene.show();
                    MediaPlayer.IsRepeating = true;
                    //Playing a different sound than the menu scene
                    MediaPlayer.Play(helpBackSound);
                }

                //About Scene
                else if (selectedIndex == 2 && keyboardState.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    aboutScene.show();
                    MediaPlayer.IsRepeating = true;
                    //Playing a different sound than the menu scene
                    MediaPlayer.Play(aboutBackSound);
                }

                //Exit
                else if (selectedIndex == 3 && keyboardState.IsKeyDown(Keys.Enter))
                {
                    Exit();
                }

            }

            if (actionScene.Enabled || helpScene.Enabled || aboutScene.Enabled)
            {
                if (keyboardState.IsKeyDown(Keys.Escape))
                {
                    hideAllScenes();
                    startScene.show();
                    //Setting the sound back to the menu back sound if you were on another page 
                    MediaPlayer.IsRepeating = true;
                    MediaPlayer.Play(menuBackSound);
                }

            }

            // Check for game over condition
            if (actionScene.Enabled && Shared.Damage == 100)
            {
                hideAllScenes();
                gameOverScene.show();
                MediaPlayer.IsRepeating = false;
                MediaPlayer.Play(gameOverSound);
            }

            if (gameOverScene.Enabled)
            {
                int index = gameOverScene.Menu.SelectedIndex;
                KeyboardState ks = Keyboard.GetState();
                oldState = ks;

                if (index == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    Shared.ship.ResetPosition();
                    Shared.missile.Reset(Shared.ship.Position);
                    Shared.Damage = 0;
                    Shared.Score = 0;
                    Shared.Reset = true;
                    hideAllScenes();
                    startScene.show();
                    MediaPlayer.IsRepeating = true;
                    MediaPlayer.Play(menuBackSound);

                }

                else if (index == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    Exit();
                }
            }


            // Check for Winner condition
         
            if (actionScene.Enabled && Shared.Score == Shared.winningScore)
            {
                hideAllScenes();
                winnerScene.show();
                MediaPlayer.IsRepeating = false;
                MediaPlayer.Play(winnerSound);
            }


            if (winnerScene.Enabled)
            {
                int index = winnerScene.Menu.SelectedIndex;
                KeyboardState ks = Keyboard.GetState();
                oldState = ks;

                if (index == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    Shared.ship.ResetPosition();
                    Shared.missile.Reset(Shared.ship.Position);
                    Shared.Damage = 0;
                    Shared.Score = 0;
                    Shared.Reset = true;
                    hideAllScenes();
                    startScene.show();
                    MediaPlayer.IsRepeating = true;
                    MediaPlayer.Play(menuBackSound);

                }
                else if (index == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    Exit();
                }
            }

            // Update oldState at the end of the Update method
            oldState = keyboardState;

            base.Update(gameTime);
        }

        /// <summary>
        /// Draws and sizes the image
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            Rectangle srcRect = new Rectangle(0, 0, 800, 480);
            _spriteBatch.Begin();
            _spriteBatch.Draw(tex, srcRect, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
