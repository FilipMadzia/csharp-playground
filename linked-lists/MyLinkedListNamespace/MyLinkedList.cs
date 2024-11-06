namespace linked_lists.MyLinkedListNamespace;

public class MyLinkedList
{
    public Node? Head { get; set; }
    public int Length => GetLength();

    int GetLength()
    {
        var length = 0;
        var currentNode = Head;
        
        if(currentNode == null)
            return length;

        while (currentNode.Next != null)
        {
            length++;
            currentNode = currentNode.Next;
        }
        
        return length;
    }

    public MyLinkedList(List<int> list)
    {
        if (list.Count == 0)
            return;

        Head = new();
        var currentNode = Head;
        
        foreach (var number in list)
        {
            currentNode.Value = number;
            currentNode.Next = new Node();
            
            currentNode = currentNode.Next;
        }
    }

    public override string ToString()
    {
        if (Head == null)
            return "[ ]";
        
        var result = "[";
        
        var currentNode = Head;

        while (currentNode.Next != null)
        {
            result += currentNode.Value + ", ";
            currentNode = currentNode.Next;
        }

        result = result.Substring(0, result.Length - 2);

        result += "]";
        
        return result;
    }
}