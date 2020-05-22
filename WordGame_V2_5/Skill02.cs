using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame_V2_5
{
    class Skill02 : SkillBase
    {
        public Skill02 ( )
        {
            name = "***爆裂大火球***";
            ID = 02;
            baseDamage = 2;
            skillRange = SkillRange.Multi;
        }

        public override void Do ( RoleBase user , RoleBase target )
        {
            base.Do (user , target);
        }


    }
}
