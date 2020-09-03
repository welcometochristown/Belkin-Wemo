using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using UPNPLib;

namespace Belkin.WeMo
{
    /// <summary>
    /// TODO : Add future functionality for controlling WeMo sensors
    /// </summary>
    public class WeMoSensor : WeMoDevice
    {
        public WeMoSensor(UPnPDevice device)
            : base(device.FriendlyName, WeMoDeviceSource.Upnp)
        { throw new NotImplementedException(); }

        public WeMoSensor(IPEndPoint device)
            :base("Belkin Wemo Sensor", WeMoDeviceSource.Multicast)
        { throw new NotImplementedException(); }

    }

    /// <summary>
    ///  TODO : Add future functionality for WeMo sensors responses
    /// </summary>
    public class WeMoSensorReponse : WeMoDeviceCommand.Response
    {
        public static WeMoSensorReponse Parse(WebResponse res)
        { throw new NotImplementedException(); }

        public override bool Success
        {
            get
            { throw new NotImplementedException(); }
        }
    }

    /// <summary>
    /// Store Command Information For WeMo Device
    /// </summary>
    public class WeMoDeviceCommand
    {
        //Command Information
        public string Command { get; set; }
        public string CommandName { get; set; }
        public CommandActionEnum CommandAction { get; set; }

        //Reponse for the command
        public Response Result { get; set; }

        /// <summary>
        /// Enum for action we are going to perform with this command
        /// </summary>
        public enum CommandActionEnum
        {
            Unknown, Get, Set
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeMoDeviceCommand"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        public WeMoDeviceCommand(string command, string commandname, CommandActionEnum action = CommandActionEnum.Unknown)
        {
            this.Command = command;
            this.CommandName = commandname;
            this.CommandAction = action;

            this.Result = null;
        }

        /// <summary>
        /// basic response from a WeMo device
        /// </summary>
        public abstract class Response
        {
            //Success of the response
            public abstract bool Success { get;  }  
        }
    }

    /// <summary>
    ///  response from a WeMo switch
    /// </summary>
    public class WeMoSwitchReponse : WeMoDeviceCommand.Response
    {
        //the binary state of the device
        public bool? BinaryState { get; set; }

        protected WeMoSwitchReponse(bool? state)
        {
            BinaryState = state;
        }

