﻿using MediaDevices.Internal;
using System.Collections.Generic;
using System.Linq;

namespace MediaDevices
{
    public static class MediaDeviceConnectors
    {

        #region static

        private static IEnumPortableDeviceConnectors connectors;

        static MediaDeviceConnectors()
        {
            IEnumPortableDeviceConnectors inst = (IEnumPortableDeviceConnectors)new EnumPortableDeviceConnectors();
            connectors = inst;
        }

        #endregion

        public static IEnumerable<MediaDeviceConnector> Connectors()
        {

            connectors.Reset();

            //IPortableDeviceConnector connector = null;
            //uint num = 1;
            //connectors.Next(1, out connector, ref num);

            //return new List<MediaDeviceConnector>() { new MediaDeviceConnector(connector) };

            IPortableDeviceConnector[] connectorArray = new IPortableDeviceConnector[10]; 
            uint num = 10;
            connectors.Next(10, ref connectorArray, ref num);


            //connectors.Clone(out IEnumPortableDeviceConnectors test);

            //num = 10;
            //test.Next(10, ref connectorArray, ref num);

            return connectorArray?.Select(c => new MediaDeviceConnector(c));
        }
    }
}