using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using FrameWork.GameF;
using FrameWork.NewFolder1;
namespace FrameWork.ProgressB
{
    public class ProgressBarClass : IProgressBar
    {
        private int decrement;
        private int lifes;
        CustomProgressBar pbar;
        public ProgressBarClass(Game game,int decrement, Color color,int lifes)
        {
            pbar = new CustomProgressBar();
            pbar.Maximum = 100;
            pbar.Minimum = 0;
            pbar.BackColor = color;
            pbar.ForeColor = color;
            pbar.Value = 100;
            this.decrement = decrement;
            game.RaiseProgressbarAdd(pbar);
            this.lifes = lifes;

        }
        

        public void reductionF(GameObject obj,IGame igame)
        {
            if (pbar.Value > decrement + 10)
            {
                pbar.Value -= decrement;
            }
            else
            {
                if(lifes > 0)
                {
                    lifes--;
                    /*if(lifes==2)
                    {
                        pbar.BackColor=Color.FromArgb(245, 22, 204);
                        pbar.ForeColor=Color.FromArgb(245, 22, 204);
                    }
                    else if(lifes==1)
                    {
                        pbar.BackColor = Color.FromArgb(250, 50, 50);
                        pbar.ForeColor = Color.FromArgb(250, 50, 50);
                    }
                    else if (lifes == 0)
                    {
                        pbar.BackColor = Color.FromArgb(104, 247, 214);
                        pbar.ForeColor = Color.FromArgb(104, 247, 214);
                    }*/
                    pbar.Value = 100;
                }
                else
                {
                    obj.DeleteProgressBar(obj);
                    igame.RemoveGameObject(obj);
                }
            }
        }

        public void DeleteProgressBar(GameObject a)
        {
            pbar.Hide();
        }
        public void updateProgressBar(PictureBox pictureBox)
        {
            pbar.Top = pictureBox.Top - 20;
            pbar.Left = pictureBox.Left;
            pbar.Width = pictureBox.Width;
            pbar.Height = 12;
        }
    }
}
