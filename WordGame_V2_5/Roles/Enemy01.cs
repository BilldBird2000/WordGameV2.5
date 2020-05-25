using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame_V2_5
{
    //Slime
    class Enemy01 : RoleBase
    {
        public Enemy01()
        {
            name = "史莱姆";
            id = 2101;
            roleType = RoleType.Monster;
            roleStatus = RoleStatus.Alive;
            MaxHp = 10;
            Hp = 15;
            Speed = 3;
            gold = Game._random.Next (3 , 5);
        }

        public override void Die ( )
        {
            Util.Input ("       ....{0}_{1}死了, 掉落{2}金币..." , this.name , this.id , gold);

        }

        public override void UseSkill ( RoleBase user , RoleBase target , SkillBase skill )
        {
            skill.Do (user , target);
        }
    }
}
