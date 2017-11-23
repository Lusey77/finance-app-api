using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceApp.Core
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public abstract class DependencyLifetimeAttribute : Attribute
    {
    }

    public class ResolveInstance : DependencyLifetimeAttribute
    {
        
    }

    public class ResolveSingleton : DependencyLifetimeAttribute
    {

    }

    public class ResolveScope : DependencyLifetimeAttribute
    {

    }

    public class ResolveMatchingScope : DependencyLifetimeAttribute
    {

    }

    public class ResolveThread : DependencyLifetimeAttribute
    {

    }

    public class ResolvePerRequest : DependencyLifetimeAttribute
    {

    }

    public class ResolvePerOwned : DependencyLifetimeAttribute
    {

    }
}
