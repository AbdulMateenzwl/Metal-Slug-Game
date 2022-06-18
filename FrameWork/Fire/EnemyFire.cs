using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameWork.GameF;
using FrameWork.Movement;
namespace FrameWork.Fire
{
    public class EnemyFire:Ifire
    {
        Random random = new Random();
        int x;
        public EnemyFire(int randomness)
        {
            this.x = randomness;
        }
        public void fire(PictureBox pb, bool direction)
        {
            if(getRandom() == 1)
            {
                if (direction)
                {
                    Game.AddGameObject(FrameWork.Properties.Resource1.fireright, ENUM.ObjectTypes.enemyfire, pb.Top + (pb.Height / 2) - 12, pb.Right, 10, 10, new Bullet(true, 20), new NoFire());
                }
                else
                {
                    Game.AddGameObject(FrameWork.Properties.Resource1.fireleft, ENUM.ObjectTypes.enemyfire, pb.Top + (pb.Height / 2) - 12, pb.Left - 10, 10, 10, new Bullet(false, 20), new NoFire());
                }
            }
        }
        public int getRandom()
        {
            return random.Next(0, x);
        }
    }
}
