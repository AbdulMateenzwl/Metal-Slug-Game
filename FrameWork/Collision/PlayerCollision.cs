using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Collision;
using FrameWork.GameF;
using FrameWork.ENUM;
namespace FrameWork.Collision
{
    public class PlayerCollision:ICollisionAction
    {
        public void performAction(IGame game,GameObject source1,GameObject source2)
        {
            GameObject player;
            if (source1.Otype==ObjectTypes.player)
            {
                player = source1;
            }
            else
            {
                player = source2;
            }
            game.RaisePlayerDieEvent(player.Pb);
        }
    }
}
