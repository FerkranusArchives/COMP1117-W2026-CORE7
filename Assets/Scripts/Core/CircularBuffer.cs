using System.Collections.Generic;

public class CircularBuffer<T> // Generic indicator
{
    // Collection itself
    private List<T> buffer;

    // Capacity
    private int capacity; // How many objects, not type of object, therefore not T

    // Constructor - allows creation of a circular buffer with a given capacity
    public CircularBuffer(int capacity)
    {
        buffer = new List<T>(capacity);
        this.capacity = capacity;
    }

    // Public property
    public int Count
        { get { return buffer.Count; } }

    // public int Count => buffer.Count - exact same as read-only property above, shorthand

    //Buffer operations:
    // 1. Push (add new info to buffer)
    public void Push(T item) // Push some kind of item
    {
        // Check if buffer is at or above capacity
        if(buffer.Count >= capacity)
        {
            buffer.RemoveAt(0); // Removes oldest data
        }

        buffer.Add(item);
    }
    // 2. Pop (remove next piece of info)
    public T Pop()
    {
        if (buffer.Count == 0) return default(T); // look at default of data type and return its default

        int lastIndex = buffer.Count - 1;
        T item = buffer[lastIndex]; // Creates copy of item in buffer's last index and stores in item
        buffer.RemoveAt(lastIndex); // removes item at last index

        return item;
    }
}
