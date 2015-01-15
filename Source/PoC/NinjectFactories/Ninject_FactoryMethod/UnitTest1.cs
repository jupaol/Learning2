using System;
using System.Linq;
using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;

namespace Ninject_FactoryMethod
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void should_not_add_a_binding_for_script_factory()
        {
            ContainerInitializer.Initialize();
            var f = ServiceLocator.Current.GetInstance<IScriptsFactory>();

            Console.WriteLine(f.Create(ScriptOrchestrators.MultipleTransactions));

            
        }
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class FactoryMappingAttribute : Attribute
    {
        public FactoryMappingAttribute(Type enumType, int a)
        {
            EnumType = enumType;
            A = a;
        }

        public Type EnumType { get; private set; }

        public int A { get; private set; }
    }

    public static class ContainerInitializer
    {
        public static void Initialize()
        {
            var kernel = new StandardKernel();

            kernel.Bind(c => c.FromThisAssembly()
                .SelectAllClasses()
                .WithoutAttribute<FactoryMappingAttribute>()
                .Excluding<UseFirstArgumentAsNameInstanceProvider>()
                .BindAllInterfaces()
                .Configure(x =>
                {
                    var target = x.BindingConfiguration.GetProvider().
                    var f = Attribute.GetCustomAttribute()
                    x.WhenClassHas<FactoryMappingAttribute>().Named()
                }));

            //kernel.Bind(c => c.FromThisAssembly()
            //    .SelectAllClasses()
            //    .WithAttribute<FactoryMappingAttribute>()
            //    .Excluding<UseFirstArgumentAsNameInstanceProvider>()
            //    .BindAllInterfaces()
            //    .Configure(z =>
            //    {
                    
            //    }));

            kernel.Bind<ScriptsOrchestrator>()
                .To<MultipleTransactionsOrchestrator>()
                .Named(string.Format("{0}_{1}", typeof (ScriptOrchestrators).FullName,
                    ScriptOrchestrators.MultipleTransactions));
            kernel.Bind<ScriptsOrchestrator>().To<SingleTransactionOrchestrator>().Named("single");

            kernel.Bind<IScriptsFactory>().ToFactory(() => new UseFirstArgumentAsNameInstanceProvider());

            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(kernel));
            kernel.Bind<IServiceLocator>().ToConstant(ServiceLocator.Current);

            
        }
    }

    public enum ScriptOrchestrators
    {
        SingleTransaction,
        MultipleTransactions
    }

    public interface IScriptsFactory
    {
        ScriptsOrchestrator Create(ScriptOrchestrators scriptOrchestrators);
    }

    public abstract class ScriptsOrchestrator
    {
        public abstract string Create();
    }

    [FactoryMappingAttribute(typeof(ScriptOrchestrators), (int)ScriptOrchestrators.MultipleTransactions)]
    public class MultipleTransactionsOrchestrator : ScriptsOrchestrator
    {
        public override string Create()
        {
            return GetType().ToString();
        }
    }

    public class SingleTransactionOrchestrator : ScriptsOrchestrator
    {
        public override string Create()
        {
            return GetType().ToString();
        }
    }

    public class UseFirstArgumentAsNameInstanceProvider : StandardInstanceProvider
    {
        protected override string GetName(System.Reflection.MethodInfo methodInfo, object[] arguments)
        {
            var @enum = (Enum)arguments[0];

            return string.Format("{0}_{1}", @enum.GetType().FullName, @enum);
        }

        protected override Ninject.Parameters.IConstructorArgument[] GetConstructorArguments(System.Reflection.MethodInfo methodInfo, object[] arguments)
        {
            return base.GetConstructorArguments(methodInfo, arguments).Skip(1).ToArray();
        }
    }
}
