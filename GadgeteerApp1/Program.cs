using System;
using System.Collections;
using System.Threading;
using Microsoft.SPOT;

using Gadgeteer.Networking;
using Gadgeteer.Modules;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using Gadgeteer.Modules.GHIElectronics;
using GHI.Glide;
using GHI.Glide.Display;
using GHI.Glide.UI;
using GHI.Networking;
using Gadgeteer;
using tempuri.org;
using Microsoft.SPOT.Time;
using System.Net;
using Ws.Services.Binding;
using Ws.Services;
using schemas.datacontract.org.ClassLibrary;

namespace GadgeteerApp1
{
    public partial class Program
    {
        
        private static bool AUTOPILOT, IRRIGATING, NETWORK_UP, TIME_SYNCHRONIZED;

        private static String httpPath = "http://192.168.0.1:62607/";
        
        /*
         * LEDS: 
         * 0. INTERNET CONNECTION ON
         * 1. TIME SYNCHRONIZED ON
         * 2. MEASURING (BLINK)
         * 3. IRRIGATING (BLINK)
         * 4. 
         * 5. INTERNET CONNECTION OFF
         * 6. TIME SYNCHRONIZED OFF
         */

        private static int NETWORK_LED_UP = 0;
        private static int TIME_LED_UP = 1;
        private static int MEASUREMENT_LED = 2;
        private static int IRRIGATION_LED = 3;
        private static int NETWORK_LED_DOWN = 5;
        private static int TIME_LED_DOWN = 6;

        void ProgramStarted()
        {
            Debug.Print("Program Started");

            loadNetwork();
            loadTimers();
        }

        private void loadNetwork()
        {

            this.ethernet.UseThisNetworkInterface();
            String[] dns = { "192.168.0.1", "192.168.0.1" };
            this.ethernet.UseStaticIP("192.168.0.10", "255.255.255.0", "192.168.0.1", dns);
            if (!this.ethernet.NetworkInterface.Opened) { this.ethernet.NetworkInterface.Open(); }
            if (!this.ethernet.NetworkInterface.IsDynamicDnsEnabled) { this.ethernet.NetworkInterface.EnableDynamicDns(); }

            this.ethernet.NetworkUp += new GTM.Module.NetworkModule.NetworkEventHandler(ethernet_NetworkUp);
            this.ethernet.NetworkDown += new GTM.Module.NetworkModule.NetworkEventHandler(ethernet_NetworkDown);
            
            //           TimeService.SystemTimeChanged += new SystemTimeChangedEventHandler(TimeService_SystemTimeChanged);
            //         TimeService.TimeSyncFailed += new TimeSyncFailedEventHandler(TimeService_TimeSyncFailed);            
        }

        private void ethernet_NetworkUp(Module.NetworkModule sender, Module.NetworkModule.NetworkState state)
        {
            Debug.Print("------------------------------------");
            Debug.Print("Connected to network.");
            Debug.Print("Network settings:");
            Debug.Print("IP Address: " + ethernet.NetworkSettings.IPAddress);
            Debug.Print("Subnet Mask: " + ethernet.NetworkSettings.SubnetMask);
            Debug.Print("Default Getway: " + ethernet.NetworkSettings.GatewayAddress);
            Debug.Print("DNS Server: " + ethernet.NetworkSettings.DnsAddresses[0]);
            Debug.Print("------------------------------------");

       //     WebServer.StartLocalServer("127.0.0.1", 8080);

            /*
            TimeServiceSettings settings = new TimeServiceSettings();
            settings.ForceSyncAtWakeUp = true;
            settings.RefreshTime = 1800;    // in seconds.

            IPAddress[] address = Dns.GetHostEntry("time-a.nist.gov").AddressList;
            if (address != null && address.Length > 0)
                settings.PrimaryServer = address[0].GetAddressBytes();

            address = Dns.GetHostEntry("pool.ntp.org").AddressList;
            if (address != null && address.Length > 0)
                settings.AlternateServer = address[0].GetAddressBytes();

            TimeService.Settings = settings;
            TimeService.SetTimeZoneOffset(60);
            TimeService.Start();
            */
            setNetwork(true);
        }

        private void ethernet_NetworkDown(Module.NetworkModule sender, Module.NetworkModule.NetworkState state)
        {
            Debug.Print("Disconnected from network.");
            setNetwork(false);
        }

        private void TimeService_SystemTimeChanged(object sender, SystemTimeChangedEventArgs e)
        {
            Debug.Print("Network time received.");
            if (!TIME_SYNCHRONIZED)
                setTimeSynch(true);
        }

        private void TimeService_TimeSyncFailed(object sender, TimeSyncFailedEventArgs e)
        {
            Debug.Print("Error synchronizing system time with NTP server: " + e.ErrorCode);
            if ( TIME_SYNCHRONIZED )
                setTimeSynch(false);
        }

        private void loadTimers()
        {
            Debug.Print("Starting 20s timer . . .");
            GT.Timer timer = new GT.Timer(20000);
            timer.Tick += timer_TakeMeasure;
            timer.Start();
            Debug.Print("Timer started.");

            Debug.Print("Starting 1m timer . . .");
            GT.Timer timer2 = new GT.Timer(60000);
            timer2.Tick += timer_takePicture;
            timer2.Tick += timer_checkSchedule;
            timer2.Tick += timer_checkParameters;
            timer2.Start();
            Debug.Print("Timer started.");
        }

