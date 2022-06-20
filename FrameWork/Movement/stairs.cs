using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameWork.GameF;
namespace FrameWork.Movement
{
    public class stairs:IMovement
    {
        public void move(GameObject obj, List<GameObject> gameobjects, IGame igame) { }
        public void scroll(PictureBox pb)
        {
            pb.Top += 10;
        }
        public bool getDirection() { return false; }
    }
}
