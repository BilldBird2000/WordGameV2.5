using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame_V2_5
{
    class Skill04 : SkillBase
    {
        public Skill04 ( )
        {
            name = "***普攻***";
            ID = 04;
            baseDamage = 2;
            skillRange = SkillRange.Single;
        }

        public override void Do ( RoleBase user , RoleBase target )
        {
            base.Do (user , target);
        }
    }
}
