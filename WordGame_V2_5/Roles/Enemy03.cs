using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame_V2_5.Roles;

namespace WordGame_V2_5
{
    //Stone
    class Enemy03 : RoleBase
    {
        public Enemy03 ( )
        {
            name = "岩石巨怪";
            id = 2301;
            roleType = RoleType.Monster;
            roleStatus = RoleStatus.Alive;

            MaxHp = 20;
            Hp = 20;
            Speed = 3;
            gold = Game._random.Next (10 , 15);
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
