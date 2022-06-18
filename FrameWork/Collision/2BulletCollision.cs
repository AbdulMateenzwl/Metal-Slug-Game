using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameWork.GameF;
using FrameWork.ENUM;
namespace FrameWork.Collision
{
    public class BulletCollision:ICollisionAction
    {

        
        public void performAction(IGame game, GameObject source1, GameObject source2)
        {
            /*GameObject enemy;
            GameObject bullet;
            if (source1.Otype == ObjectTypes.player)
            {
                enemy = source1;
                bullet = source2;
            }
            else
            {
                enemy = source2;
                bullet = source1;
            }
            game.RaisePlayerDieEvent(enemy.Pb);
            game.RaisePlayerBullet(bullet.Pb);*/
        }

    }
}
