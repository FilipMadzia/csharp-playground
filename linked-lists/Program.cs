using linked_lists.MyLinkedListNamespace;

namespace linked_lists;

static class Program
{
    static void Main()
    {
        var myLinkedList = new MyLinkedList([3, 2, 4, 1]);

        /*Console.WriteLine(myLinkedList);
        Console.WriteLine(myLinkedList.Length);
        Console.WriteLine(myLinkedList.Last);*/

        foreach (var item in myLinkedList)
        {
            Console.WriteLine(item);
        }
    }
}