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
        public static event EventHandler onAdd;
        public static event EventHandler onGamobjectRemove;

        public int decrement;
        CustomProgressBar pbar;
        public ProgressBarClass(int decrement, Color color)
        {
            //Game.ondecrement += new EventHandler(raise);
            pbar = new CustomProgressBar();
            pbar.Maximum = 100;
            pbar.Minimum = 0;
            pbar.BackColor = color;
            pbar.ForeColor = color;
            pbar.Value = 100;
            this.decrement = decrement;
            onAdd?.Invoke(pbar, EventArgs.Empty);
            Game.onPlayerHit += new EventHandler(raise);
            Game.onEnemyHit += new EventHandler(raise);
        }
        private void raise(object sender, EventArgs e)
        {
            GameObject obj = (sender as GameObject);
            obj.ProgressBar.reductionF(obj);
        }

        public void reductionF(GameObject obj)
        {
            if (pbar.Value > decrement + 10)
            {
                pbar.Value -= decrement;
            }
            else
            {
                obj.DeleteProgressBar(obj);
                onGamobjectRemove?.Invoke(obj, EventArgs.Empty);
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
