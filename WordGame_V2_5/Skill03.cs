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
            baseDamage = 3;
            skillRange = SkillRange.All;
        }

        public override void Do ( RoleBase user , RoleBase target )
        {
            base.Do (user , target);
        }
    }
}
