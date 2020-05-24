using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame_V2_5
{
    class Skill06 : SkillBase
    {
        public Skill06 ( )
        {
            name = "***愈合***";
            ID = 06;
            damageBase = 10;
            skillProperty = SkillProperty.Single;
        }

        public override void Do ( RoleBase user , RoleBase target )
        {
            int hp = target.Hp;
            int damage = damageBase;
            hp += damage;

            Util.Input ("           {0}_{1} 向 {2}_{3} 释放技能 {4}, 恢复 {5} 点生命值!!!" ,
                user.name , user.id , target.name , target.id , name , damage);
            target.Hp = hp;
        }

    }
}
