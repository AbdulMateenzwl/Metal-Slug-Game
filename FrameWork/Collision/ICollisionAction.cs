using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.GameF;
namespace FrameWork.Collision
{
    public interface ICollisionAction
    {
        void performAction(IGame igame, GameObject source1, GameObject source2);
    }
}
