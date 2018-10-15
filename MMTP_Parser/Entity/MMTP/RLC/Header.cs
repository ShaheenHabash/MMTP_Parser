using MMTP_Parser.Entity.Custom;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMTP_Parser.Tools;
using MMTP_Parser.Entity.MMTP.RLC.MessageContent;

namespace MMTP_Parser.Entity.MMTP.RLC
{
    public class Header
    {
        public ObservableCollection<Field> _ObsFields { get; set; }
        public MessageContents _MessageContents { get; set; }
        public bool _IsFirstSubFiled = false;
        public bool _IsValedMessage = false;
        //***************************************************************************************
        public void FillFirstSub(Byte[] vArrFirstSub)
        {
            decimal xTypeOfHeaderForRlcMessage = vArrFirstSub.SubArray(1, 1).ToNumerical();
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            if (xTypeOfHeaderForRlcMessage == 1)
            {
                //**AEttRLCY1 ==> Header for RLC message, type 1 , Page ==> 82
                //**AEttTchRLCY1  ==> Technical header for RLC message, type 1 , Page 83
                xField = new Field("YTchRLC", FieldType.Numerical, 1, 1, "Type of header for RLC message", "", "179", "");
                _ObsFields.Add(xField);

                xField = new Field("CEmetRLC", FieldType.Numerical, 2, 2, "ID of the RLC sending application", "", "88", "");
                _ObsFields.Add(xField);

                xField = new Field("ZOctMsgRLC", FieldType.Numerical, 3, 4, "RLC message length in bytes (3 digits)", "", "182", "");
                _ObsFields.Add(xField);

                xField = new Field("NMsgInRLC", FieldType.Numerical, 6, 7, "Number for incoming RLC message", "", "131", "");
                _ObsFields.Add(xField);

                xField = new Field("NMsgOutRLC", FieldType.Numerical, 6, 13, "Number for outgoing RLC message", "", "131", "");
                _ObsFields.Add(xField);

                xField = new Field("CGrRLC", FieldType.Alphanumerical, 2, 19, "RLC group code", "", "91", "");
                _ObsFields.Add(xField);

                xField = new Field("CSgrRLC", FieldType.Alphanumerical, 2, 21, "Code for RLC subgroup", "", "102", "");
                _ObsFields.Add(xField);

                xField = new Field("YMsgRLC", FieldType.Alphanumerical, 2, 23, "Type of RLC message", "", "174", "");
                _ObsFields.Add(xField);
                //##AEttTchRLCY1  ==> Technical header for RLC message, type 1 , Page 83

                //**AEttFnlRLCY1 ==> Functional header for RLC message, type 1 ,Page 82
                xField = new Field("CSicoRGA", FieldType.Alphanumerical, 6, 25, "Short instrument ID", "", "102", "");
                _ObsFields.Add(xField);

                xField = new Field("CValMne", FieldType.Alphanumerical, 5, 31, "Instrument mnemonic code", "", "104", "");
                _ObsFields.Add(xField);

                xField = new Field("CPlCot", FieldType.Numerical, 3, 36, "Market place ID for instrument", "", "98", "");
                _ObsFields.Add(xField);

                //**ADHEvenRLC ==> Aggregate for time stamp for RLC event (up to the milliseconds) , Page ==> 81
                xField = new Field("DEvenRLC", FieldType.Numerical, 8, 39, "Date of RLC event", "", "106", "");
                _ObsFields.Add(xField);

                xField = new Field("HEvenRLC", FieldType.Numerical, 6, 47, "Time of RLC event", "", "109", "");
                _ObsFields.Add(xField);

                xField = new Field("ZMlsHEvenRLC", FieldType.Alphanumerical, 3, 53, "Number of milliseconds in time of RLC event", "", "181", "");
                _ObsFields.Add(xField);
                //##ADHEvenRLC ==> Aggregate for time stamp for RLC event (up to the milliseconds) , Page ==> 81

                xField = new Field("InstrumentID", FieldType.Alphanumerical, 12, 56, "Instrument identifier", "", "119", "");
                _ObsFields.Add(xField);

                xField = new Field("ZOctMsgRLC5", FieldType.Numerical, 5, 68, "RLC message length in bytes (5 digits)", "", "182", "");
                _ObsFields.Add(xField);

                xField = new Field("Filler_1", FieldType.Alphanumerical, 12, 73, "", "");
                _ObsFields.Add(xField);
                //##AEttFnlRLCY1 ==> Functional header for RLC message, type 1 ,Page 82
                //##AEttRLCY1 ==> Header for RLC message, type 1 , Page ==> 82
                _ObsFields.FillArrByteInObsField(vArrFirstSub);
                _IsFirstSubFiled = true;
            }
        }
        //***************************************************************************************
        public void FillSecondSub(Byte[] vArrSecondSub)
        {
            _IsValedMessage = true;
            switch (_ObsFields.GetFieldFromObs("YMsgRLC")._Alphanumerical)
            {
                case "01":
                    _MessageContents = new Message_01();
                    break;
                case "02":
                    _MessageContents = new Message_02();
                    break;
                case "03":
                    _MessageContents = new Message_03();
                    break;
                case "04":
                    _MessageContents = new Message_04();
                    break;
                case "05":
                    _MessageContents = new Message_05();
                    break;
                case "07":
                    _MessageContents = new Message_07();
                    break;
                case "08":
                    _MessageContents = new Message_08();
                    break;
                case "16":
                    _MessageContents = new Message_16();
                    break;
                case "23":
                    _MessageContents = new Message_23();
                    break;
                case "30":
                    _MessageContents = new Message_30();
                    break;
                case "32":
                    _MessageContents = new Message_32();
                    break;
                case "33":
                    _MessageContents = new Message_33();
                    break;
                case "37":
                    _MessageContents = new Message_37();
                    break;
                case "52":
                    _MessageContents = new Message_52();
                    break;
                case "53":
                    _MessageContents = new Message_53();
                    break;
                case "5E":
                    _MessageContents = new Message_5E();
                    break;
                case "5F":
                    _MessageContents = new Message_5F();
                    break;
                case "5G":
                    _MessageContents = new Message_5G();
                    break;
                case "5J":
                    _MessageContents = new Message_5J();
                    break;
                case "A3":
                    _MessageContents = new Message_A3();
                    break;
                case "A4":
                    _MessageContents = new Message_A4();
                    break;
                case "A5":
                    _MessageContents = new Message_A5();
                    break;
                case "B1":
                    _MessageContents = new Message_B1();
                    break;
                case "M1":
                    _MessageContents = new Message_M1();
                    break;
                default:
                    _IsValedMessage = false;
                    break;
            }
            if (_IsValedMessage && _MessageContents._ObsFields != null)
            {
                _MessageContents._ObsFields = _MessageContents._ObsFields.FillArrByteInObsField(vArrSecondSub);
            }
        }
        //***************************************************************************************
    }
}
