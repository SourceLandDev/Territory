namespace Territory.Utils;

internal static class Helper
{
    /// <summary>
    /// 获取DirectoryInfo，不存在时自动创建
    /// </summary>
    /// <param name="path">文件夹目录</param>
    /// <returns>文件夹DirectoryInfo对象</returns>
    internal static DirectoryInfo CheckDir(string path)
    {
        DirectoryInfo info = new(path);
        if (!info.Exists)
        {
            info.Create();
        }
        return info;
    }
    /// <summary>
    /// 读取文件全部文字，不存在时自动创建
    /// </summary>
    /// <param name="path">文件目录</param>
    /// <param name="defaultValue">创建时的默认内容</param>
    /// <returns>文件当前数据</returns>
    internal static string CheckFile(string path, string defaultValue = "")
    {
        if (!File.Exists(path))
        {
            File.WriteAllText(path, defaultValue);
            return defaultValue;
        }
        return File.ReadAllText(path);
    }
    /// <summary>
    /// 维度枚举
    /// </summary>
    internal enum Dimension
    {
        OverWorld = 1,
        Nether,
        TneEnd = 4
    }
    internal static int ToDimID(Dimension dimension) => dimension switch
    {
        Dimension.OverWorld => 0,
        Dimension.Nether => 1,
        Dimension.TneEnd => 2,
        _ => throw new InvalidValueException("Value is not exist in Dimension enum")
    };
}
