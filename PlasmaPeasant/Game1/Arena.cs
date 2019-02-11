using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.IO;
/*
* Arena Level
* (Wave Defence)
* Creates different rooms based on files
* Programmed by David and Fred
*/

namespace PlasmaPeasant
{
    //Arena Class
    class Arena:Level
    {
        // attributes
        private Random rgen;
        // background texture
        Texture2D background;

        // WALLS
        // vertical walls
        public Objects wall1;
        public Objects wall2;
        public Objects wall3;
        public Objects wall4;
        public Objects wall5;
        public Objects wall6;
        public Objects wall7;
        public Objects wall8;
        public Objects wall9;
        public Objects wall10;
        public Objects wall11;

        public Objects wall21;
        public Objects wall22;
        public Objects wall23;
        public Objects wall24;
        public Objects wall25;
        public Objects wall26;
        public Objects wall27;
        public Objects wall28;
        public Objects wall29;
        public Objects wall30;
        public Objects wall31;

        // horizontal walls
        public Objects wall100;
        public Objects wall101;
        public Objects wall102;
        public Objects wall103;
        public Objects wall104;
        public Objects wall105;
        public Objects wall106;
        public Objects wall107;
        public Objects wall108;
        public Objects wall109;
        public Objects wall110;
        public Objects wall111;
        public Objects wall112;
        public Objects wall113;

        public Objects wall200;
        public Objects wall201;
        public Objects wall202;
        public Objects wall203;
        public Objects wall204;
        public Objects wall205;
        public Objects wall206;
        public Objects wall207;
        public Objects wall208;
        public Objects wall209;
        public Objects wall210;
        public Objects wall211;
        public Objects wall212;
        public Objects wall213;

        //More variables used
        StreamReader strm;
        string current;
        string[] currentDelimited;
        private int levelNum;
        bool needsLoaded = true;
        private int nextX = 450;
        private int nextY = 350;

        //Properties
        public int LevelNum
        {
            get { return levelNum; }
            set { levelNum = value; }
        }
        public bool NeedsLoaded
        {
            get { return needsLoaded; }
            set { needsLoaded = value; }
        }
        public int NextX
        {
            get { return nextX; }
            set { nextX = value; }
        }
        public int NextY
        {
            get { return nextY; }
            set { nextY = value; }
        }

