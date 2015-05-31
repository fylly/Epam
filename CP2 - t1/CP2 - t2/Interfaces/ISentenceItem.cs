using System;

namespace CP2___t1
{
    public interface ISentenceItem
    {
        String Item { get; }
        
        int IndexOf(String item);
        bool IsNullOrEmpty();
        int Length();
        String ToLower();

    }
}
