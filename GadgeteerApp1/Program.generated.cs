//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GadgeteerApp1 {
    using Gadgeteer;
    using GTM = Gadgeteer.Modules;
    
    
    public partial class Program : Gadgeteer.Program {
        
        /// <summary>The USB Client SP module using socket 1 of the mainboard.</summary>
        private Gadgeteer.Modules.GHIElectronics.USBClientSP usbClientSP;
        
        /// <summary>The LightSense module using socket 10 of the mainboard.</summary>
        private Gadgeteer.Modules.GHIElectronics.LightSense light;
        
        /// <summary>The TempHumid SI70 module using socket 11 of the mainboard.</summary>
        private Gadgeteer.Modules.GHIElectronics.TempHumidSI70 temp;
        
        /// <summary>The Moisture module using socket 9 of the mainboard.</summary>
        private Gadgeteer.Modules.GHIElectronics.Moisture moisture;
        
        /// <summary>The Camera module using socket 3 of the mainboard.</summary>
        private Gadgeteer.Modules.GHIElectronics.Camera camera;
        
        /// <summary>The Ethernet J11D module using socket 7 of the mainboard.</summary>
        private Gadgeteer.Modules.GHIElectronics.EthernetJ11D ethernet;
        
        /// <summary>The LED Strip module using socket 14 of the mainboard.</summary>
        private Gadgeteer.Modules.GHIElectronics.LEDStrip ledStrip;
        
        /// <summary>The Breakout module using socket 12 of the mainboard.</summary>
        private Gadgeteer.Modules.GHIElectronics.Breakout breakout;
        
        /// <summary>This property provides access to the Mainboard API. This is normally not necessary for an end user program.</summary>
        protected new static GHIElectronics.Gadgeteer.FEZSpider Mainboard {
            get {
                return ((GHIElectronics.Gadgeteer.FEZSpider)(Gadgeteer.Program.Mainboard));
            }
            set {
                Gadgeteer.Program.Mainboard = value;
            }
        }
        
        /// <summary>This method runs automatically when the device is powered, and calls ProgramStarted.</summary>
        public static void Main() {
            // Important to initialize the Mainboard first
            Program.Mainboard = new GHIElectronics.Gadgeteer.FEZSpider();
            Program p = new Program();
            p.InitializeModules();
            p.ProgramStarted();
            // Starts Dispatcher
            p.Run();
        }
        
        private void InitializeModules() {
            this.usbClientSP = new GTM.GHIElectronics.USBClientSP(1);
            this.light = new GTM.GHIElectronics.LightSense(10);
            this.temp = new GTM.GHIElectronics.TempHumidSI70(11);
            this.moisture = new GTM.GHIElectronics.Moisture(9);
            this.camera = new GTM.GHIElectronics.Camera(3);
            this.ethernet = new GTM.GHIElectronics.EthernetJ11D(7);
            this.ledStrip = new GTM.GHIElectronics.LEDStrip(14);
            this.breakout = new GTM.GHIElectronics.Breakout(12);
        }
    }
}
