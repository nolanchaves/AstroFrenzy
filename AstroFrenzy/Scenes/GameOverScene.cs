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
    /// Game over scene, shows a menu to return to main menu or quit as well as final score 
    /// </summary>
    public class GameOverScene : GameScene
    {
        private SpriteBatch sb;
        private Texture2D texture;
        ScoreComponent score { get; set; }


        public MenuComponentGameOver Menu { get; set; }
        string[] menuItems = { "Main Menu", "Quit" };

        /// <summary>
        /// Loading fonts, images, final score, damage 
        /// </summary>
        /// <param name="game"></param>
        public GameOverScene(Game game) : base(game)
        {
            Game1 game1 = (Game1)game;
            sb = game1._spriteBatch;
            SpriteFont regularFont = game.Content.Load<SpriteFont>("fonts/RegularFont");
            SpriteFont highlightFont = game.Content.Load<SpriteFont>("fonts/HighlightFont");

            Menu = new MenuComponentGameOver(game, sb, regularFont, highlightFont, menuItems);
            Components.Add(Menu);
            texture = game1.Content.Load<Texture2D>("images/gameOverScenebg");

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
        /// Draw function for game over scene 
        /// </summary>
        /// <param name="gameTime"></param>

        public override void Draw(GameTime gameTime)
        {
            sb.Begin();
            sb.Draw(texture, Vector2.Zero, Color.White);
            sb.End();

            base.Draw(gameTime);
        }
    }
}
