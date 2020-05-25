using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame_V2_5
{
    //关卡基类
    //名称,id,notpass,type
    //maxround,num1,num2,num3
    //alllist,livelist,tarslist,actseqlist

    class GamelevelBase
    {
        public string name;
        public int id;
        public bool notPass;
        public GamelevelType gamelevelType;
        public int maxRound;
        public int num1;
        public int num2;
        public int num3;

        public RoleBase _player;
        public SkillBase enemy01AI;
        public SkillBase enemy02AI;
        public SkillBase enemy03AI;

        public List<RoleBase> allList = new List<RoleBase> ( );
        public List<RoleBase> liveList = new List<RoleBase> ( );
        public List<RoleBase> actSeqList = new List<RoleBase> ( );
        public List<RoleBase> tarsList = new List<RoleBase> ( );


        public virtual void Battle ( )
        {
            Util.Input ("Battle...");
        }


        //解析技能和目标ID,每个关卡都需要执行,so放在Base类
        public void OrderPass ( )
        {
            bool skillOrder = false;
            bool idOrder = false;
            while ( !skillOrder )
            {
                skillOrder = ImportMng.Ins.ParseSkillOrder ( );
                if ( skillOrder == true )
                {
                    while ( !idOrder )
                        idOrder = ImportMng.Ins.ParseTarsOrder (liveList , _player);
                }
            }
        }

    }
}
