﻿// This file is part of the TA.Ascom.ReactiveCommunications project
// 
// Copyright © 2015 Tigra Astronomy, all rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so,. The Software comes with no warranty of any kind.
// You make use of the Software entirely at your own risk and assume all liability arising from your use thereof.
// 
// File: SerialDeviceEndpoint.cs  Last modified: 2015-05-25@18:23 by Tim Long

using System.IO.Ports;

namespace TA.Ascom.ReactiveCommunications
    {
    /// <summary>
    ///     Class SerialDeviceEndpoint. Represents a serial port endpoint with a comm port name,
    ///     data (baud) rate, parity type, number of data bits and number of stop bits.
    /// </summary>
    public class SerialDeviceEndpoint : DeviceEndpoint
        {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SerialDeviceEndpoint" /> class.
        /// </summary>
        /// <param name="portName">Name of the port, COMx where x is an integer.</param>
        /// <param name="baudRate">The baud rate.</param>
        /// <param name="parity">The parity bit type.</param>
        /// <param name="dataBits">The number of data bits.</param>
        /// <param name="stopBits">The number stop bits.</param>
        public SerialDeviceEndpoint(string portName,
            int baudRate = 9600,
            Parity parity = Parity.None,
            int dataBits = 8,
            StopBits stopBits = StopBits.One, bool dtrEnable = true, bool rtsEnable = true)
            {
            PortName = portName;
            BaudRate = baudRate;
            Parity = parity;
            DataBits = dataBits;
            StopBits = stopBits;
            DtrEnable = dtrEnable;
            RtsEnable = rtsEnable;
            }

        /// <summary>
        ///     Gets the name of the port being used.
        ///     The port name is typically in the form <c>COMx</c> where x is an integer.
        ///     However, Windows will also accept a UNC path format of <c>\\.\COMx</c>
        /// </summary>
        /// <value>The name of the port.</value>
        public string PortName { get; private set; }

        /// <summary>
        ///     Gets the configured baud rate.
        ///     For serial ports, 1 Baud equals 1 bit per second.
        /// </summary>
        /// <value>The baud rate.</value>
        public int BaudRate { get; private set; }

        /// <summary>
        ///     Gets the parity algorithm.
        /// </summary>
        /// <value>The parity.</value>
        public Parity Parity { get; private set; }

        /// <summary>
        ///     Gets the configured number of data bits.
        /// </summary>
        /// <value>The data bits.</value>
        public int DataBits { get; private set; }

        /// <summary>
        ///     Gets the stop bits configuration.
        /// </summary>
        /// <value>The stop bits (enumerated value).</value>
        public StopBits StopBits { get; private set; }

        public bool RtsEnable { get; private set; }

        public bool DtrEnable { get; private set; }

        public override string ToString()
            {
            return string.Format("{0}:{1},{2},{3},{4}", PortName, BaudRate, Parity, DataBits, StopBits);
            }
        }
    }