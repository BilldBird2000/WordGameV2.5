using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//缩写:
//Ins=Instance
//Mng=Manager

namespace WordGame_V2_5
{
    //Version2.5
    //增加控制台输入解析,实现选择技能和选择目标对象
    //增加技能范围类型
    //增加单例属性访问器
    //增加Boss简单AI,小怪采用用固定技能形式
    //有速度属性,控制回合内行动顺序
    //有回合统计,有关卡结算,有多种类怪,玩家操作角色唯一

    //V3.增加填表

    class Program
    {
        static void Main ( string [ ] args )
        {
            Util.Input ( );
            Util.Input ("==欢迎来到文字游戏==");

            Game game = Game.Ins;
            game.Start ( );

            Util.Input ( );
            Util.Input ("==按任意键退出==");
            Util.Key ( );
        }

    }
}
