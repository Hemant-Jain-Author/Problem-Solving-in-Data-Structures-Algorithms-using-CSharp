using System.Collections.Generic;

public class Space
{
	int temp;
}

public class parkingLot
{
	private IDictionary<int, Space> unreservedMap;
	private IDictionary<int, Space> reservedMap;

	public virtual bool reserveSpace(Space sp)
	{



		//It will find if there is space in the 
		//unreserved map 
		//If yes, then we will pick that element and 
		//put into the reserved map with the current time value.
	}

	public virtual int unreserveSpace(Space sp)
	{
		// It will find the entry in reserve map 
		// if yes then we will pick that 
		// Element and put into the unreserved map. 
		// And return the charge units with the current time value.
	}
}
class Machine
{

}
class Person
{

}
public class system
{
	private Dictionary<int, int> personIdToMachineIdMap;
	private Dictionary<int, Machine> machineIdToMachineMap;

	Machine getMachine(int machineId)
	{
		return machineIdToMachineMap[machineId];
	}

	Person getPerson(int personId)
	{
		int machienId = personIdToMachineIdMap[personId];
		Machine m = machineIdToMachineMap[machienId];
		return m.getPersonWithId(personId);
	}
}

class fibdemo
{
	int fibonacci(int n)
	{
		if (n <= 1)
			return n;
		return fibonacci(n - 1) + fibonacci(n - 2);
	}

	int fibo(int n)
	{
		int first = 0, second = 1;
		int temp = 0, i;

		if (n == 0)
			return first;
		else if (n == 1)
			return second;

		for (i = 2; i <= n; i++)
		{
			temp = first + second;
			first = second;
			second = temp;
		}
		return temp;
	}


}