using LiteLoader.Schedule;
using Territory.Type;

namespace Territory.Utils;

internal static class ActionHelper
{
    private static readonly Dictionary<string, Creation.Data> _creationData = new();
    internal static void CreationInit()
    {
        // 圈地时提醒
        ScheduleAPI.Delay(() =>
        {
            IEnumerable<Player> players = from player in Level.GetAllPlayers() where _creationData.ContainsKey(player.Xuid) select player;
            foreach (Player player in players)
            {
                if (!_creationData.TryGetValue(player.Xuid, out Creation.Data data) || data.Step > Creation.Steps.Pos2)
                {
                    continue;
                }
                player.SendText(Main.i18nHelper[player.LanguageCode][$"territory.action.create.pos{data.Step}"], TextType.Popup);
            }
        }, 1);
        // 选点逻辑
        PlayerAttackBlockEvent.Event += e =>
        {
            if (!_creationData.TryGetValue(e.Player.Xuid, out Creation.Data data) || data.Step > Creation.Steps.Pos2)
            {
                return true;
            }
            Console.WriteLine($"{e.Player.Name}触发圈地选择");
            switch (data.Step)
            {
                case Creation.Steps.Pos1:
                    data.Pos1 = e.BlockInstance.Position;
                    break;
                case Creation.Steps.Pos2:
                    data.Pos2 = e.BlockInstance.Position;
                    // TODO：修改坐标、设置名称之类的UI、计算扣费（Step3）
                    // FormHelper.EditPos(player, data);
                    break;
                // 临时使用 - 开始
                case Creation.Steps.Pos3:
                    ILiteCollection<LandData> col = Main.DataBase.GetCollection<LandData>("lands");
                    col.Insert(new LandData()
                    {
                        Dimension = e.Player.DimensionId,
                        Owner = e.Player.Xuid,
                        Bounding = new(data.Pos1, data.Pos2),
                        Price = 0,
                        Name = ""
                    });
                    e.Player.SendText(Main.i18nHelper[e.Player.LanguageCode]["territory.action.create.finish"], TextType.Popup);
                    break;
                // 临时使用 - 结束
                default:
                    return true;
            }
            data.Step++;
            return false;
        };
    }
    internal static void StartCreate(Player player)
    {
        // 推进数据列表待选
        _creationData[player.Xuid] = new();
        Console.WriteLine($"{player.Name}已加进待选");
    }
}
