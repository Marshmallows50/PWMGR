using System.Collections;

namespace PWMGR;
public class Data : IEnumerable<EntryGroup>
{
    private List<EntryGroup> groups;
    public EntryGroup selectedGroup;

    public int Size => groups.Count;
    
    public Data()
    {
        groups = new List<EntryGroup>();
    }

    public void Add(EntryGroup group)
    {
        AddGroup(group);
    }

    public void AddGroup(EntryGroup group)
    {
        groups.Add(group);
        if (Size == 1)
            selectedGroup = group;
    }

    public void RemoveGroup(EntryGroup group)
    {
        groups.Remove(group);
    }

    public void SelectGroup(EntryGroup group)
    {
        selectedGroup = group;
    }

    public IEnumerator<EntryGroup> GetEnumerator()
    {
        return groups.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}