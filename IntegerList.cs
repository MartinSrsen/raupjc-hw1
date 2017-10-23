using System;


namespace IntegerList
{
    class IntegerList : IIntegerList
    {

        private int[] _internalStorage;
        private int[] _helper;
        private int _numberOfItems = 0;

        private void SetDefault()
        {
            _internalStorage = new int[4];
        }

        public IntegerList()
        {
            SetDefault();
        }

        public IntegerList(int initialSize)
        {
            if (initialSize <= 0)
            {

                Console.WriteLine("Storage size must be greater than 0\nSet to default value.");
                Console.ReadLine();
                SetDefault();

            }
            else
            {
                _internalStorage = new int[initialSize];
            }
        }


        public void Add(int item)
        {
            if (_numberOfItems == _internalStorage.Length)
            {
                _helper = new int[_internalStorage.Length];
                for (int i = 0; i < _internalStorage.Length; ++i)
                {
                    _helper[i] = _internalStorage[i];
                }

                _internalStorage = new int[_internalStorage.Length * 2];
                for (int i = 0; i < _helper.Length; ++i)
                {
                    _internalStorage[i] = _helper[i];

                }
                _helper = null;
            }

            _internalStorage[_numberOfItems] = item;
            _numberOfItems++;
        }


        public bool RemoveAt(int index)
        {
            if (index >= _numberOfItems)
            {
                throw new IndexOutOfRangeException();
                
            }
            _internalStorage[index] = 0;
            for (int i = index; i < _numberOfItems - 1; ++i)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }

            _numberOfItems--;
            return true;
        }

        public bool Remove(int item)
        {
            int index = IndexOf(item);

            if (index != -1)
            {
                return RemoveAt(index);
            }

            return false;
        }

        public int GetElement(int index)
        {
            if (index >= _numberOfItems)
            {
                throw new IndexOutOfRangeException();
            }

            return _internalStorage[index];
        }

        public int Count
        {
            get { return _numberOfItems; }
        }

        public int IndexOf(int item)
        {

            for (int i = 0; i < _numberOfItems; ++i)
            {
                if (_internalStorage[i] == item)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(int item)
        {
            if (IndexOf(item) != -1)
            {
                return true;
            }

            return false;
        }

        public void Clear()
        {

            for (int i = 0; i < _numberOfItems; ++i)
            {
                _internalStorage[i] = 0;
            }
            _numberOfItems = 0;

        }
    }
}
