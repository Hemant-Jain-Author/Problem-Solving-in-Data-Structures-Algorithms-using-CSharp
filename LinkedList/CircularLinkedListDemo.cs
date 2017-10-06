public class CircularLinkedListDemo
{

	public static void Main(string[] args)
	{
		CircularLinkedList ll = new CircularLinkedList();
		ll.addHead(1);
		ll.addHead(2);
		ll.addHead(3);
		ll.addHead(1);
		ll.addHead(2);
		ll.addHead(3);
		ll.print();
	}
}
