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

        public int decrement;
        CustomProgressBar pbar;
        public ProgressBarClass(int decrement, Color color)
        {
            Game.ondecrement += new EventHandler(raise);
            pbar = new CustomProgressBar();
            pbar.Maximum = 100;
            pbar.Minimum = 0;
            pbar.BackColor = color;
            pbar.ForeColor = color;
            pbar.Value = 100;
            this.decrement = decrement;
            onAdd?.Invoke(pbar, EventArgs.Empty);
        }

        private void raise(object sender, EventArgs e)
        {
            if (pbar.Value >= decrement)
            {
                pbar.Value -= decrement;
            }
        }

        public void updateProgressBar(PictureBox pictureBox)
        {
            pbar.Top = pictureBox.Top - 20;
            pbar.Left = pictureBox.Left;
            pbar.Width = pictureBox.Width;
            pbar.Height = 15;
        }

    }
}