        //Constructor used
        public Arena() : base()
        {
            //starts the game at the first level
            levelNum = 1;
            current = "";
            rgen = new Random();
        }
        //Creates all of the walls
        public void CreateWalls()
        {
            // vertical walls
            wall1 = new Objects(this, new Rectangle(0, 0, 64, 64), "TopLeft");
            wall2 = new Objects(this, new Rectangle(0, 64, 64, 64), "Vertical");
            wall3 = new Objects(this, new Rectangle(0, 128, 64, 64), "Vertical");
            wall4 = new Objects(this, new Rectangle(0, 192, 64, 64), "Vertical");
            wall5 = new Objects(this, new Rectangle(0, 256, 64, 64), "Vertical");
            wall6 = new Objects(this, new Rectangle(0, 320, 64, 64), "Vertical");
            wall7 = new Objects(this, new Rectangle(0, 384, 64, 64), "Vertical");
            wall8 = new Objects(this, new Rectangle(0, 448, 64, 64), "Vertical");
            wall9 = new Objects(this, new Rectangle(0, 512, 64, 64), "Vertical");
            wall10 = new Objects(this, new Rectangle(0, 576, 64, 64), "Vertical");
            wall11 = new Objects(this, new Rectangle(0, 640, 64, 64), "BottomLeft");
            wall21 = new Objects(this, new Rectangle(960, 0, 64, 64), "TopRight");
            wall22 = new Objects(this, new Rectangle(960, 64, 64, 64), "Vertical");
            wall23 = new Objects(this, new Rectangle(960, 128, 64, 64), "Vertical");
            wall24 = new Objects(this, new Rectangle(960, 192, 64, 64), "Vertical");
            wall25 = new Objects(this, new Rectangle(960, 256, 64, 64), "Vertical");
            wall26 = new Objects(this, new Rectangle(960, 320, 64, 64), "Vertical");
            wall27 = new Objects(this, new Rectangle(960, 384, 64, 64), "Vertical");
            wall28 = new Objects(this, new Rectangle(960, 448, 64, 64), "Vertical");
            wall29 = new Objects(this, new Rectangle(960, 512, 64, 64), "Vertical");
            wall30 = new Objects(this, new Rectangle(960, 576, 64, 64), "Vertical");
            wall31 = new Objects(this, new Rectangle(960, 640, 64, 64), "BottomRight");
            objs.Add(wall1);
            objs.Add(wall2);
            objs.Add(wall3);
            objs.Add(wall4);
            objs.Add(wall5);
            objs.Add(wall6);
            objs.Add(wall7);
            objs.Add(wall8);
            objs.Add(wall9);
            objs.Add(wall10);
            objs.Add(wall11);
            objs.Add(wall21);
            objs.Add(wall22);
            objs.Add(wall23);
            objs.Add(wall24);
            objs.Add(wall25);
            objs.Add(wall26);
            objs.Add(wall27);
            objs.Add(wall28);
            objs.Add(wall29);
            objs.Add(wall30);
            objs.Add(wall31);

            // horizontal walls
            wall100 = new Objects(this, new Rectangle(64, 0, 64, 64), "grate");
            wall101 = new Objects(this, new Rectangle(128, 0, 64, 64), "grate");
            wall102 = new Objects(this, new Rectangle(192, 0, 64, 64), "grate");
            wall103 = new Objects(this, new Rectangle(256, 0, 64, 64), "grate");
            wall104 = new Objects(this, new Rectangle(320, 0, 64, 64), "grate");
            wall105 = new Objects(this, new Rectangle(384, 0, 64, 64), "grate");
            wall106 = new Objects(this, new Rectangle(448, 0, 64, 64), "grate");
            wall107 = new Objects(this, new Rectangle(512, 0, 64, 64), "grate");
            wall108 = new Objects(this, new Rectangle(576, 0, 64, 64), "grate");
            wall109 = new Objects(this, new Rectangle(640, 0, 64, 64), "grate");
            wall110 = new Objects(this, new Rectangle(704, 0, 64, 64), "grate");
            wall111 = new Objects(this, new Rectangle(768, 0, 64, 64), "grate");
            wall112 = new Objects(this, new Rectangle(832, 0, 74, 64), "grate");
            wall113 = new Objects(this, new Rectangle(898, 0, 64, 64), "grate");
            wall200 = new Objects(this, new Rectangle(64, 640, 64, 64), "grate");
            wall201 = new Objects(this, new Rectangle(128, 640, 64, 64), "grate");
            wall202 = new Objects(this, new Rectangle(192, 640, 64, 64), "grate");
            wall203 = new Objects(this, new Rectangle(256, 640, 64, 64), "grate");
            wall204 = new Objects(this, new Rectangle(320, 640, 64, 64), "grate");
            wall205 = new Objects(this, new Rectangle(384, 640, 64, 64), "grate");
            wall206 = new Objects(this, new Rectangle(448, 640, 64, 64), "grate");
            wall207 = new Objects(this, new Rectangle(512, 640, 64, 64), "grate");
            wall208 = new Objects(this, new Rectangle(576, 640, 64, 64), "grate");
            wall209 = new Objects(this, new Rectangle(640, 640, 64, 64), "grate");
            wall210 = new Objects(this, new Rectangle(704, 640, 64, 64), "grate");
            wall211 = new Objects(this, new Rectangle(768, 640, 64, 64), "grate");
            wall212 = new Objects(this, new Rectangle(832, 640, 74, 64), "grate");
            wall213 = new Objects(this, new Rectangle(898, 640, 64, 64), "grate");
            objs.Add(wall100);
            objs.Add(wall101);
            objs.Add(wall102);
            objs.Add(wall103);
            objs.Add(wall104);
            objs.Add(wall105);
            objs.Add(wall106);
            objs.Add(wall107);
            objs.Add(wall108);
            objs.Add(wall109);
            objs.Add(wall110);
            objs.Add(wall111);
            objs.Add(wall112);
            objs.Add(wall113);
            objs.Add(wall200);
            objs.Add(wall201);
            objs.Add(wall202);
            objs.Add(wall203);
            objs.Add(wall204);
            objs.Add(wall205);
            objs.Add(wall206);
            objs.Add(wall207);
            objs.Add(wall208);
            objs.Add(wall209);
            objs.Add(wall210);
            objs.Add(wall211);
            objs.Add(wall212);
            objs.Add(wall213);
        }

        //Starts the creation of a level (the player + the arena)
        public override void CreateLevel()
        {
            //Creates the player
            player = new Player(this, 450, 350, 64, 64, 100, 5);

            //Sets the position
            nextX = 450;
            nextY = 450;

            //Creates the walls
            CreateWalls();
            // base.CreateLevel();
        }

        //Resets the Arena to the first level
        public override void Reset()
        {
            objs.Clear();
            weapDrop.Clear();
            enemies.Clear();
            projs.Clear();
            itemList.Clear();
            doors.Clear();
            CreateLevel();
            levelNum = 1;
            needsLoaded = true;
            player = new Player(this, 450, 350, 64, 64, 100, 5);
            NeedsReset = false;
        }

        //Update
        public override void Update()
        {
            //Checks if a level is needed to be loaded
            if (needsLoaded && levelNum <= 12)
            {
                //Updates everything
                player.X = nextX;
                player.Y = nextY;
                doors.Clear();
                itemList.Clear();
                weapDrop.Clear();
                projs.Clear();
                objs.Clear();
                CreateWalls();

                //Loads level
                LoadFile(levelNum);

                needsLoaded = false;
            }
            //If the levelNum over 12
            else if(levelNum > 12)
            {
                //Go back to the main screen
                Game1.currentScreen = Game1.GameStates.MainScreen;
            }

            //If every enemy is dead
            if(enemies.Count == 0)
            {
                //Check all doors and open them
                foreach(Door d in doors)
                {
                    d.Open = true;
                }
                
                //If the dungeon is over
                if(levelNum == 12)
                {
                    levelNum++;
                }
            }
            // if player dies, reset
            if (player.Health <= 0)
            {
                Reset();
                base.Reset();
            }
            base.Update();
        }

