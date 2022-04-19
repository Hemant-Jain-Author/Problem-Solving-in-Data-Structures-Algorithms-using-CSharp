public class System
{
    private map<int, int> personIdToMachineIdMap;
    private map<int, Machine> machineIdToMachineMap;

    Machine GetMachine(int machineId);

    Person GetPerson(int personId)
    {
        int machineId = personIdToMachineIdMap[personId];
        Machine m = machineIdToMachineMap[machineId];
        return m.getPersonWithId(personId);
    }
}
