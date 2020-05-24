using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame_V2_5.Roles
{
    //Goblin
    class Enemy02 : RoleBase
    {
        public Enemy02 ( )
        {
            name = "哥布林";
            id = 2201;
            roleType = RoleType.Monster;
            roleStatus = RoleStatus.Alive;
            MaxHp = 10;
            Hp = 10;
            Speed = 4;
            gold = Game._random.Next (5 , 8);
        }

        public override void Die ( )
        {
            Util.Input ("       ....{0}_{1}死了, 掉落{2}金币..." , this.name , this.id , gold);
        }

        public override void UseSkill ( RoleBase user , RoleBase target , SkillBase skill )
        {
            base.UseSkill (user , target , skill);
        }

    }
}
