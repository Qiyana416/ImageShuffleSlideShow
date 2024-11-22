using System.Reflection;

namespace ImageShuffleSlideShow
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += ResolveAssembly;

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

        }

        private static Assembly ResolveAssembly(object sender, ResolveEventArgs args)
        {
            var thisAssembly = Assembly.GetExecutingAssembly();
            var name = args.Name.Substring(0, args.Name.IndexOf(',')) + ".dll";

            var resources = thisAssembly.GetManifestResourceNames().Where(s => s.EndsWith(name));
            var enumerable = resources.ToList();
            if (!enumerable.Any()) return null;
            var resourceName = enumerable.First();
            using var stream = thisAssembly.GetManifestResourceStream(resourceName);
            if (stream == null) return null;
            var assembly = new byte[stream.Length];
            stream.Read(assembly, 0, assembly.Length);
            return Assembly.Load(assembly);
        }
    }
}