        public static WeMoSwitchReponse Parse(WebResponse res)
        {
            bool? state = null;

            try
            {
                //read the xml response
                var xml = new StreamReader(res.GetResponseStream()).ReadToEnd();

                //parse into variable
                var document = XDocument.Parse(xml);

                //get the root node
                var root = document.Root;

                //find the element that has the binary state information
                var found = root.Descendants("BinaryState").FirstOrDefault();

                //if we couldnt find it or the value is error then return a bad response
                if (found == null || found.Value == "Error")
                    return new WeMoSwitchReponse(null);

                try
                {
                    //try to parse to boolean
                    state = Convert.ToBoolean(Convert.ToInt16(found.Value));
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }catch
            {
                state = null;
            }
           
            return new WeMoSwitchReponse(state) ;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="WeMoSwitchReponse"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public override bool Success
        {
            get
            {
                return BinaryState != null;
            }
        }
    }

    /// <summary>
    /// Exposes functionality to control a WeMo outlet switch (On/Off)
    /// </summary>
    public class WeMoSwitch : WeMoDevice
    {
        const string COMMAND_GETSTATE = @"<?xml version=""1.0"" encoding=""utf-8""?><s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"" s:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""><s:Body><u:GetBinaryState xmlns:u=""urn:Belkin:service:basicevent:1""></u:GetBinaryState></s:Body></s:Envelope>";
        const string COMMAND_OFF = @"<?xml version=""1.0"" encoding=""utf-8""?><s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"" s:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""><s:Body><u:SetBinaryState xmlns:u=""urn:Belkin:service:basicevent:1""><BinaryState>0</BinaryState></u:SetBinaryState></s:Body></s:Envelope>";
        const string COMMAND_ON = @"<?xml version=""1.0"" encoding=""utf-8""?><s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"" s:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""><s:Body><u:SetBinaryState xmlns:u=""urn:Belkin:service:basicevent:1""><BinaryState>1</BinaryState></u:SetBinaryState></s:Body></s:Envelope>";
        
        /// <summary>
        /// Create abstraction layer on UPnPDevice
        /// </summary>
        /// <param name="device"></param>
        public WeMoSwitch(UPnPDevice device)
             :base(device.FriendlyName, WeMoDeviceSource.Upnp)
        {
            this.IPDevice = new IPEndPoint( IPAddress.Parse(new Uri(device.PresentationURL).Host),
                                                            new Uri(device.PresentationURL).Port);
        }

        /// <summary>
        /// Create abstraction layer on IPEndPoint
        /// </summary>
        /// <param name="device"></param>
        public WeMoSwitch(IPEndPoint device)
            :base("Belkin Wemo Switch", WeMoDeviceSource.Multicast)
        {
            this.IPDevice = device;
        }

        #region Commands (BinaryState)

        /// <summary>
        /// Send command to underlying device to turn on
        /// </summary>
        /// <returns></returns>
        public WeMoSwitchReponse On()
        {
            return SendBinaryStateCommand(COMMAND_ON, WeMoDeviceCommand.CommandActionEnum.Set);
        }

        /// <summary>
        /// Send command to underlying device to turn off
        /// </summary>
        /// <returns></returns>
        public WeMoSwitchReponse Off()
        {
            return SendBinaryStateCommand(COMMAND_OFF, WeMoDeviceCommand.CommandActionEnum.Set);
        }

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <returns></returns>
        public WeMoSwitchReponse GetState()
        {
            return SendBinaryStateCommand(COMMAND_GETSTATE, WeMoDeviceCommand.CommandActionEnum.Get);
        }

        /// <summary>
        /// Sends the binary state command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        public WeMoSwitchReponse SendBinaryStateCommand(string command, WeMoDeviceCommand.CommandActionEnum action)
        {
            return SendCommand(new WeMoDeviceCommand(command, "BinaryState", action));
        }

        #endregion

      
        /// <summary>
        /// Sends one of the pre-fabricated SOAP messages to the WeMo switch by IP/PORT using HTTP POST
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private WeMoSwitchReponse SendCommand(WeMoDeviceCommand cmd)
        {
            //
            //  Pull presentation URL from device and extract IP and PORT
            //
            string port = IPDevice.Port.ToString();
            string baseUrl = IPDevice.Address.ToString();
          
            //
            //  Build new target URL including the basicevent1 path
            //
            string targetUrl = "http://" + baseUrl + ":" + port + "/upnp/control/basicevent1";

            //
            //  Create the packet and payload to send to the endpoint to get the switch to process the command
            //
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(targetUrl);
            request.Method = "POST";
            request.Headers.Add("SOAPAction", "\"urn:Belkin:service:basicevent:1#" + cmd.CommandAction.ToString() + cmd.CommandName + "\"");
            request.ContentType = @"text/xml; charset=""utf-8""";
            request.KeepAlive = false;
            Byte[] bytes = UTF8Encoding.ASCII.GetBytes(cmd.Command);
            request.ContentLength = bytes.Length;

            using(Stream stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
                WebResponse resp = request.GetResponse();

                //get a result from the command
                cmd.Result = WeMoSwitchReponse.Parse(resp);
                
            }
            
            //
            //  HACK: If we don't abort the result the device holds on to the connection sometimes and prevents other commands from being received
            //
            request.Abort();

            return cmd.Result as WeMoSwitchReponse;
        }
    }

    /// <summary>
    /// Base class used to find and reference the WeMo devices
    /// </summary>
    public class WeMoDevice
    {
        public string Name { get; set; }
        public WeMoDeviceSource Source { get; set; }

        /// <summary>
        /// The possible sources of a wemo device
        /// </summary>
        public enum WeMoDeviceSource
        {
            Unknown, Upnp, Multicast
        }

        /// <summary>
        /// The possible types of WeMo devices that can be detected
        /// </summary>
        public enum WeMoDeviceType
        {
            Switch,
            Sensor,
            Unknown
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WeMoDevice"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        protected WeMoDevice(string name, WeMoDeviceSource source = WeMoDeviceSource.Unknown)
        {
            this.Name = name;
            this.Source = source;
        }

        /// <summary>
        /// Reference to the underlying IP device this object abstract from
        /// </summary>
        public IPEndPoint IPDevice { get; set; }

        /// <summary>
        /// Searches network for WeMo devices and returns all that are found or none
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static WeMoDevice GetDevice(string Name, WeMoDeviceSource source)
        {
            //find devices using source
            List<WeMoDevice> devices = GetDevices(source);

            if (devices == null)
                return null;

            //find by name
            return devices.FirstOrDefault(a => a.Name == Name);
        }

        /// <summary>
        /// Queries for Belkin WeMo devices and returns a reference to them
        /// </summary>
        /// <returns>A collection of located WeMo devices</returns>
        public static List<WeMoDevice> GetDevices(WeMoDeviceSource source)
        {
            if (source == WeMoDeviceSource.Upnp)
                return WeMoDevice.GetDevicesByUpnp();
            else if (source == WeMoDeviceSource.Multicast)
                return WeMoDevice.GetDevicesByMulticast();

            return null;

        }


        /// <summary>
        /// Searches network for WeMo devices (by IP) and returns all that are found or none
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static List<WeMoDevice> GetDevicesByMulticast()
        {
            List<WeMoDevice> foundDevices = new List<WeMoDevice>();

            //foreach (IPAddress remoteAddress in Dns.GetHostAddresses(Dns.GetHostName()).Where(i => i.AddressFamily == AddressFamily.InterNetwork))
            //{
            //    int port = 49153;
            //    string remoteAddressSrc;

            //    using (Socket mSendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            //    {
            //        mSendSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership,
            //                                    new MulticastOption(IPAddress.Parse(remoteAddressSrc)));

            //        mSendSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 255);
            //        mSendSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            //        mSendSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            //        IPEndPoint ipep = new IPEndPoint(remoteAddress, port);
            //        mSendSocket.Connect(ipep);


            //        byte[] bytes = Encoding.ASCII.GetBytes("This is my welcome message");
            //        mSendSocket.Send(bytes, bytes.Length, SocketFlags.None);
            //    }
          //  }

            //TODO : multicast, find all devices. blah blah blah
            //Socket s = new Socket(AddressFamily.InterNetwork,
            //    SocketType.Dgram, ProtocolType.Udp);

            //IPAddress ip = IPAddress.Parse("224.5.6.7");

            //s.SetSocketOption(SocketOptionLevel.IP,
            //    SocketOptionName.AddMembership, new MulticastOption(ip));

            //s.SetSocketOption(SocketOptionLevel.IP,
            //    SocketOptionName.MulticastTimeToLive, 2);

            //IPEndPoint ipep = new IPEndPoint(ip, 4567);
            //s.Connect(ipep);

            return foundDevices;
        }

        /// <summary>
        /// Gets the devices by upnp.
        /// </summary>
        /// <returns></returns>
        public static List<WeMoDevice> GetDevicesByUpnp()
        {
            UPnPDeviceFinder finder = new UPnPDeviceFinder();
            List<WeMoDevice> foundDevices = new List<WeMoDevice>();
            
            //
            //  Query all UPNP root devices
            //
            string deviceType = "upnp:rootdevice";
            UPnPDevices devices = finder.FindByType(deviceType, 1);
 
            //
            //  Iterate devices and create proper parent types based on WeMo device type and store in collection
            //
            foreach (UPnPDevice device in devices)
            {
                string type = device.Type;
                //Console.WriteLine("Found " + type);

                if (type.StartsWith("urn:Belkin:"))
                {
                    switch (GetDeviceType(device))
                    {
                        case WeMoDeviceType.Switch :
                            WeMoSwitch wemoSwitch = new WeMoSwitch( device );
                            foundDevices.Add(wemoSwitch);
                            break;

                        case WeMoDeviceType.Sensor :
                            WeMoSensor wemoSensor = new WeMoSensor( device );
                            foundDevices.Add(wemoSensor);
                            break;
                        default:
                            // TODO: Decide what to do with non Sensor/Switch devices
                            break;
                            
                    }
                }
            }

            return foundDevices;
        }

        /// <summary>
        /// Returns the specific WeMo device type from the UPnPDevice object
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static WeMoDeviceType GetDeviceType(UPnPDevice device)
        {
            return GetDeviceType(device.Type, WeMoDeviceSource.Upnp);
        }

        /// <summary>
        /// Gets the device type by packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <returns></returns>
        public static WeMoDeviceType GetDeviceTypeByMulticastPacket(string packet)
        {
            return GetDeviceType(packet, WeMoDeviceSource.Multicast);
        }

        /// <summary>
        /// Gets the type of the device.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static WeMoDeviceType GetDeviceType(string type, WeMoDeviceSource source)
        {
            if (source == WeMoDeviceSource.Upnp)
            {
                if (type.Contains("controllee"))
                {
                    return WeMoDeviceType.Switch;
                }
                else if (type.Contains("sensor"))
                {
                    return WeMoDeviceType.Sensor;
                }
            }

            return WeMoDeviceType.Unknown;
        }
    }
}
