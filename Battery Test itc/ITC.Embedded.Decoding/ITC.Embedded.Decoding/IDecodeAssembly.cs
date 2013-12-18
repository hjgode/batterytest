using System;

/// <summary>
/// global event handler
/// </summary>
/// <param name="sender"></param>
/// <param name="args"></param>
//public delegate void DecodeEventHandler(object sender, DecodeAssemblyITC.DecodeEventArgs args);

/// <summary>
/// an interface to maintain the same methods and properties as defined by HSM SDK
/// </summary>
interface IBarcodeAssembly
{
    void Disconnect();
    void Connect();
    int ScanTimeout
    {
        get;
        set;
    }
    void ScanBarcode();
//    event DecodeEventHandler DecodeEvent;
}
