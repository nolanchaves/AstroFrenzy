using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
/* AstroFrenzy
 * Developers: Nolan Chaves & Brittany Rogers 
 * Purpose: Astro Frenzy Final Project, design, develop, and implement a MonoGame game. 
 * Revision History: 
 *       Nolan Chaves Brittany Rogers, 2023.11.22:Created
 *       Nolan Chaves Brittany Rogers, 2023.12.10:Debugging Completed
 *       Nolan Chaves Brittany Rogers, 2023.12.10:Comments added
 */
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroFrenzy.Components
{
    /// <summary>
    /// Score Component, Creates a score, how many asteroids are hit 
    /// Creates properties and formats the score on the screen 
    /// </summary>
    public class ScoreComponent : DrawableGameComponent
    {
        private SpriteBatch sb;
        private SpriteFont regularFont;
        private String ScoreTitle;
        private string DamageTile;
        private Vector2 position;
        private Color regularColor = Color.White;
        private Color bgColour = Color.Yellow;
        private Texture2D tex;

        /// <summary>
        /// Score properties 
        /// </summary>
        /// <param name="game"></param>
        /// <param name="sb"></param>
        /// <param name="regularFont"></param>
        /// <param name="tex"></param>
        /// <param name="scoreTitle"></param>
        /// <param name="score"></param>
        /// <param name="damageTitle"></param>
        /// <param name="damage"></param>
        public ScoreComponent(Game game, SpriteBatch sb, SpriteFont regularFont, Texture2D tex, String scoreTitle, int score, String damageTitle, int damage) : base(game)
        {
            this.sb = sb;
            this.regularFont = regularFont;
            this.tex = tex;
            this.ScoreTitle = scoreTitle;
            Shared.Score = score;
            this.DamageTile = damageTitle;
            Shared.Damage = damage;
            position = new Vector2(0, 0);
        }

        /// <summary>
        /// Updates 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the score and damage points in the right position 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            Vector2 scorePosition = new Vector2(4, 10);
            Vector2 damagePosition = new Vector2(GraphicsDevice.Viewport.Width - regularFont.MeasureString(DamageTile).X - regularFont.MeasureString(Shared.Damage.ToString()).X, 10);
            sb.Begin();

            sb.Draw(tex, position, bgColour);

            //Score
            sb.DrawString(regularFont, ScoreTitle, scorePosition, regularColor);
            scorePosition.X = scorePosition.X + regularFont.MeasureString(ScoreTitle).X;
            sb.DrawString(regularFont, Shared.Score.ToString(), scorePosition, regularColor);

            //Damage
            sb.DrawString(regularFont, DamageTile, damagePosition, regularColor);
            damagePosition.X = damagePosition.X + regularFont.MeasureString(DamageTile).X;
            sb.DrawString(regularFont, Shared.Damage.ToString(), damagePosition, regularColor);

            sb.End();
        }
    }
}
