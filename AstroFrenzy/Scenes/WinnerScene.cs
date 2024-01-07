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
    /// Winner Scene, Shows the final score, menu items to return to main menu or quit 
    /// </summary>
    public class WinnerScene : GameScene
    {
        private SpriteBatch sb;
        private Texture2D texture;
        ScoreComponent score { get; set; }

        public MenuComponentWinner Menu { get; set; }
        string[] menuItems = { "Main Menu", "Quit" };

        /// <summary>
        /// Winner Scene, Displays final score and damage 
        /// </summary>
        /// <param name="game"></param>
        public WinnerScene(Game game) : base(game)
        {
            Game1 game1 = (Game1)game;
            sb = game1._spriteBatch;
            SpriteFont regularFont = game.Content.Load<SpriteFont>("fonts/RegularFont");
            SpriteFont highlightFont = game.Content.Load<SpriteFont>("fonts/HighlightFont");

            Menu = new MenuComponentWinner(game, sb, regularFont, highlightFont, menuItems);
            Components.Add(Menu);
            texture = game1.Content.Load<Texture2D>("images/winnerScene");

            //ScoreBoard
            String scoreTile = "Score: ";
            Shared.Score = 0;
            String damageTitle = "Damage: ";
            Shared.Damage = 0;
            Texture2D texScore = game.Content.Load<Texture2D>("images/bgBlackScore");
            score = new ScoreComponent(game, this.sb, regularFont, texScore, scoreTile, Shared.Score, damageTitle, Shared.Damage);

            this.Components.Add(score);
        }

        /// <summary>
        /// Draw function 
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
