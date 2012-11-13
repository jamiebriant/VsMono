using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell.Flavor;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;

namespace BinaryFinery.MonoFlave2010
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    ///
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the 
    /// IVsPackage interface and uses the registration attributes defined in the framework to 
    /// register itself and its components with the shell.
    /// </summary>
    // This attribute tells the PkgDef creation utility (CreatePkgDef.exe) that this class is
    // a package.
    [ProvideProjectFactory(typeof(MonoTouchFlavorProjectFactory),
        "MonoTouch Flavor", "Mono Files (*.csproj);*.csproj", null, null, null)]
    [ProvideProjectFactory(typeof(MonoTouch5FlavorProjectFactory),
        "MonoTouch5 Flavor", "Mono Files (*.csproj);*.csproj", null, null, null)]
    [ProvideProjectFactory(typeof(MonoMacFlavorProjectFactory),
        "MonoMac Flavor", "Mono Files (*.csproj);*.csproj", null, null, null)]
    [PackageRegistration(UseManagedResourcesOnly = true)]
    // This attribute is used to register the informations needed to show the this package
    // in the Help/About dialog of Visual Studio.
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [Guid(GuidList.guidMonoFlave2010PkgString)]
    public sealed class MonoFlave2010Package : Package
    {
        /// <summary>
        /// Default constructor of the package.
        /// Inside this method you can place any initialization code that does not require 
        /// any Visual Studio service because at this point the package object is created but 
        /// not sited yet inside Visual Studio environment. The place to do all the other 
        /// initialization is the Initialize method.
        /// </summary>
        public MonoFlave2010Package()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }



        /////////////////////////////////////////////////////////////////////////////
        // Overriden Package Implementation
        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initilaization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            Trace.WriteLine (string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
            this.RegisterProjectFactory(new MonoTouchFlavorProjectFactory(this));
            this.RegisterProjectFactory(new MonoTouch5FlavorProjectFactory(this));
            this.RegisterProjectFactory(new MonoMacFlavorProjectFactory(this));
            base.Initialize();

        }
        #endregion

    }

    [ComVisible(false)]
    [Guid(MonoProjectFactoryGuid)]
    public class MonoTouchFlavorProjectFactory : FlavoredProjectFactoryBase
    {
        private const string MonoProjectFactoryGuid = "E613F3A2-FE9C-494F-B74E-F63BCB86FEA6";
        //private const string MonoProjectFactoryGuid = "628E6A0A-36B0-4a79-BB2E-3E1B3BB38C82";
        private MonoFlave2010Package package;

        public MonoTouchFlavorProjectFactory(MonoFlave2010Package package)
            : base()
        {
            this.package = package;
        }

        protected override object PreCreateForOuter(IntPtr outerProjectIUnknown)
        {
            return new MonoTouchFlavePackageProject(this.package);
        }
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid(PackageProjectGuid)]
    public class MonoTouchFlavePackageProject : FlavoredProjectBase
    {
        private const string PackageProjectGuid = "628E6A0A-36B0-4a79-BB2E-3E1B3BB38C82";
        //private const string PackageProjectGuid = "E613F3A2-FE9C-494F-B74E-F63BCB86FEA6";
        private MonoFlave2010Package package;

        public MonoTouchFlavePackageProject(MonoFlave2010Package package)
        {
            this.package = package;
        }

        protected override void SetInnerProject(IntPtr innerIUnknown)
        {
            if (base.serviceProvider == null)
            {
                base.serviceProvider = this.package;
            }

            base.SetInnerProject(innerIUnknown);
        }

    }

    [ComVisible(false)]
    [Guid(MonoTouch5ProjectFactoryGuid)]
    public class MonoTouch5FlavorProjectFactory : FlavoredProjectFactoryBase
    {
        private const string MonoTouch5ProjectFactoryGuid = "6BC8ED88-2882-458C-8E55-DFD12B67127B";
        private MonoFlave2010Package package;

        public MonoTouch5FlavorProjectFactory(MonoFlave2010Package package)
            : base()
        {
            this.package = package;
        }

        protected override object PreCreateForOuter(IntPtr outerProjectIUnknown)
        {
            return new MonoTouch5FlavePackageProject(this.package);
        }
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid(PackageProjectGuid)]
    public class MonoTouch5FlavePackageProject : FlavoredProjectBase
    {
        private const string PackageProjectGuid = "FDB50E18-0B79-4B8F-A500-B82729B03842";
        private MonoFlave2010Package package;

        public MonoTouch5FlavePackageProject(MonoFlave2010Package package)
        {
            this.package = package;
        }

        protected override void SetInnerProject(IntPtr innerIUnknown)
        {
            if (base.serviceProvider == null)
            {
                base.serviceProvider = this.package;
            }

            base.SetInnerProject(innerIUnknown);
        }

    }


    [ComVisible(false)]
    [Guid(MonoMacProjectFactoryGuid)]
    public class MonoMacFlavorProjectFactory : FlavoredProjectFactoryBase
    {
        private const string MonoMacProjectFactoryGuid = "1C533B1C-72DD-4CB1-9F6B-BF11D93BCFBE";
        //private const string MonoProjectFactoryGuid = "628E6A0A-36B0-4a79-BB2E-3E1B3BB38C82";
        private MonoFlave2010Package package;

        public MonoMacFlavorProjectFactory(MonoFlave2010Package package)
            : base()
        {
            this.package = package;
        }

        protected override object PreCreateForOuter(IntPtr outerProjectIUnknown)
        {
            return new MonoMacFlavePackageProject(this.package);
        }
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid(PackageProjectGuid)]
    public class MonoMacFlavePackageProject : FlavoredProjectBase
    {
        private const string PackageProjectGuid = "8EF05C55-2E27-4F2C-9ABD-79EB3C74635C";
        //private const string PackageProjectGuid = "E613F3A2-FE9C-494F-B74E-F63BCB86FEA6";
        private MonoFlave2010Package package;

        public MonoMacFlavePackageProject(MonoFlave2010Package package)
        {
            this.package = package;
        }

        protected override void SetInnerProject(IntPtr innerIUnknown)
        {
            if (base.serviceProvider == null)
            {
                base.serviceProvider = this.package;
            }

            base.SetInnerProject(innerIUnknown);
        }

    }

}
