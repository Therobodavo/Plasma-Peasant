using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
/*
 * GDAPS 2 Online Section 2
 * Level Class
 * Programmed by Fred and David
 */
namespace PlasmaPeasant
{
    class Level : Screen
    {
        // list to keep track of all objects
        public Player player;
        public Enemy enemy1;
        public Enemy enemy2;
        public Enemy enemy3;
        public Enemy enemy4;
        public Enemy enemy5;
        public Items itemTest1;
        public Items itemTest2;
        public List<Objects> objs = new List<Objects>();
        public List<Door> doors = new List<Door>();
        public List<Enemy> enemies = new List<Enemy>();
        public List<Projectile> projs = new List<Projectile>();
        public List<Items> itemList = new List<Items>();
        public List<RangedWeap> weapDrop = new List<RangedWeap>();
        public ContentManager content;

        // game time stuff
        private GameTime gmTime;
        public GameTime GmTime { get { return gmTime; } set { gmTime = value; } }

        public Level():base()
        {
            CreateLevel();
        }
        public Level(Player p) : base()
        {
            this.player = p;
            CreateLevel();
        }

        public virtual void CreateLevel()
        {
            //create things here

        }

        // loads all objects in the lists
        public override void Load(ContentManager content)
        {
            this.content = content;

            for(int i = 0; i < doors.Count; i++)
            {
                doors[i].Load(content);
            }
            for (int i = 0; i < projs.Count; i++)
            {
                projs[i].Load(content);
            }
            for (int i = 0; i < objs.Count; i++)
            {
                objs[i].Load(content);
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Load(content);
            }
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].Load(content);
            }
            for (int i = 0; i < weapDrop.Count; i++)
            {
                weapDrop[i].Load(content);
            }
            player.Load(content);
        }

        //""C:\Program Files (x86)\MSBuild\MonoGame\v3.0\Tools\MGCB.exe" /quiet /platform:Windows /@:"C:\Users\Thero\source\repos\Game1\Game1\Content\Content.mgcb" /outputDir:"bin\Windows\Content" /intermediateDir:"obj\Windows\Content""		

        //Updates everything 
        public override void Update()
        {
            for (int i = 0; i < doors.Count; i++)
            {
                doors[i].Update();
            }
            for (int i = 0; i < projs.Count; i++)
            {
                projs[i].Update();
            }
            for (int i = 0; i < objs.Count; i++)
            {
                objs[i].Update();
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Update();
            }
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].Update();
            }
            player.Update();
            // checks if enemies are alive
            // if not removes them from list
            //CheckAlive();
        }

        // Draws everything
        public override void Draw(SpriteBatch spriteBatch)
        {
            //Loads everything incase of new objects being added since last load
            Load(content);

            //Draws everything
            for (int i = 0; i < objs.Count; i++)
            {
                objs[i].Draw(spriteBatch);
            }
            for (int i = 0; i < doors.Count; i++)
            {
                doors[i].Draw(spriteBatch);
            }
            player.Draw(spriteBatch);
            for (int i = 0; i < projs.Count; i++)
            {
                projs[i].Draw(spriteBatch);
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Draw(spriteBatch);
            }
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].Draw(spriteBatch);
            }
            for (int i = 0; i < weapDrop.Count; i++)
            {
                weapDrop[i].Draw(spriteBatch);
            }
        }

        // checking if anything is dead
        public void CheckAlive()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].CheckDead())
                {
                    enemies.Remove(enemies[i]);
                }
            }
        }
        //Method used to check collision (Projectiles)
        public Projectile CheckCollisionProjectiles(Characters chara)
        {
            foreach (Projectile proj in projs)
            {
                
                if (chara.Rectangle.Intersects(proj.Rectangle))
                {
                    if (proj.Sender == chara)
                    {
                        return null;
                    }
                    Projectile i = proj;
                    proj.Despawn();
                    return i;
                }
                
            }
            return null;
        }

        //Method used to check collision (Objects)
        public bool CheckCollisionObjects(Objects objct)
        {
            foreach(Objects obj in objs)
            {
                if (objct.Rectangle.Intersects(obj.Rectangle)) { return true; }
            }
            return false;
        }

        //Method used to check collision (Items)
        public bool CheckCollisionEnemy(Player play)
        {
            foreach (Enemy enemy in enemies)
            {
                if (play.Rectangle.Intersects(enemy.Rectangle))
                {
                    return true;
                }
            }
            return false;
        }

        //Method used to check collision (Items)
        public Items CheckCollisionItems(Player play)
        {
            foreach (Items item in itemList)
            {
                if (play.Rectangle.Intersects(item.Rectangle))
                {
                    Items i = item;
                    itemList.Remove(item);
                    return i;
                }
            }
            return null;
        }

        public RangedWeap CheckCollisionWeap(Player play)
        {
            foreach (RangedWeap item in weapDrop)
            {
                if (play.Rectangle.Intersects(item.Rectangle))
                {
                    RangedWeap i = item;
                    weapDrop.Remove(item);
                    return i;
                }
            }
            return null;
        }
    }
}