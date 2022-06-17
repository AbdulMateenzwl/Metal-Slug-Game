using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.ENUM;
using FrameWork.Collision;
namespace FrameWork.Collision
{
    public class CollisionClass
    {
        private ObjectTypes g1;
        private ObjectTypes g2;
        private ICollisionAction behavior;

        public CollisionClass(ObjectTypes g1, ObjectTypes g2, ICollisionAction behavior)
        {
            this.G1 = g1;
            this.G2 = g2;
            this.behavior = behavior;
        }

        public ObjectTypes G1 { get => g1; set => g1 = value; }
        public ObjectTypes G2 { get => g2; set => g2 = value; }
        public ICollisionAction Behavior { get => behavior; set => behavior = value; }
    }
}
