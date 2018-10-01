namespace EPCData.API
{
    public class SingleRequestParameter
    {
        public string Name { get; }
        public string Value { get; }

        public SingleRequestParameter(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
