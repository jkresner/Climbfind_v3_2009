
namespace ClimbFind.Model.DataAccess
{
    /// <summary>
    /// IDATransactionContext, is used by passing this context into a DA's contructor to 
    /// make that DA transaction aware without passing in a full blown DataContexta and
    /// tightly coupling out DAs implementation with how we run transactions in higher layers
    /// </summary>
    public interface IDATransactionContext { }
}
