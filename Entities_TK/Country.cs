namespace Entities_TK
{
    public class Country
    {
        public int Id { get; set; }
        public string? Country_Name { get; set; }
        public ICollection<State>? Statelist { get; set; }=new HashSet<State>();
    }
}