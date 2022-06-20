using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FrameWork.GameF
{
    public interface IGame
    {
        void RaisePlayerHitEvent(GameObject obj);
        void RaiseEnemyHitEvent(GameObject obj);
        void RaisePlayerBulletRemove(GameObject obj);
        void AddGameObject(GameObject a);
        void RemoveGameObject(GameObject a);
        void AddScore(int x);
    }
}
