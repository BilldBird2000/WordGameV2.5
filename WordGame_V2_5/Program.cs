using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//缩写:
//Ins=Instance
//Mng=Manager

namespace WordGame_V2_5
{
    //Version3.0(Preview)
    //1_增加技能填表,角色配置填表
    //2_增加角色选择功能
    //3_增加Monster类型AI,怪释放高伤害技能预警
    //4_增加回合CD

    //Version2.5:
    //1_增加控制台输入解析,实现选择技能和选择目标对象
    //2_增加单例属性访问器
    //3_增加枚举集合,抽象出Base类中可被菜单化的属性
    //4_增加把player列入技能释放对象的玩法
    //5_增加撤销技能操作,支持重新选择技能
    //6_优化吸血算法,实际伤害值在剩余血量与技能数值之间取小
    //7_优化技能对象单体与多目标的判定逻辑,改为RoleProperty
    //8_保留V2.0已有玩法

    //Version2.0:
    //1_增加speed属性,定义场上对象的行动顺序
    //2_增加回合数统计,扩展统计的用途
    //3_增加关卡种类,增加关卡结算
    //4_增加怪物的种类
    //5_增加玩家操作(Delay)
    //6_保留V1.0已有玩法

    //Version1.0:
    //1_伪输入,舍弃角色[选取目标]和[选取技能]的输入操作,着重实现战斗逻辑
    //2_技能建立简单基类,角色和怪建立简单基类
    //3_运用SkillManager类处理部分战斗数据
    //4_实现单体目标与多目标选择,实现单体技能与多目标技能
    //5_单体技能与多目标技能使用条件简单判定
    //6_掉落金币有随机值,金币总值统计

    class Program
    {
        static void Main ( string [ ] args )
        {
            Util.Input ( );
            Util.Input ("==WordGame.Version2.5==");

            Game game = Game.Ins;
            game.Start ( );

            Util.Input ( );
            Util.Input ("==按任意键退出==");
            Util.Key ( );
        }

    }
}
