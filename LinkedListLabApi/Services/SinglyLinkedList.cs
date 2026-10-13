namespace LinkedListLabApi.Services
{
    /// <summary>
    /// Singly Linked List — Standard CRUD Operations.
    /// Registered as Singleton so state persists across HTTP requests.
    /// </summary>
    public class SinglyLinkedList
    {
        // ---------- Internal Node class ----------
        private class Node
        {
            public int Data;
            public Node? Next;
            public Node(int data) { Data = data; Next = null; }
        }

        private Node? _head;   // first node
        private int _size;     // number of nodes

        public int Size => _size;

        // ---------- Traverse ----------
        // Time Complexity: O(n), Space Complexity: O(n)
        public int[] Traverse()
        {
            var list = new System.Collections.Generic.List<int>();
            var current = _head;
            while (current != null)
            {
                list.Add(current.Data);
                current = current.Next;
            }
            return list.ToArray();
        }

        // ---------- Insert at beginning ----------
        // Time Complexity: O(1)
        public void InsertAtBeginning(int value)
        {
            var node = new Node(value);
            node.Next = _head;
            _head = node;
            _size++;
        }

        // ---------- Insert at end ----------
        // Time Complexity: O(n)
        public void InsertAtEnd(int value)
        {
            var node = new Node(value);
            if (_head == null) { _head = node; _size++; return; }

            var current = _head;
            while (current.Next != null) current = current.Next;
            current.Next = node;
            _size++;
        }

        // ---------- Insert at position ----------
        // Position is 0-based. Valid: 0 .. _size. Time Complexity: O(n)
        public (bool ok, string msg) InsertAtPosition(int pos, int value)
        {
            if (pos < 0 || pos > _size)
                return (false, $"Invalid position. Valid range: 0 to {_size}.");

            if (pos == 0) { InsertAtBeginning(value); return (true, "Inserted at position 0."); }

            var current = _head;
            for (int i = 0; i < pos - 1 && current != null; i++)
                current = current.Next;

            if (current == null) return (false, "Position out of range.");

            var node = new Node(value);
            node.Next = current.Next;
            current.Next = node;
            _size++;
            return (true, $"Inserted {value} at position {pos}.");
        }

        // ---------- Delete from beginning ----------
        // Time Complexity: O(1)
        public (bool ok, string msg) DeleteFromBeginning()
        {
            if (_head == null) return (false, "Underflow: list is empty.");
            _head = _head.Next;
            _size--;
            return (true, "Removed first node.");
        }

        // ---------- Delete from end ----------
        // Time Complexity: O(n)
        public (bool ok, string msg) DeleteFromEnd()
        {
            if (_head == null) return (false, "Underflow: list is empty.");
            if (_head.Next == null) { _head = null; _size--; return (true, "Removed last node."); }

            var current = _head;
            while (current.Next!.Next != null) current = current.Next;
            current.Next = null;
            _size--;
            return (true, "Removed last node.");
        }

        // ---------- Delete at position ----------
        // Time Complexity: O(n)
        public (bool ok, string msg) DeleteAtPosition(int pos)
        {
            if (_head == null) return (false, "Underflow: list is empty.");
            if (pos < 0 || pos >= _size)
                return (false, $"Invalid position. Valid range: 0 to {_size - 1}.");

            if (pos == 0) return DeleteFromBeginning();

            var current = _head;
            for (int i = 0; i < pos - 1; i++) current = current.Next!;
            current.Next = current.Next!.Next;
            _size--;
            return (true, $"Removed node at position {pos}.");
        }

        // ---------- Search ----------
        // Time Complexity: O(n)
        public int Search(int key)
        {
            var current = _head;
            int idx = 0;
            while (current != null)
            {
                if (current.Data == key) return idx;
                current = current.Next;
                idx++;
            }
            return -1;
        }

        // ---------- Update at position ----------
        // Time Complexity: O(n)
        public (bool ok, string msg) UpdateAtPosition(int pos, int newValue)
        {
            if (pos < 0 || pos >= _size)
                return (false, $"Invalid position. Valid range: 0 to {_size - 1}.");

            var current = _head;
            for (int i = 0; i < pos; i++) current = current!.Next;
            current!.Data = newValue;
            return (true, $"Updated position {pos} to {newValue}.");
        }

        // ---------- Helper: clear all (for demo resets) ----------
        public void Clear() { _head = null; _size = 0; }
    }
}
