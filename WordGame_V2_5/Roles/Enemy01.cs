using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame_V2_5
{
    class Enemy01 : RoleBase
    {
        public Enemy01()
        {
            name = "史莱姆";
            id = 2101;
            roleType = RoleType.Monster;
            roleStatus = RoleStatus.Alive;
            MaxHp = 15;
            Hp = 15;
            Speed = 3;
        }
        //public int atk = 10;
        public override void Die ( )
        {
            base.Die ( );
        }

        public override void UseSkill ( RoleBase user , RoleBase target , SkillBase skill )
        {
            skill.Do (user , target);
        }
    }
}
