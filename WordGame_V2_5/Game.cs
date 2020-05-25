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
        public int nowID;

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
            nowID = nowGamelevel.id;
            while ( nowID != 0 )
            {
                nowGamelevel.Battle ( );
                if ( BattleMng.Ins.GameLevelPass == true )
                {
                    nowID = nowGamelevel.nextID;
                    Util.Input ( );
                    Util.Input ("       恭喜通关~~累计获得 {0} 金币!!!" , BattleMng.Ins.GoldTotal);
                    Util.Input ("       按任意键进入下一关卡~~" , BattleMng.Ins.GoldTotal);
                    Console.ReadKey ( );
                }
                else
                {
                    Util.Input ( );
                    Util.Input ("       路漫漫其修远兮...");
                    break;
                }

                //foreach(int k in level.Keys)
                //{
                //    MatchLevel (k);     //实例化第k关,并完成对matchLevel的赋值
                //}
            }

            Util.Input ( );
            Util.Input ("这只是个测试...");


            Util.Input ( );
            Util.Input ("==游戏结束==");

        }

 
    }
}
