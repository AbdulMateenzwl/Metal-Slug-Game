using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.GameF;
using FrameWork.ENUM;

namespace FrameWork.Collision
{
    public class PlayerBulletCollision:ICollisionAction
    {
        public void performAction(IGame game, GameObject source1, GameObject source2)
        {
            GameObject enemy;
            GameObject bullet;
            if (source1.Otype == ObjectTypes.enemy)
            {
                enemy = source1;
                bullet = source2;
            }
            else
            {
                enemy = source2;
                bullet = source1;
            }
           // game.RaiseEnemyDieEvent(enemy.Pb);
            game.Raise(bullet.Pb);
        }

    }
}
