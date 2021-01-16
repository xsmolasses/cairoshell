using System.ComponentModel.Composition;
using CairoDesktop.Application.Interfaces;

namespace CairoDesktop.Extensions.MenuBar
{
    [Export(typeof(IDependencyRegistrant))]
    public class DependencyRegistrant : IDependencyRegistrant
    {
        public void Register(IDependencyRegistrar registrar)
        {
            registrar.AddSingleton<SupportingClasses.IWindowService, MenuBarWindowService>();
        }
    }
}