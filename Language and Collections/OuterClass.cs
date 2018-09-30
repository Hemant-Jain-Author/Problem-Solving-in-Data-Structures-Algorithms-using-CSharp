public class OuterClass
{

	public static class NestedClass
	{

		// NestedClass fields and methods.
	}

	// OuterClass fields and methods.
}

public class LinkedList
{
	private class Node
	{
		internal int value;
		internal Node next;
		// Nested Class Node other fields and methods.
	}

	private Node head;
	// Outer Class LinkedList other fields and methods.
}

public class Tree
{
	private class Node
	{
		private int value;
		private Node lChild;
		private Node rChild;
		// Nested Class Node other fields and methods.	
	}

	private Node root;
	// Outer Class Tree other fields and methods.
}
