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
    /// Asteroid class, formatting the asteroid
    /// </summary>
    public class Asteroid : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 speed;

        public Vector2 Speed { get => speed; set => speed = value; }
        public Vector2 Position { get => position; set => position = value; }

        /// <summary>
        /// Asteroids properties 
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="tex"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        public Asteroid(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 position, Vector2 speed) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            Position = position;
            this.speed = speed;
        }

        /// <summary>
        /// Draw function using the properties 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Updating the position and speed 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            position -= speed;
            base.Update(gameTime);
        }

        /// <summary>
        /// Getting the bounds 
        /// </summary>
        /// <returns></returns>
        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }
    }
}
