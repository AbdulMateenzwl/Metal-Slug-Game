using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameWork.GameF;
namespace FrameWork
{
    public interface Ifire
    {
        void fire(PictureBox pb,bool direction,IGame igame);
    }
}
