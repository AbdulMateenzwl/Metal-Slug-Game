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
        private List<GameObject> gameobjects;
        private List<CollisionClass> collisions;
        public event EventHandler onGameObjectAdded;
        public event EventHandler onPlayerDie;
        public Game()
        {
            gameobjects = new List<GameObject>();
            collisions = new List<CollisionClass>();
        }
        public void AddGameObject(Image img,ObjectTypes otype, int top,int left,int width,int height,IMovement movement)
        {
            GameObject ob = new GameObject(img,otype,top,left,width,height,movement);
            gameobjects.Add(ob);
            onGameObjectAdded?.Invoke(ob.Pb, EventArgs.Empty);
        }
        public void update()
        {
            detectCollision();
            for (int i = 0; i < gameobjects.Count; i++)
            {
                gameobjects[i].move(gameobjects);
            }
        }
        public void scroll()
        {
            for (int i = 0; i < gameobjects.Count; i++)
            {
                gameobjects[i].scroll();
            }
        }
        public void RaisePlayerDieEvent(PictureBox playergameobject)
        {
            onPlayerDie?.Invoke(playergameobject, EventArgs.Empty);
        }
        public void detectCollision()
        {
            for (int i = 0; i < gameobjects.Count; i++)
            {
                for (int m = 0; m < gameobjects.Count; m++)
                {
                    if (gameobjects[i].Pb.Bounds.IntersectsWith(gameobjects[m].Pb.Bounds))
                    {
                        foreach(CollisionClass c in collisions)
                        {
                            if (gameobjects[i].Otype == c.G1&& gameobjects[m].Otype==c.G2)
                            {
                                c.Behavior.performAction(this, gameobjects[i], gameobjects[m]);
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
    }

}
