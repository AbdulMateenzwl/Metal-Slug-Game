using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using FrameWork.GameF;

namespace FrameWork.Movement
{
    public interface IMovement
    {
        void move(GameObject obj, List<GameObject> gameobjects,IGame igame);
        void scroll(PictureBox p);
        bool getDirection();
    }
}
