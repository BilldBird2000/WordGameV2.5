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

        public List<RoleBase> allList = new List<RoleBase> ( );
        public List<RoleBase> liveList = new List<RoleBase> ( );
        public List<RoleBase> actSeqList = new List<RoleBase> ( );
        public List<RoleBase> tarsList = new List<RoleBase> ( );

        public virtual void Battle ( )
        {
            Util.Input ("Battle");
        }

    }
}
