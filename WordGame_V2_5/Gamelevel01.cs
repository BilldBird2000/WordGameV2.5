using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame_V2_5
{
    class Gamelevel01 : GamelevelBase
    {
        public Gamelevel01 ( )
        {
            name = "==关卡01==";
            id = 01;
            notPass = true;
            gamelevelType = GamelevelType.Battle;
            maxRound = 11;
            num1 = 5;

            for ( int i = 0; i < num1; i++ )
            {
                RoleBase Enemy = new Enemy01 ( );
                Enemy.id += i;
                allList.Add (Enemy);

            }
        }

        public override void Battle ( )
        {
            Util.Input ( );
            Util.Input ("{0}" , name);
            for ( int i = 0; i < allList.Count; i++ )
                liveList.Add (allList [ i ]);

            while ( notPass )
            {
                for ( int r = 1; r < maxRound; r++ )
                {
                    Util.Input ( );
                    Util.Input ("=第{0}回合=" , r);

                    actSeqList = BattleMng.Ins.ActSequence (Mage.Ins , liveList);
                    Util.Input ("场上状态:");
                    for ( int i = 0; i < actSeqList.Count; i++ )
                    {
                        Util.Input ("        {0}, ID:{1}, 生命值:{2}, 最大生命值{3}, 速度值:{4}. " ,
                                        actSeqList [ i ].name , actSeqList [ i ].id , actSeqList [ i ].Hp ,
                                        actSeqList [ i ].MaxHp , actSeqList [ i ].Speed);
                    }

                    OrderPass ( );
                    tarsList = BattleMng.Ins.IDToRole (ImportMng.Ins.tarsIDList , allList);
                    for ( int i = 0; i < actSeqList.Count; i++ )
                    {
                        if ( actSeqList [ i ] is Mage )
                        {
                            for ( int j = 0; j < tarsList.Count; j++ )
                            {
                                actSeqList [ i ].UseSkill (actSeqList [ i ] , tarsList [ j ] , ImportMng.Ins.matchSkill);
                            }
                            for ( int j = tarsList.Count - 1; j > 0; j-- )
                            {
                                if ( tarsList [ j ].roleStatus == RoleStatus.Dead )
                                    liveList.Remove (tarsList [ j ]);
                            }
                        }
                    }


                    //notPass = false;


                }
            }
        }

        //解析技能和目标ID
        public void OrderPass()
        {
            bool skillOrder = false;
            bool idOrder = false;
            while ( !skillOrder )
            {
                skillOrder = ImportMng.Ins.ParseSkillOrder ( );
                if ( skillOrder == true )
                {
                    while ( !idOrder )
                        idOrder = ImportMng.Ins.ParseTarsOrder (liveList);
                }
            }
        }



    }
}
