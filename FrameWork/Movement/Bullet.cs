using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace FrameWork.Movement
{
    public class Bullet : IMovement
    {
        bool direcrion;
        int speed;
        Point boundary;
        public static event EventHandler onEnd;
        public Bullet(bool direction, int speed, Point boundary)
        {
            this.direcrion = direction;
            this.speed = speed;
            this.boundary = boundary;
        }
        
        public void move(PictureBox pb, List<GameF.GameObject> list)
        {
            if (direcrion)
            {
                if (pb.Right < boundary.X)
                {
                    pb.Left += speed;
                }
                else
                {
                    onEnd?.Invoke(pb, EventArgs.Empty);
                }
            }
            else
            {
                if (pb.Left > 0)
                {
                    pb.Left -= speed;
                }
                else
                {
                    onEnd?.Invoke(pb, EventArgs.Empty);
                }
            }
        }
        public void scroll(PictureBox pb)
        {
            pb.Top += 10;
        }
        public bool getDirection() { return false; }

    }
}
