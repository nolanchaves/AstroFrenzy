/* AstroFrenzy
 * Developers: Nolan Chaves & Brittany Rogers 
 * Purpose: Astro Frenzy Final Project, design, develop, and implement a MonoGame game. 
 * Revision History: 
 *       Nolan Chaves Brittany Rogers, 2023.11.22:Created
 *       Nolan Chaves Brittany Rogers, 2023.12.10:Debugging Completed
 *       Nolan Chaves Brittany Rogers, 2023.12.10:Comments added
 */
using AstroFrenzy.Objects;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroFrenzy.Managers
{
    /// <summary>
    /// Collision Manager, Logic for if a missile hits and asteroid, if a asteroid hits the ship
    /// </summary>
    public class CollisionManager : GameComponent
    {
        private SoundEffect astroHitSound;
        private SoundEffect shipDamageSound;
        private Explosion explosion;
        private List<Asteroid> asteroidsToRemove = new List<Asteroid>();

        /// <summary>
        /// Collision Manager properties 
        /// </summary>
        /// <param name="game"></param>
        /// <param name="asteroid"></param>
        /// <param name="ship"></param>
        /// <param name="explosion"></param>
        /// <param name="missile"></param>
        /// <param name="astroHitSound"></param>
        /// <param name="shipDamageSound"></param>

        public CollisionManager(Game game, Asteroid asteroid, Ship ship, Explosion explosion, Missile missile, SoundEffect astroHitSound, SoundEffect shipDamageSound) : base(game)
        {
            Shared.asteroid = asteroid;
            Shared.ship = ship;
            Shared.missile = missile;
            this.explosion = explosion;
            this.astroHitSound = astroHitSound;
            this.shipDamageSound = shipDamageSound;
        }

        /// <summary>
        /// Update function, what happens if an asteriod hits the ship / if missile hits asteroid, updates the damage points and the score
        /// Activates the explosion and sound. Removes asteriods where necassary 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            //Ship Crashing into Asteriod
            Rectangle shipRect = Shared.ship.getBounds();

            if (Shared.asteroids != null)
            {
                foreach (Asteroid asteroid in Shared.asteroids)
                {
                    Rectangle asteroidRect = asteroid.getBounds();

                    if (shipRect.Intersects(asteroidRect))
                    {
                        Rectangle intersection = Rectangle.Intersect(shipRect, asteroidRect);

                        if (intersection.Top == shipRect.Top && intersection.Bottom == asteroidRect.Bottom)
                        {
                            if (Shared.Damage == 75)
                            {
                                Shared.Damage = Shared.Damage + Shared.damageAmount;
                                Shared.Score = Shared.Score + Shared.scoreAmount;
                                Debug.WriteLine("hit detected");
                                int randomY = new Random().Next(-1000, 0);
                                asteroid.Position = new Vector2(asteroid.Position.X, randomY);
                                Debug.WriteLine(Shared.asteroids.Count);
                                explosion.Position = new Vector2(asteroidRect.X - (asteroidRect.Width / 10), asteroidRect.Y + (asteroidRect.Height / 2));
                            }
                            else
                            {
                                shipDamageSound.Play();
                                Shared.Damage = Shared.Damage + Shared.damageAmount;
                                Shared.Score = Shared.Score + Shared.scoreAmount;
                                Debug.WriteLine("hit detected");
                                int randomY = new Random().Next(-1000, 0);
                                asteroid.Position = new Vector2(asteroid.Position.X, randomY);
                                Debug.WriteLine(Shared.asteroids.Count);
                                explosion.Position = new Vector2(asteroidRect.X - (asteroidRect.Width / 10), asteroidRect.Y + (asteroidRect.Height / 2));
                                explosion.restart();
                            }
                        }
                    }
                }
            }

            // Missile Crashing into Asteroid
            Rectangle missileRect = Shared.missile.getBounds();
            foreach (Asteroid asteroid in Shared.asteroids)
            {
                Rectangle asteroidRect = asteroid.getBounds();

                if (missileRect.Intersects(asteroidRect))
                {
                    Rectangle intersection = Rectangle.Intersect(missileRect, asteroidRect);

                    if (intersection.Top == missileRect.Top && intersection.Bottom == asteroidRect.Bottom && Shared.missile.Visible == true)
                    {
                        Shared.missile.Reset(Shared.ship.Position);
                        int randomY = new Random().Next(-1000, 0);
                        asteroid.Position = new Vector2(asteroid.Position.X, randomY);
                        Debug.WriteLine("asteroid removed");
                        Debug.WriteLine(Shared.asteroids.Count);

                        Shared.Score = Shared.Score + Shared.scoreAmount;

                        explosion.Position = new Vector2(missileRect.X - (shipRect.Width / 10), missileRect.Y + (missileRect.Height - (missileRect.Height * 2)));
                        astroHitSound.Play();
                        explosion.restart();
                    }
                }
            }

            foreach (Asteroid asteroid in Shared.asteroids)
            {
                Rectangle asteroidRect = asteroid.getBounds();

                //Removes astriods when they leave screen
                if (asteroidRect.Bottom - asteroidRect.Height > Shared.stage.Y)
                {
                    Debug.WriteLine("asteroid removed");
                    Debug.WriteLine(Shared.asteroids.Count);
                    int randomY = new Random().Next(-1000, 0);
                    asteroid.Position = new Vector2(asteroid.Position.X, randomY);
                }
            }

            // Remove the asteroids after the iteration
            foreach (Asteroid asteroid in asteroidsToRemove)
            {
                Shared.asteroids.Remove(asteroid);
                asteroid.Visible = false;
            }

            if (Shared.Reset)
            {
                Random random = new Random();

                foreach (Asteroid a in Shared.asteroids)
                {
                    // Update the Y position for each asteroid
                    int randomY = random.Next(-1000, -1);
                    a.Position = new Vector2(a.Position.X, randomY);
                }

                // Reset the flag after updating asteroid positions
                Shared.Reset = false;
            }

            base.Update(gameTime);
        }

    }
}
