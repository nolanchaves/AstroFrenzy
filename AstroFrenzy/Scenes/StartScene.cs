/* AstroFrenzy
 * Developers: Nolan Chaves & Brittany Rogers 
 * Purpose: Astro Frenzy Final Project, design, develop, and implement a MonoGame game. 
 * Revision History: 
 *       Nolan Chaves Brittany Rogers, 2023.11.22:Created
 *       Nolan Chaves Brittany Rogers, 2023.12.10:Debugging Completed
 *       Nolan Chaves Brittany Rogers, 2023.12.10:Comments added
 */
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroFrenzy.Components;

namespace AstroFrenzy.Scenes
{
    /// <summary>
    /// Start Scene, Creating the menu items to show on start up 
    /// </summary>
    public class StartScene : GameScene
    {
        public MenuComponent Menu { get; set; }
        private SpriteBatch sb;
        string[] menuItems = { "Start Game", "Help", "Credit", "Quit" };

        /// <summary>
        /// Adding the menu and loading fonts to it
        /// </summary>
        /// <param name="game"></param>
        public StartScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            sb = g._spriteBatch;

            SpriteFont regularFont = game.Content.Load<SpriteFont>("fonts/RegularFont");
            SpriteFont highlightFont = g.Content.Load<SpriteFont>("fonts/HighlightFont");

            Menu = new MenuComponent(game, sb, regularFont, highlightFont, menuItems);
            Components.Add(Menu);
        }
    }
}
