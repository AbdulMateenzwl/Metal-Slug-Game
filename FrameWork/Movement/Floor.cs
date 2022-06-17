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
        public void move(PictureBox p, List<GameObject> gameobjects) { }
        public void scroll(PictureBox pb)
        {
            pb.Top += 10;
        }
    }
}
