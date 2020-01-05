using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class HardwareInfo
{
    [NonSerialized] private List<USBDeviceInfo> allUSBDeviceInfo = new List<USBDeviceInfo>();
    public List<USBDeviceInfo> filteredUSBDeviceInfo = new List<USBDeviceInfo>();

    public void LoadAllUSBControllers()
    {
        ProcessStartInfo info = new ProcessStartInfo(Application.dataPath + "/StreamingAssets/USB Info/App/USB_Information.exe")
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };

        Process p = Process.Start(info);
        p.OutputDataReceived += p_OutputDataReceived;
        p.ErrorDataReceived += p_ErrorDataReceived;

        p.BeginOutputReadLine();
        p.BeginErrorReadLine();
        p.WaitForExit();

        allUSBDeviceInfo = JsonConvert.DeserializeObject<USBDeviceInfo[]>(stdoutString).ToList();

        for (int i = 0; i < allUSBDeviceInfo.Count; i++)
        {
            if (allUSBDeviceInfo[i].DeviceID.Contains(@"USB\ROOT_HUB") == false)
            {
                filteredUSBDeviceInfo.Add(allUSBDeviceInfo[i]);
            }
        }

        /*
        UnityEngine.Debug.Log(usbDeviceInfo[1].Availability);
        UnityEngine.Debug.Log(usbDeviceInfo[1].Caption);
        UnityEngine.Debug.Log(usbDeviceInfo[1].ClassCode);
        UnityEngine.Debug.Log(usbDeviceInfo[1].ConfigManagerErrorCode);
        UnityEngine.Debug.Log(usbDeviceInfo[1].ConfigManagerUserConfig);
        UnityEngine.Debug.Log(usbDeviceInfo[1].CreationClassName);
        UnityEngine.Debug.Log(usbDeviceInfo[1].CurrentAlternateSettings);
        UnityEngine.Debug.Log(usbDeviceInfo[1].CurrentConfigValue);
        UnityEngine.Debug.Log(usbDeviceInfo[1].Description);
        UnityEngine.Debug.Log(usbDeviceInfo[1].DeviceID);//Contains the VID&PID
        UnityEngine.Debug.Log(usbDeviceInfo[1].ErrorCleared);
        UnityEngine.Debug.Log(usbDeviceInfo[1].ErrorDescription);
        UnityEngine.Debug.Log(usbDeviceInfo[1].GangSwitched);
        UnityEngine.Debug.Log(usbDeviceInfo[1].InstallDate);
        UnityEngine.Debug.Log(usbDeviceInfo[1].LastErrorCode);
        UnityEngine.Debug.Log(usbDeviceInfo[1].Name);
        UnityEngine.Debug.Log(usbDeviceInfo[1].NumberOfConfigs);
        UnityEngine.Debug.Log(usbDeviceInfo[1].NumberOfPorts);
        UnityEngine.Debug.Log(usbDeviceInfo[1].PNPDeviceID);//Contains the VID&PID
        UnityEngine.Debug.Log(usbDeviceInfo[1].PowerManagementCapabilities);
        UnityEngine.Debug.Log(usbDeviceInfo[1].PowerManagementSupported);
        UnityEngine.Debug.Log(usbDeviceInfo[1].ProtocolCode);
        UnityEngine.Debug.Log(usbDeviceInfo[1].Status);
        UnityEngine.Debug.Log(usbDeviceInfo[1].StatusInfo);
        UnityEngine.Debug.Log(usbDeviceInfo[1].SubclassCode);
        UnityEngine.Debug.Log(usbDeviceInfo[1].SystemCreationClassName);
        UnityEngine.Debug.Log(usbDeviceInfo[1].SystemName);
        UnityEngine.Debug.Log(usbDeviceInfo[1].USBVersion);
        */
    }

    private string stdoutString = "";

    void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        stdoutString += e.Data;
    }

    void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
    {
        UnityEngine.Debug.Log("Received from standard out error: " + e.Data);
    }

    /*
    private UsbRegDeviceList mRegDevices => UsbDevice.AllDevices;
    public List<DeviceInfo> deviceInfo = new List<DeviceInfo>();
    public static Dictionary<string, VendorIdInfo> VendorDictionary = new Dictionary<string, VendorIdInfo>();
    public static Dictionary<Guid, string> DeviceClassGuid = new Dictionary<Guid, string>()
    {
        { Guid.Parse("72631e54-78a4-11d0-bcf7-00aa00b7b32a"), "Battery" },
        { Guid.Parse("53D29EF7-377C-4D14-864B-EB3A85769359"), "Biometric" },
        { Guid.Parse("e0cbf06c-cd8b-4647-bb8a-263b43f0f974"), "Bluetooth" },
        { Guid.Parse("ca3e7ab9-b4c3-4ae6-8251-579ef933890f"), "Camera" },
        { Guid.Parse("4d36e965-e325-11ce-bfc1-08002be10318"), "CDROM" },
        { Guid.Parse("4d36e967-e325-11ce-bfc1-08002be10318"), "DiskDrive" },
        { Guid.Parse("4d36e968-e325-11ce-bfc1-08002be10318"), "Display" },
        { Guid.Parse("e2f84ce7-8efa-411c-aa69-97454ca4cb57"), "Extension" },
        { Guid.Parse("4d36e969-e325-11ce-bfc1-08002be10318"), "FDC" },
        { Guid.Parse("4d36e980-e325-11ce-bfc1-08002be10318"), "FloppyDisk" },
        { Guid.Parse("4d36e96a-e325-11ce-bfc1-08002be10318"), "HDC" },
        { Guid.Parse("745a17a0-74d3-11d0-b6fe-00a0c90f57da"), "HIDClass" },
        { Guid.Parse("48721b56-6795-11d2-b1a8-0080c72e74a2"), "Dot4" },
        { Guid.Parse("49ce6ac8-6f86-11d2-b1e5-0080c72e74a2"), "Dot4Print" },
        { Guid.Parse("7ebefbc0-3200-11d2-b4c2-00a0C9697d07"), "61883" },
        { Guid.Parse("c06ff265-ae09-48f0-812c-16753d7cba83"), "AVC" },
        { Guid.Parse("d48179be-ec20-11d1-b6b8-00c04fa372a7"), "SBP2" },
        { Guid.Parse("6bdd1fc1-810f-11d0-bec7-08002be2092f"), "1394" },
        { Guid.Parse("6bdd1fc6-810f-11d0-bec7-08002be2092f"), "Image" },
        { Guid.Parse("6bdd1fc5-810f-11d0-bec7-08002be2092f"), "Infrared" },
        { Guid.Parse("4d36e96b-e325-11ce-bfc1-08002be10318"), "Keyboard" },
        { Guid.Parse("ce5939ae-ebde-11d0-b181-0000f8753ec4"), "MediumChanger" },
        { Guid.Parse("4d36e970-e325-11ce-bfc1-08002be10318"), "MTD" },
        { Guid.Parse("4d36e96d-e325-11ce-bfc1-08002be10318"), "Modem" },
        { Guid.Parse("4d36e96e-e325-11ce-bfc1-08002be10318"), "Monitor" },
        { Guid.Parse("4d36e96f-e325-11ce-bfc1-08002be10318"), "Mouse" },
        { Guid.Parse("4d36e971-e325-11ce-bfc1-08002be10318"), "Multifunction" },
        { Guid.Parse("4d36e96c-e325-11ce-bfc1-08002be10318"), "Media" },
        { Guid.Parse("50906cb8-ba12-11d1-bf5d-0000f805f530"), "MultiportSerial" },
        { Guid.Parse("4d36e972-e325-11ce-bfc1-08002be10318"), "Net" },
        { Guid.Parse("4d36e973-e325-11ce-bfc1-08002be10318"), "NetClient" },
        { Guid.Parse("4d36e974-e325-11ce-bfc1-08002be10318"), "NetService" },
        { Guid.Parse("4d36e975-e325-11ce-bfc1-08002be10318"), "NetTrans" },
        { Guid.Parse("268c95a1-edfe-11d3-95c3-0010dc4050a5"), "SecurityAccelerator" },
        { Guid.Parse("4d36e977-e325-11ce-bfc1-08002be10318"), "PCMCIA" },
        { Guid.Parse("4d36e978-e325-11ce-bfc1-08002be10318"), "Ports" },
        { Guid.Parse("4d36e979-e325-11ce-bfc1-08002be10318"), "Printer" },
        { Guid.Parse("4658ee7e-f050-11d1-b6bd-00c04fa372a7"), "PNPPrinters" },
        { Guid.Parse("50127dc3-0f36-415e-a6cc-4cb3be910b65"), "Processor" },
        { Guid.Parse("4d36e97b-e325-11ce-bfc1-08002be10318"), "SCSIAdapter" },
        { Guid.Parse("5175d334-c371-4806-b3ba-71fd53c9258d"), "Sensor" },
        { Guid.Parse("50dd5230-ba8a-11d1-bf5d-0000f805f530"), "SmartCardReader" },
        { Guid.Parse("5c4c3332-344d-483c-8739-259e934c9cc8"), "SoftwareComponent" },
        { Guid.Parse("71a27cdd-812a-11d0-bec7-08002be2092f"), "Volume" },
        { Guid.Parse("4d36e97d-e325-11ce-bfc1-08002be10318"), "System" },
        { Guid.Parse("6d807884-7d21-11cf-801c-08002be10318"), "TapeDrive" },
        { Guid.Parse("88BAE032-5A81-49f0-BC3D-A4FF138216D6"), "USBDevice" },
        { Guid.Parse("25dbce51-6c8f-4a72-8a6d-b54c2b4fc835"), "WCEUSBS" },
        { Guid.Parse("eec5ad98-8080-425f-922a-dabf3de3f69a"), "WPD" },
        { Guid.Parse("997b5d8d-c442-4f2e-baf3-9c8e671e9e21"), "SideShow" },
    };

    public int GetConnectedUsbCount()
    {
        return mRegDevices.Count;
    }

    public void LoadAllUSBControllers()
    {
        Usb_Id_Parser.LoadUsbIds();
        UsbDevice.ForceLibUsbWinBack = true;

        for (int index = 0; index < GetConnectedUsbCount(); index++)
        {
            deviceInfo.Add(new DeviceInfo()
            {
                SymbolicName = mRegDevices[index].SymbolicName,
                CompanyName = VendorDictionary[mRegDevices[index].Vid.ToHex().ToUpper()].VendorName,
                DeviceName = VendorDictionary[mRegDevices[index].Vid.ToHex().ToUpper()].DeviceDictionary.ContainsKey(mRegDevices[index].Pid.ToHex())
                ? VendorDictionary[mRegDevices[index].Vid.ToHex().ToUpper()].DeviceDictionary[mRegDevices[index].Pid.ToHex()].DeviceName.Trim()
                : "Unknown",
                //DeviceGUID = mRegDevices[index].DeviceInterfaceGuids[0].ToString().Replace(" ", ""),
                VID = mRegDevices[index].Vid,
                PID = mRegDevices[index].Pid,
                VID_Hex = mRegDevices[index].Vid.ToHex(),
                PID_Hex = mRegDevices[index].Pid.ToHex()
            });
        }

        Debug.Log(Get_RegistryInfo(deviceInfo[0].VID_Hex, deviceInfo[0].PID_Hex));
        UsbDevice.Exit();
    }

    public string Get_RegistryInfo(string VID, string PID)
    {
        try
        {
            string COM_Port = null;
            RegistryKey rk1 = Registry.LocalMachine;
            // HKEY_LOCAL_MACHINE
            RegistryKey rk2 = rk1.OpenSubKey("HARDWARE\\\\DEVICEMAP\\\\SERIALCOMM");
            // HKEY_LOCAL_MACHINE\HARDWARE\\\\DEVICEMAP\\\\SERIALCOMM
            string pattern = string.Format("^VID_{0}.PID_{1}", VID, PID);
            Regex _rx = new Regex(pattern, RegexOptions.IgnoreCase);
            string rk2_SubKeyNames = null;
            foreach (string rk2_SubKeyNames_loopVariable in rk2.GetValueNames())
            {
                rk2_SubKeyNames = rk2_SubKeyNames_loopVariable;
                if (rk2_SubKeyNames == "\\Device\\ProlificSerial0")
                {
                    COM_Port = rk2.GetValue(rk2_SubKeyNames).ToString();
                }
            }
            return COM_Port;
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
            return null;
        }

    }

    public void GetKeyboardInfo()
    {

    }

    public void GetMouseInfo()
    {

    }
    */
}

