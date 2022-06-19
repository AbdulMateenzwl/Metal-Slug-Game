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
        public Space()
        {
            InitializeComponent();
        }

        private void Space_Load(object sender, EventArgs e)
        {
            g = new Game();
            Game.onGameObjectAdded += new EventHandler(Ongameobjectadded);
            ProgressBarClass.onGamobjectRemove += new EventHandler(removeGamobject);
            ProgressBarClass.onAdd += new EventHandler(ONADDprogress);
            Player.onAdd += new EventHandler(ONADDprogress);
            g.onPlayerBullet += new EventHandler(removeGamobject);
            Bullet.onEnd += new EventHandler(removePictureBox);
            g.onEnd += new EventHandler(removeGamobject);
            System.Drawing.Point boundary = new System.Drawing.Point(this.Width,this. Height);


            Game.AddGameObject(Resources.ufoGreen,ObjectTypes.player, 200, 0, 50, 50, new Player(boundary,10,10,14),new PlayerFire(boundary),new ProgressBarClass(1,Color.YellowGreen));
            Game.AddGameObject(Resources.ufoGreen,ObjectTypes.enemy, Height-410, 300, 50, 50, new Enemy(boundary,7,10,100),new EnemyFire(20,boundary),new ProgressBarClass(1,Color.Red));
            Game.AddGameObject(Resources.ufoGreen,ObjectTypes.enemy, Height-410, 700, 50, 50, new Enemy(boundary,7,10,100),new EnemyFire(20,boundary),new ProgressBarClass(1,Color.Red));
            Game.AddGameObject(Resources.floor1,ObjectTypes.floor, Height-50, 0, Width, Resources.ufoGreen.Height, new Floor(),new NoFire(),new NoProgressBar());
            /*Game.AddGameObject(Resources.floor1, ObjectTypes.floor, Height - 200, 0, Width - 100, 10, new Floor(), new NoFire());
            Game.AddGameObject(Resources.floor1, ObjectTypes.floor, Height - 350, 100, Width - 100, 10, new Floor(), new NoFire());
            Game.AddGameObject(Resources.stairs, ObjectTypes.stairs, Height - 350, 0, 100, 150, new stairs(), new NoFire());*/

            CollisionClass c = new CollisionClass(ObjectTypes.player, ObjectTypes.enemy, new PlayerCollision());
            g.addCollision(c);
            CollisionClass b = new CollisionClass(ObjectTypes.enemy, ObjectTypes.playerfire, new BulletCollision());
            g.addCollision(b);
            CollisionClass a = new CollisionClass(ObjectTypes.player, ObjectTypes.enemyfire, new EnemyBulletCollision());
            g.addCollision(a);
        }

        private void removeGamobject(object sender, EventArgs e)
        {
            GameObject a = (sender as GameObject);
            removeProgressbar(a.ProgressBar,EventArgs.Empty);
            removePictureBox(a.Pb,EventArgs.Empty);
            Game.removeGameobject(a);
        }
        private void removeProgressbar(object sender, EventArgs e)
        {
            ProgressBar progressBar = sender as ProgressBar;
            this.Controls.Remove(progressBar);
        }

        private void ONADDprogress(object sender, EventArgs e)
        {
            this.Controls.Add(sender as ProgressBar);
        }

        public void Ongameobjectadded(object sender,EventArgs e)
        {   
            this.Controls.Add(sender as PictureBox);
        }
        public void removePictureBox(object sender ,EventArgs e)
        {
            this.Controls.Remove(sender as PictureBox);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            g.update();
            if(Keyboard.IsKeyPressed(Key.Escape))
            {
                this.Close();
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            //g.scroll();
        }
    }
}
