using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using FrameWork.GameF;
namespace FrameWork.Movement
{
    public class HorizentalMove:IMovement
    {
        private int speed;
        private Point boundary;
        private string direction;

        public HorizentalMove(int speed, Point boundary, string direction)
        {
            this.speed = speed;
            this.boundary = boundary;
            this.direction = direction;
        }
        public void move(PictureBox pb, List<GameObject> gameobjects)
        {
           /* if((pb.Right)>=0)
            {
                direction = "left";
            }
            else if(pb.Left+speed<=0)
            {
                direction="right";
            }*/
            /*if(direction=="left")
            {
                pb.Location.X -= speed;
            }
            else
            {
                location.X += speed;
            }*/
        }
        public void scroll(PictureBox pb)
        {

        }
    }
}