[System.Serializable]
public class USBDeviceInfo
{
    public string Availability { get; set; }
    public string Caption { get; set; }
    public string ClassCode { get; set; }
    public UInt32 ConfigManagerErrorCode { get; set; }
    public bool ConfigManagerUserConfig { get; set; }
    public string CreationClassName { get; set; }
    public string CurrentAlternateSettings { get; set; }
    public string CurrentConfigValue { get; set; }
    public string Description { get; set; }
    public string DeviceID { get; set; }
    public string ErrorCleared { get; set; }
    public string ErrorDescription { get; set; }
    public string GangSwitched { get; set; }
    public string InstallDate { get; set; }
    public string LastErrorCode { get; set; }
    public string Name { get; set; }
    public string NumberOfConfigs { get; set; }
    public string NumberOfPorts { get; set; }
    public string PNPDeviceID { get; set; }
    public string PowerManagementCapabilities { get; set; }
    public string PowerManagementSupported { get; set; }
    public string ProtocolCode { get; set; }
    public string Status { get; set; }
    public string StatusInfo { get; set; }
    public string SubclassCode { get; set; }
    public string SystemCreationClassName { get; set; }
    public string SystemName { get; set; }
    public string USBVersion { get; set; }

    public UsbGenericInfo usbGenericInfo;

