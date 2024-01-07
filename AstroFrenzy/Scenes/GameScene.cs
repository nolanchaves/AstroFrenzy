/* AstroFrenzy
 * Developers: Nolan Chaves & Brittany Rogers 
 * Purpose: Astro Frenzy Final Project, design, develop, and implement a MonoGame game. 
 * Revision History: 
 *       Nolan Chaves Brittany Rogers, 2023.11.22:Created
 *       Nolan Chaves Brittany Rogers, 2023.12.10:Debugging Completed
 *       Nolan Chaves Brittany Rogers, 2023.12.10:Comments added
 */
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroFrenzy.Scenes
{
    /// <summary>
    /// Game Scene, Logic for update and draw of game components 
    /// </summary>
    public abstract class GameScene : DrawableGameComponent
    {
        private List<GameComponent> components;
        public List<GameComponent> Components { get => components; set => components = value; }

        /// <summary>
        /// Will show the specified game scene if enabled 
        /// </summary>
        public virtual void show()
        {
            Enabled = true;
            Visible = true;
        }

        /// <summary>
        /// Will hide the specified game scene if enabled 
        /// </summary>
        public virtual void hide()
        {
            Enabled = false;
            Visible = false;
        }

        /// <summary>
        /// Using a list for the components
        /// </summary>
        /// <param name="game"></param>
        protected GameScene(Game game) : base(game)
        {
            components = new List<GameComponent>();
            hide();
        }

        /// <summary>
        /// Draw function of the components
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            foreach (GameComponent item in components)
            {
                if (item is DrawableGameComponent)
                {
                    DrawableGameComponent comp = (DrawableGameComponent)item;
                    if (comp.Visible)
                    {
                        comp.Draw(gameTime);
                    }
                }
            }

            base.Draw(gameTime);
        }

        /// <summary>
        /// Update function for components
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            foreach (GameComponent item in components)
            {
                if (item.Enabled)
                {
                    item.Update(gameTime);
                }
            }
            base.Update(gameTime);
        }

    }
}
