﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameWork.GameF;
using FrameWork.ProgressB;
using FrameWork.Movement;
using System.Drawing;

namespace FrameWork.Fire
{
    public class EnemyFire:Ifire
    {
        private Random random = new Random();
        private int x;
        private Point boundary;
        public EnemyFire(int randomness,Point boundary)
        {
            this.x = randomness;
            this.boundary=boundary;
        }
        public void fire(PictureBox pb, bool direction, IGame igame)
        {
            if(getRandom() == 1)
            {
                if (direction)
                {
                    GameObject a = new GameObject(FrameWork.Properties.Resource1.enemyfireright, ENUM.ObjectTypes.enemyfire, pb.Top + (pb.Height / 2) - 12, pb.Right, 15, 15, new Bullet(true, 20, boundary), new NoFire(), new NoProgressBar());
                    igame.AddGameObject(a);
                }
                else
                {
                    GameObject a = new GameObject(FrameWork.Properties.Resource1.enemyfireleft, ENUM.ObjectTypes.enemyfire, pb.Top + (pb.Height / 2) - 12, pb.Left - 10, 15, 15, new Bullet(false, 20,boundary), new NoFire(),new NoProgressBar());
                    igame.AddGameObject(a);
                }
            }
        }
        public int getRandom()
        {
            return random.Next(0, x);
        }
    }
}
