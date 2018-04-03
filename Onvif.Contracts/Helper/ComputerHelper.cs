using System;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;

namespace Onvif.Contracts.Helper
{
    public class ComputerHelper
    {
        public static string GetUniqueId(string drive)
        {
            if (drive == string.Empty)
            {
                //Find first drive
                foreach (DriveInfo compDrive in DriveInfo.GetDrives())
                {
                    if (compDrive.IsReady)
                    {
                        drive = compDrive.RootDirectory.ToString();
                        break;
                    }
                }
            }

            if (drive.EndsWith(":\\"))
            {
                //C:\ -> C
                drive = drive.Substring(0, drive.Length - 2);
            }

            string volumeSerial = GetVolumeSerial(drive);
            string cpuId = GetCpuid();

            //Mix them up and remove some useless 0's
            return cpuId.Substring(13) + cpuId.Substring(1, 4) + volumeSerial + cpuId.Substring(4, 4);
        }

        private static string GetVolumeSerial(string drive)
        {
            ManagementObject disk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
            disk.Get();

            string volumeSerial = disk["VolumeSerialNumber"].ToString();
            disk.Dispose();

            return volumeSerial;
        }

        private static string GetCpuid()
        {
            string cpuInfo = string.Empty;
            ManagementClass managClass = new ManagementClass("win32_processor");
            ManagementObjectCollection managCollec = managClass.GetInstances();

            foreach (var o in managCollec)
            {
                var managObj = (ManagementObject) o;
                if (string.IsNullOrWhiteSpace(cpuInfo))
                {
                    //Get only the first CPU's ID
                    cpuInfo = managObj.Properties["processorID"].Value.ToString();
                    break;
                }
            }

            return cpuInfo;
        }

        private string GetMacAddress()
        {
            string result = string.Empty;
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    result = nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            return result;
        }

        private static string _fingerPrint = string.Empty;

        public static string GetUniqueComputerFingerPrint()
        {
            if (string.IsNullOrEmpty(_fingerPrint))
            {
                _fingerPrint = GetHash("CPU >> " + CpuId() + "\nBIOS >> " + 
                                BiosId() + "\nBASE >> " + BaseId() +"\nDISK >> "+ DiskId() + "\nVIDEO >> " + 
                                VideoId() +"\nMAC >> "+ MacId());
            }
            return _fingerPrint;
        }
        private static string GetHash(string s)
        {
            MD5 sec = new MD5CryptoServiceProvider();
            ASCIIEncoding enc = new ASCIIEncoding();
            byte[] bt = enc.GetBytes(s);
            return GetHexString(sec.ComputeHash(bt));
        }
        private static string GetHexString(byte[] bt)
        {
            string s = string.Empty;
            for (int i = 0; i < bt.Length; i++)
            {
                byte b = bt[i];
                int n, n1, n2;
                n = (int)b;
                n1 = n & 15;
                n2 = (n >> 4) & 15;
                if (n2 > 9)
                    s += ((char)(n2 - 10 + (int)'A')).ToString();
                else
                    s += n2.ToString();
                if (n1 > 9)
                    s += ((char)(n1 - 10 + (int)'A')).ToString();
                else
                    s += n1.ToString();
                if ((i + 1) != bt.Length && (i + 1) % 2 == 0) s += "-";
            }
            return s;
        }

        #region Original Device ID Getting Code
        //Return a hardware identifier
        private static string GetIdentifier(string wmiClass, string wmiProperty, string wmiMustBeTrue)
        {
            string result = string.Empty;
            var mc = new ManagementClass(wmiClass);
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (var o in moc)
            {
                var mo = (ManagementObject) o;
                if (mo[wmiMustBeTrue].ToString() == "True")
                {
                    //Only get the first one
                    if (string.IsNullOrWhiteSpace(result))
                    {
                        try
                        {
                            result = mo[wmiProperty].ToString();
                            break;
                        }
                        catch
                        {
                            // ignored
                        }
                    }
                }
            }
            return result;
        }
        //Return a hardware identifier
        private static string GetIdentifier(string wmiClass, string wmiProperty)
        {
            string result = string.Empty;
            var mc = new ManagementClass(wmiClass);
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (var o in moc)
            {
                var mo = (ManagementObject) o;
                //Only get the first one
                if (string.IsNullOrWhiteSpace(result))
                {
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }
            return result;
        }
        private static string CpuId()
        {
            //Uses first CPU identifier available in order of preference
            //Don't get all identifiers, as it is very time consuming
            string retVal = GetIdentifier("Win32_Processor", "UniqueId");
            if (retVal == "") //If no UniqueID, use ProcessorID
            {
                retVal = GetIdentifier("Win32_Processor", "ProcessorId");
                if (retVal == "") //If no ProcessorId, use Name
                {
                    retVal = GetIdentifier("Win32_Processor", "Name");
                    if (retVal == "") //If no Name, use Manufacturer
                    {
                        retVal = GetIdentifier("Win32_Processor", "Manufacturer");
                    }
                    //Add clock speed for extra security
                    retVal += GetIdentifier("Win32_Processor", "MaxClockSpeed");
                }
            }
            return retVal;
        }
        //BIOS Identifier
        private static string BiosId()
        {
            return GetIdentifier("Win32_BIOS", "Manufacturer")
            + GetIdentifier("Win32_BIOS", "SMBIOSBIOSVersion")
            + GetIdentifier("Win32_BIOS", "IdentificationCode")
            + GetIdentifier("Win32_BIOS", "SerialNumber")
            + GetIdentifier("Win32_BIOS", "ReleaseDate")
            + GetIdentifier("Win32_BIOS", "Version");
        }
        //Main physical hard drive ID
        private static string DiskId()
        {
            return GetIdentifier("Win32_DiskDrive", "Model")
            + GetIdentifier("Win32_DiskDrive", "Manufacturer")
            + GetIdentifier("Win32_DiskDrive", "Signature")
            + GetIdentifier("Win32_DiskDrive", "TotalHeads");
        }
        //Motherboard ID
        private static string BaseId()
        {
            return GetIdentifier("Win32_BaseBoard", "Model")
            + GetIdentifier("Win32_BaseBoard", "Manufacturer")
            + GetIdentifier("Win32_BaseBoard", "Name")
            + GetIdentifier("Win32_BaseBoard", "SerialNumber");
        }
        //Primary video controller ID
        private static string VideoId()
        {
            return GetIdentifier("Win32_VideoController", "DriverVersion") + GetIdentifier("Win32_VideoController", "Name");
        }
        //First enabled network card ID
        private static string MacId()
        {
            return GetIdentifier("Win32_NetworkAdapterConfiguration", "MACAddress", "IPEnabled");
        }
        #endregion

        public static string GenerateSecurityToken()
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string securityToken = Convert.ToBase64String(time.Concat(key).ToArray());
            return securityToken;
        }

        public static bool IsValidSecurityToken(string secToken)
        {
            try
            {
                bool isValidGuid = false;
                byte[] data = Convert.FromBase64String(secToken);

                var guid = data.Skip(8).Take(16).ToArray();
                try
                {
                    var tmpGuid = new Guid(guid);
                    isValidGuid = true;
                }
                catch
                {
                    isValidGuid = false;
                }
                DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
                if (when < DateTime.UtcNow.AddHours(-24))
                {
                    return false;
                }
                return when.Date == DateTime.UtcNow.Date && isValidGuid;
            }
            catch
            {
                // ignored
            }
            return false;
            
        }

        
    }
}
