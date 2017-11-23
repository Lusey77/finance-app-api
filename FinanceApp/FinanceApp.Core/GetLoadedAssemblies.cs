using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FinanceApp.Core
{
    public static class GetAssemblies
    {
        public static Assembly[] GetAllLoadedAssemblies()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            return assemblies;
        }

        public static Assembly[] GetAllLoadedAssemblies(string searchString)
        {
            Assembly[] assemblies = GetAllLoadedAssemblies().Where(assembly => assembly.FullName.Contains(searchString)).ToArray();

            return assemblies;
        }

        public static Assembly[] GetAllReferenceAssemblies()
        {
            Assembly assembly = Assembly.GetEntryAssembly();

            HashSet<Assembly> assembliesChecked = new HashSet<Assembly>();

            Stack<Assembly> assembliesToCheck = new Stack<Assembly>();

            assembliesToCheck.Push(assembly);

            while (assembliesToCheck.Count() != 0)
            {
                assembly = assembliesToCheck.Pop();

                if (assembliesToCheck.Contains(assembly)) continue;

                assembliesChecked.Add(assembly);

                foreach (AssemblyName referencedAssembly in assembly.GetReferencedAssemblies())
                {
                    assembliesToCheck.Push(Assembly.Load(referencedAssembly));
                }
            }
            
            return assembliesChecked.ToArray();
        }

        public static Assembly[] GetAllReferenceAssemblies(string searchString)
        {
            Assembly[] assemblies = GetAllReferenceAssemblies().Where(assembly => assembly.FullName.Contains(searchString)).ToArray();

            return assemblies;
        }

        public static Assembly[] GetAllReferenceAssemblies(Assembly assembly)
        {
            HashSet<Assembly> assembliesChecked = new HashSet<Assembly>();

            Stack<Assembly> assembliesToCheck = new Stack<Assembly>();

            assembliesToCheck.Push(assembly);

            while (assembliesToCheck.Count() != 0)
            {
                assembly = assembliesToCheck.Pop();

                if (assembliesToCheck.Contains(assembly)) continue;

                assembliesChecked.Add(assembly);

                foreach (AssemblyName referencedAssembly in assembly.GetReferencedAssemblies())
                {
                    assembliesToCheck.Push(Assembly.Load(referencedAssembly));
                }
            }

            return assembliesChecked.ToArray();
        }

        public static Assembly[] GetAllReferenceAssemblies(Assembly referenceAssembly, string searchString)
        {
            Assembly[] assemblies = GetAllReferenceAssemblies(referenceAssembly).Where(assembly => assembly.FullName.Contains(searchString)).ToArray();

            return assemblies;
        }

        public static Assembly[] GetAllDirectoryAssemblies()
        {
            string binPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin");

            foreach (string dll in Directory.GetFiles(binPath, "*.dll", SearchOption.AllDirectories))
            {
                try
                {
                    Assembly loadedAssembly = Assembly.LoadFile(dll);
                }
                catch (FileLoadException loadEx)
                { }
                catch (BadImageFormatException imgEx)
                { }

            }

            return GetAllLoadedAssemblies();
        }

        public static Assembly[] GetAllDirectoryAssemblies(string searchString)
        {
            string binPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);

            foreach (string dll in Directory.GetFiles(binPath, "*.dll", SearchOption.AllDirectories))
            {
                try
                {
                    Assembly loadedAssembly = Assembly.LoadFile(dll);
                }
                catch (FileLoadException loadEx)
                { }
                catch (BadImageFormatException imgEx)
                { }

            }

            return GetAllLoadedAssemblies(searchString);
        }
    }
}