    public USBDeviceInfo(string availability, string caption, string classCode, UInt32 configManagerErrorCode, bool configManagerUserConfig, string creationClassName,
                            string currentAlternateSettings, string currentConfigValue, string description, string deviceID, string errorCleared,
                            string errorDescription, string gangSwitched, string installDate, string lastErrorCode, string name,
                            string numberOfConfigs, string numberOfPorts, string pnpDeviceID, string powerManagementCapabilities, string powerManagementSupported,
                            string protocolCode, string status, string statusInfo, string subclassCode, string systemCreationClassName,
                            string systemName, string usbVersion)
    {
        this.Availability = availability;
        this.Caption = caption;
        this.ClassCode = classCode;
        this.ConfigManagerErrorCode = configManagerErrorCode;
        this.ConfigManagerUserConfig = configManagerUserConfig;
        this.CreationClassName = creationClassName;
        this.CurrentAlternateSettings = currentAlternateSettings;
        this.CurrentConfigValue = currentConfigValue;
        this.Description = description;
        this.DeviceID = deviceID;
        this.ErrorCleared = errorCleared;
        this.ErrorDescription = errorDescription;
        this.GangSwitched = gangSwitched;
        this.InstallDate = installDate;
        this.LastErrorCode = lastErrorCode;
        this.Name = name;
        this.NumberOfConfigs = numberOfConfigs;
        this.NumberOfPorts = numberOfPorts;
        this.PNPDeviceID = pnpDeviceID;
        this.PowerManagementCapabilities = powerManagementCapabilities;
        this.PowerManagementSupported = powerManagementSupported;
        this.ProtocolCode = protocolCode;
        this.Status = status;
        this.StatusInfo = statusInfo;
        this.SubclassCode = subclassCode;
        this.SystemCreationClassName = systemCreationClassName;
        this.SystemName = systemName;
        this.USBVersion = usbVersion;

        usbGenericInfo = new UsbGenericInfo()
        {
            CompanyName = "",
            usbType = UsbGenericInfo.DeviceGuidType.None,
            DeviceName = "",
            PID = deviceID.PassAsPID(),
            VID = deviceID.PassAsVID()
        };

        //usbGenericInfo.DeviceGUID.
    }
}

