using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace PlasmaPeasant
{
    class RangedWeap:Weapon
    {
        // int for projectile speed
        protected int speed;
        protected int fireRate;

        // property for fire rate
        public int FireRate { get { return fireRate; } }


        public RangedWeap(Characters host, Level lvl,int x, int y, int damage, int rate, int projspeed):base(host,lvl,x,y,damage)
        {
            this.speed = projspeed;
            this.fireRate = rate;
        }

        //method for shooting weapon
        public override void Attack()
        {
            // creates projectile from player location and view
            // return new Projectile(lvl, new Rectangle(play.X, play.Y, 32, 32), 1, speed, motion, "ball");
            if (host.textureFileName == "playerAnimFull")
            {
                lvl.projs.Add(new Projectile(lvl, host, new Rectangle(this.X, this.Y, 32, 32), Damage, 0, speed, host.Motion, "plasmaBoltSheet"));
            }
            if (host.textureFileName == "enemy1Sheet")
            {
                lvl.projs.Add(new Projectile(lvl, host, new Rectangle(this.X, this.Y, 32, 32), Damage, 0, speed, host.Motion, "plasmaBoltSheetPurpleEnemy1"));
            }
            if (host.textureFileName == "Enemy2AnimFull")
            {
                lvl.projs.Add(new Projectile(lvl, host, new Rectangle(this.X, this.Y, 32, 32), Damage, 0, speed, host.Motion, "plasmaBoltSheetEnemy2"));
            }
            if (host.textureFileName == "Enemy3AnimFull")
            {
                lvl.projs.Add(new Projectile(lvl, host, new Rectangle(this.X, this.Y, 64, 64), Damage, 0, speed, host.Motion, "plasmaBoltSheetEnemy3Sheet"));
            }

        }
    }
}
