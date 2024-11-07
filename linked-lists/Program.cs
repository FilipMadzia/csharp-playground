using linked_lists.MyLinkedListNamespace;

namespace linked_lists;

static class Program
{
    static void Main()
    {
        var myLinkedList = new MyLinkedList<int>([3, 2, 4, 1]);
        var stringLinkedList = new MyLinkedList<string>(["hello", "world", "from", "Poland"]);
        
        foreach (var item in stringLinkedList)
        {
            Console.Write(item + " ");
        }

        /*Console.WriteLine(myLinkedList);
        Console.WriteLine(myLinkedList.Length);
        Console.WriteLine(myLinkedList.Last);*/

        foreach (var item in myLinkedList)
        {
            Console.Write(item + " ");
        }
    }
}