public static class USBDeviceInfoExtension
{
    public static string PassAsVID(this string deviceID)
    {
        if (deviceID.IndexOf("VID_") != -1)
        {
            int vidIndex = deviceID.IndexOf("VID_");
            string startingAtVid = deviceID.Substring(vidIndex + 4); // + 4 to remove "VID_"                    
            string vid = startingAtVid.Substring(0, 4); // vid is four characters long
            return vid;
        }

        return "";
    }

    public static string PassAsPID(this string deviceID)
    {
        if (deviceID.IndexOf("PID_") != -1)
        {
            int pidIndex = deviceID.IndexOf("PID_");
            string startingAtPid = deviceID.Substring(pidIndex + 4); // + 4 to remove "PID_"                    
            string pid = startingAtPid.Substring(0, 4); // pid is four characters long
            return pid;
        }

        return "";
    }

    public static string ToHex(this int val)
    {
        return (val.ToString("x4"));
    }

    public static int FromHex(this string str)
    {
        if (string.IsNullOrEmpty(str))
            return -1;
        return (int.Parse(str, System.Globalization.NumberStyles.HexNumber));
    }
}

[System.Serializable]
public class UsbGenericInfo
{
    public string CompanyName;
    public string DeviceName;
    public string ClassGuid;
    public enum DeviceGuidType
    {
        None,
        Battery,
        Biometric,
        Bluetooth,
        Camera,
        CDROM,
        DiskDrive,
        Display,
        Extension,
        FDC,
        FloppyDisk,
        HDC,
        HIDClass,
        Dot4,
        Dot4Print,
        six_one_eight_eight_three,
        AVC,
        SBP2,
        one_three_nine_four,
        Image,
        Infrared,
        Keyboard,
        MediumChanger,
        MTD,
        Modem,
        Monitor,
        Mouse,
        Multifunction,
        Media,
        MultiportSerial,
        Net,
        NetClient,
        NetService,
        NetTrans,
        SecurityAccelerator,
        PCMCIA,
        Ports,
        Printer,
        PNPPrinters,
        Processor,
        SCSIAdapter,
        Sensor,
        SmartCardReader,
        SoftwareComponent,
        Volume,
        System,
        TapeDrive,
        USBDevice,
        WCEUSBS,
        WPD,
        SideShow,
    };
    public DeviceGuidType usbType = DeviceGuidType.None;

