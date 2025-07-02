namespace Quantaventis.Trading.Modules.Transmission.Domain.Model
{
    internal class FileName
    {

        internal string Value { get; }

        internal FileName(string value)
        {
            Value = value;
        }
        internal FileName WithoutExtension()
        => new FileName(Path.GetFileNameWithoutExtension(Value));


        internal string GetExtension()
         => Path.GetExtension(Value);



        internal FileName AddTimeStamp(DateTime timeStamp, string format)
        => AddBeforeExtension($"_{timeStamp.ToString(format)}");


        internal FileName AddBeforeExtension(string text)
                 => new FileName($"{WithoutExtension()}{text}{GetExtension()}");

        internal FileName AddExtension(string extension)
            => new FileName($"{Value}.{extension.TrimStart('.')}");

        public override bool Equals(object? obj)
        {
            return obj is FileName name &&
                   Value == name.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        public override string? ToString()
        {
            return Value;
        }
    }
}
