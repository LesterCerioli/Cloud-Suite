namespace CloudSuite.Modules.Domain.Helpers
{
    public sealed class StringCollection
    {
        public bool? Modificado => this.Any(item => !string.IsNullOrEmpty((string?)item));

        private bool? Any(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}