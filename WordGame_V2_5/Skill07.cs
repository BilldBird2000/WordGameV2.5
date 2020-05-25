using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame_V2_5
{
    class Skill07 : SkillBase
    {
        public Skill07 ( )
        {
            name = "快速射击";
            ID = 07;
            damageBase = 3;
            skillProperty = SkillProperty.Single;
        }

        public override void Do ( RoleBase user , RoleBase target )
        {
            int hp = target.Hp;
            int r = Game._random.Next (0 , 2);
            int damage = damageBase + r;
            hp -= damage;

            Util.Input ("           {0}_{1} 向 {2}_{3} 释放技能 {4}, 造成 {5} 点伤害!!!" ,
            user.name , user.id , target.name , target.id , name , damage);
            target.Hp = hp;
        }

    }
}
