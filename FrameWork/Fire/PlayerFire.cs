using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.GameF;
using FrameWork.Movement;
using FrameWork.ProgressB;
using FrameWork.ENUM;
using System.Windows.Forms;
using EZInput;
namespace FrameWork.Fire
{
    public class PlayerFire : Ifire
    {
        private int fire_count = 0;
        private bool fire_ = false;
        System.Drawing.Point boundary;
        public PlayerFire(System.Drawing.Point point)
        {
            boundary = point;
        }
        public void fire(PictureBox pb, bool direction,IGame igame)
        {
            
            fire_ = false;
            if (Keyboard.IsKeyPressed(Key.W))
            {
                fire_ = true;
                if (fire_count == 0)
                {
                    if (direction)
                    {
                        GameObject a = new GameObject(Properties.Resource1.playerfireright1, ObjectTypes.playerfire, pb.Top + (pb.Height / 2) - 12, pb.Right, 15, 15, new Bullet(true, 20, boundary), new NoFire(), new NoProgressBar());
                        igame.AddGameObject(a);
                    }
                    else
                    {
                        GameObject a= new GameObject(FrameWork.Properties.Resource1.playerfireleft, ENUM.ObjectTypes.playerfire, pb.Top + (pb.Height / 2) - 12, pb.Left - 10, 15, 15, new Bullet(false, 20, boundary), new NoFire(),new NoProgressBar());
                        igame.AddGameObject(a);
                    }
                }
            }
            fire_count++;
            if (!fire_)
            {
                fire_count = 0;
            }
            if (fire_count >= 5)
            {
                fire_ = false;
                fire_count = 0;
            }
        }
    }
}
