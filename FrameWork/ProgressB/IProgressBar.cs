using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameWork.GameF;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrameWork.ProgressB
{
    public interface IProgressBar
    {
        void updateProgressBar(PictureBox pictureBox);
        void reductionF(GameObject obj,IGame igame);
        void DeleteProgressBar(GameObject a);

    }
}
