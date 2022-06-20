using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameWork.GameF;
namespace FrameWork.Movement
{
    public class Floor:IMovement
    {
        public void move(GameObject p, List<GameObject> gameobjects, IGame igame) { }
        public void scroll(PictureBox pb)
        {
            pb.Top += 10;
        }
        public bool getDirection() { return false; }
    }
}
