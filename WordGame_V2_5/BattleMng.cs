using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame_V2_5
{
    //用于战斗要素处理的函数集合
    //IdToRole
    //ActSequence
    //GoldTatol属性访问器
    //LevelPass属性访问器

    class BattleMng
    {
        private static BattleMng _battleManager = null;
        public static BattleMng Ins
        {
            get
            {
                if ( _battleManager == null )
                    _battleManager = new BattleMng ( );
                return _battleManager;
            }
        }

        //按速度排序
        public int maxSpeed = 5;
        public List<RoleBase> ActSequence ( RoleBase player , List<RoleBase> liveList )
        {
            List<RoleBase> actSeq = new List<RoleBase> ( );
            for ( int s = maxSpeed; s > 1; s-- )
            {
                if ( player.Speed == s )
                    actSeq.Add (player);
                for ( int i = 0; i < liveList.Count; i++ )
                {
                    if ( liveList [ i ].Speed == s )
                        actSeq.Add (liveList [ i ]);
                }
            }

            return actSeq;
        }

        //用比较ID的方法获得技能对象列表
        public List<RoleBase> IDToRole ( List<int> tarsIDList , List<RoleBase> allList , RoleBase player )
        {
            RemoveTheSameID (tarsIDList);
            List<RoleBase> tars = new List<RoleBase> ( );
            for ( int i = 0; i < tarsIDList.Count; i++ )
            {
                for ( int j = 0; j < allList.Count; j++ )
                {
                    if ( tarsIDList [ i ] == allList [ j ].id )
                        tars.Add (allList [ j ]);
                    else if ( tarsIDList [ i ] == player.id )
                    {
                        tars.Add (player);
                        break;
                    }
                }
            }
            return tars;
        }

        public void RemoveTheSameID ( List<int> tarsIDList )
        {
            for ( int i = tarsIDList.Count - 1; i > 0; i-- )
            {
                foreach ( int j in tarsIDList )
                {
                    if ( j == tarsIDList [ i ] )
                        tarsIDList.Remove (tarsIDList [ i ]);
                    break;
                }
            }
        }

        //金币计算器
        private int _goldTotal = 0;
        public int GoldTotal
        {
            set { _goldTotal += value; }
            get { return _goldTotal; }
        }


    }
}
