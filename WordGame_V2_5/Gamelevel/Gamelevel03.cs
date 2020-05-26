using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame_V2_5.Roles;

namespace WordGame_V2_5
{
    class Gamelevel03 : GamelevelBase
    {
        public Gamelevel03 ( )
        {
            name = "==关卡03==";
            id = 03;
            nextID = 04;
            notPass = true;
            gamelevelType = GamelevelType.Battle;
            maxRound = 11;
            num1 = 1;
            num2 = 2;
            num3 = 1;

            _player = Sally.Ins;
            enemy01AI = new Skill11 ( );
            enemy02AI = new Skill12 ( );
            enemy03AI = new Skill13 ( );

            allList.Clear ( );
            liveList.Clear ( );
            actSeqList.Clear ( );
            tarsList.Clear ( );

            allList.Add (new Enemy01 ( ));
            for ( int i = 0; i < num2; i++ )
            {
                RoleBase enemy = new Enemy02 ( );
                enemy.id += i;
                allList.Add (enemy);
            }
            allList.Add (new Enemy03 ( ));

        }

        public override void Battle ( )
        {
            Util.Input ( );
            Util.Input ("{0} >>>>>>通关条件:在{1}回合内完成战斗!<<<<<<" , name , maxRound - 1);
            for ( int i = 0; i < allList.Count; i++ )
                liveList.Add (allList [ i ]);

            while ( notPass )
            {
                for ( int r = 1; r < maxRound; r++ )
                {
                    Util.Input ( );
                    Util.Input ("第{0}回合" , r);
                    actSeqList = BattleMng.Ins.ActSequence (_player , liveList);
                    Util.Input ( );
                    Util.Input ("   双方信息与行动顺序:");
                    for ( int i = 0; i < actSeqList.Count; i++ )
                    {
                        Util.Input ("       {0}, ID:{1}, 生命值:{2}. " ,
                                        actSeqList [ i ].name , actSeqList [ i ].id , actSeqList [ i ].Hp);
                    }
                    Util.Input ("   玩家可用技能:");
                    Util.Input ("       单体: skill 01_小火球[-6], skill 05_愈合[+10]");
                    Util.Input ("       群体: skill 02_炎爆术[-5], skill 04_吸血[-3,+3]");
                    Util.Input ("       全体: skill 03_流星火雨[-4]");
                    Util.Input ("   敌方可用技能:");
                    Util.Input ("       史莱姆: 弹跳攻击[-2], 哥布林: 快速射击[-3~-5]");
                    Util.Input ("       岩石巨怪: 投石[-4~-7]");

                    OrderPass ( );
                    tarsList = BattleMng.Ins.IDToRole (ImportMng.Ins.tarsIDList , allList , _player);
                    for ( int i = 0; i < actSeqList.Count; i++ )
                    {
                        if ( actSeqList [ i ].roleType == RoleType.Player )
                        {
                            for ( int j = 0; j < tarsList.Count; j++ )
                                _player.UseSkill (_player , tarsList [ j ] , ImportMng.Ins.matchSkill);
                            for ( int j = tarsList.Count - 1; j >= 0; j-- )
                            {
                                if ( tarsList [ j ].roleStatus == RoleStatus.Dead )
                                {
                                    liveList.Remove (tarsList [ j ]);
                                    BattleMng.Ins.GoldTotal = tarsList [ j ].gold;
                                }
                            }
                        }
                        else if ( actSeqList [ i ] is Enemy01 && actSeqList [ i ].roleStatus == RoleStatus.Alive )
                        {
                            actSeqList [ i ].UseSkill (actSeqList [ i ] , _player , enemy01AI);
                            if ( _player.roleStatus == RoleStatus.Dead )
                            {
                                notPass = false;
                                maxRound = r;
                                break;
                            }
                        }
                        else if ( actSeqList [ i ] is Enemy02 && actSeqList [ i ].roleStatus == RoleStatus.Alive )
                        {
                            actSeqList [ i ].UseSkill (actSeqList [ i ] , _player , enemy02AI);
                            if ( _player.roleStatus == RoleStatus.Dead )
                            {
                                notPass = false;
                                maxRound = r;
                                break;
                            }
                        }
                        else if ( actSeqList [ i ] is Enemy03 && actSeqList [ i ].roleStatus == RoleStatus.Alive )
                        {
                            actSeqList [ i ].UseSkill (actSeqList [ i ] , _player , enemy03AI);
                            if ( _player.roleStatus == RoleStatus.Dead )
                            {
                                notPass = false;
                                maxRound = r;
                                break;
                            }
                        }
                    }

                    if ( liveList.Count == 0 )
                    {
                        notPass = false;
                        BattleMng.Ins.GameLevelPass = true;
                        nextID = 0;
                        break;
                    }

                }

                if ( liveList.Count > 0 && _player.roleStatus == RoleStatus.Alive )
                {
                    notPass = false;
                    Util.Input ( );
                    Util.Input ("       未能在{0}回合内完成战斗,闯关失败..." , maxRound - 1);
                }


            }


        }
    }
}
