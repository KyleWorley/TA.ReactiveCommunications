# Reactive ASCOM #

![Reactive ASCOM Logo](http://tigra-astronomy.com/Media/TigraAstronomy/ProjectIcons/ReactiveASCOM520x520.png)  

## Reactive-style transactional device communications for [ASCOM][3] drivers with guaranteed sequencing and thread-safety ##

[Reactive ASCOM][1] (namespace TA.Ascom.ReactiveCommunications) is a library based on the [Reactive Extensions for .NET][2] for simplifying device communications over serial, Ethernet and other types of communications channel to embedded controllers, while guaranteeing correct sequencing and thread-safety of transactions.

Originally developed for use with [ASCOM][3] drivers, but may be useful for any software that needs to communicate with an embedded controller using a predominantly command-response protocol.

This [blog article][5] describes the approach and gives a bried overview of how to use the library. The source code contains a sample console application demonstrating how to create and use the various classes.

Available as a [NuGet][4] package - simply `Install-Package TA.Ascom.ReactiveCommunications`

The [main project page][1] for [Reactive ASCOM][1] is at: http://tigra-astronomy.com/reactive-communications-for-ascom

## License ##

Reactive ASCOM uses the [MIT License][6].

Tim Long - Tigra Astronomy, May 2015.

## Release Notes ##

### 0.5.1 ###

- Updated dependent NuGet packages to latest release versions before rebuilding and pushing to NuGet.

### 0.5.0 ###

- added the `ChannelFactory` class and the ability to register custom user-supplied channel implementations.  Removed `DeviceEndpoint.FromConnectionString()`. This is a breaking change and applications will now need to use the new `ChannelFactory` class to create a communications channel from a connection string, instead of `DeviceEndpoint.FromConnectionString()`

  Builtin channel types are pre-registered in the `ChannelFactory`. Custom channel implementations can be added by calling `RegisterChannelType()`. You must supply a `Predicate<string>` that tests whether a connection string is valid for the channel type; a `Func<string,DeviceEndpoint>` for creating an endpoint from a connection string; and a `Func<DeviceEndpoint, ICommunicationsChannel>` for creating the channel itself.

  If the builtin channel types are not required, they can be deleted by calling `ClearRegisteredDevices()` prior to adding any custom implementations.

  [1]: http://tigra-astronomy.com/reactive-communications-for-ascom "Project Page"
  [2]: https://rx.codeplex.com/ "Rx Project"
  [3]: http://ascom-standards.org "Astronomy Common Object Model"
  [4]: http://www.nuget.org "NuGet Package Manager"
  [5]: http://tigra-astronomy.com/blog/the-well-travelled-photon/reactive-ascom "Introducing Reactive ASCOM"
  [6]: http://tigra.mit-license.org/ "Tigra Astronomy MIT License"