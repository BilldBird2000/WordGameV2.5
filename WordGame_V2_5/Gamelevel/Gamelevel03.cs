using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame_V2_5
{
    class Gamelevel03 : GamelevelBase
    {
        public Gamelevel03 ( )
        {
            name = "==关卡03==";
            id = 03;
        }

        public override void Battle ( )
        {
            Util.Input ("第三关,测试");
            nextID = 0;
            BattleMng.Ins.GameLevelPass = false;
        }
    }
}
