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
            baseDamage = 30;
            skillRange = SkillRange.Single;

        }

        public override void Do ( RoleBase user , RoleBase target )
        {
            int tarHp = target.Hp;
            int damage = baseDamage;
            Util.Input ("{0}向{1}.{2}释放技能{3},造成{4}点伤害!!!" , 
                user.name , target.name , target.id , name , damage);
            tarHp -= damage;
            target.Hp = tarHp;

        }

    }
}
