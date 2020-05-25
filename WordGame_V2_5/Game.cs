using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame_V2_5
{
    //次级入口,启动游戏
    //思考:怎样在进入关卡之前由玩家指定一个角色的职业,即在Game类中完成_player的实例化和赋值

    class Game
    {
        private static Game _game = null;
        public static Game Ins  //Instance
        {
            get
            {
                if ( _game == null )
                    _game = new Game ( );
                return _game;
            }
        }

        public static Random _random = new Random ( );
        public GamelevelBase matchLevel = null;
        public Dictionary<int , GamelevelBase> level = new Dictionary<int , GamelevelBase>
        {
            {01, null},
            {02, null},
            {03, null}
        };


        public void Start ( )
        {
            Util.Input ( );
            Util.Input ("==游戏开始==");

            bool passCheck = false;
            while( !passCheck )
            {
                foreach(int k in level.Keys)
                {
                    MatchLevel (k);     //实例化第k关,并完成对matchLevel的赋值
                    matchLevel.Battle ( );
                    if ( BattleMng.Ins.GameLevelPass == true )
                    {
                        Util.Input ( );
                        Util.Input ("       恭喜通关~~累计获得 {0} 金币!!!" , BattleMng.Ins.GoldTotal);
                        Util.Input ("       按任意键进入下一关卡~~" , BattleMng.Ins.GoldTotal);
                    }
                    else
                    {
                        passCheck = true;
                        Util.Input ( );
                        Util.Input ("       路漫漫其修远兮...");
                        break;
                    }
                }
            }
            
            Util.Input ( );
            Util.Input ("这只是个测试...");


            Util.Input ( );
            Util.Input ("==游戏结束==");

        }

        //匹配关卡并实例化关卡
        public void MatchLevel(int k)
        {
            switch(k)
            {
                case 01:
                    matchLevel= new Gamelevel01 ( );
                    break;
                case 02:
                    matchLevel = new Gamelevel02 ( );
                    break;
                case 03:
                    matchLevel = new Gamelevel03 ( );
                    break;

                default:
                    Util.Input ( );
                    Util.Input ("创建关卡失败...");
                    break;

            }
        }

    }
}
