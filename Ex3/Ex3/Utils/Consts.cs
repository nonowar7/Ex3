﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ex3.Utils
{
    public class Consts
    {
        public const int BUFFER_SIZE = 1024;
        public const string FLIGHT_SERVER_IP = "127.0.0.1";
        public const int FLIGHT_INFO_PORT = 5400;
        public const int FLIGHT_COMMAND_PORT = 5402;
        public const int READ_FAILED = -1;
        public const string LON_XML = "longitude-deg";
        public const string LAT_XML = "latitude-deg";
        public const string THROTTLE_XML = "/controls/engines/current-engine/throttle";
        public const string RUDDER_XML = "/controls/flight/rudder";
        public const string AILERON_XML = "/controls/flight/aileron";
        public const string ELEVATOR_XML = "/controls/flight/elevator";
        public const string LATITUDE_XML = "/position/latitude-deg";
        public const string LONGIDUTE_XML = "/position/longitude-deg";
        public const string NEW_LINE = "\r\n";
    }
}