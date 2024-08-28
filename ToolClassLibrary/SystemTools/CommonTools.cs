using System.Reflection;

namespace ToolClassLibrary.SystemTools;

public class CommonTools
{
    /// <summary>
    ///  深拷贝。
    /// </summary>
    /// <typeparam name="T">泛型</typeparam>
    /// <param name="obj">传入值</param>
    /// <returns>返回值</returns>
    public static T DeepCopy<T>(T obj)
    {
        // 如果传入值为空，直接返回。
        if (obj == null)
            return obj;

        // 获取obj类型。
        Type type = obj.GetType();

        // 使用传入值类型的无参数构造函数创建该类型的实例。
        var copy = Activator.CreateInstance(typeof(T), nonPublic: true);

        // 获取传入值的所有属性。
        PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (PropertyInfo property in properties)
        {
            if (property.CanWrite)
            {
                object? value = property.GetValue(obj);
                if (value != null)
                {
                    if (property.PropertyType.IsValueType || property.PropertyType == typeof(string))
                    {
                        // 属性为基础类型或string，拷贝。
                        property.SetValue(copy, value);
                    }
                    else
                    {
                        // 属性为引用类型，递归调用深拷贝。
                        property.SetValue(copy, DeepCopy(value));
                    }
                }
            }
        }

        return (T)copy!;
    }

    /// <summary>
    ///  类型对比。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj1"></param>
    /// <param name="obj2"></param>
    /// <returns></returns>
    public static bool CompareObjects<T>(T obj1, T obj2)
    {
        if (obj1 == null && obj2 == null)
            return true;

        if (obj1 == null || obj2 == null)
            return false;

        Type type1 = obj1.GetType();
        Type type2 = obj2.GetType();

        if (type1 != type2)
            return false;

        PropertyInfo[] properties = type1.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (PropertyInfo property in properties)
        {
            if (property.CanWrite)
            {
                object? value1 = property.GetValue(obj1);
                object? value2 = property.GetValue(obj2);

                if (value1 != null && value2 != null)
                {
                    if (property.PropertyType.IsValueType || property.PropertyType == typeof(string))
                    {
                        if (!value1.Equals(value2))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        CompareObjects(value1, value2);
                    }
                }
                else if (value1 == null && value2 == null)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
        }

        return true;
    }
}

