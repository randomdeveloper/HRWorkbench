using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRWorkbench.Candidates;
using Microsoft.Practices.Unity;

namespace HRWorkbench.Tests
{
    public static class Container
    {
        private static readonly IUnityContainer InnerContainer = new UnityContainer();
        
        public static T Resolve<T>()
        {
            return InnerContainer.Resolve<T>();
        }
    }
}
