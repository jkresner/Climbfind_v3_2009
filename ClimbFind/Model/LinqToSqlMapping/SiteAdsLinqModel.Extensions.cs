using System;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects.Interfaces;

namespace ClimbFind.Model.LinqToSqlMapping
{   
    public partial class Ad : IKeyObject<int> { }

    public partial class AdClick : IKeyObject<int> { }

    public partial class AdClient : IKeyObject<int> { }

    public partial class AdProduct : IKeyObject<int> { }

}
