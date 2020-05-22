using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame_V2_5
{
    //枚举合集
    //枚举不需要放在类里面,可以被直接调用

    
    public enum SkillRange
    {
        Single,
        Multi,
        All,
        //None,   //召唤
        //Region  //地毯
    }

    public enum RoleType
    {
        Player,
        Summon,
        Monster,
        Boss,
    }

    public enum RoleStatus
    {
        Alive,
        Dead,
        Constraint,
    }

    public enum GamelevelType
    {
        Battle,
        Shop,
        Rest,
        Event,
    }

    
}
