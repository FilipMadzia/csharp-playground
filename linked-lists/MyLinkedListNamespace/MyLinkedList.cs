using System.Collections;

namespace linked_lists.MyLinkedListNamespace;

public class MyLinkedList<T> : ICollection<T>
{
    public Node<T>? First { get; private set; }
    public Node<T>? Last => GetLast();
    public int Count => GetCount();
    public bool IsReadOnly => false;

    int GetCount()
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

    Node<T>? GetLast()
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

    public void Add(T item)
    {
        if (Last == null)
            First = new() { Value = item };
        else
            Last.Next = new() { Value = item };
    }

    public bool Remove(T item)
    {
        if (First == null)
            return false;
        if (item == null)
            return false;
        
        if (item.Equals(First.Value))
        {
            First = First.Next;
            First = null;
            
            return true;
        }

        var previousNode = First;
        var currentNode = First.Next;

        while (currentNode != null && !item.Equals(currentNode.Value))
        {
            previousNode = currentNode;
            currentNode = currentNode.Next;
        }
        
        if (currentNode == null)
            return false;
        
        previousNode.Next = currentNode.Next;

        return true;
    }

    public void Clear()
    {
        First = null;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        foreach (var nodeValue in this)
        {
            if (item != null && item.Equals(nodeValue))
                return true;
        }

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = First;

        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override string ToString()
    {
        var linkedListAsString = string.Empty;

        foreach (var nodeValue in this)
        {
            linkedListAsString += nodeValue + ", ";
        }
        
        linkedListAsString = linkedListAsString.TrimEnd(',', ' ');
        
        return linkedListAsString;
    }
}