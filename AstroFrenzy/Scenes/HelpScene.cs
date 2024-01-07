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
    /// Help Scene, shows a graphic on how to play the game 
    /// </summary>
    public class HelpScene : GameScene
    {
        private SpriteBatch sb;
        private Texture2D texture;

        /// <summary>
        /// Loads the help graphic
        /// </summary>
        /// <param name="game"></param>
        public HelpScene(Game game) : base(game)
        {
            Game1 game1 = (Game1)game;
            sb = game1._spriteBatch;
            texture = game1.Content.Load<Texture2D>("images/helpScreen");
        }

        /// <summary>
        /// Draws the graphic and to size
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            Rectangle srcRect = new Rectangle(0, 0, 800, 480);
            sb.Begin();
            sb.Draw(texture, srcRect, Color.White);
            sb.End();

            base.Draw(gameTime);
        }
    }
}