        //Loads background texture
        public override void Load(ContentManager content)
        {
            background = content.Load<Texture2D>("level1");
            base.Load(content);
        }

        //Draws background
        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(background, new Rectangle(0, 0, 1024, 768), Color.White);
            base.Draw(spriteBatch);
        }

        //method for loading custom files in
        public void LoadFile(int num)
        {
            //File stuff
            strm = new StreamReader("level" + num + ".txt");
            current = strm.ReadLine();

            //Temp objects used
            Items tempItem;
            Objects tempStructure;

            //Main loop through file
            while (current != null)
            {
                //info from each line
                currentDelimited = current.Split(',');

                //Switch based on object name
                switch (currentDelimited[0])
                {
                    case "Enemy1":
                        enemy1 = new Enemy(this, int.Parse(currentDelimited[1]), int.Parse(currentDelimited[2]), int.Parse(currentDelimited[3]), int.Parse(currentDelimited[4]), int.Parse(currentDelimited[5]), int.Parse(currentDelimited[6]), 1 + (levelNum * 2));
                        enemy1.textureFileName = "enemy1Sheet";
                        enemies.Add(enemy1);
                        break;
                    case "Enemy2":
                        enemy2 = new Enemy(this, int.Parse(currentDelimited[1]), int.Parse(currentDelimited[2]), int.Parse(currentDelimited[3]), int.Parse(currentDelimited[4]), int.Parse(currentDelimited[5]), int.Parse(currentDelimited[6]), 1 + (levelNum * 2));
                        enemy2.textureFileName = "Enemy2AnimFull";
                        enemies.Add(enemy2);
                        break;
                    case "Enemy3":
                        enemy3 = new Enemy(this, int.Parse(currentDelimited[1]), int.Parse(currentDelimited[2]), int.Parse(currentDelimited[3]), int.Parse(currentDelimited[4]), int.Parse(currentDelimited[5]), int.Parse(currentDelimited[6]), 1 + (levelNum * 2));
                        enemy3.textureFileName = "Enemy3AnimFull";
                        enemies.Add(enemy3);
                        break;
                    case "structure":
                        tempStructure = new Objects(this, new Rectangle(int.Parse(currentDelimited[1]), int.Parse(currentDelimited[2]), int.Parse(currentDelimited[3]), int.Parse(currentDelimited[4])), "structureTex");
                        tempStructure.textureFileName = "structureTex";
                        objs.Add(tempStructure);
                        break;
                    case "Potion":
                        tempItem = new Items(this, int.Parse(currentDelimited[2]), int.Parse(currentDelimited[3]), int.Parse(currentDelimited[1]), 0, 0, "Potion");
                        tempItem.textureFileName = "Potion";
                        itemList.Add(tempItem);
                        break;
                    case "SpeedBoost":
                        tempItem = new Items(this, int.Parse(currentDelimited[2]), int.Parse(currentDelimited[3]), 0, int.Parse(currentDelimited[1]), 0, "SpeedBoost");
                        tempItem.textureFileName = "SpeedBoost";
                        itemList.Add(tempItem);
                        break;
                    case "DamageBuff":
                        tempItem = new Items(this, int.Parse(currentDelimited[2]), int.Parse(currentDelimited[3]), 0, 0, int.Parse(currentDelimited[1]), "DamageBuff");
                        tempItem.textureFileName = "DamageBuff";
                        itemList.Add(tempItem);
                        break;
                    case "Weapon":
                        player.Weapon = new RangedWeap(player, this, player.X, player.Y, int.Parse(currentDelimited[1]), int.Parse(currentDelimited[2]), int.Parse(currentDelimited[3]));
                        break;
                    case "door":
                        doors.Add(new Door(this,new Rectangle(int.Parse(currentDelimited[1]), int.Parse(currentDelimited[2]), int.Parse(currentDelimited[3]), int.Parse(currentDelimited[4])), int.Parse(currentDelimited[5]), int.Parse(currentDelimited[6]), int.Parse(currentDelimited[7])));
                        break;
                    case "Boss":
                        enemy2 = new Enemy(this, int.Parse(currentDelimited[1]), int.Parse(currentDelimited[2]), int.Parse(currentDelimited[3]), int.Parse(currentDelimited[4]), int.Parse(currentDelimited[5]) + 100, int.Parse(currentDelimited[6]), 1 + (levelNum * 2));
                        enemy2.textureFileName = "Enemy2AnimFull";
                        enemies.Add(enemy2);
                        break;
                    default:
                        break;
                }

                current = strm.ReadLine();
            }
            strm.Close();
        }
    }
}
