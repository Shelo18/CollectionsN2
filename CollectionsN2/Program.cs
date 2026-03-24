namespace CollectionsN2
{
    internal class Program
    {
        static void Main()
        {
            MyList list = new MyList();
            list.Add("Nika");
            list.Add("Tamta");
            list.Add("Beka");

            list.Insert(1, "Luka");
            list[2] = "Keti";

            foreach (var item in list)
            {
                Console.WriteLine("List Item: " + item);
            }
            Console.WriteLine();

            MyQueue queue = new MyQueue();
            queue.Enqueue("Ana");
            queue.Enqueue("Tamuna");
            queue.Enqueue("Salome");

            foreach (var item in queue)
            {
                Console.WriteLine("Queue Item: " + item);
            }

            Console.WriteLine("Dequeued: " + queue.Dequeue());
            Console.WriteLine("Peeked: " + queue.Peek());
            Console.WriteLine();

            MyStack stack = new MyStack();
            stack.Push("Gio");
            stack.Push("Daviti");
            stack.Push("Nika");

            foreach (var item in stack)
            {
                Console.WriteLine("Stack Item: " + item);
            }
            Console.WriteLine("Popped: " + stack.Pop());
        }
    }
}
