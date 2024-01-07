/* AstroFrenzy
 * Developers: Nolan Chaves & Brittany Rogers 
 * Purpose: Astro Frenzy Final Project, design, develop, and implement a MonoGame game. 
 * Revision History: 
 *       Nolan Chaves Brittany Rogers, 2023.11.22:Created
 *       Nolan Chaves Brittany Rogers, 2023.12.10:Debugging Completed
 *       Nolan Chaves Brittany Rogers, 2023.12.10:Comments added
 */
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace AstroFrenzy.Objects
{
    /// <summary>
    /// Ship Class, Creates the logic for the ship.  Formats the controls to use to move the ship. 
    /// </summary>
    public class Ship : DrawableGameComponent
    {
        private SpriteBatch sb;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 speed;

        public Vector2 Speed { get => speed; set => speed = value; }
        public Vector2 Position { get => position; set => position = value; }

        /// <summary>
        /// Ships properties
        /// </summary>
        /// <param name="game"></param>
        /// <param name="sb"></param>
        /// <param name="tex"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        public Ship(Game game, SpriteBatch sb, Texture2D tex, Vector2 position, Vector2 speed) : base(game)
        {
            this.sb = sb;
            this.tex = tex;
            Position = position;
            this.speed = speed;
        }

        /// <summary>
        /// Resets the ship once the player has won, lost, or quit the game
        /// </summary>
        public void ResetPosition()
        {
            Position = new Vector2(Shared.stage.X / 2 - tex.Width, Shared.stage.Y - tex.Height);
        }

        /// <summary>
        /// Update function, controls for the ship using the arrow keys 
        /// Left arrow key is move ship to the left
        /// Right arrow key is move ship to the right 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Left))
            {
                position -= speed;
                if (position.X <= 0)
                {
                    position.X = 0;
                }
            }

            if (ks.IsKeyDown(Keys.Right))
            {
                position += speed;
                if (position.X >= Shared.stage.X - tex.Width)
                {
                    position.X = Shared.stage.X - tex.Width;
                }
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// Draw function for the ship
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            sb.Begin();
            sb.Draw(tex, position, Color.White);
            sb.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// Getting the bounds 
        /// </summary>
        /// <returns></returns>
        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y,
                tex.Width, tex.Height);
        }

    }
}
