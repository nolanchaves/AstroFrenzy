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

namespace AstroFrenzy.Objects
{
    /// <summary>
    /// Explosion class,  Creates the animation of the explosion/ formatting 
    /// </summary>
    public class Explosion : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 dimension;
        private List<Rectangle> frames;
        private int frameIndex = -1;

        private int delay;
        private int delayCounter;

        private const int ROW = 5;
        private const int COL = 5;

        public Vector2 Position { get => position; set => position = value; }

        /// <summary>
        /// properties of explosion 
        /// </summary>
        public Explosion(Game game, SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position,
            int delay) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.delay = delay;

            dimension = new Vector2(tex.Width / COL, tex.Height / ROW);
            hide();
            createFrames();
        }

        /// <summary>
        /// Hide function 
        /// </summary>
        public void hide()
        {
            Enabled = false;
            Visible = false;
        }

        /// <summary>
        /// Restart function 
        /// </summary>
        public void restart()
        {
            frameIndex = -1;
            delayCounter = 0;
            Enabled = true;
            Visible = true;
        }

        /// <summary>
        /// Creating the frames to creat animation of the explosion image 
        /// </summary>
        private void createFrames()
        {
            frames = new List<Rectangle>();
            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COL; j++)
                {
                    int x = j * (int)dimension.X;
                    int y = i * (int)dimension.Y;
                    Rectangle r = new Rectangle(x, y, (int)dimension.X, (int)dimension.Y);
                    frames.Add(r);
                }
            }

        }

        /// <summary>
        /// Draw function for the animation using the frames 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            if (frameIndex >= 0)
            {
                //v 4
                spriteBatch.Draw(tex, position, frames[frameIndex], Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Update function for the frames /delay
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            delayCounter++;
            if (delayCounter > delay)
            {
                frameIndex++;
                if (frameIndex > ROW * COL - 1)
                {
                    frameIndex = -1;
                    hide();

                }
                delayCounter = 0;
            }


            base.Update(gameTime);
        }
    }
}
