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
            g.onPlayerDie += new EventHandler(removePictureBox);
            g.onEnemyDie += new EventHandler(removePictureBox);
            g.onPlayerBullet += new EventHandler(removePictureBox);
            System.Drawing.Point boundary = new System.Drawing.Point(this.Width,this. Height);


            Game.AddGameObject(Resources.ufoGreen,ObjectTypes.player, 200, 0, 50, 50, new Player(boundary,10,10,14),new PlayerFire());
            Game.AddGameObject(Resources.ufoGreen,ObjectTypes.enemy, Height-410, 700, 50, 50, new Enemy(boundary,7,10),new EnemyFire(10));
            Game.AddGameObject(Resources.floor1,ObjectTypes.floor, Height-50, 0, Width, Resources.ufoGreen.Height, new Floor(),new NoFire());
            Game.AddGameObject(Resources.floor1, ObjectTypes.floor, Height - 200, 0, Width - 100, 10, new Floor(), new NoFire());
            Game.AddGameObject(Resources.floor1, ObjectTypes.floor, Height - 350, 100, Width - 100, 10, new Floor(), new NoFire());
            Game.AddGameObject(Resources.stairs, ObjectTypes.stairs, Height - 350, 0, 100, 150, new stairs(), new NoFire());

            CollisionClass c = new CollisionClass(ObjectTypes.player, ObjectTypes.enemy, new PlayerCollision());
            g.addCollision(c);
            CollisionClass b = new CollisionClass(ObjectTypes.enemy, ObjectTypes.playerfire, new BulletCollision());
            g.addCollision(b);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            g.update();
            if(Keyboard.IsKeyPressed(Key.Escape))
            {
                this.Close();
            }
        }
        public void Ongameobjectadded(object sender,EventArgs e)
        {
            this.Controls.Add(sender as PictureBox);
        }
        public void removePictureBox(object sender ,EventArgs e)
        {
            this.Controls.Remove(sender as PictureBox);
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            //g.scroll();
        }
    }
}
