namespace Kokosnoot.Models.Persistence
{
    public class Document
    {
        public string Id { get; set; }

        public bool IsNew
        {
            get
            {
                return string.IsNullOrEmpty(Id);
            }
        }
    }
}
