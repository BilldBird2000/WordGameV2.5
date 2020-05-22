using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame_V2_5
{
    class Mage : RoleBase
    {
        private static Mage _mage = null;
        public static Mage Ins
        {
            get
            {
                if ( _mage == null )
                    _mage = new Mage ( );
                return _mage;
            }
        }

        public Mage()
        {
            name = "小鸡莎莉";
            id = 1001;
            roleType = RoleType.Player;
            roleStatus = RoleStatus.Alive;
            MaxHp = 30;
            Hp = 30;
            Speed = 4;
        }

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
