/* AstroFrenzy
 * Developer: Nolan Chaves & Brittany Rogers 
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
    /// Main Menu, Creates logic for navigating through the menu items (scenes)
    /// </summary>
    public class MenuComponent : DrawableGameComponent
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
        public MenuComponent(Game game, SpriteBatch sb, SpriteFont regularFont, SpriteFont highlightFont, string[] menus) : base(game)
        {
            this.sb = sb;
            this.regularFont = regularFont;
            this.highlightFont = highlightFont;
            menuItems = menus.ToList();
            position = new Vector2(Shared.stage.X / 2, Shared.stage.Y / 2);
        }

        /// <summary>
        /// Update function for menu keys 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Down) && oldState.IsKeyUp(Keys.Down))
            {
                SelectedIndex++;
                if (SelectedIndex == menuItems.Count)
                {
                    SelectedIndex = 0;
                }
            }
            if (ks.IsKeyDown(Keys.Up) && oldState.IsKeyUp(Keys.Up))
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
        /// Draw function for menu keys, formatting fonts, pos, color 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            Vector2 tempPos = position;
            sb.Begin();
            for (int i = 0; i < menuItems.Count; i++)
            {
                if (i == SelectedIndex)
                {
                    sb.DrawString(highlightFont, menuItems[i], tempPos, highlightColor);
                    tempPos.Y += highlightFont.LineSpacing;
                }
                else
                {
                    sb.DrawString(regularFont, menuItems[i], tempPos, regularColor);
                    tempPos.Y += regularFont.LineSpacing;
                }
            }
            sb.End();

            base.Draw(gameTime);
        }
    }
}
