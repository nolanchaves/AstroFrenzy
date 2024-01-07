/* AstroFrenzy
 * Developers: Nolan Chaves & Brittany Rogers 
 * Purpose: Astro Frenzy Final Project, design, develop, and implement a MonoGame game. 
 * Revision History: 
 *       Nolan Chaves Brittany Rogers, 2023.11.22:Created
 *       Nolan Chaves Brittany Rogers, 2023.12.10:Debugging Completed
 *       Nolan Chaves Brittany Rogers, 2023.12.10:Comments added
 */
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroFrenzy.Components
{
    /// <summary>
    /// Winner Menu, Creates menu to nav back to main menu or quit the game, only get here if you get 2500 points 
    /// </summary>
    public class MenuComponentWinner : DrawableGameComponent
    {
        private SpriteBatch sb;
        private SpriteFont regularFont, highlightFont;
        private List<string> menuItems;
        public int SelectedIndex { get; set; }
        private Vector2 position;
        private Color regularColor = Color.White;
        private Color highlightColor = Color.Yellow;

        private KeyboardState oldState;

        /// <summary>
        /// Menu properties 
        /// </summary>
        /// <param name="game"></param>
        /// <param name="sb"></param>
        /// <param name="regularFont"></param>
        /// <param name="highlightFont"></param>
        /// <param name="menus"></param>
        public MenuComponentWinner(Game game, SpriteBatch sb, SpriteFont regularFont, SpriteFont highlightFont, string[] menus) : base(game)
        {
            this.sb = sb;
            this.regularFont = regularFont;
            this.highlightFont = highlightFont;
            menuItems = menus.ToList();
            position = new Vector2(Shared.stage.X / 6, Shared.stage.Y / 2 + 100);
        }

        /// <summary>
        /// Update and creates an index to select menu or quit 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Right) && oldState.IsKeyUp(Keys.Right))
            {
                SelectedIndex++;
                if (SelectedIndex == menuItems.Count)
                {
                    SelectedIndex = 0;
                }
            }
            if (ks.IsKeyDown(Keys.Left) && oldState.IsKeyUp(Keys.Left))
            {
                SelectedIndex--;
                if (SelectedIndex == -1)
                {
                    SelectedIndex = menuItems.Count - 1;
                }
            }
            oldState = ks;

            base.Update(gameTime);
        }

        /// <summary>
        /// Draw function 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            string fScore = "Final Score: " + Shared.Score.ToString();
            Vector2 scorePos = new Vector2(Shared.stage.X, Shared.stage.Y);

            Vector2 tempPos = position;
            sb.Begin();
            sb.DrawString(regularFont, Shared.Score.ToString(), scorePos, regularColor);
            for (int i = 0; i < menuItems.Count; i++)
            {
                if (i == SelectedIndex)
                {
                    sb.DrawString(highlightFont, menuItems[i], tempPos, highlightColor);
                    tempPos.X = tempPos.X + 300;

                }
                else
                {
                    sb.DrawString(regularFont, menuItems[i], tempPos, regularColor);
                    tempPos.X = tempPos.X + 300;
                }
            }
            sb.End();

            base.Draw(gameTime);
        }
    }
}
