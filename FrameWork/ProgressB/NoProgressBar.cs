using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.GameF;
using System.Windows.Forms;
namespace FrameWork.ProgressB
{
    public class NoProgressBar:IProgressBar
    {
        public void updateProgressBar(PictureBox pictureBox) { }
        public void reductionF(GameObject obj) { }
        public void DeleteProgressBar(GameObject a) { }

    }
}
