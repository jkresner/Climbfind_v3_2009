using System;

namespace ClimbFind.Model.Objects.Interfaces
{
    /// <summary>
    /// IKeyObject is a critical inteface in making our data access parttern work.
    /// It's purpose is to make sure objects have keys that we can user perfrom selects
    /// (and hence updates and deletes).
    ///
    /// Here T is Defined as : IEquatable<T>, this simply means that the key is of a type
    /// where we can user the .Equals method to compare two different objects to see if they
    /// have the same key. In the SSR T is usually either an Int or Guid
    /// </summary>
    public interface IKeyObject<T> : IOOObject where T : IEquatable<T> 
    {
        T ID { get; set; }
    }
}
