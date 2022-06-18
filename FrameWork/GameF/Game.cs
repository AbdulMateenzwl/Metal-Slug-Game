using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using FrameWork.Movement;
using FrameWork.ENUM;
using FrameWork.Collision;
namespace FrameWork.GameF
{
    public class Game:IGame
    {
        private static List<GameObject> gameobjects;
        private List<CollisionClass> collisions;

        public static List<GameObject> Gameobjects { get => gameobjects; set => gameobjects = value; }

        public static event EventHandler onGameObjectAdded;
        public event EventHandler onPlayerDie;
        public event EventHandler onEnemyDie;
        public event EventHandler onPlayerBullet;
        public Game()
        {
            Gameobjects = new List<GameObject>();
            collisions = new List<CollisionClass>();
        }
        public static void AddGameObject(Image img,ObjectTypes otype, int top,int left,int width,int height,IMovement movement,Ifire ifire)
        {
            GameObject ob = new GameObject(img,otype,top,left,width,height,movement,ifire);
            Gameobjects.Add(ob);
            onGameObjectAdded?.Invoke(ob.Pb, EventArgs.Empty);
        }
        public void update()
        {
            detectCollision();
            fire();
            for (int i = 0; i < Gameobjects.Count; i++)
            {
                Gameobjects[i].move(Gameobjects);
            }
        }
        public void scroll()
        {
            for (int i = 0; i < Gameobjects.Count; i++)
            {
                Gameobjects[i].scroll();
            }
        }
        public void fire()
        {
            for (int i = 0; i < Gameobjects.Count; i++)
            {
                Gameobjects[i].fire(Gameobjects[i].Pb);
            }
        }
        public void RaisePlayerDieEvent(PictureBox playergameobject)
        {
            onPlayerDie?.Invoke(playergameobject, EventArgs.Empty);
        }
        public void RaiseEnemyDieEvent(PictureBox playergameobject)
        {
            onEnemyDie?.Invoke(playergameobject, EventArgs.Empty);
        }
        public void RaisePlayerBullet(PictureBox pictureBox)
        {
            onPlayerBullet?.Invoke(pictureBox, EventArgs.Empty);
        }
        public void detectCollision()
        {
            for (int i = Gameobjects.Count-1; i >= 0; i--)
            {
                for (int m = Gameobjects.Count-1; m >=0; m--)
                {
                    if (Gameobjects[i].Pb.Bounds.IntersectsWith(Gameobjects[m].Pb.Bounds))
                    {
                        foreach(CollisionClass c in collisions)
                        {
                            if (Gameobjects[i].Otype == c.G1&& Gameobjects[m].Otype==c.G2)
                            {
                                c.Behavior.performAction(this, Gameobjects[i], Gameobjects[m]);
                                Gameobjects.RemoveAt(i);
                            }
                        }
                    }
                }
            }
        }
        public void removefromlist(int x)
        {
            gameobjects.RemoveAt(x);
        }
        public void addCollision(CollisionClass c)
        {
            collisions.Add(c);
        }
    }

}
