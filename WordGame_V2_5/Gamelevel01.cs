﻿using System;
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
            num1 = 3;

            _player = Sally.Ins;
            enemy01AI = new Skill04 ( );

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
            Util.Input (name);
            for ( int i = 0; i < allList.Count; i++ )
                liveList.Add (allList [ i ]);

            while ( notPass )
            {
                for ( int r = 1; r < maxRound; r++ )
                {
                    Util.Input ( );
                    Util.Input ("=第{0}回合=" , r);

                    actSeqList = BattleMng.Ins.ActSequence (_player , liveList);
                    Util.Input ("场上状态:");
                    for (int i = 0; i < actSeqList.Count; i++ )
                    {
                        Util.Input ("       {0}, ID:{1}, 生命值:{2}. " ,
                                        actSeqList [ i ].name , actSeqList [ i ].id , actSeqList [ i ].Hp ,
                                        actSeqList [ i ].MaxHp , actSeqList [ i ].Speed);
                    }
                    Util.Input ("可用技能:");
                    Util.Input ("       单体: skill01_小火球[-6], skill04_普攻[-5], skill06_愈合[+10]");
                    Util.Input ("       群体: skill02_爆裂大火球[-4], skill05_吸血[-2,+2]");
                    Util.Input ("       全体: skill03_流星火雨[-5]");

                    OrderPass ( );

                    tarsList = BattleMng.Ins.IDToRole (ImportMng.Ins.tarsIDList , allList , _player);
                    for ( int i = 0; i < actSeqList.Count; i++ )
                    {
                        if ( actSeqList [ i ].roleType == RoleType.Player )
                        {
                            for ( int j = 0; j < tarsList.Count; j++ )
                                actSeqList [ i ].UseSkill (actSeqList [ i ] , tarsList [ j ] , ImportMng.Ins.matchSkill);
                            for ( int j = tarsList.Count - 1; j >= 0; j-- )
                            {
                                if ( tarsList [ j ].roleStatus == RoleStatus.Dead )
                                {
                                    liveList.Remove (tarsList [ j ]);
                                    BattleMng.Ins.GoldTotal = tarsList [ j ].gold;
                                }
                            }
                        }
                        if ( actSeqList [ i ].roleType == RoleType.Monster && actSeqList [ i ].roleStatus == RoleStatus.Alive )
                        {
                            actSeqList [ i ].UseSkill (actSeqList [ i ] , _player , enemy01AI);
                            if ( _player.roleStatus == RoleStatus.Dead )
                            {
                                maxRound = r;
                                notPass = false;
                                break;
                            }
                        }
                    }

                    if ( liveList.Count == 0 )
                    {
                        maxRound = r;
                        notPass = false;
                        BattleMng.Ins.GameLevelPass = true;
                    }

                }
            }
        }

        //解析技能和目标ID
        //public void OrderPass ( )
        //{
        //    bool skillOrder = false;
        //    bool idOrder = false;
        //    while ( !skillOrder )
        //    {
        //        skillOrder = ImportMng.Ins.ParseSkillOrder ( );
        //        if ( skillOrder == true )
        //        {
        //            while ( !idOrder )
        //                idOrder = ImportMng.Ins.ParseTarsOrder (liveList , _player);
        //        }
        //    }
        //}



    }
}
