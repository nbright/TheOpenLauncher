using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace TheOpenLauncher {
    class DependenciesLoader {
        private static DependenciesLoader loader = null;
        public static void Init() {
            if (loader == null) {
                loader = new DependenciesLoader();
            }
        }

        private DependenciesLoader() {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) => {
                return ResolveAssembly(args.Name);
            };
        }

        private Assembly ResolveAssembly(string name) {
            String resourceName = "TheOpenLauncher.EmbeddedLibs." + new AssemblyName(name).Name + ".dll";
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName)) {
                Byte[] assemblyData = new Byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return Assembly.Load(assemblyData);
            }
        }
    }
}
