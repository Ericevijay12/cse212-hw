public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add new people to the queue with a name and number of turns
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue and return them. Handles finite and infinite turns correctly.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        if (person.Turns <= 0)
        {
            // Infinite turns, re-add to the queue without modifying Turns
            _people.Enqueue(person);
        }
        else if (person.Turns > 1)
        {
            // Decrease turns and re-enqueue
            person.Turns -= 1;
            _people.Enqueue(person);
        }
        // If Turns == 1, they don't get added back. This was their final turn.

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}