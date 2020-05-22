using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame_V2_5
{
    //次级入口,启动游戏

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

        //RoleBase _mage = Mage.MageIns;   //单例,延迟实例化mage
        public static Random _random = new Random ( );


        public void Start()
        {
            Util.Input ( );
            Util.Input ("==游戏开始==");

            GamelevelBase g01 = new Gamelevel01 ( );
            g01.Battle ( );
            if ( g01.notPass == false )
                Util.Input ("这只是个测试...");


            Util.Input ( );
            Util.Input ("==游戏结束==");

        }



    }
}
