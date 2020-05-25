using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame_V2_5
{
    class Skill05:SkillBase
    {
        public Skill05()
        {
            name = "***吸血***";
            ID = 05;
            damageBase = 3;
            skillProperty = SkillProperty.Multi;
        }

        public override void Do ( RoleBase user , RoleBase target )
        {
            int hp = target.Hp;
            int damage = damageBase;
            hp -= damage;

            Util.Input ("           {0}_{1} 向 {2}_{3} 释放技能 {4}, 造成 {5} 点伤害, 恢复 {5} 点生命值!!!" ,
                user.name , user.id , target.name , target.id , name , damage);
            target.Hp = hp;
            user.Hp += damage;
        }

    }
}
