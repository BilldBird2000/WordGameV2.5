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
        public GamelevelBase nowGamelevel = null;
        public int nextID;

        //public Dictionary<int , GamelevelBase> level = new Dictionary<int , GamelevelBase>
        //{
        //    {01, null},
        //    {02, null},
        //    {03, null}
        //};


        public void Start ( )
        {
            Util.Input ( );
            Util.Input ("==游戏开始==");

            nowGamelevel = new Gamelevel01 ( );
            nextID = nowGamelevel.nextID;   
            while ( nextID != 0 )
            {
                nowGamelevel.Battle ( );   
                if ( BattleMng.Ins.GameLevelPass == true )
                {
                    BattleMng.Ins.GameLevelPass = false;
                    nextID = nowGamelevel.nextID;
                    Util.Input ( );
                    Util.Input ("       恭喜通关~~累计获得 {0} 金币!!!" , BattleMng.Ins.GoldTotal);
                    if ( nextID != 0 )
                        Util.Input ("       按任意键进入下一关卡~~");
                    else
                        Util.Input ("       完成全部关卡!!按任意键继续~~");

                    Console.ReadKey ( );
                }
                else
                {
                    Util.Input ( );
                    Util.Input ("       SayGoodbye...");
                    break;
                }

            }

            Util.Input ( );
            Util.Input ("==游戏结束==");

            Util.Input ( );
            Util.Input ("Only for test...");

        }


    }
}
