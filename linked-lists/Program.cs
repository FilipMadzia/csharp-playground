using linked_lists.MyLinkedListNamespace;

namespace linked_lists;

static class Program
{
    static void Main()
    {
        var myLinkedList = new MyLinkedList([1, 2, 3, 4, 5]);

        Console.WriteLine(myLinkedList);
        Console.WriteLine(myLinkedList.Length);
    }
}