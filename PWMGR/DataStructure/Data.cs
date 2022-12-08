using System.Collections;

namespace PWMGR;
[Serializable]
public class Data : IEnumerable<EntryGroup>
{
    private List<EntryGroup> groups;
    public EntryGroup SelectedGroup { get; set; }

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
            SelectedGroup = group;
    }

    public void RemoveGroup(EntryGroup group)
    {
        groups.Remove(group);
    }

    public void SelectGroup(EntryGroup group)
    {
        SelectedGroup = group;
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