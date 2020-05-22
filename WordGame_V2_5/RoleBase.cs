using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame_V2_5
{
    //角色基类,构造基础属性
    //名字,ID,类型,血量,最大血量,速度
    //死亡标记
    //virtual Die
    //virtual UseSkill
    //id规则--------
        //[1][1][0][1]:[玩家][英雄1][占位][号码]
        //[2][1][0][1]:[怪  ][怪1  ][占位][号码]

    class RoleBase
    {
        public string name;
        public int id;
        public RoleType roleType;

        protected int maxHp = 0;
        public int MaxHp
        {
            set { maxHp = value; }
            get { return maxHp; }
        }

        protected int hp = 0;
        public int Hp
        {
            set
            {
                if ( value > MaxHp )
                    hp = MaxHp;
                else if ( value <= 0  )
                {
                    hp = 0;
                    RoleStatus roleStatus = RoleStatus.Dead;
                    IsDead = true;
                    Die ( );
                }
                else
                {
                    hp = value;
                }
            }
            get { return hp; }
        }

        protected int speed = 0;
        public int Speed
        {
            set { speed = value; }
            get { return speed; }
        }

        protected bool isDead = false;
        public bool IsDead
        {
            set { isDead = value; }
            get { return isDead; }
        }

        public virtual void Die()
        {
            Util.Input ("Die...");
        }

        public virtual void UseSkill ( RoleBase user , RoleBase target , SkillBase skill )
        {
            skill.Do (user , target);
        }

    }
}
