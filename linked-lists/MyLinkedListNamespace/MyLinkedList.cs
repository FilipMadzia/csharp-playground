namespace linked_lists.MyLinkedListNamespace;

public class MyLinkedList
{
    public Node? First { get; }
    public Node? Last => GetLast();
    public int Length => GetLength();

    int GetLength()
    {
        if (First == null)
            return 0;
        
        var currentNode = First;
        var length = 1;

        while (currentNode.Next != null)
        {
            length++;
            currentNode = currentNode.Next;
        }
        
        return length;
    }

    Node? GetLast()
    {
        if (First == null)
            return null;
        
        var currentNode = First;

        while (currentNode.Next != null)
        {
            currentNode = currentNode.Next;
        }
        
        return currentNode;
    }
    
    public MyLinkedList() { }

    public MyLinkedList(ICollection<int> list)
    {
        if (list.Count == 0)
            return;

        First = new();
        var currentNode = First;

        for (var i = 0; i < list.Count - 1; i++)
        {
            currentNode.Value = list.ElementAt(i);
            currentNode.Next = new();
            
            currentNode = currentNode.Next;
        }
        
        currentNode.Value = list.Last();
    }

    public override string ToString()
    {
        if (First == null)
            return string.Empty;
        
        var result = "[ ";
        
        var currentNode = First;

        while (currentNode.Next != null)
        {
            result += currentNode.Value + ", ";
            currentNode = currentNode.Next;
        }
        
        result += currentNode.Value + " ]";
        
        return result;
    }
}