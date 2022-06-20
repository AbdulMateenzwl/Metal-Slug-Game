using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using FrameWork.GameF;
namespace FrameWork.Movement
{
    public class Bullet : IMovement
    {
        private bool direcrion;
        private int speed;
        private Point boundary;
        public Bullet(bool direction, int speed, Point boundary)
        {
            this.direcrion = direction;
            this.speed = speed;
            this.boundary = boundary;
        }
        public void move(GameF.GameObject obj, List<GameF.GameObject> list, IGame igame)
        {
            if (direcrion)
            {
                if (obj.Pb.Left < boundary.X)
                {
                    obj.Pb.Left += speed;
                }
                else
                {
                    igame.RemoveGameObject(obj);
                }
            }
            else
            {
                if (obj.Pb.Right> 0)
                {
                    obj.Pb.Left -= speed;
                }
                else
                {
                    igame.RemoveGameObject(obj);
                }
            }
        }
        public void scroll(PictureBox pb)
        {
            pb.Top += 10;
        }
        public bool getDirection() { return direcrion; }
    }
}
