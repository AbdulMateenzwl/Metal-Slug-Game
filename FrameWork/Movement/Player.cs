﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using EZInput;
using FrameWork.GameF;
namespace FrameWork.Movement
{
    public class Player:IMovement
    {
        private System.Drawing.Point boundary;
        bool direction = false;
        public EventHandler onAdd;
        public EventHandler onDelete;
        int r_count = 0;
        int l_count = 0;
        bool key_pressed = false;
        bool jump = false;
        private int jump_count = 0;

        int walking_speed;
        int G;
        private int jumpSteps;
        public Player( System.Drawing.Point boundary, int walking_speed, int g, int jumpSteps)
        {
            this.boundary = boundary;
            this.walking_speed = walking_speed;
            G = g;
            this.jumpSteps = jumpSteps;
        }

        public void move(PictureBox pb, List<GameObject> gameobjects)
        {
            key_pressed = false;
            if(Keyboard.IsKeyPressed(Key.RightArrow))
            {
                moveright(pb,gameobjects);
                updatepic_right(pb);
                key_pressed = true;
            }
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                moveleft(pb,gameobjects);
                updatepic_left(pb);
                key_pressed = true;
            }
            if(check_under(pb,gameobjects))
            {
                if (Keyboard.IsKeyPressed(Key.Space))
                {
                    jump = true;
                }
            }
            if(jump)
            {
                Jump(pb);
                key_pressed = true;
            }
            if(!jump)
            {
                gravity(pb,gameobjects);
            }
            if(!key_pressed)
            {
                is_standing(pb);
            }
        }
        protected bool check_hurdles_left(PictureBox pb, List<GameObject> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Pb.Bounds.IntersectsWith(pb.Bounds)&& list[i].Otype == ENUM.ObjectTypes.floor && chkleft(pb, list[i].Pb))
                {
                    return false;
                }
            }
            return true;
        }
        protected bool check_hurdles_right(PictureBox pb,List<GameObject> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Pb.Bounds.IntersectsWith(pb.Bounds) && list[i].Otype==ENUM.ObjectTypes.floor && chkright(pb, list[i].Pb))
                {
                    return false;
                }
            }
            return true;

        }
        public bool chkright(PictureBox player,PictureBox floor)
        {
            if(player.Top < floor.Top && player.Bottom >floor.Bottom&&player.Left<floor.Left)
            {
                return true;
            }
            return false;
        }
        public bool chkleft(PictureBox player, PictureBox floor)
        {
            if (player.Top < floor.Top && player.Bottom > floor.Bottom && player.Left > floor.Left)
            {
                return true;
            }
            return false;
        }
        public void moveright(PictureBox pb, List<GameObject> gameobjects)
        {
            //if (check_borders_right(pb, width) && check_hurdles_right(list))
            if(pb.Right<boundary.X && check_hurdles_right(pb,gameobjects))
            {
                direction = true;
                pb.Left += walking_speed;
                r_count++;
                if (r_count == 7)
                {
                    r_count = 1;
                }
            }
        }
        public void moveleft(PictureBox pb, List<GameObject> gameobjects)
        {
            if (pb.Left  > 0 && check_hurdles_left(pb,gameobjects))
            {
                direction = false;
                pb.Left -= walking_speed;
                l_count++;
                if (l_count == 7)
                {
                    l_count = 1;
                }
            }
        }
        public void updatepic_right(PictureBox pb)
        {
            if (r_count == 1)
            {
                pb.Image = FrameWork.Properties.Resource1._1;
            }
            else if (r_count == 2)
            {
                pb.Image = FrameWork.Properties.Resource1._2;
            }
            else if (r_count == 3)
            {
                pb.Image = FrameWork.Properties.Resource1._3;
            }
            else if (r_count == 4)
            {
                pb.Image = FrameWork.Properties.Resource1._4;
            }
            else if (r_count == 5)
            {
                pb.Image = FrameWork.Properties.Resource1._5;
            }
            else if (r_count == 6)
            {
                pb.Image = FrameWork.Properties.Resource1._6;
            }
        }
        public void updatepic_left(PictureBox pb)
        {
            if (l_count == 1)
            {
                pb.Image = FrameWork.Properties.Resource1._1L;
            }
            else if (l_count == 2)
            {
                pb.Image = FrameWork.Properties.Resource1._2L;
            }
            else if (l_count == 3)
            {
                pb.Image = FrameWork.Properties.Resource1._3L;
            }
            else if (l_count == 4)
            {
                pb.Image = FrameWork.Properties.Resource1._4L;
            }
            else if (l_count == 5)
            {
                pb.Image = FrameWork.Properties.Resource1._5L;
            }
            else if (l_count == 6)
            {
                pb.Image = FrameWork.Properties.Resource1._6L;
            }
        }
        public void Jump(PictureBox pb)
        {
            jump_count++;
            if (jump_count == 6)
            {
                jump_count = 0;
            }
            if (direction)
            {
                if (jump_count == 1)
                {
                    pb.Image = FrameWork.Properties.Resource1.j1r;
                }
                else if (jump_count == 2)
                {
                    pb.Image = FrameWork.Properties.Resource1.j2r;
                }
                else if (jump_count == 3)
                {
                    pb.Image = FrameWork.Properties.Resource1.j3r;
                }
                else if (jump_count == 4)
                {
                    pb.Image = FrameWork.Properties.Resource1.j4r;
                }
                else if (jump_count == 5)
                {
                    pb.Image = FrameWork.Properties.Resource1.j5r;
                    jump = false;
                }
            }
            else
            {
                if (jump_count == 1)
                {
                    pb.Image = FrameWork.Properties.Resource1.j1l;
                }
                else if (jump_count == 2)
                {
                    pb.Image = FrameWork.Properties.Resource1.j2l;
                }
                else if (jump_count == 3)
                {
                    pb.Image = FrameWork.Properties.Resource1.j3l;
                }
                else if (jump_count == 4)
                {
                    pb.Image = FrameWork.Properties.Resource1.j4l;
                }
                else if (jump_count == 5)
                {
                    pb.Image = FrameWork.Properties.Resource1.j5l;
                    jump = false;
                }
            }
            pb.Top -= jumpSteps;
        }
        public void is_standing(PictureBox pb)
        {
            if (direction)
            {
                pb.Image = FrameWork.Properties.Resource1.RS;
            }
            else
            {
                pb.Image = FrameWork.Properties.Resource1.LS;
            }
        }
        public void gravity(PictureBox pb, List<GameObject> gameobjects)
        {
            if (!check_under(pb,gameobjects))
            {
                pb.Top += G;
            }
        }
        public bool check_under(PictureBox pb , List<GameObject> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Pb.Bounds.IntersectsWith(pb.Bounds) && !location(pb, list[i].Pb) && list[i].Otype==ENUM.ObjectTypes.floor)
                {
                    return true;
                }
            }
            return false;
        }
        public bool location(PictureBox obj, PictureBox surface)
        {
            if (!bound_right(obj, surface) && !bound_left(obj, surface) && !bound_down(obj, surface))
            {
                return false;
            }
            return true;
        }
        public bool bound_left(PictureBox obj, PictureBox surface)
        {
            if (obj.Left > surface.Right)
            {
                return true;
            }
            return false;
        }
        public bool bound_right(PictureBox obj, PictureBox surface)
        {
            if (obj.Right < surface.Left)
            {
                return true;
            }
            return false;
        }
        public bool bound_down(PictureBox obj, PictureBox surface)
        {
            if (obj.Bottom < surface.Top)
            {
                return true;
            }
            return false;
        }
    }
}