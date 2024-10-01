namespace WebAppMvcClientLocation.Data
{
    public class InsertResult
    {

        public bool Succeeded { get; set; }
        private List<string> errors = new List<string>();
        public IEnumerable<string> Errors => errors;
        public void AddError(string error)
        {
            errors.Add(error);

        }
    }
}
