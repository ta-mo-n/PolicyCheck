
namespace PolicyCheck.src.module
{
    public struct PolicyKeyValue
    {
        public string PolicyName { get; set; }

        public string KeyName { get; set; }

        public string ValueName { get; set; }

        public string ValueType { get; set; }

        public string ValueLength { get; set; }

        public string ValueData { get; set; }
    }

    public enum PolicyKeyValueEnum : int
    {
        KeyName = 0,

        ValueName = KeyName,

        ValueType,

        ValueLength,

        ValueData,

        End,
    }
}