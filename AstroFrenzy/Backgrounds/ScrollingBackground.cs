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

namespace AstroFrenzy.Backgrounds
{
    /// <summary>
    /// Scrolling background for action scene.  Scrolls an image up in the background of the play 
    /// </summary>
    public class ScrollingBackground : DrawableGameComponent
    {
        private SpriteBatch sb;
        private Texture2D tex;
        private Vector2 position1, position2;
        private Rectangle srcRect;
        private Vector2 speed;

        /// <summary>
        /// Background properties 
        /// </summary>
        /// <param name="game"></param>
        /// <param name="sb"></param>
        /// <param name="tex"></param>
        /// <param name="position"></param>
        /// <param name="srcRect"></param>
        /// <param name="speed"></param>
        public ScrollingBackground(Game game, SpriteBatch sb, Texture2D tex, Vector2 position, Rectangle srcRect, Vector2 speed) : base(game)
        {
            this.sb = sb;
            this.tex = tex;
            this.srcRect = srcRect;
            this.speed = speed;
            this.position1 = position;
            this.position2 = new Vector2(position.X, position.Y - srcRect.Height);
        }

        /// <summary>
        /// Update function , formatting speed and position 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            position1.Y += speed.Y;
            position2.Y += speed.Y;

            if (position1.Y > Shared.stage.Y)
            {
                position1.Y = position2.Y - srcRect.Height;
            }

            if (position2.Y > Shared.stage.Y)
            {
                position2.Y = position1.Y - srcRect.Height;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Draw function of the position
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            sb.Begin();

            sb.Draw(tex, position1, srcRect, Color.White);

            sb.Draw(tex, position2, srcRect, Color.White);

            sb.End();

            base.Draw(gameTime);
        }
    }
}
