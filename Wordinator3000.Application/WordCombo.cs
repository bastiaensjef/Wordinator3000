namespace Wordinator3000.Application
{
    public class WordCombo
    {
        private string[] _parts;
        public string[] Parts 
        {
            get 
            {
                return _parts;
            }
        }

        public string this[int i] 
        {
            get 
            {
                return _parts[i];
            }
            set 
            {
                _parts[i] = value;
            }
        }

        public string FullWord 
        {
            get 
            {
                return string.Concat(_parts);
            } 
        }

        public string SumOfWords 
        {
            get 
            {
                return $"{string.Join("+", _parts)}={FullWord}";
            }
        }

        public WordCombo(int length) 
        {
            _parts = new string[length];
        }
        
        public WordCombo(string[] parts)
        {
            _parts = parts;
        }
    }
}
