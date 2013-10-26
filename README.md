batterytest
===========

Test battery performance of windows mobile device

This small Visual Studio 2008 Windows Mobile SDK C# SmartDevice app will show the battery performance running down when issuing different tasks on a device.

Currently the following tasks can be scheduled:

*  Barcode Scanning
*  Camera activation
*  ftp file transfer

There is also a GPS task running all the time.

To enable different scenarios, you can define the following settings:
+  overall runtime
+  barcodes scan count
+  barcode scan duration
+  camera activation count
+  camera activation duration
+  ftp session count

The app will record the battery percentage level over the time and you will get an image of how long the battery will last with the provided scenarios.

The above scenario definitions are choosen by custom. From my point of view all these battery tests only give theory of operation but can not replace a live performance test.

There are still some essential items missing that have a great impact on the battery life:
*  background light level, the screen backlight setting has a great impact of the power consumption
*  not associated WLAN setup, a WLAN module that searches for an AP uses much more power than a connected WLAN module.
*  WWAN connection and coverage
*  power management settings like backlight dimming, screen-off after idle time etc

Possibly you take the project as an starter and enhanced with the above items.

keywords: Windows Mobile, battery, performance, measure, scenarios, backlight, WLAN, WWAN, ftp, barcode scanner, power management
