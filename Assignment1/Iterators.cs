namespace Assignment1;

public static class Iterators
{
    public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items)
    {
        foreach(IEnumerable<T> i in items)
        {
            foreach(var v in i)
            {
                yield return v;
            }
        }
        
        
    }

    public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate)
    {
        foreach(var i in items)
        {
            if(predicate(i))
            {
                yield return i;
            }
        }
    }
    
}