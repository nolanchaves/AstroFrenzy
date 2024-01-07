/* AstroFrenzy
 * Developers: Nolan Chaves & Brittany Rogers 
 * Purpose: Astro Frenzy Final Project, design, develop, and implement a MonoGame game. 
 * Revision History: 
 *       Nolan Chaves Brittany Rogers, 2023.11.22:Created
 *       Nolan Chaves Brittany Rogers, 2023.12.10:Debugging Completed
 *       Nolan Chaves Brittany Rogers, 2023.12.10:Comments added
 */
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AstroFrenzy.Components;
using AstroFrenzy.Objects;
using AstroFrenzy.Backgrounds;
using AstroFrenzy.Managers;

namespace AstroFrenzy.Scenes
{
    /// <summary>
    /// Action Scene, Game play logic, pulling from other object classes 
    /// </summary>
    public class ActionScene : GameScene
    {
        ScoreComponent score { get; set; }
        SpriteBatch sb;

        private Ship ship;

        private Asteroid asteroid;

        private Explosion explosion;

        private Missile missile;

        private ScrollingBackground background;

        private CollisionManager cm;
       
        /// <summary>
        /// Formatting the game objects, ship, asteroids, missile, scrolling background, scoreboard, collison manager, 
        /// and adding all the components, loads sounds and images 
        /// </summary>
        /// <param name="game"></param>
        public ActionScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.sb = g._spriteBatch;

            //Ship - Ship starts in the middle of play 
            Texture2D shipTex = game.Content.Load<Texture2D>("images/shipTemp");
            Vector2 shipIntPos = new Vector2(Shared.stage.X / 2 - shipTex.Width, Shared.stage.Y - (shipTex.Height));
            Vector2 shipSpeed = new Vector2(5, 0);
            ship = new Ship(game, this.sb, shipTex, shipIntPos, shipSpeed);

            //Asteroids - generating them to fall by random
            Texture2D asteroidTex = game.Content.Load<Texture2D>("images/asteroid");
            for (int i = 0; i < Shared.numberofAsteroids; i++)
            {
                Random r = new Random();

                int randomX = r.Next(GraphicsDevice.Viewport.Width);
                int randomY = r.Next(-1000, 0);

                int rSpeedY = new Random().Next(-5, 1);

                Vector2 asteroidPos = new Vector2(randomX, randomY);
                Vector2 asteroidSpeed = new Vector2(0, rSpeedY);

                Asteroid asteroid = new Asteroid(game, this.sb, asteroidTex, asteroidPos, asteroidSpeed);
                Shared.asteroids.Add(asteroid);
            }

            //Scrolling Background
            Texture2D tex = game.Content.Load<Texture2D>("images/blackSpace");
            Rectangle srcRect = new Rectangle(0, 0, tex.Width, tex.Height);
            Vector2 pos = new Vector2(0, Shared.stage.Y);
            Vector2 speed = new Vector2(0, 4);
            background = new ScrollingBackground(game, this.sb, tex, pos, srcRect, speed);

            //ScoreBoard - loads score and damage
            String scoreTile = "Score: ";
            Shared.Score = 0;
            String damageTitle = "Damage: ";
            Shared.Damage = 0;
            Texture2D texScore = game.Content.Load<Texture2D>("images/bgBlackScore");
            SpriteFont regularFont = game.Content.Load<SpriteFont>("fonts/RegularFont");
            score = new ScoreComponent(game, this.sb, regularFont, texScore, scoreTile, Shared.Score, damageTitle, Shared.Damage);

            //Explosion
            Texture2D explosionTex = game.Content.Load<Texture2D>("images/explosionV2");
            explosion = new Explosion(game, this.sb, explosionTex, Vector2.Zero, 1);


            //Missile - shoots from where the ship is 
            Texture2D missileTex = game.Content.Load<Texture2D>("images/missile");
            Vector2 missilePosition = new Vector2(ship.Position.X + (shipTex.Width / 2) - 14, ship.Position.Y + (shipTex.Height / 2) - 23);
            Vector2 missileSpeed = new Vector2(0, 5);
            missile = new Missile(game, this.sb, missileTex, missilePosition, missileSpeed);

            //Collision Manager
            SoundEffect astroHitSound = game.Content.Load<SoundEffect>("sounds/hitSoundv2");
            SoundEffect shipDamageSound = game.Content.Load<SoundEffect>("sounds/shipDamageSoundv3");
            cm = new CollisionManager(game, asteroid, ship, explosion, missile, astroHitSound, shipDamageSound);

            //Adding Components
            this.Components.Add(background);
            this.Components.Add(missile);
            this.Components.Add(ship);
            foreach (Asteroid a in Shared.asteroids)
            {
                this.Components.Add(a);
            }
            this.Components.Add(explosion);
            this.Components.Add(score);
            this.Components.Add(cm);
        }
    }
}
