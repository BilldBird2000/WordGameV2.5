using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame_V2_5
{
    class Skill01 : SkillBase
    {
        public Skill01 ( )
        {
            name = "***小火球***";
            ID = 01;
            baseDamage = 3;
            skillRange = SkillRange.Single;

        }

        public override void Do ( RoleBase user , RoleBase target )
        {
            base.Do (user , target);
        }

    }
}
