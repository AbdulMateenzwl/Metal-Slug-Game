using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using FrameWork.ENUM;
using FrameWork.ProgressB;
using FrameWork.Movement;
namespace FrameWork.GameF
{
    public class GameObject
    {
        private PictureBox pb;
        private IMovement movement;
        private ObjectTypes otype;
        private Ifire ifire;
        private IProgressBar progressBar;

        public GameObject(Image img, ObjectTypes otype, int top, int left, int Width, int Height, IMovement m, Ifire ifire, IProgressBar ibar)
        {
            pb = new PictureBox();
            pb.Image = img;
            pb.Top = top;
            pb.Left = left;
            pb.Width = Width;
            pb.Height = Height;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.BackColor = Color.Transparent;
            this.Otype = otype;
            this.Movement = m;
            this.ifire = ifire;
            ProgressBar = ibar;
        }
        public IMovement Movement { get => movement; set => movement = value; }
        public PictureBox Pb { get => pb; set => pb = value; }
        public ObjectTypes Otype { get => otype; set => otype = value; }
        public IProgressBar ProgressBar { get => progressBar; set => progressBar = value; }

        public void move(List<GameObject> gameobjects,IGame igame)
        {
            Movement.move(this, gameobjects,igame);
        }
        public void scroll()
        {
            if (Otype != ObjectTypes.Mainfloor)
            {
                Movement.scroll(this.pb);
            }
        }
        public void fire(PictureBox pb,IGame igame)
        {
            ifire.fire(pb, movement.getDirection(),igame);
        }
        public void updateprogressbar()
        {
            ProgressBar.updateProgressBar(Pb);
        }
        public void DeleteProgressBar(GameObject a)
        {
            a.ProgressBar.DeleteProgressBar(a);
        }

    }
}
