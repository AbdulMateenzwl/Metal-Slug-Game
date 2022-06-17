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
            g.onGameObjectAdded += new EventHandler(Ongameobjectadded);
            g.onPlayerDie += new EventHandler(removePlayer);
            System.Drawing.Point boundary = new System.Drawing.Point(this.Width,this. Height);


            g.AddGameObject(Resources.ufoGreen,ObjectTypes.player, 200, 0, Resources.ufoGreen.Width, Resources.ufoGreen.Height, new Player(boundary,10,10,20));
            g.AddGameObject(Resources.ufoGreen,ObjectTypes.floor, Height-100, 0, Width, Resources.ufoGreen.Height, new Floor());
            g.AddGameObject(Resources.ufoGreen,ObjectTypes.floor, Height-250, 0, 300, 30, new Floor());
            g.AddGameObject(Resources.ufoGreen,ObjectTypes.floor, Height-150, 0, 700, 30, new Floor());
            g.AddGameObject(Resources.ufoGreen,ObjectTypes.floor, Height - 150, Width-300, 300, 30, new Floor());
            g.AddGameObject(Resources.ufoGreen,ObjectTypes.floor, Height - 250, Width-600, 300, 30, new Floor());
            g.AddGameObject(Resources.ufoGreen,ObjectTypes.floor, Height - 350, Width-300, 300, 30, new Floor());

            //CollisionClass c = new CollisionClass(ObjectTypes.player, ObjectTypes.floor, new PlayerCollision());
            //g.addCollision(c);
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
        public void removePlayer(object sender ,EventArgs e)
        {
            this.Controls.Remove(sender as PictureBox);
        }
    }
}
