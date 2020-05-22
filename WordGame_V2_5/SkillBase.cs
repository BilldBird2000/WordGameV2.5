using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame_V2_5
{
    //技能构造基类
    //名称,ID,范围类型
    //技能算法
    //当前技能都是单段攻击,没有多段攻击设计

    class SkillBase
    {
        public string name;
        public int ID;
        public int baseDamage;
        public  SkillRange skillRange;

        public virtual void Do ( RoleBase user , RoleBase target )
        {
            Util.Input ("释放技能!!");
        }

    }
}
