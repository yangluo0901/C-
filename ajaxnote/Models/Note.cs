namespace ajaxnote.Models
{
    public class AddNote
    {
        public string title {get;set;}
       
    }
    public class UpdateNote
    {
        public int id {get;set;}
        public string description {get;set;}
    }
}