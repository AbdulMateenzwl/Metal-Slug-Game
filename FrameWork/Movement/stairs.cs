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
        public void move(PictureBox pb, List<GameObject> gameobjects) { }
        public void scroll(PictureBox pb)
        {
            pb.Top += 10;
        }
        public bool getDirection() { return false; }
    }
}
