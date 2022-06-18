using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FrameWork.GameF
{
    public interface IGame
    {
        void RaisePlayerDieEvent(PictureBox pictureBox);
        void RaiseEnemyDieEvent(PictureBox pictureBox);
        void RaisePlayerBullet(PictureBox pictureBox);
        void Raise(PictureBox pictureBox);
    }
}
