using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.GameF;
using FrameWork.ENUM;
namespace FrameWork.Collision
{
    public class EnemyBulletCollision:ICollisionAction
    {
        public void performAction(IGame game, GameObject source1, GameObject source2)
        {
            GameObject chr;
            GameObject bullet;
            if (source1.Otype == ObjectTypes.player)
            {
                chr = source1;
                bullet = source2;
            }
            else
            {
                chr = source2;
                bullet = source1;
            }
            game.RaisePlayerBulletRemove(bullet);
            game.RaisePlayerHitEvent(chr);
            game.AddScore(10);
        }
    }
}
