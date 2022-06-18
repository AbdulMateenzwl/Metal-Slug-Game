using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FrameWork.Movement
{
    public class Bullet : IMovement
    {
        bool direcrion;
        int speed;
        public Bullet(bool direction, int speed)
        {
            this.direcrion = direction;
            this.speed = speed;
        }

        public void move(PictureBox pb, List<GameF.GameObject> list)
        {
            if(direcrion)
            {
                pb.Left += speed;
            }
            else
            {
                pb.Left -= speed;
            }
        }
        public void scroll(PictureBox pb)
        {
            pb.Top += 10;
        }
    }
}
