using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame_V2_5
{
    //Brown:Warrior
    //Sally:Mage
    //Cony:Priest

    class Sally : RoleBase
    {
        private static Sally _sally = null;
        public static Sally Ins
        {
            get
            {
                if ( _sally == null )
                    _sally = new Sally ( );
                return _sally;
            }
        }

        public Sally()
        {
            name = "~~莎莉";
            id = 1001;
            roleType = RoleType.Player;
            roleStatus = RoleStatus.Alive;
            MaxHp = 30;
            Hp = 30;
            Speed = 3;
        }

        public override void Die ( )
        {
            //base.Die ( );
            Util.Input ("       ....{0}挂了,{1}金币散落一地..." , this.name , BattleMng.Ins.GoldTotal);
        }

        public override void UseSkill ( RoleBase user , RoleBase target , SkillBase skill )
        {
            skill.Do (user , target);
        }

    }
}
