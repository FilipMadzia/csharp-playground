using linked_lists.MyLinkedListNamespace;

namespace linked_lists;

static class Program
{
    static void Main()
    {
        var myLinkedList = new MyLinkedList<int> { 1, 3, 6, 2, 5 };

        var sum = 0;

        foreach (var item in myLinkedList)
        {
            sum += item;
        }

        Console.WriteLine(sum);
    }
}