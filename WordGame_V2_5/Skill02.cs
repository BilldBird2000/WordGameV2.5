using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame_V2_5
{
    class Skill02 : SkillBase
    {
        public Skill02 ( )
        {
            name = "***爆裂大火球***";
            ID = 02;
            damageBase = 4;
            skillProperty = SkillProperty.Multi;
        }

        public override void Do ( RoleBase user , RoleBase target )
        {
            //base.Do (user , target);
            int hp = target.Hp;
            int damage = damageBase;
            hp -= damage;

            Util.Input ("           {0}_{1} 向 {2}_{3} 释放技能 {4}, 造成 {5} 点伤害!!!" ,
                user.name , user.id , target.name , target.id , name , damage);
            target.Hp = hp;
        }


    }
}
