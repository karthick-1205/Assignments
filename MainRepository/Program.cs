// Implementation of DoubleEnd Queue using array
TQueue<int> q = new();
q.EnqueueFront(1);
q.EnqueueFront(2);
q.EnqueueFront(3);
while (!q.IsEmpty)
    Console.Write(q.DequeueFront() + " ");
Console.WriteLine();
q.EnqueueRear(1);
q.EnqueueRear(2);
q.EnqueueRear(3);
while (!q.IsEmpty)
    Console.Write(q.DequeueRear() + " ");
class TQueue<T>
{
    // Add element in the front position
    public void EnqueueFront(T a)
    {
        if (mCount == mData.Length)
        {
            T[] tmp = new T[mCount * 2];
            for (int i = 0; i < mCount; i++)
                tmp[i] = mData[(mFront + i) % mCount];
            (mData, mFront, mRear) = (tmp, 0, mCount);
        }
        mFront = (mFront - 1 + mData.Length) % mData.Length;
        mData[mFront] = a;
        mCount++;
        Console.WriteLine($"Inserting {a}");
    }
    // Add element in the rear position
    public void EnqueueRear(T a)
    {
        if (mCount == mData.Length)
        {
            T[] tmp = new T[mCount * 2];
            for (int i = 0; i < mCount; i++)
                tmp[i] = mData[(mFront + i) % mCount];
            (mData, mFront, mRear) = (tmp, 0, mCount);
        }
        mData[mRear] = a;
        mRear = (mRear + 1) % mData.Length;
        mCount++;
        Console.WriteLine($"Inserting {a}");

    }
    // Remove element in the front position
    public T DequeueFront()
    {
        if (IsEmpty) throw new Exception("Queue empty");
        T a = mData[mFront];
        mFront = (mFront + 1 + mData.Length) % mData.Length;
        mCount--;
        return a;
    }
    // Remove element in the rear position
    public T DequeueRear()
    {
        if (IsEmpty) throw new Exception("Queue empty");
        mRear = (mRear - 1 + mData.Length) % mData.Length;
        T a = mData[mRear];
        mCount--;
        return a;
    }
    // Check queue is empty or not
    public bool IsEmpty => mCount == 0;

    int mCount; // Count of elements in the Queue
    int mRear; // Index of the next Enqueue and Dequeue operation
    int mFront;  // Index of the next Enqueue and Dequeue operation
    T[] mData = new T[4];
}