using System.Collections.Generic;

namespace ArrayLabApi.Services
{
    /// <summary>
    /// Fixed-size array operations (Tasks 01–04).
    /// Registered as a Singleton so state persists across HTTP requests.
    /// </summary>
    public class ArrayOperations
    {
        // ---------- FIELDS (private data) ----------
        private readonly int[] _arr;
        private int _size;

        public int Capacity { get; }

        // ---------- CONSTRUCTOR ----------
        public ArrayOperations(int capacity = 15)
        {
            Capacity = capacity;
            _arr = new int[capacity];
            _size = 0;
        }

        // ---------- PROPERTIES ----------
        public int Size => _size;

        public int[] Snapshot()
        {
            var copy = new int[_size];
            System.Array.Copy(_arr, copy, _size);
            return copy;
        }

        // ================= TASK 01 =================
        // Insert at end. Time complexity: O(1) amortized.
        public bool InsertAtEnd(int value)
        {
            if (_size >= Capacity) return false;
            _arr[_size++] = value;
            return true;
        }

        // Insert at beginning. Time complexity: O(n)
        public bool InsertAtBeginning(int value)
        {
            if (_size >= Capacity) return false;
            for (int i = _size; i > 0; i--) _arr[i] = _arr[i - 1];
            _arr[0] = value;
            _size++;
            return true;
        }

        // ================= TASK 02 =================
        // Insert at arbitrary position.
        public (bool ok, string msg) InsertAtPosition(int pos, int value)
        {
            if (_size >= Capacity)
                return (false, "Overflow: array is full.");

            if (pos < 0 || pos > _size)
                return (false, $"Invalid position. Valid range: 0 to {_size}.");

            for (int i = _size; i > pos; i--) _arr[i] = _arr[i - 1];
            _arr[pos] = value;
            _size++;
            return (true, "Inserted.");
        }

        // Delete element at arbitrary position.
        public (bool ok, string msg) DeleteAtPosition(int pos)
        {
            if (_size == 0)
                return (false, "Underflow: array is empty.");

            if (pos < 0 || pos >= _size)
                return (false, $"Invalid position. Valid range: 0 to {_size - 1}.");

            for (int i = pos; i < _size - 1; i++) _arr[i] = _arr[i + 1];
            _size--;
            return (true, "Deleted.");
        }

        // Delete from end. Time complexity: O(1)
        public bool DeleteFromEnd()
        {
            if (_size == 0) return false;
            _size--;
            return true;
        }

        // ================= TASK 04 =================
        // Delete from beginning. Time complexity: O(n)
        public bool DeleteFromBeginning()
        {
            if (_size == 0) return false;
            for (int i = 0; i < _size - 1; i++) _arr[i] = _arr[i + 1];
            _size--;
            return true;
        }

        // ================= TASK 03 =================
        // Update value at position. Time complexity: O(1)
        public bool UpdateAtPosition(int pos, int newValue)
        {
            if (pos < 0 || pos >= _size) return false;
            _arr[pos] = newValue;
            return true;
        }

        // Linear search → returns FIRST index of key, or -1 if not found.
        public int LinearSearch(int key)
        {
            for (int i = 0; i < _size; i++)
                if (_arr[i] == key) return i;
            return -1;
        }

        // Bonus: return ALL indices where 'key' appears as a List<int>.
        public List<int> LinearSearchAll(int key)
        {
            var list = new List<int>();
            for (int i = 0; i < _size; i++)
                if (_arr[i] == key) list.Add(i);
            return list;
        }

        // ================= HELPER =================
        public void Seed(params int[] values)
        {
            foreach (var v in values)
            {
                if (_size < Capacity) _arr[_size++] = v;
                else break;
            }
        }
    }
}