        private void timer_checkParameters(GT.Timer timer)
        {
            /*
            if ( ! NETWORK_UP )
            {
                Debug.Print("Network down... unable to read data from server.");
                return;
            }

            var req = HttpHelper.CreateHttpGetRequest(httpPath);

            req.ResponseReceived += new HttpRequest.ResponseHandler(req_ResponseReceived);
            req.SendRequest();
            */
        }

        private void timer_checkSchedule(GT.Timer timer)
        {
            if ( !NETWORK_UP )
            {
                Debug.Print("Network down... unable to read data from server.");
                return;
            }

            /*
            var req = HttpHelper.CreateHttpGetRequest(httpPath+"Schedules");

            req.ResponseReceived += new HttpRequest.ResponseHandler(req_ResponseReceived);
            req.SendRequest();
            */
            
        }

        private void timer_takePicture(GT.Timer timer)
        {
            Debug.Print("Taking picture...");
            camera.TakePicture();
            Debug.Print("Picture taken.");
        }

        private bool checkIrrigationNecessary(double temp, double l, double mois)
        {
            Debug.Print("AutoPilot ON . . . Checking Irrigation");
            return false;
        }

        private void irrigate()
        {
            //Activate the motor
        }

        private void timer_TakeMeasure(GT.Timer timer)
        {

            Debug.Print("Measuring conditions ... ");
            GT.Timer t = new GT.Timer(300);
            t.Tick += timer_blinkLed;
            t.Start();
            TempHumidSI70.Measurement m = temp.TakeMeasurement();
            double l = light.ReadProportion();
            int mois = moisture.ReadMoisture();

            
            Measurement ms = new Measurement()
            {
                Time = DateTime.Now,
                Temperature = m.Temperature,
                Light = l,
                Moisture = mois
            }; 
  
            Debug.Print("Measurement --- " + ms.Time.ToString() + ": - Light " + ms.Light
                + " - Temperature " + ms.Temperature + " - Moisture " + ms.Moisture );

               
            if ( ! NETWORK_UP )
                Debug.Print("Network down... not sending data to server.");
         //   else if ( ! TIME_SYNCHRONIZED )
           //     Debug.Print("Time not synchronized... not sending data to server.");
            else 
            {
                Debug.Print("Sending data to server....");

                /*
                Debug.Print("Attempt A - Sending data to server using MfSvcUtil and built-in classes....");

                tempuri.org.CreateMeasurement cm = new tempuri.org.CreateMeasurement();
                cm.m = new schemas.datacontract.org.SGService.MeasurementContract();
                cm.m.measurement = ms;
                
                //WebBinding b = new WebBinding(new HttpTransportBindingElement(new HttpTransportBindingConfig(new Uri("http://192.168.0.1:62607/"))));
                //b.CreateClientChannel(new ClientBindingContext(new ProtocolVersion11()));
                
                ISmartServiceClientProxy scproxy = new ISmartServiceClientProxy(new WS2007HttpBinding(), new ProtocolVersion11());
                scproxy.EndpointAddress = "http://192.168.0.1:62607/SmartService.svc";
                scproxy.CreateMeasurement(cm);
                */
                
                Debug.Print("Attempt B - Sending data to server using just POST....");

                //Let's change the time so that it will get in the DB (time is Primary Key)
                ms.Time = DateTime.Now;

                POSTContent emptyPost = new POSTContent();

                String path = httpPath + "SmartService.svc/Measurements/Create/" + ms.Temperature.ToString().Substring(0, 4) + "/" + ms.Light.ToString().Substring(0, 4) + "/" + ms.Moisture.ToString() + "/";
                var req = HttpHelper.CreateHttpPostRequest(path, emptyPost, null);
                
                Debug.Print("HTTP request to server: " + path);
                
                req.ResponseReceived += new HttpRequest.ResponseHandler(req_ResponseReceived);
                req.SendRequest();
                
            }

            Thread.Sleep(1000);
            t.Stop();
            ledStrip.SetLed(MEASUREMENT_LED, false);

            if (AUTOPILOT && !IRRIGATING && checkIrrigationNecessary(m.Temperature, l, mois))
                irrigate();

        }

        bool state = true;
        private void timer_blinkLed(GT.Timer timer)
        {
            state = !state;
            ledStrip.SetLed(MEASUREMENT_LED, state);
        }

        private void req_ResponseReceived(HttpRequest sender, HttpResponse response)
        {
            if (response.StatusCode != "200")
                Debug.Print(response.StatusCode);
            else
                Debug.Print("Data sent to server correctly.");
        }

        private void setNetwork(bool up)
        {
            NETWORK_UP = up;
            ledStrip.SetLed(NETWORK_LED_UP, up);
            ledStrip.SetLed(NETWORK_LED_DOWN, !up);
        }

        private void setTimeSynch(bool b)
        {
            TIME_SYNCHRONIZED = b;
            if ( b )
            {
                ledStrip.SetLed(TIME_LED_UP, b);
                ledStrip.SetLed(TIME_LED_DOWN, !b);
            }
            else
            {
                ledStrip.SetLed(TIME_LED_UP, !b);
                ledStrip.SetLed(TIME_LED_DOWN, b);
            }
        }


    }
}
