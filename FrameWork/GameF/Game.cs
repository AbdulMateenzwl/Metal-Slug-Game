using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using FrameWork.Movement;
using FrameWork.ENUM;
using FrameWork.ProgressB;
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
        public static event EventHandler onEnemyHit;
        public event EventHandler onPlayerBullet;
        //public static event EventHandler ondecrement;
        public Game()
        {
            Gameobjects = new List<GameObject>();
            collisions = new List<CollisionClass>();

        }
        public static void AddGameObject(Image img,ObjectTypes otype, int top,int left,int width,int height,IMovement movement,Ifire ifire,IProgressBar ibar)
        {
            GameObject ob = new GameObject(img,otype,top,left,width,height,movement,ifire,ibar);
            Gameobjects.Add(ob);
            onGameObjectAdded?.Invoke(ob.Pb, EventArgs.Empty);
        }
        public void update()
        {
            detectCollision();
            fire();
            update_progressbar();
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
        public void update_progressbar()
        {
            for (int i = 0; i < Gameobjects.Count; i++)
            {
                Gameobjects[i].updateprogressbar();
            }
        }
        public void RaisePlayerDieEvent(PictureBox playergameobject)
        {
            onPlayerDie?.Invoke(playergameobject, EventArgs.Empty);
        }
        public void Raise(GameObject obj)
        {
            // ?.Invoke(obj, EventArgs.Empty);
        }
        public void RaiseEnemyHitEvent(GameObject obj)
        {
            onEnemyHit?.Invoke(obj, EventArgs.Empty);
        }
        public void RaisePlayerBulletRemove(GameObject obj)
        {
            onPlayerBullet?.Invoke(obj, EventArgs.Empty);
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
                            }
                        }
                    }
                }
            }
        }
        public void addCollision(CollisionClass c)
        {
            collisions.Add(c);
        }
        public static void removeGameobject(GameObject a)
        {
            Gameobjects.Remove(a);
        }
    }

}
