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
    /// Missile Class, Creates the logic for the missile and how interacts with ship.  Formats the controls to use to move the missile. 
    /// </summary>
    public class Missile : DrawableGameComponent
    {
        private SpriteBatch sb;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 speed;
        private bool isShooting = false;

        virtual public Vector2 Position { get => position; set => position = value; }

        /// <summary>
        /// Missile properties 
        /// </summary>
        /// <param name="game"></param>
        /// <param name="sb"></param>
        /// <param name="tex"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        public Missile(Game game, SpriteBatch sb, Texture2D tex, Vector2 position, Vector2 speed) : base(game)
        {
            this.sb = sb;
            this.tex = tex;
            Position = position;
            this.speed = speed;
        }

        /// <summary>
        /// Draw function for missile
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
        /// Formats controls for the missile, shoots it from the ships pos. if space bar is hit 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            Vector2 shipPos = new Vector2(Shared.ship.Position.X + (tex.Width + 32) / 2, Shared.ship.Position.Y + (tex.Height - 25) / 2);

            KeyboardState ks = Keyboard.GetState();

            if (!isShooting && ks.IsKeyDown(Keys.Space))
            {
                isShooting = true;
                Visible = true;
            }

            if (isShooting)
            {
                position.Y -= speed.Y;

                if (position.Y < 0)
                {
                    Reset(shipPos);
                }
            }
            else
            {
                Reset(shipPos);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Resets the missile once the player has won, lost, or quit the game
        /// </summary>
        /// <param name="shipPos"></param>
        public void Reset(Vector2 shipPos)
        {
            position = shipPos;
            isShooting = false;
            Visible = false;
        }

        /// <summary>
        /// Gets the bounds
        /// </summary>
        /// <returns></returns>
        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }
    }
}
