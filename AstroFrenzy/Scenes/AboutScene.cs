/* AstroFrenzy
 * Developers: Nolan Chaves & Brittany Rogers 
 * Purpose: Astro Frenzy Final Project, design, develop, and implement a MonoGame game. 
 * Revision History: 
 *       Nolan Chaves Brittany Rogers, 2023.11.22:Created
 *       Nolan Chaves Brittany Rogers, 2023.12.10:Debugging Completed
 *       Nolan Chaves Brittany Rogers, 2023.12.10:Comments added
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroFrenzy.Scenes
{
    /// <summary>
    /// About Scene, loads a graphic with Developer names 
    /// </summary>
    public class AboutScene : GameScene
    {
        private SpriteBatch sb;
        private Texture2D tex;

        /// <summary>
        /// Loads the credit image
        /// </summary>
        /// <param name="game"></param>
        public AboutScene(Game game) : base(game)
        {
            Game1 game1 = (Game1)game;
            sb = game1._spriteBatch;
            tex = game1.Content.Load<Texture2D>("images/AboutScene");

        }

        /// <summary>
        /// Draws and sizes the image 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            Rectangle srcRect = new Rectangle(0, 0, 800, 480);
            sb.Begin();
            sb.Draw(tex, srcRect, Color.White);
            sb.End();
            base.Draw(gameTime);
        }
    }
}
