using System.Runtime.Serialization;

namespace Infrastrucrure.Utils;

public static class EnumUtil
{   
    public static ICollection<(string Name, int Value)> GetValues<T>() where T : Enum
    {
        return Enum.GetValues(typeof(T))
                   .Cast<T>()
                   .Select(value => (Name: value.ToString(), Value: Convert.ToInt32(value)))
                   .ToList();

        //return Enum.GetValues(typeof(T)).Cast<T>().ToList();
    }
}
