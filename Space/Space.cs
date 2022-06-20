using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameWork.GameF;
using FrameWork.Movement;
using FrameWork.ENUM;
using FrameWork.Fire;
using FrameWork.ProgressB;
using EZInput;
using FrameWork.Collision;
using Space.Properties;
namespace Space
{
    public partial class Space : Form
    {
        Game g;
        System.Drawing.Point boundary;
        int previousFloor;
        public Space()
        {
            InitializeComponent();
        }

        private void Space_Load(object sender, EventArgs e)
        {
            boundary = new System.Drawing.Point(this.Width, this.Height);
            label1.Location = new System.Drawing.Point(0,Height - 100);
            g = new Game(boundary);
            g.onGameObjectAdded += new EventHandler(Ongameobjectadded);
            g.removeObject += new EventHandler(removeGameobject);
            g.AddProgressBar += new EventHandler(ONADDprogress);
            g.RemoveProgressBar += new EventHandler(removeProgressbar);
            g.onPlayerHit += new EventHandler(raise);
            g.onEnemyHit += new EventHandler(raise);
            g.AddLable += new EventHandler(ONADDLable);

            //COllisions
            CollisionClass c = new CollisionClass(ObjectTypes.player, ObjectTypes.enemy, new PlayerCollision());
            g.addCollision(c);
            CollisionClass b = new CollisionClass(ObjectTypes.enemy, ObjectTypes.playerfire, new BulletCollision());
            g.addCollision(b);
            CollisionClass a = new CollisionClass(ObjectTypes.player, ObjectTypes.enemyfire, new EnemyBulletCollision());
            g.addCollision(a);
            //PLAYER
            g.AddGameObject(Resources.ufoGreen, ObjectTypes.player, 200, 0, 50, 50, new Player(boundary, 10, 10, 12), new PlayerFire(boundary), new ProgressBarClass(g,5, Color.YellowGreen,3));
            g.AddGameObject(Resources.floor1, ObjectTypes.Mainfloor, Height - 50, 0, Width, Resources.ufoGreen.Height, new Floor(), new NoFire(), new NoProgressBar());

        }


        //Remove Controls
        private void removeGameobject(object sender, EventArgs e)
        {
            GameObject a = (sender as GameObject);
            removeProgressbar(a.ProgressBar, EventArgs.Empty);
            removePictureBox(a.Pb, EventArgs.Empty);
            this.Controls.Remove(a.Pb);
            g.removeGameObjectfromlist(sender as GameObject);
            g.AddScore(50);
        }
        private void raise(object sender, EventArgs e)
        {
            GameObject obj = (sender as GameObject);
            obj.ProgressBar.reductionF(obj,g);
        }
        private void removeProgressbar(object sender, EventArgs e)
        {
            ProgressBar progressBar = sender as ProgressBar;
            this.Controls.Remove(progressBar);
        }
        private void removePictureBox(object sender, EventArgs e)
        {
            this.Controls.Remove(sender as PictureBox);
        }

        //Add Controls
        private void ONADDprogress(object sender, EventArgs e)
        {
            this.Controls.Add(sender as ProgressBar);
        }
        private void ONADDLable(object sender, EventArgs e)
        {
            this.Controls.Add(sender as Label);
        }
        public void Ongameobjectadded(object sender, EventArgs e)
        {
            this.Controls.Add(sender as PictureBox);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            updateScore();
            UpdateHurdles();
            g.update();
            if (Keyboard.IsKeyPressed(Key.Escape))
            {
                this.Close();
            }
        }
        private void updateScore()
        {
            label1.Text = "Score :" + g.Get_Score().ToString();
        }
        private void updateLifes()
        {
            //label2.Text = "Lifes :" + g.().ToString();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            g.scroll();
            g.increaseScoreTime();
            //g.RemoveUnwanted();
        }

        //Random Movement
        private void floor1(int top)
        {
            g.AddGameObject(Resources.floor1, ObjectTypes.floor, top, 100, Width - 100, 10, new Floor(), new NoFire(), new NoProgressBar());
            g.AddGameObject(Resources.stairs, ObjectTypes.stairs, top, 0, 100, 150, new stairs(), new NoFire(), new NoProgressBar());
        }
        private void floor2(int top)
        {
            g.AddGameObject(Resources.floor1, ObjectTypes.floor, top, 0, Width - 100, 10, new Floor(), new NoFire(), new NoProgressBar());
            g.AddGameObject(Resources.stairs, ObjectTypes.stairs, top, Width - 100, 100, 150, new stairs(), new NoFire(), new NoProgressBar());
        }
        private void floor3(int top)
        {
            g.AddGameObject(Resources.floor1, ObjectTypes.floor, top, 0, Width - 600, 10, new Floor(), new NoFire(), new NoProgressBar());
            g.AddGameObject(Resources.stairs, ObjectTypes.stairs, top, Width - 600, 100, 150, new stairs(), new NoFire(), new NoProgressBar());
            g.AddGameObject(Resources.floor1, ObjectTypes.floor, top, Width - 500, 500, 10, new Floor(), new NoFire(), new NoProgressBar());
            generate_enemy(top - 10, 0);
        }
        private void floor4(int top)
        {
            g.AddGameObject(Resources.floor1, ObjectTypes.floor, top, 0, Width - 1000, 10, new Floor(), new NoFire(), new NoProgressBar());
            g.AddGameObject(Resources.stairs, ObjectTypes.stairs, top, Width - 1000, 100, 150, new stairs(), new NoFire(), new NoProgressBar());
            g.AddGameObject(Resources.floor1, ObjectTypes.floor, top, Width - 900, 900, 10, new Floor(), new NoFire(), new NoProgressBar());
            generate_enemy(top - 10, 0);
        }
        public void UpdateHurdles()
        {
            if (g.get_lowest_floor() >= 150)
            {
                generate_Random_Floors();
            }
        }
        public void generate_Random_Floors()
        {
            Random random1 = new Random();
            int rand = random1.Next(0, 4);
            if (previousFloor == rand)
            {
                if(rand>3)
                {
                    rand--;
                }
                else
                {
                    rand++;
                }
            }
            previousFloor=rand;
            if (rand == 0)
            {
                floor1(0);
            }
            else if (rand == 1)
            {
                floor2(0);
            }
            else if (rand == 2)
            {
                floor3(0);
            }
            else if (rand == 3)
            {
                floor4(0);
            }
            else
            {
                floor3(0);
            }
        }
        public void generate_enemy(int top,int left)
        {
            int Count = Random(0,3);
            for (int i = 0; i < Count; i++)
            {
                int colorx = Random(1, 5);
                g.AddGameObject(Resources.ufoGreen, ObjectTypes.enemy, top, left, 50, 50, new Enemy(boundary, Random(5,12), 10, Random(70,120)), new EnemyFire(Random(0,30), boundary), new ProgressBarClass(g,colorx, colorEnemyBar(colorx),0));
            }
        }
        public Color colorEnemyBar(int x)
        {
            if(x==1)
            {
                return Color.FromArgb(110, 2, 7);
            }
            else if (x == 2)
            {
                return Color.FromArgb(255, 82, 90);
            }
            else if (x == 3)
            {
                return Color.FromArgb(217, 171, 4);
            }
            else if (x == 4)
            {
                return Color.FromArgb(115, 8, 255);
            }
            else
            {
                return Color.FromArgb(220, 120, 222);
            }
        }
        public int Random(int limit1,int limit2)
        {
            Random random = new Random();
             return random.Next(limit1, limit2);
        }
    }
}
