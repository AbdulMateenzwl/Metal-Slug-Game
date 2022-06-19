using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameWork.GameF;
namespace FrameWork.Movement
{
    public class Enemy : IMovement
    {
        private System.Drawing.Point boundary;
        bool direction = true;
        public EventHandler onAdd;
        public EventHandler onDelete;
        int r_count = 0;
        int l_count = 0;
        int walking_speed;
        int G;
        int direction_count = 0;
        public Enemy(System.Drawing.Point boundary, int walking_speed, int g,int randomDirection)
        {
            this.boundary = boundary;
            this.walking_speed = walking_speed;
            G = g;
            direction_count = randomDirection;
        }
        public bool getDirection() { return direction; }
        public void scroll(PictureBox pb) { }
        public void gravity(PictureBox pb, List<GameObject> gameobjects)
        {
            if (!check_under(pb, gameobjects))
            {
                pb.Top += G;
            }
        }
        public bool check_under(PictureBox pb, List<GameObject> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Pb.Bounds.IntersectsWith(pb.Bounds) &&(list[i].Otype == ENUM.ObjectTypes.floor))
                {
                    return true;
                }
            }
            return false;
        }
        public bool location(PictureBox obj, PictureBox surface)
        {
            if (!bound_right(obj, surface) && !bound_left(obj, surface) && obj.Bottom >= surface.Top)
            {
                return true;
            }
            return false;
        }
        public bool bound_left(PictureBox obj, PictureBox surface)
        {
            if (obj.Left > surface.Right)
            {
                return true;
            }
            return false;
        }
        public bool bound_right(PictureBox obj, PictureBox surface)
        {
            if (obj.Right < surface.Left)
            {
                return true;
            }
            return false;
        }
        public void move(PictureBox pb, List<GameObject> gameobjects)
        {
            gravity(pb, gameobjects);
            for (int i = 0; i < gameobjects.Count; i++)
            {
                if (gameobjects[i].Pb.Bounds.IntersectsWith(pb.Bounds) && gameobjects[i].Otype==ENUM.ObjectTypes.floor)
                {
                    RandomDirection();
                    if (pb.Left-walking_speed < gameobjects[i].Pb.Left)
                    {
                        direction = true;
                    }
                    else if (pb.Right + walking_speed > gameobjects[i].Pb.Right)
                    {
                        direction = false;
                    }
                    if (direction)
                    {
                        pb.Left += walking_speed;
                        r_count++;
                        if (r_count == 7)
                        {
                            r_count = 1;
                        }
                        updatepic_right(pb);
                    }
                    else
                    {
                        pb.Left -= walking_speed;
                        l_count++;
                        if (l_count == 7)
                        {
                            l_count = 1;
                        }
                        updatepic_left(pb);
                    }
                }
            }
        }
        public void updatepic_right(PictureBox pb)
        {
            if (r_count == 1)
            {
                pb.Image = FrameWork.Properties.Resource1._1e;
            }
            else if (r_count == 2)
            {
                pb.Image = FrameWork.Properties.Resource1._2e;
            }
            else if (r_count == 3)
            {
                pb.Image = FrameWork.Properties.Resource1._3e;
            }
            else if (r_count == 4)
            {
                pb.Image = FrameWork.Properties.Resource1._4e;
            }
            else if (r_count == 5)
            {
                pb.Image = FrameWork.Properties.Resource1._5e;
            }
            else if (r_count == 6)
            {
                pb.Image = FrameWork.Properties.Resource1._6e;
            }
        }
        public void updatepic_left(PictureBox pb)
        {
            if (l_count == 1)
            {
                pb.Image = FrameWork.Properties.Resource1._1le;
            }
            else if (l_count == 2)
            {
                pb.Image = FrameWork.Properties.Resource1._2le;
            }
            else if (l_count == 3)
            {
                pb.Image = FrameWork.Properties.Resource1._3le;
            }
            else if (l_count == 4)
            {
                pb.Image = FrameWork.Properties.Resource1._4le;
            }
            else if (l_count == 5)
            {
                pb.Image = FrameWork.Properties.Resource1._5le;
            }
            else if (l_count == 6)
            {
                pb.Image = FrameWork.Properties.Resource1._6le;
            }
        }
        public void RandomDirection()
        {
            direction_count++;
            if(direction_count>50)
            {
                direction_count = 0;
                Random random = new Random();
                if (random.Next(0, 100) > 50)
                {
                    direction = true;
                }
                else
                {
                    direction = false;
                }
            }
        }
    }
}
