/* AstroFrenzy
 * Developers: Nolan Chaves & Brittany Rogers 
 * Purpose: Astro Frenzy Final Project, design, develop, and implement a MonoGame game. 
 * Revision History: 
 *       Nolan Chaves Brittany Rogers, 2023.11.22:Created
 *       Nolan Chaves Brittany Rogers, 2023.12.10:Debugging Completed
 *       Nolan Chaves Brittany Rogers, 2023.12.10:Comments added
 */
using AstroFrenzy.Managers;
using AstroFrenzy.Objects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AstroFrenzy
{
    /// <summary>
    /// Astro Frenzy Final Project, Shared properties to avoid repetition 
    /// </summary>
    public class Shared
    {
        public static Vector2 stage;

        public static List<Asteroid> asteroids = new List<Asteroid>();

        public static Ship ship;

        public static Missile missile;

        public static Asteroid asteroid;

        public static CollisionManager collisionManager;

        public static Explosion explosion;

        public static bool Reset { get; set; }

        public static int Score { get; set; }

        public static int Damage { get; set; }

        public static int numberofAsteroids = 20;

        public static int winningScore = 2500;

        public static int damageAmount = 20;

        public static int scoreAmount = 100;

    }
}
