using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame_V2_5
{
    class Skill03 : SkillBase
    {
        public Skill03()
        {
            name = "***流星火雨***";
            ID = 03;
            damageBase = 40;
            skillProperty = SkillProperty.All;
        }

        public override void Do ( RoleBase user , RoleBase target )
        {
            int tarHp = target.Hp;
            int damage = damageBase;
            tarHp -= damage;

            Util.Input ("           {0}_{1} 向 {2}_{3} 释放技能{4},造成 {5} 点伤害!!!" ,
                user.name , user.id , target.name , target.id , name , damage);
            target.Hp = tarHp;
        }
    }
}
