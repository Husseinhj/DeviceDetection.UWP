﻿using System;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;

//Hussein.Juybari@gmail.com
//https://github.com/Husseinhj/DeviceDetection.UWP
namespace DeviceDetection.UWP
{
    public static class UniversalHelper
    {
        public static class UniversalClass
        {
            public class ScreenResolutionHelper
            {
                /// <summary> 
                /// Get screen resolution. 
                /// If you want to get the resolution on every page in your solution, you need to call this method from app.xaml.cs and save the data as a global variable. 
                /// If you have more than one computer monitor, you can only get the main monitor's screen resolution. 
                /// </summary> 
                /// <returns></returns> 
                public static Size GetScreenResolutionInfo()
                {
                    var applicationView = ApplicationView.GetForCurrentView();
                    var displayInformation = DisplayInformation.GetForCurrentView();
                    var bounds = applicationView.VisibleBounds;
                    var scale = displayInformation.RawPixelsPerViewPixel;
                    var size = new Size(bounds.Width * scale, bounds.Height * scale);
                    return size;
                }

                private ScreenResolutionHelper()
                { }
            }

            /// <summary>
            /// This enum have device name
            /// </summary>
            public enum Devices
            {
                Phone4Inch,
                Phone45Inch,
                Phone5Inch,
                Phone6Inch,
                Tablet,
                Wide,
                Unknown
            }

            /// <summary>
            /// This class show us what device is running and give it to your device size
            /// </summary>
            public class DeviceAndSizes
            {
                /// <summary>
                /// This class give device name and width and height
                /// </summary>
                /// <param name="size">Width and height</param>
                /// <param name="device">Device name</param>
                /// <param name="exception">Exception for error if this happening</param>
                /// <param name="orientation">Orientation of your device</param>
                protected internal DeviceAndSizes(Size size, Devices device, Exception exception,
                    DisplayOrientations orientation)
                {
                    Size = size;
                    Device = device;
                    Exception = exception;
                    Orientation = orientation;
                }

                public Size Size { get; private set; }

                public Devices Device { get; private set; }

                public Exception Exception { get; private set; }

                public DisplayOrientations Orientation { get; private set; }
            }

