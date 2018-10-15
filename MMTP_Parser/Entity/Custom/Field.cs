using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTP_Parser.Entity.Custom
{
    public class Field
    {
        public string _Name { get; set; }
        public FieldType _Type { get; set; }
        public int _Length { get; set; }
        public int _Position { get; set; }
        public string _Short_Description { get; set; }
        public string _DefultValue { get; set; }
        public string _Page { get; set; }
        public string _Occurance { get; set; }

        public string _Alphanumerical { get; set; }
        public decimal _Numerical { get; set; }
        public Byte[] _Binary { get; set; }
        public DoubleQtm _QtmX { get; set; }
        //********************************************************************************************
        //All
        public Field(string vName, FieldType vType, int vLength, int vPosition, string vShort_Description, string vDefultValue, string vPage, string vOccurance, string vAlphanumerical, decimal vNumerical, Byte[] vBinary, DoubleQtm vQtmX)
        {
            this._Name = vName;
            this._Type = vType;
            this._Length = vLength;
            this._Position = vPosition;
            this._Short_Description = vShort_Description;
            this._DefultValue = vDefultValue;
            this._Page = vPage;
            this._Occurance = vOccurance;
            this._Alphanumerical = vAlphanumerical;
            this._Numerical = vNumerical;
            this._Binary = vBinary;
            this._QtmX = vQtmX;
        }
        //********************************************************************************************
        public Field(string vName, FieldType vType, int vLength, int vPosition, string vShort_Description, string vDefultValue, string vPage, string vOccurance)
        {
            this._Name = vName;
            this._Type = vType;
            this._Length = vLength;
            this._Position = vPosition;
            this._Short_Description = vShort_Description;
            this._DefultValue = vDefultValue;
            this._Page = vPage;
            this._Occurance = vOccurance;
        }
        //********************************************************************************************
        public Field(string vName, FieldType vType, int vLength, int vPosition, string vShort_Description, string vDefultValue)
        {
            this._Name = vName;
            this._Type = vType;
            this._Length = vLength;
            this._Position = vPosition;
            this._Short_Description = vShort_Description;
            this._DefultValue = vDefultValue;
        }
        //********************************************************************************************
    }
}
