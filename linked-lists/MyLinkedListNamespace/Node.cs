namespace linked_lists.MyLinkedListNamespace;

public class Node<T>
{
    public T Value { get; set; }
    public Node<T>? Next { get; set; }

    public override string ToString()
    {
        return $"Value:\t{Value}" +
               $"\nNext:\t{Next}";
    }
}