using System;
using System.Reflection;

public abstract class SingleTon<T> where T : class
{
    private static object   s_syncObject    = new object();
    private static T        s_instance      = null;

    public static T Instance
    {
        get
        {
            if (null == s_instance)
            {
                lock (s_syncObject)
                {
                    if (null == s_instance)
                    {
                        Type t = typeof(T);

                        ConstructorInfo[] constructors = t.GetConstructors();

                        if (constructors.Length > 0)
                        {
                            throw new InvalidOperationException(String.Format("{0} - private 생성자 강제 구현 필요(적어도 하나의 접근가능(public) 생성자가 존재하므로 싱글톤 생성이 불가합니다.)", t.Name));
                        }

                        s_instance = (T)Activator.CreateInstance(t, true);
                    }
                }
            }

            return s_instance;
        }
    }
}
