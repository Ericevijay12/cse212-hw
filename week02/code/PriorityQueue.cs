public string Dequeue()
{
    if (_queue.Count == 0)
    {
        throw new InvalidOperationException("The queue is empty.");
    }

    // Fix: Include the last element in the loop by using < _queue.Count
    var highPriorityIndex = 0;
    for (int index = 1; index < _queue.Count; index++)
    {
        if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
        {
            highPriorityIndex = index;
        }
    }

    var value = _queue[highPriorityIndex].Value;
    _queue.RemoveAt(highPriorityIndex); // Also remove it from the list!
    return value;
}
