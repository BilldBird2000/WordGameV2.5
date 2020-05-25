using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame_V2_5.Roles;

namespace WordGame_V2_5
{
    class Gamelevel02 : GamelevelBase
    {
        public Gamelevel02 ( )
        {
            name = "==关卡02==";
            id = 02;
            nextID = 03;
            notPass = true;
            gamelevelType = GamelevelType.Battle;
            maxRound = 11;
            num1 = 2;
            num2 = 1;

            _player = Sally.Ins;
            enemy01AI = new Skill04 ( );  //slime use skill04
            enemy02AI = new Skill07 ( );  //goblin use skill07

            BattleMng.Ins.GameLevelPass = false;
            allList.Clear ( );
            liveList.Clear ( );
            actSeqList.Clear ( );
            tarsList.Clear ( );

            for ( int i = 0; i < num1; i++ )
            {
                RoleBase enemy = new Enemy01 ( );
                enemy.id += i;
                allList.Add (enemy);
            }
            for ( int i = 0; i < num2; i++ )
            {
                RoleBase enemy = new Enemy02 ( );
                enemy.id += i;
                allList.Add (enemy);
            }
        }


        public override void Battle ( )
        {

            Util.Input ( );
            Util.Input ("{0} 通关条件:在{1}回合内完成战斗!" , name , maxRound - 1);
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
                    Util.Input ("场上状态:");
                    for ( int i = 0; i < actSeqList.Count; i++ )
                    {
                        Util.Input ("       {0}, ID:{1}, 生命值:{2}. " ,
                                        actSeqList [ i ].name , actSeqList [ i ].id , actSeqList [ i ].Hp);
                    }
                    Util.Input ("可用技能:");
                    Util.Input ("       单体: skill 01_小火球[-6], skill 06_愈合[+10]");
                    Util.Input ("       群体: skill 02_炎爆术[-5], skill 05_吸血[-3,+3]");
                    Util.Input ("       全体: skill 03_流星火雨[-4]");

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
                                    liveList.Remove (tarsList [ j ]);
                            }
                        }
                        else if ( actSeqList [ i ] is Enemy01 || actSeqList [ i ].roleStatus == RoleStatus.Alive )
                        {
                            actSeqList [ i ].UseSkill (actSeqList [ i ] , _player , enemy01AI);
                            if ( _player.roleStatus == RoleStatus.Dead )
                            {
                                Util.Input ( );
                                notPass = false;
                                maxRound = r;
                            }
                        }
                        else if ( actSeqList [ i ] is Enemy02 || actSeqList [ i ].roleStatus == RoleStatus.Alive )
                        {
                            actSeqList [ i ].UseSkill (actSeqList [ i ] , _player , enemy02AI);
                            if ( _player.roleStatus == RoleStatus.Dead )
                            {
                                Util.Input ( );
                                notPass = false;
                                maxRound = r;
                            }
                        }
                    }

                    if ( liveList.Count == 0 )
                    {
                        maxRound = r;
                        notPass = false;
                        BattleMng.Ins.GameLevelPass = true;
                        Game.Ins.nowGamelevel = new Gamelevel03 ( );
                        break;
                    }

                }



            }


        }

    }
}
