using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame_V2_5
{
    //对输入的字符串解析------
    //输入规则:第一行:[skill] [skillID]
    //第二行:[tarID] [tarID]...[tarID]
    //1.接收输入的字符串,检查输入内容是否合法.
    //2.拆分字符串,存放入字符串数组,可以顺便转成list
    //3.分析list中的元素是否合法----
    //1.第一行两个元素,检查第一个元素是否是skill;检查skillID是否存在
    //2.第二行的元素,技能类型为all时,可以为空;技能类型为multi时,至少有一个元素;技能类型为single时,只能有一个元素
    //3.检查tarID是否都存在

    //得到技能id和技能实例
    //得到技能对象的idlist

    class ImportMng
    {
        private static ImportMng _importManager = null;
        public static ImportMng Ins
        {
            get
            {
                if ( _importManager == null )
                    _importManager = new ImportMng ( );
                return _importManager;
            }
        }

        public List<string> skillList;
        public int skillID;
        public SkillBase matchSkill;    //技能
        public List<string> idStrList;
        public List<int> tarsIDList;    //目标ID列表

        //技能指令输入格式:skill skillID
        //执行后获得返回值true,和skillID的赋值
        public bool ParseSkillOrder ( )
        {
            Util.Input ("请输入: skill skillID : ");

            string import = Console.ReadLine ( );
            if ( string.IsNullOrWhiteSpace (import) )
            {
                Util.Input ("空白输入,无效!");
                return false;
            }
            string [ ] skillArr = import.Split (new char [ ] { ' ' } , StringSplitOptions.RemoveEmptyEntries);
            skillList = new List<string> (skillArr);

            if ( skillList == null || skillList.Count < 2 )
            {
                Util.Input ("找不到技能列表!");
                return false;
            }
            switch ( skillList [ 0 ] )
            {
                case "skill":
                    skillID = FindSkill ( );
                    if ( skillID < 0 )
                        return false;
                    break;
                default:
                    Util.Input ("输入指令无效!");
                    return false;
            }

            return true;
        }

        //将目标指令ID的部分转换成数字.输入为非数字或超出int32范围时,会执行catch中的部分
        //完成对skillMatch的赋值,玩家使用的技能确定了
        public int FindSkill ( )
        {
            try
            {
                skillID = Convert.ToInt32 (skillList [ 1 ]);
            }
            catch
            {
                Util.Input ("无效ID00000000!");
                skillID = -1;
                return skillID;
            }

            SkillMng.Ins.MatchSkill (skillID , out matchSkill);
            if ( matchSkill == null )
            {
                skillID = -1;
                return skillID;
            }

            return skillID;
        }

        //解析第二段输入:tarsID
        public bool ParseTarsOrder ( List<RoleBase> liveList )
        {
            Util.Input ("请输入目标ID:");
            string import = Console.ReadLine ( );
            tarsIDList = new List<int> ( );

            if ( string.IsNullOrWhiteSpace (import) )
            {
                if ( matchSkill.skillRange != SkillRange.All )
                {
                    Util.Input ("未输入目标,技能无法使用!");
                    return false;
                }
                else
                {
                    Util.Input ("当前技能为全体技能,按任意键继续...");
                    return AllTarsID (liveList);
                }
            }
            string [ ] idArr = import.Split (new char [ ] { ' ' } , StringSplitOptions.RemoveEmptyEntries);
            idStrList = new List<string> (idArr);

            if ( idStrList == null )
            {
                Util.Input ("找不到ID列表!");
                return false;
            }
            if ( idStrList.Count > 1 )
            {
                if ( matchSkill.skillRange == SkillRange.Single )
                {
                    Util.Input ("当前技能为单体技能,目标无效!");
                    return false;
                }
                else if ( matchSkill.skillRange == SkillRange.Multi )
                {
                    return FindTargetsID (liveList);
                }
                else
                {
                    return AllTarsID (liveList);
                }
            }
            else
            {
                if ( matchSkill.skillRange != SkillRange.All )
                {
                    return FindTargetsID (liveList);
                }
                else
                {
                    return AllTarsID (liveList);
                }
            }
        }

        //将string类型的idList转换成int类型
        //当前版本目标不包括:召唤物,施法者本人,已死对象
        public bool FindTargetsID ( List<RoleBase> liveList )
        {
            try
            {
                List<int> enemyID = new List<int> ( );
                for ( int i = 0; i < liveList.Count; i++ )
                    enemyID.Add (liveList [ i ].id);
                for ( int i = 0; i < idStrList.Count; i++ )
                {
                    int id = Convert.ToInt32 (idStrList [ i ]);
                    foreach ( int EnemyID in enemyID )
                    {
                        if ( id == EnemyID )
                        {
                            tarsIDList.Add (id);
                            break;
                        }
                    }

                    bool inList = InListCheck (id , tarsIDList);
                    if ( inList )
                        Util.Input ("技能释放对象: {0}" , id);
                    else
                    {
                        Util.Input ("{0}是无效ID!" , id);
                        return false;
                    }

                }
            }
            catch
            {
                Util.Input ("无效ID00000000!");
                return false;
            }
            return true;
        }

        //判断ID是否有效
        public bool InListCheck ( int id , List<int> tarsIDList )
        {
            foreach ( int tarID in tarsIDList )
            {
                if ( id == tarID )
                    return true;
            }
            return false;
        }

        //存活对象全部是技能目标
        public bool AllTarsID ( List<RoleBase> liveList )
        {
            for ( int i = 0; i < liveList.Count; i++ )
                tarsIDList.Add (liveList [ i ].id);

            return true;
        }


    }
}