            /// <summary>
            /// Get device screen size from window size. Detect your device is 4 inch , 4.5 , 5 , 6 ,...
            /// </summary>
            /// <param name="size">Screen size</param>
            /// <returns>Device type</returns>
            public static DeviceAndSizes GetDeviceTypeFromSize(Size size)
            {
                try
                {
                    #region Phone 4 inch

                    if ((size.Height >= 250 && size.Height <= 534) &&
                        (size.Width >= 250 && size.Width <= 534))
                    {
                        if (size.Width > size.Height)
                            return new DeviceAndSizes(new Size(533, 320), Devices.Phone4Inch, null,
                                DisplayOrientations.Landscape);

                        return new DeviceAndSizes(new Size(320, 533), Devices.Phone4Inch, null,
                            DisplayOrientations.Portrait);
                    }

                    #endregion

                    #region Phone 4.5 inch

                    if ((size.Height >= 341 && size.Height <= 568) &&
                        (size.Width >= 341 && size.Width <= 568))
                    {
                        if (size.Width > size.Height)
                            return new DeviceAndSizes(new Size(568, 341), Devices.Phone45Inch, null,
                                DisplayOrientations.Landscape);

                        return new DeviceAndSizes(new Size(341, 568), Devices.Phone45Inch, null,
                            DisplayOrientations.Portrait);
                    }

                    #endregion

                    #region Phone 5 inch

                    if ((size.Height >= 360 && size.Height <= 640) &&
                        (size.Width >= 360 && size.Width <= 640))
                    {
                        if (size.Width > size.Height)
                            return new DeviceAndSizes(new Size(640, 341), Devices.Phone5Inch, null,
                                DisplayOrientations.Landscape);

                        return new DeviceAndSizes(new Size(341, 640), Devices.Phone5Inch, null,
                            DisplayOrientations.Portrait);
                    }

                    #endregion

                    #region Phone 6 inch

                    if ((size.Height >= 432 && size.Height <= 768) &&
                        (size.Width >= 432 && size.Width <= 468) || IsPhone())
                    {
                        if (size.Width > size.Height)
                            return new DeviceAndSizes(new Size(768, 432), Devices.Phone6Inch, null,
                                DisplayOrientations.Landscape);

                        return new DeviceAndSizes(new Size(432, 768), Devices.Phone6Inch, null,
                            DisplayOrientations.Portrait);
                    }

                    #endregion

                    #region Tablet

                    if ((size.Height >= 768 && size.Height <= 1024) &&
                        (size.Width >= 768 && size.Width <= 1024))
                    {
                        if (size.Width > size.Height)
                            return new DeviceAndSizes(new Size(1024, 768), Devices.Tablet, null,
                                DisplayOrientations.Landscape);

                        return new DeviceAndSizes(new Size(768, 1024), Devices.Tablet, null,
                            DisplayOrientations.Portrait);
                    }

                    #endregion

                    #region Wide

                    if ((size.Height >= 1024 && size.Width >= 1024))
                    {
                        if (size.Width > size.Height)
                            return new DeviceAndSizes(size, Devices.Wide, null,
                                DisplayOrientations.Landscape);

                        return new DeviceAndSizes(size, Devices.Wide, null,
                            DisplayOrientations.Portrait);
                    }

                    #endregion

                    if ((size.Height >= 700 && size.Width >= 700))
                    {
                        if (size.Width > size.Height)
                            return new DeviceAndSizes(size, Devices.Tablet, null,
                                DisplayOrientations.Landscape);

                        return new DeviceAndSizes(size, Devices.Tablet, null, DisplayOrientations.Portrait);
                    }

                    if ((size.Height >= 432 && size.Width >= 432))
                    {
                        if (size.Width > size.Height)
                            return new DeviceAndSizes(size, Devices.Phone6Inch, null,
                                DisplayOrientations.Landscape);

                        return new DeviceAndSizes(size, Devices.Phone6Inch, null, DisplayOrientations.Portrait);
                    }

                    if ((size.Height >= 360 && size.Width >= 360))
                    {
                        if (size.Width > size.Height)
                            return new DeviceAndSizes(size, Devices.Phone5Inch, null,
                                DisplayOrientations.Landscape);

                        return new DeviceAndSizes(size, Devices.Phone5Inch, null, DisplayOrientations.Portrait);
                    }

                    if ((size.Height >= 341 && size.Width >= 341))
                    {
                        if (size.Width > size.Height)
                            return new DeviceAndSizes(size, Devices.Phone45Inch, null,
                                DisplayOrientations.Landscape);

                        return new DeviceAndSizes(size, Devices.Phone45Inch, null, DisplayOrientations.Portrait);
                    }

                    if ((size.Height >= 310 && size.Width >= 310))
                    {
                        if (size.Width > size.Height)
                            return new DeviceAndSizes(size, Devices.Phone4Inch, null,
                                DisplayOrientations.Landscape);

                        return new DeviceAndSizes(size, Devices.Phone4Inch, null, DisplayOrientations.Portrait);
                    }

                    if (size.Width > size.Height)
                        return new DeviceAndSizes(size, Devices.Wide, null,
                            DisplayOrientations.Landscape);

                    return new DeviceAndSizes(size, Devices.Wide, null,
                        DisplayOrientations.Portrait);
                }
                catch (Exception exception)
                {
                    return new DeviceAndSizes(new Size(0, 0), Devices.Unknown, exception, DisplayOrientations.None);
                }
            }

            /// <summary>
            /// Get device type with screen size.
            /// </summary>
            /// <returns>Device type</returns>
            public static DeviceAndSizes GetDeviceType()
            {
                var size = ScreenResolutionHelper.GetScreenResolutionInfo();

                return GetDeviceTypeFromSize(size);
            }

            /// <summary>
            /// Detect your window size is mobile or wide device
            /// </summary>
            /// <returns>If it's was true means device is Phon</returns>
            public static bool IsMobileWithResponsiveDesign()
            {
                try
                {
                    var size = ScreenResolutionHelper.GetScreenResolutionInfo();
                    var device = GetDeviceTypeFromSize(size);
                    if (device.Device == Devices.Unknown ||
                        device.Device == Devices.Tablet ||
                        device.Device == Devices.Wide)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception exception)
                {
                    return false;
                }
            }

            /// <summary>
            /// Check your device is phone or not. (Check "Windows.UI.ViewManagement.StatusBar")
            /// </summary>
            /// <returns>If it's was true means device is Phone</returns>
            public static bool IsPhone()
            {
                return ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar");
            }
        }
    }
}
