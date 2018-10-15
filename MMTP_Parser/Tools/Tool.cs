using MMTP_Parser.Entity.Custom;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MMTP_Parser.Tools
{
    public static class Tool
    {
        public static string _ProtocoleMode = "";
        //********************************************************************************************
        /// <summary>
        /// Powered by Shaheen Al-Habash 2017-11-12
        /// </summary>
        /// <param name="vArrAll"></param>
        /// <returns>decimal</returns>
        public static decimal ToNumerical(this byte[] vArrAll)
        {
            decimal xReval = 0;
            if (vArrAll.Length == 1 && Tool._ProtocoleMode == "diff")
            {
                xReval = vArrAll[0].Nvl(0);
            }
            else
            {
                try
                {
                    xReval = Encoding.Default.GetString(vArrAll).Nvl(0);
                }
                catch (Exception)
                {
                }
            }
            return xReval;
        }
        //********************************************************************************************
        /// <summary>
        /// Powered by Shaheen Al-Habash 2017-11-12
        /// </summary>
        /// <param name="vData"></param>
        /// <param name="vIndex"></param>
        /// <param name="vLength"></param>
        /// <returns>T[]</returns>
        public static T[] SubArray<T>(this T[] vData, int vIndex, int vLength)
        {
            T[] xResult = new T[vLength];
            Array.Copy(vData, vIndex, xResult, 0, vLength);
            return xResult;
        }
        //********************************************************************************************
        /// <summary>
        /// Powered by Shaheen Al-Habash 2017-11-12
        /// </summary>
        /// <param name="vArrAll"></param>
        /// <returns></returns>
        //********************************************************************************************
        public static ObservableCollection<Field> FillArrByteInObsField(this ObservableCollection<Field> vObs, Byte[] vArrAll)
        {
            foreach (var iItem in vObs)
            {
                if (iItem._Position + iItem._Length > vArrAll.Length)
                {
                    break;
                }
                if (iItem._Name.Contains("Filler_"))
                {
                    continue;
                }
                if (iItem._Name.Contains("ItabModMeLim_"))
                {

                }
                switch (iItem._Type)
                {
                    case FieldType.Alphanumerical:
                        if (iItem._Length == 1 && Tool._ProtocoleMode == "diff" && !iItem._Name.Contains("ItabModMeLim_"))
                        {
                            iItem._Alphanumerical = vArrAll.SubArray(iItem._Position, iItem._Length)[0].Nvl("");
                        }
                        else
                        {
                            iItem._Alphanumerical = Encoding.Default.GetString(vArrAll, iItem._Position, iItem._Length);
                        }
                        break;
                    case FieldType.Numerical:
                        iItem._Numerical = vArrAll.SubArray(iItem._Position, iItem._Length).ToNumerical();
                        break;
                    case FieldType.Binary:
                        iItem._Binary = vArrAll.SubArray(iItem._Position, iItem._Length);
                        break;
                    case FieldType.QtmX:
                        iItem._QtmX = new DoubleQtm(vArrAll.SubArray(iItem._Position, iItem._Length), iItem._Length - 1);
                        break;
                }
            }
            return vObs;
        }
        //********************************************************************************************
        /// <summary>
        /// Powered by Shaheen Al-Habash 2018-07-19
        /// </summary>
        /// <param name="vObs"></param>
        /// <returns></returns>
        //********************************************************************************************
        public static ObservableCollection<Field> Move_AMeLim(this ObservableCollection<Field> vObs,int vFrom,int vTo)
        {
            if (vFrom < vTo)
            {
                vObs.GetFieldFromObs("QTitMeDem_" + vTo)._Numerical = vObs.GetFieldFromObs("QTitMeDem_" + vFrom)._Numerical;
                vObs.GetFieldFromObs("QTitMeDem_" + vFrom)._Numerical = 0;

                vObs.GetFieldFromObs("ZOrdMeDem_" + vTo)._Numerical = vObs.GetFieldFromObs("ZOrdMeDem_" + vFrom)._Numerical;
                vObs.GetFieldFromObs("ZOrdMeDem_" + vFrom)._Numerical = 0;

                vObs.GetFieldFromObs("PmeDem_" + vTo)._QtmX = vObs.GetFieldFromObs("PmeDem_" + vFrom)._QtmX;
                vObs.GetFieldFromObs("PmeDem_" + vFrom)._QtmX = null;

                vObs.GetFieldFromObs("PmeOf_" + vTo)._QtmX = vObs.GetFieldFromObs("PmeOf_" + vFrom)._QtmX;
                vObs.GetFieldFromObs("PmeOf_" + vFrom)._QtmX = null;

                vObs.GetFieldFromObs("ZOrdMeOf_" + vTo)._Numerical = vObs.GetFieldFromObs("ZOrdMeOf_" + vFrom)._Numerical;
                vObs.GetFieldFromObs("ZOrdMeOf_" + vFrom)._Numerical = 0;

                vObs.GetFieldFromObs("QTitMeOf_" + vTo)._Numerical = vObs.GetFieldFromObs("QTitMeOf_" + vFrom)._Numerical;
                vObs.GetFieldFromObs("QTitMeOf_" + vFrom)._Numerical = 0;
            }
            return vObs;
        }
        //*************************************************************
        /// <summary>
        /// Powered by Shaheen Al-Habash 2017-11-12
        /// </summary>
        /// <param name="vObs"></param>
        /// <param name="vName"></param>
        /// <returns>Field</returns>
        public static Field GetFieldFromObs(this ObservableCollection<Field> vObs, string vName)
        {
            foreach (var iItem in vObs)
            {
                if (iItem._Name == vName)
                {
                    return iItem;
                }
            }
            return null;
        }

        //*************************************************************
        /// <summary>
        /// Powered by Shaheen Al-Habash 2016-01-24
        /// </summary>
        /// <param name="vValue"></param>
        /// <param name="vReValue"></param>
        /// <returns></returns>
        public static int Nvl(this object vValue, int vReValue)
        {
            if (vValue == null)
                return vReValue;
            else if (vValue is System.DBNull)
                return vReValue;
            else if (vValue.ToString() == "")
                return vReValue;
            else
                try
                {
                    return Convert.ToInt32(vValue);

                }
                catch (FormatException)
                {
                    return Convert.ToInt32(Convert.ToDouble(vValue));

                }
        }
        //*************************************************************
        /// <summary>
        /// Powered by Shaheen Al-Habash 2016-01-24
        /// </summary>
        /// <param name="vValue"></param>
        /// <param name="vReValue"></param>
        /// <returns></returns>
        public static double Nvl(this object vValue, double vReValue)
        {
            if (vValue == null)
                return vReValue;
            else if (vValue is System.DBNull)
                return vReValue;
            else if (vValue.ToString() == "")
                return vReValue;
            else
                return Convert.ToDouble(vValue);
        }
        //*************************************************************
        /// <summary>
        /// Powered by Shaheen Al-Habash 2016-01-24
        /// </summary>
        /// <param name="vValue"></param>
        /// <param name="vReValue"></param>
        /// <returns></returns>
        public static string Nvl(this object vValue, string vReValue)
        {
            if (vValue == null)
                return vReValue;
            else if (vValue is DBNull)
                return vReValue;
            else if (vValue.ToString() == "")
                return vReValue;
            else
                return Convert.ToString(vValue);
        }
        //*************************************************************
        /// <summary>
        /// Powered by Shaheen Al-Habash 2016-01-24
        /// Move Pointer Of vNetStream number of byte equal to vNumOfByte
        /// </summary>
        /// <param name="vNetStream"></param>
        /// <param name="vNumOfByte"></param>
        public static void ReadDummy(this NetworkStream vNetStream, int vNumOfByte)
        {
            for (int i = 0; i < vNumOfByte; i++)
            {
                vNetStream.ReadByte();
            }
        }
        //*************************************************************
        /// <summary>
        /// Powered by Shaheen Al-Habash 2016-01-27
        /// Set Decimal point for vAmount starting from left until vDecimalPointLocator
        /// vDecimalPointLocator Values ==>
        /// 0-9 Positive
        /// A-I Nigative
        /// </summary>
        /// <param name="vAmount"></param>
        /// <param name="vDecimalPointLocator"></param>
        /// <returns>double</returns>
        public static double SetAEMS(this string vAmount, string vDecimalPointLocator)
        {
            double xReVal = 0d;
            if (!IsChar(vDecimalPointLocator))
            {
                switch (vDecimalPointLocator.Trim().ToUpper())
                {
                    case "0":
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "10":
                    case "11":
                    case "12":
                    case "13":
                    case "14":
                    case "15":
                    case "16":
                    case "17":
                    case "18":
                    case "19":
                    case "20":
                    case "21":
                    case "22":
                    case "23":
                    case "24":
                    case "25":
                        xReVal = vAmount.Nvl(0d) / Math.Pow(10, vDecimalPointLocator.Nvl(0));
                        break;
                }
            }
            else
            {
                string xDecimalPointLocator = (CharToInteger((char)vDecimalPointLocator.Trim().ToUpper().ToCharArray()[0]) - 1).ToString();
                switch (xDecimalPointLocator)
                {
                    case "0":
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "10":
                    case "11":
                    case "12":
                    case "13":
                    case "14":
                    case "15":
                    case "16":
                    case "17":
                    case "18":
                    case "19":
                    case "20":
                    case "21":
                    case "22":
                    case "23":
                    case "24":
                    case "25":
                        xReVal = -vAmount.Nvl(0d) / Math.Pow(10, xDecimalPointLocator.Nvl(0));
                        break;
                }
            }
            return xReVal;
        }
        //*************************************************************
        /// <summary>
        /// Powered by Shaheen Al-Habash 2017-10-23
        /// check if vStr string is charecter
        /// vStr Values ==>
        /// a-z OR A-Z
        /// </summary>
        /// <param name="vStr"></param>
        /// <returns>bool</returns>
        private static bool IsChar(String vStr)
        {
            return Regex.IsMatch(vStr, @"^[a-zA-Z]+$");
        }
        //*************************************************************
        /// <summary>
        /// Powered by Shaheen Al-Habash 2017-10-23
        /// Convert vChar to its equivalent integer
        /// vChar Values ==>
        /// a-z OR A-Z
        /// </summary>
        /// <param name="vChar"></param>
        /// <returns>int</returns>
        private static int CharToInteger(char vChar)
        {
            return (char.ToUpper(vChar) - 64);// For 'A'  ==> index == 1
        }
        //*************************************************************
        public static void WriteToTxtMmtpUnReadable(Byte[] vArrFirstSub, Byte[] vArrSecondSub)
        {
            using (FileStream fs = new FileStream(string.Format("MMTP-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".log"), FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                string xMessage = "";
                foreach (var iItem in vArrFirstSub)
                {
                    xMessage += iItem + ",";
                }
                foreach (var iItem in vArrSecondSub)
                {
                    xMessage += iItem + ",";
                }
                xMessage = xMessage.Remove(xMessage.Length - 1);
                sw.Write(xMessage + "\n");
            }
        }
        //*************************************************************
        public static void WriteToTxtMmtpDiffReadable(MMTP_Parser.Entity.MMTP.DIFF.Header vHeader)
        {
            string xMessageReadable = "";

            xMessageReadable = vHeader._BusinessDataHeader._InstrumentCharacteristicHeader._ObsFields.GetFieldFromObs("Message_Type_Code")._Alphanumerical + "," + vHeader._BusinessDataHeader._InstrumentCharacteristicHeader._ObsFields.GetFieldFromObs("CValMne")._Alphanumerical + ",";
            foreach (var item in vHeader._BusinessDataHeader._MessageContents._ObsFields)
            {
                xMessageReadable += item._Name + "==>";
                try
                {
                    switch (item._Type)
                    {
                        case FieldType.Alphanumerical:
                            xMessageReadable += item._Alphanumerical + ",";
                            break;
                        case FieldType.Numerical:
                            xMessageReadable += item._Numerical + ",";
                            break;
                        case FieldType.Binary:
                            xMessageReadable += ",";
                            break;
                        case FieldType.QtmX:
                            xMessageReadable += item._QtmX._Amount + ",";
                            break;
                        case FieldType.BusinessDataHeader:
                            xMessageReadable += ",";
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    xMessageReadable += ",";
                }
            }
            xMessageReadable = xMessageReadable.Remove(xMessageReadable.Length - 1);
            using (FileStream fs = new FileStream(string.Format("MMTP-Readable-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".log"), FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(xMessageReadable + "\n");
            }
        }
        //*************************************************************
        public static void WriteToTxtMmtpRlcReadable(MMTP_Parser.Entity.MMTP.RLC.Header vHeader)
        {
            string xMessageReadable = "";

            xMessageReadable = vHeader._ObsFields.GetFieldFromObs("YMsgRLC")._Alphanumerical + "," + vHeader._ObsFields.GetFieldFromObs("CValMne")._Alphanumerical + ",";
            foreach (var item in vHeader._MessageContents._ObsFields)
            {
                xMessageReadable += item._Name + "==>";
                try
                {
                    switch (item._Type)
                    {
                        case FieldType.Alphanumerical:
                            xMessageReadable += item._Alphanumerical + ",";
                            break;
                        case FieldType.Numerical:
                            xMessageReadable += item._Numerical + ",";
                            break;
                        case FieldType.Binary:
                            xMessageReadable += ",";
                            break;
                        case FieldType.QtmX:
                            xMessageReadable += item._QtmX._Amount + ",";
                            break;
                        case FieldType.BusinessDataHeader:
                            xMessageReadable += ",";
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    xMessageReadable += ",";
                }
            }
            xMessageReadable = xMessageReadable.Remove(xMessageReadable.Length - 1);
            using (FileStream fs = new FileStream(string.Format("MMTP-Readable-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".log"), FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(xMessageReadable + "\n");
            }
        }
        //*************************************************************

    }
}
