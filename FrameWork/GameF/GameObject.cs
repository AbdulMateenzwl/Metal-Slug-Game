using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using FrameWork.ENUM;
using FrameWork.Movement;
namespace FrameWork.GameF
{
    public class GameObject
    {
        private PictureBox pb;
        private IMovement movement;
        private ObjectTypes otype;

        public GameObject(Image img, ObjectTypes otype, int top, int left, int Width, int Height, IMovement m)
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
        }
        public IMovement Movement { get => movement; set => movement = value; }
        public PictureBox Pb { get => pb; set => pb = value; }
        public ObjectTypes Otype { get => otype; set => otype = value; }

        public void move(List<GameObject> gameobjects)
        {
            Movement.move(this.pb, gameobjects);
        }
        public void scroll()
        {
            Movement.scroll(this.pb);
        }
    }
}
