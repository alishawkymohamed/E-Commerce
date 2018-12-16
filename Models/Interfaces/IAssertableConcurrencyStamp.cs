namespace Models.Interfaces
{
    public interface IAssertableConcurrencyStamp
    {
        string ConcurrencyStamp { get; set; }
    }
}