    public string VID;
    public string PID;
}

/*
[System.Serializable]
public class DeviceInfo
{
    public string SymbolicName;
    public string CompanyName;
    public string DeviceName;
    public string DeviceGUID;

    public int VID;
    public int PID;

    public string VID_Hex;
    public string PID_Hex;
}

[System.Serializable]
public class VendorIdInfo
{
    public string VendorName;
    public Dictionary<string, DeviceIdInfo> DeviceDictionary = new Dictionary<string, DeviceIdInfo>();
}

[System.Serializable]
public class DeviceIdInfo
{
    public string DeviceName;
}

public static class HexidecimalExtension
{
    public static string ToHex(this int val)
    {
        return (val.ToString("x4"));
    }

    public static int FromHex(this string str)
    {
        return (int.Parse(str, System.Globalization.NumberStyles.HexNumber));
    }
}

public static class Usb_Id_Parser
{
    private static string UsbIdsPath =>
#if UNITY_STANDALONE_WIN
    Application.dataPath + "/StreamingAssets/";
#endif

#if UNITY_STANDALONE_OSX
    Application.dataPath + "/Resources/Data/StreamingAssets/";
#endif

    private static string FileName = "usb.ids";
    private static string currentVendorId = "";

    public static void LoadUsbIds()
    {
        string[] lines = System.IO.File.ReadAllLines(UsbIdsPath + FileName);
        

        foreach (string line in lines)
        {
            if (line == "# List of known device classes, subclasses and protocols")
                break;

            if (string.IsNullOrEmpty(line) || line[0] == '#' || (line[0] == '\t' && line[1] == '\t') ||
                line.Substring(0, 4).Contains(" "))
                continue;

            if (line[0] == '\t')
            {
                string DeviceId = line.Trim().Substring(0, 4).ToUpper();
                string DeviceName = line.Trim().Substring(5);

                HardwareInfo.VendorDictionary[currentVendorId].DeviceDictionary.Add(DeviceId, new DeviceIdInfo() { DeviceName = DeviceName });
            }
            else
            {
                string VendorId = currentVendorId = line.Trim().Substring(0, 4).ToUpper();
                string VendorName = line.Trim().Substring(5);

                HardwareInfo.VendorDictionary.Add(VendorId, new VendorIdInfo()
                {
                    VendorName = VendorName,
                    DeviceDictionary = new Dictionary<string, DeviceIdInfo>()
                });
            }
        }
    }
}
*/
