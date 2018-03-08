﻿// This file is part of the TA.Ascom.ReactiveCommunications project
// 
// Copyright © 2018 Tigra Astronomy, all rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so,. The Software comes with no warranty of any kind.
// You make use of the Software entirely at your own risk and assume all liability arising from your use thereof.
// 
// File: ChannelFactorySpecs.cs  Last modified: 2018-03-08@00:33 by Tim Long

using System;
using System.Reactive.Linq;
using Machine.Specifications;

namespace TA.Ascom.ReactiveCommunications.Specifications
    {
    #region  Context base classes
    internal class with_default_channel_factory
        {
        Establish context = () => Factory = new ChannelFactory();
        Cleanup after = () =>
            {
            Channel?.Dispose();
            Channel = null;
            Factory = null;
            };
        protected static ICommunicationChannel Channel;
        protected static ChannelFactory Factory;
        }
    #endregion

    [Subject(typeof(ChannelFactory), "default channels")]
    internal class when_creating_a_serial_channel : with_default_channel_factory
        {
        Because of = () => Channel = Factory.FromConnectionString("COM22:");
        It should_create_a_serial_channel = () => Channel.ShouldBeOfExactType<SerialCommunicationChannel>();
        It should_have_a_Serial_endpoint = () => Channel.Endpoint.ShouldBeOfExactType<SerialDeviceEndpoint>();
        It should_have_the_expected_com_port =
            () => ((SerialDeviceEndpoint) Channel.Endpoint).PortName.ShouldEqual("COM22");
        }

    [Subject(typeof(ChannelFactory), "custom channel implementations")]
    internal class when_creating_a_custom_channel : with_default_channel_factory
        {
        Establish context = () =>
            {
            Factory.RegisterChannelType(
                p => p.StartsWith("UnitTest:"),
                conn => new UnitTestDeviceEndpoint(),
                endpoint => new UnitTestChannel(endpoint));
            };
        Because of = () => Channel = Factory.FromConnectionString("UnitTest:blobby");
        It should_create_the_registered_channel_type = () => Channel.ShouldBeOfExactType<UnitTestChannel>();
        }

    internal class UnitTestDeviceEndpoint : DeviceEndpoint { }

    internal class UnitTestChannel : ICommunicationChannel
        {
        public UnitTestChannel(DeviceEndpoint endpoint)
            {
            Endpoint = endpoint;
            }

        public void Dispose() { }

        public void Open() => IsOpen = true;

        public void Close() => IsOpen = false;

        public void Send(string txData) { }

        public IObservable<char> ObservableReceivedCharacters => Observable.Never<char>();

        public bool IsOpen { get; private set; }

        public DeviceEndpoint Endpoint { get; }
        }
    }