using MMTP_Parser.Entity.MMTP.DIFF.BusinessData.Technical;
using MMTP_Parser.Entity.MMTP.DIFF.BusinessData.InstrumentCharacteristic;
using MMTP_Parser.Entity.Custom;
using MMTP_Parser.Tools;
using System;
using MMTP_Parser.Entity.MMTP.DIFF.BusinessData.MessageContent;

namespace MMTP_Parser.Entity.MMTP.DIFF.BusinessData
{
    public class BusinessDataHeader
    {
        public TechnicalHeader _TechnicalHeader { get; set; }
        public InstrumentCharacteristicHeader _InstrumentCharacteristicHeader { get; set; }
        public MessageContents _MessageContents { get; set; }
        public bool _IsValedMessage = false;

        public BusinessDataHeader(Byte[] vArrAll)
        {
            _TechnicalHeader = new TechnicalHeader();
            _TechnicalHeader._ObsFields = _TechnicalHeader._ObsFields.FillArrByteInObsField(vArrAll.SubArray(0, 25));

            _InstrumentCharacteristicHeader = new InstrumentCharacteristicHeader();
            _InstrumentCharacteristicHeader._ObsFields = _InstrumentCharacteristicHeader._ObsFields.FillArrByteInObsField(vArrAll.SubArray(25, 52));
            _IsValedMessage = true;
            switch (_InstrumentCharacteristicHeader._ObsFields.GetFieldFromObs("Message_Type_Code")._Alphanumerical)
            {
                case "0001":
                    _MessageContents = new Message_01();
                    break;
                case "0002":
                    _MessageContents = new Message_02();
                    break;
                case "0003":
                    _MessageContents = new Message_03();
                    break;
                case "0004":
                    _MessageContents = new Message_04();
                    break;
                case "0005":
                    _MessageContents = new Message_05();
                    break;
                case "0007":
                    _MessageContents = new Message_07();
                    break;
                case "0008":
                    _MessageContents = new Message_08();
                    break;
                case "0016":
                    _MessageContents = new Message_16();
                    break;
                case "0023":
                    _MessageContents = new Message_23();
                    break;
                case "0030":
                    _MessageContents = new Message_30();
                    break;
                case "0032":
                    _MessageContents = new Message_32();
                    break;
                case "0033":
                    _MessageContents = new Message_33();
                    break;
                case "0037":
                    _MessageContents = new Message_37();
                    break;
                case "0052":
                    _MessageContents = new Message_52();
                    break;
                case "0053":
                    _MessageContents = new Message_53();
                    break;
                case "005E":
                    _MessageContents = new Message_5E();
                    break;
                case "005F":
                    _MessageContents = new Message_5F();
                    break;
                case "005G":
                    _MessageContents = new Message_5G();
                    break;
                case "005J":
                    _MessageContents = new Message_5J();
                    break;
                case "00A0":
                    _MessageContents = new Message_A0();
                    break;
                case "00A3":
                    _MessageContents = new Message_A3();
                    break;
                case "00A4":
                    _MessageContents = new Message_A4();
                    break;
                case "00A5":
                    _MessageContents = new Message_A5();
                    break;
                case "00A6":
                    _MessageContents = new Message_A6();
                    break;
                case "00B1":
                    _MessageContents = new Message_B1();
                    break;
                default:
                    _IsValedMessage = false;
                    break;
            }
            if (_IsValedMessage && _MessageContents._ObsFields != null)
            {
                _MessageContents._ObsFields = _MessageContents._ObsFields.FillArrByteInObsField(vArrAll.SubArray(76, vArrAll.Length - 76));
            }

            //**Proccess for 0004 message only
            if (_InstrumentCharacteristicHeader._ObsFields.GetFieldFromObs("Message_Type_Code")._Alphanumerical == "0004")
            {
                string[] xArrItabModMeLim = new string[6];
                int[] xArrMoveTo = new int[6];
                bool xIsFullChange = true;
                int xMomeCount = 0;
                //int xChangeCount = 0;
                for (int i = 0; i < xArrItabModMeLim.Length; i++)
                {
                    string xItabModMeLim = _MessageContents._ObsFields.GetFieldFromObs("ItabModMeLim_" + (i + 1))._Alphanumerical;
                    if (xItabModMeLim == "1")
                    {
                        xArrMoveTo[i] = i + 1;
                        xMomeCount++;
                    }
                    else
                    {
                        xIsFullChange = false;
                        xArrMoveTo[i] = 0;
                    }
                    xArrItabModMeLim[i] = xItabModMeLim;
                }
                if (!xIsFullChange)
                {
                    if (_InstrumentCharacteristicHeader._ObsFields.GetFieldFromObs("CValMne")._Alphanumerical == "FFCO ")
                    {

                    }
                    for (int i = xArrMoveTo.Length - 1; i >= 0; i--)
                    {
                        if (xArrMoveTo[i] > 0)
                        {
                            _MessageContents._ObsFields.Move_AMeLim(xMomeCount, xArrMoveTo[i]);
                            xMomeCount--;
                        }
                    } 
                }

            }
            //##Proccess for 0004 message only
        }
    }
}
