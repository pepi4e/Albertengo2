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
            
            setNetwork(true);
        }

        private void ethernet_NetworkDown(Module.NetworkModule sender, Module.NetworkModule.NetworkState state)
        {
            Debug.Print("Disconnected from network.");
            setNetwork(false);
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

            if ( !TIME_SYNCHRONIZED )
            {

                Debug.Print("Attempt B2 - Synchronizing Time Reference....");
                GETContent get = new GETContent();
                String pathB = httpPath + "SmartService.svc/web/Time/";
                var reqB = HttpHelper.CreateHttpGetRequest(pathB, get);
                Debug.Print("HTTP request to server: " + pathB);

                reqB.ResponseReceived += new HttpRequest.ResponseHandler(req_ResponseReceived);
                reqB.ResponseReceived += new HttpRequest.ResponseHandler(Synchronize_Time);
                reqB.SendRequest();
            }
            

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
  
            Debug.Print("Measurement --- Light " + l + " - Temperature " + m.Temperature + " - Moisture " + mois );
               
            if ( ! NETWORK_UP )
                Debug.Print("Network down... not sending data to server.");
            else 
            {
                Debug.Print("Sending data to server....");

                Debug.Print("Attempt B1 - Sending data to server using just POST....");

                POSTContent emptyPost = new POSTContent();
                String pathA = httpPath + "SmartService.svc/web/Measurements/Create/" + m.Temperature.ToString().Substring(0, 4) +
                               "/" + l.ToString().Substring(0, 4) + "/" + mois.ToString() + "/";
                var reqA = HttpHelper.CreateHttpPostRequest(pathA, emptyPost, null);
                Debug.Print("HTTP request to server: " + pathA);
          
                reqA.ResponseReceived += new HttpRequest.ResponseHandler(req_ResponseReceived);
                reqA.SendRequest();
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

        private void Synchronize_Time(HttpRequest sender, HttpResponse response)
        {
            if (response.StatusCode == "200")
            {

                String content = response.Text;
                Debug.Print("----------------------------------------------------------");
                Debug.Print("Time Received... " + content + " trying to synchronize ....");
                DateTime d = new DateTime(Int16.Parse(content.Substring(1, 4)), 
                                          Int16.Parse(content.Substring(5, 2)),
                                          Int16.Parse(content.Substring(7, 2)),
                                          Int16.Parse(content.Substring(9, 2)),
                                          Int16.Parse(content.Substring(11, 2)),
                                          Int16.Parse(content.Substring(13, 2)));
                TimeService.SetUtcTime(d.Ticks);
                Debug.Print("Time Synchronized at " + d.ToString());
                setTimeSynch(true);
                Debug.Print("----------------------------------------------------------");
            }
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
