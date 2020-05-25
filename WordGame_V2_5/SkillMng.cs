using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame_V2_5
{
    //处理技能使用前的一系列检查判断处理的集合
    //SkillMatch,技能匹配
    //范围类型作用目标个数的检查

    class SkillMng
    {
        private static SkillMng _skillManager = null;
        public static SkillMng Ins
        {
            get
            {
                if ( _skillManager == null )
                    _skillManager = new SkillMng ( );
                return _skillManager;
            }
        }

        //带入技能ID,并给skillMatch赋值
        public void MatchSkill ( int id , out SkillBase skillMatch )
        {
            switch ( id )
            {
                case 01:
                    skillMatch = new Skill01 ( );
                    break;
                case 02:
                    skillMatch = new Skill02 ( );
                    break;
                case 03:
                    skillMatch = new Skill03 ( );
                    break;
                case 04:
                    skillMatch = new Skill04 ( );
                    break;
                case 05:
                    skillMatch = new Skill05 ( );
                    break;
                case 06:
                    skillMatch = new Skill06 ( );
                    break;
                case 07:
                    skillMatch = new Skill07 ( );
                    break;

                default:
                    Util.Input ("技能ID无效!");
                    skillMatch = null;
                    break;
            }
        }




    }
}
