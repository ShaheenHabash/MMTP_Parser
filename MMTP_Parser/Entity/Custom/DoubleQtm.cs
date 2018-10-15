using MMTP_Parser.Tools;
using System;
using System.Text;
namespace MMTP_Parser.Entity.Custom
{
    public class DoubleQtm
    {
        public string _lft = "0";
        public string _Qmt = "0";
        public double _Amount
        {
            get
            {
                if (_lft != "0")
                {
                    return _Qmt.SetAEMS(_lft);
                }
                else
                {
                    return 0.0;
                }
            }
        }

        public DoubleQtm(Byte[] vArrAll, int vQmtLevel)
        {
            _lft = Encoding.Default.GetString(vArrAll, 0, 1);//Decimal point locator
            _Qmt = Encoding.Default.GetString(vArrAll, 1, vQmtLevel);//Amount
        }
    }
}
