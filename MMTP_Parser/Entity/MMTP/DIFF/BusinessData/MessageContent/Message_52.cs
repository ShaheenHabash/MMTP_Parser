using MMTP_Parser.Entity.Custom;
using System.Collections.ObjectModel;
namespace MMTP_Parser.Entity.MMTP.DIFF.BusinessData.MessageContent
{
    /// <summary>
    ///Definition
    /// This message indicates the main characteristics of a listed instrument:
    ///     * Characteristics of the instrument itself
    ///     * Trading characteristics of the instrument
    ///     * Previous trading day price and amount of capital traded.
    /// The message contains characteristics that are valid on D+1. The MMTP message header contains the switching criteria that are valid on D+1; the date of MMTP event is D+1 if D is the trading day that is just finishing when the message is sent.
    /// This message allows receiving application to initialize their local Instrument Referential at the beginning of the Trading Day.
    ///Transmission functions
    /// This message is sent for every listed security affected by one of the following events:
    ///     * The listed security has been created with effect on D+1;
    ///     * The listed security exists in the Closed state on day D and changes to Open on D+1;
    ///     * At least one of the listed security's characteristics or at least one of the related instrument's Characteristics has been modified by an event that takes effect on D+1;
    ///     * The AFC code of the instrument has changed with effect on D+1.
    /// </summary>
    public class Message_52 : MessageContents //Length ==> 1705 , Short description ==> Deletion of Instrument Characteristics
    {
        //********************************************************************************************
        public Message_52()
        {
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            //ACarValRLC ==> Aggregate for instrument characteristics , Page ==> 50
            xField = new Field("Lval18", FieldType.Alphanumerical, 18, 1, "18-character instrument name", "", "97", "");
            _ObsFields.Add(xField);

            xField = new Field("YVal", FieldType.Numerical, 3, 19, "Type of instrument", "", "146", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_1", FieldType.Alphanumerical, 1, 22, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("CPyEmet", FieldType.Alphanumerical, 3, 23, "Code (ISO3A norm) for country of issuer", "", "68", "");
            _ObsFields.Add(xField);

            xField = new Field("QnmVlo", FieldType.QtmX, 14, 26, "Amount of par value of instrument for calculating amount for trade", "", "115", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_2", FieldType.Alphanumerical, 3, 40, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("ZTitAd", FieldType.Numerical, 12, 43, "Number of shares or bonds outstanding", "", "150", "");
            _ObsFields.Add(xField);

            xField = new Field("CSocCSAC", FieldType.Alphanumerical, 5, 55, "Code for issuing company", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("Lsoc30", FieldType.Alphanumerical, 30, 60, "30-character AFC name for issuing company", "", "97", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_3", FieldType.Alphanumerical, 66, 90, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("DESop", FieldType.Numerical, 8, 156, "Date on which the creation, modification, or deletion of an instrument takes effect", "", "74", "");
            _ObsFields.Add(xField);

            xField = new Field("YOPSJ", FieldType.Numerical, 2, 164, "Type of corporate event causing instrument modification on current day", "", "143", "");
            _ObsFields.Add(xField);

            xField = new Field("CGdSVal", FieldType.Alphanumerical, 1, 166, "Code of the instrument category", "", "61", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_4", FieldType.Alphanumerical, 7, 167, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("CDevPEmis", FieldType.Alphanumerical, 3, 174, "Currency code (ISO3A format) for issue price of bond or warrant", "", "58", "");
            _ObsFields.Add(xField);

            xField = new Field("Pemis", FieldType.QtmX, 14, 177, "Issue price for an instrument (bond, new issue, right, or warrant)", "", "105", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_5", FieldType.Alphanumerical, 14, 191, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("IlcoVwap", FieldType.Alphanumerical, 1, 205, "VWAP listed security flag", "", "85", "");
            _ObsFields.Add(xField);

            xField = new Field("CGrValCot", FieldType.Alphanumerical, 2, 206, "Instrument group ID", "", "62", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_6", FieldType.Alphanumerical, 15, 208, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("CPyCot", FieldType.Alphanumerical, 3, 223, "Code (ISO3A norm) for the country where the instrument is listed", "", "67", "");
            _ObsFields.Add(xField);

            xField = new Field("CDevCot", FieldType.Alphanumerical, 3, 226, "Trading currency code according to the Iso3A coding system", "", "58", "");
            _ObsFields.Add(xField);

            xField = new Field("DInMar", FieldType.Numerical, 8, 229, "Date of first day of trading for instrument", "", "75", "");
            _ObsFields.Add(xField);

            xField = new Field("CCpmLco", FieldType.Alphanumerical, 1, 337, "ID of segment for listed security", "", "58", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_7", FieldType.Alphanumerical, 6, 238, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("CIdxPasCotVarVal", FieldType.Alphanumerical, 2, 244, "Index of the Variable Tick Table", "", "64", "");
            _ObsFields.Add(xField);

            xField = new Field("YUniExpP", FieldType.Numerical, 1, 246, "Type of unit of expression for instrument price", "", "146", "");
            _ObsFields.Add(xField);

            xField = new Field("DDrCV", FieldType.Numerical, 8, 247, "Date of last price for instrument", "", "73", "");
            _ObsFields.Add(xField);

            xField = new Field("PDrAjSajCotV", FieldType.QtmX, 14, 255, "Last adjusted and super-adjusted closing price", "", "103", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_8", FieldType.Alphanumerical, 13, 269, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("PDrAjCotV", FieldType.QtmX, 14, 282, "Last adjusted closing price", "", "102", "");
            _ObsFields.Add(xField);

            xField = new Field("QpasCotFxeVal", FieldType.QtmX, 14, 296, "Amount of the fixed price tick for an instrument", "", "116", "");
            _ObsFields.Add(xField);

            xField = new Field("Lval18AFC", FieldType.Alphanumerical, 18, 310, "18-character instrument name (AFC norm)", "", "98", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_9", FieldType.Alphanumerical, 19, 328, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("CAFCValObjMsg", FieldType.Alphanumerical, 6, 347, "Cash Product code for instrument about which the message is sent", "", "57", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_10", FieldType.Alphanumerical, 50, 353, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("QqtTranMarVal", FieldType.Numerical, 12, 403, "Instrument lot size", "", "116", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_11", FieldType.Alphanumerical, 9, 415, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("Lval30", FieldType.Alphanumerical, 30, 424, "30-character instrument name", "", "98", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_12", FieldType.Alphanumerical, 21, 454, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("CIsin", FieldType.Alphanumerical, 12, 475, "ISIN code for the Cash product", "", "64", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_13", FieldType.Alphanumerical, 48, 487, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("ZNorTitBlcNg", FieldType.Numerical, 12, 535, "Weighted Average spread quantity", "", "147", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_14", FieldType.Alphanumerical, 25, 547, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("CFlmVal", FieldType.Alphanumerical, 2, 572, "Market flow code for an instrument", "", "61", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_15", FieldType.Alphanumerical, 57, 574, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("DHDebCotProdMdv", FieldType.Alphanumerical, 14, 631, "Date and time at which trading starts on a derivative product", "", "74", "");
            _ObsFields.Add(xField);

            xField = new Field("DHFinCotProdMdv", FieldType.Alphanumerical, 14, 645, "Date and time at which trading ends on a derivative product", "", "75", "");
            _ObsFields.Add(xField);

            xField = new Field("IvaliOmIns", FieldType.Alphanumerical, 1, 659, "Default date validity", "", "91", "");
            _ObsFields.Add(xField);

            //Occ. 40
            xField = new Field("CProdCpsProdYCbn_1", FieldType.Alphanumerical, 12, 660, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_2", FieldType.Alphanumerical, 12, 672, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_3", FieldType.Alphanumerical, 12, 684, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_4", FieldType.Alphanumerical, 12, 696, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_5", FieldType.Alphanumerical, 12, 708, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_6", FieldType.Alphanumerical, 12, 720, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_7", FieldType.Alphanumerical, 12, 732, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_8", FieldType.Alphanumerical, 12, 744, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_9", FieldType.Alphanumerical, 12, 756, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_10", FieldType.Alphanumerical, 12, 768, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_11", FieldType.Alphanumerical, 12, 780, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_12", FieldType.Alphanumerical, 12, 792, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_13", FieldType.Alphanumerical, 12, 804, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_14", FieldType.Alphanumerical, 12, 816, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_15", FieldType.Alphanumerical, 12, 828, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_16", FieldType.Alphanumerical, 12, 840, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_17", FieldType.Alphanumerical, 12, 852, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_18", FieldType.Alphanumerical, 12, 864, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_19", FieldType.Alphanumerical, 12, 876, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_20", FieldType.Alphanumerical, 12, 888, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_21", FieldType.Alphanumerical, 12, 900, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_22", FieldType.Alphanumerical, 12, 912, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_23", FieldType.Alphanumerical, 12, 924, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_24", FieldType.Alphanumerical, 12, 936, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_25", FieldType.Alphanumerical, 12, 948, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_26", FieldType.Alphanumerical, 12, 960, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_27", FieldType.Alphanumerical, 12, 972, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_28", FieldType.Alphanumerical, 12, 984, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_29", FieldType.Alphanumerical, 12, 996, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_30", FieldType.Alphanumerical, 12, 1008, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_31", FieldType.Alphanumerical, 12, 1020, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_32", FieldType.Alphanumerical, 12, 1032, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_33", FieldType.Alphanumerical, 12, 1044, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_34", FieldType.Alphanumerical, 12, 1056, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_35", FieldType.Alphanumerical, 12, 1068, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_36", FieldType.Alphanumerical, 12, 1080, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_37", FieldType.Alphanumerical, 12, 1092, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_38", FieldType.Alphanumerical, 12, 1104, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_39", FieldType.Alphanumerical, 12, 1116, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            xField = new Field("CProdCpsProdYCbn_40", FieldType.Alphanumerical, 12, 1128, "NSC® Code for a combined product component", "", "67", "40");
            _ObsFields.Add(xField);

            //AKProdCpsProdYCbn ==> Aggregate ratio for a leg of strategy instrument ,Occ. 40 , Page ==> 54
            xField = new Field("CSignKMuProdCps_1", FieldType.Alphanumerical, 1, 1140, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_1", FieldType.Numerical, 2, 1141, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_2", FieldType.Alphanumerical, 1, 1143, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_2", FieldType.Numerical, 2, 1144, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_3", FieldType.Alphanumerical, 1, 1146, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_3", FieldType.Numerical, 2, 1147, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_4", FieldType.Alphanumerical, 1, 1149, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_4", FieldType.Numerical, 2, 1150, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_5", FieldType.Alphanumerical, 1, 1152, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_5", FieldType.Numerical, 2, 1153, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_6", FieldType.Alphanumerical, 1, 1155, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_6", FieldType.Numerical, 2, 1156, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_7", FieldType.Alphanumerical, 1, 1158, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_7", FieldType.Numerical, 2, 1159, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_8", FieldType.Alphanumerical, 1, 1161, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_8", FieldType.Numerical, 2, 1162, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_9", FieldType.Alphanumerical, 1, 1164, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_9", FieldType.Numerical, 2, 1165, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_10", FieldType.Alphanumerical, 1, 1167, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_10", FieldType.Numerical, 2, 1168, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_11", FieldType.Alphanumerical, 1, 1170, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_11", FieldType.Numerical, 2, 1171, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_12", FieldType.Alphanumerical, 1, 1173, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_12", FieldType.Numerical, 2, 1174, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_13", FieldType.Alphanumerical, 1, 1176, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_13", FieldType.Numerical, 2, 1177, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_14", FieldType.Alphanumerical, 1, 1179, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_14", FieldType.Numerical, 2, 1180, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_15", FieldType.Alphanumerical, 1, 1182, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_15", FieldType.Numerical, 2, 1183, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_16", FieldType.Alphanumerical, 1, 1185, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_16", FieldType.Numerical, 2, 1186, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_17", FieldType.Alphanumerical, 1, 1188, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_17", FieldType.Numerical, 2, 1189, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_18", FieldType.Alphanumerical, 1, 1191, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_18", FieldType.Numerical, 2, 1192, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_19", FieldType.Alphanumerical, 1, 1193, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_19", FieldType.Numerical, 2, 1194, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_20", FieldType.Alphanumerical, 1, 1196, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_20", FieldType.Numerical, 2, 1197, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_21", FieldType.Alphanumerical, 1, 1199, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_21", FieldType.Numerical, 2, 1200, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_22", FieldType.Alphanumerical, 1, 1202, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_22", FieldType.Numerical, 2, 1203, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_23", FieldType.Alphanumerical, 1, 1205, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_23", FieldType.Numerical, 2, 1206, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_24", FieldType.Alphanumerical, 1, 1208, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_24", FieldType.Numerical, 2, 1209, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_25", FieldType.Alphanumerical, 1, 1211, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_25", FieldType.Numerical, 2, 1212, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_26", FieldType.Alphanumerical, 1, 1214, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_26", FieldType.Numerical, 2, 1215, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_27", FieldType.Alphanumerical, 1, 1217, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_27", FieldType.Numerical, 2, 1218, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_28", FieldType.Alphanumerical, 1, 1220, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_28", FieldType.Numerical, 2, 1221, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_29", FieldType.Alphanumerical, 1, 1223, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_29", FieldType.Numerical, 2, 1224, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_30", FieldType.Alphanumerical, 1, 1226, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_30", FieldType.Numerical, 2, 1227, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_31", FieldType.Alphanumerical, 1, 1229, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_31", FieldType.Numerical, 2, 1230, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_32", FieldType.Alphanumerical, 1, 1232, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_32", FieldType.Numerical, 2, 1233, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_33", FieldType.Alphanumerical, 1, 1235, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_33", FieldType.Numerical, 2, 1237, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_34", FieldType.Alphanumerical, 1, 1239, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_34", FieldType.Numerical, 2, 1240, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_35", FieldType.Alphanumerical, 1, 1242, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_35", FieldType.Numerical, 2, 1243, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_36", FieldType.Alphanumerical, 1, 1345, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_36", FieldType.Numerical, 2, 1246, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_37", FieldType.Alphanumerical, 1, 1248, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_37", FieldType.Numerical, 2, 1249, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_38", FieldType.Alphanumerical, 1, 1251, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_38", FieldType.Numerical, 2, 1252, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_39", FieldType.Alphanumerical, 1, 1254, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_39", FieldType.Numerical, 2, 1255, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("CSignKMuProdCps_40", FieldType.Alphanumerical, 1, 1257, "Leg multiplication coefficient sign", "", "70", "");
            _ObsFields.Add(xField);

            xField = new Field("KmuProdCpsProdCbn_40", FieldType.Numerical, 2, 1258, "Leg multiplication ratio", "", "95", "");
            _ObsFields.Add(xField);


            xField = new Field("Filler_16", FieldType.Alphanumerical, 1, 1260, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("YExpVarPValDrPRf", FieldType.Alphanumerical, 1, 1261, "Net change expression type", "", "140", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_17", FieldType.Alphanumerical, 14, 1262, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("PExoProdMdv", FieldType.QtmX, 14, 1276, "Strike price for a derivative product", "", "106", "");
            _ObsFields.Add(xField);

            xField = new Field("CDevPExoProdMdv", FieldType.Alphanumerical, 3, 1290, "Strike price currency code", "", "58", "");
            _ObsFields.Add(xField);

            xField = new Field("QtitMinSaiOmProd", FieldType.Numerical, 12, 1293, "Minimum quantity which can be entered for orders on the instrument", "", "119", "");
            _ObsFields.Add(xField);

            xField = new Field("QTitMaxSaiOmProd", FieldType.Numerical, 12, 1305, "Maximum quantity which can be entered for o rders on the instrument", "", "117", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_18", FieldType.Alphanumerical, 24, 1317, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("PsaiSMaxOkValMdv", FieldType.QtmX, 14, 1341, "High Intermediate Threshold", "", "108", "");
            _ObsFields.Add(xField);

            xField = new Field("PsaiSMinOkValMdv", FieldType.QtmX, 14, 1355, "Low Intermediate Threshold", "", "113", "");
            _ObsFields.Add(xField);

            xField = new Field("ZMaxLimDifVal", FieldType.Numerical, 2, 1369, "Maximum number of limits transmitted in the limit message for the instrument", "", "147", "");
            _ObsFields.Add(xField);

            xField = new Field("YAppaValMdv", FieldType.Alphanumerical, 1, 1371, "Matching type", "", "137", "");
            _ObsFields.Add(xField);

            xField = new Field("YQStg", FieldType.Alphanumerical, 13, 1372, "Strategy Quantity Type", "", "144", "");
            _ObsFields.Add(xField);

            xField = new Field("PCpsDrvObl", FieldType.QtmX, 14, 1375, "Future-type leg price", "", "102", "");
            _ObsFields.Add(xField);

            xField = new Field("XDtaStg", FieldType.QtmX, 14, 1389, "Delta Strategy percentage", "", "125", "");
            _ObsFields.Add(xField);

            xField = new Field("YStg", FieldType.Alphanumerical, 2, 1403, "Strategy Type", "", "144", "");
            _ObsFields.Add(xField);

            xField = new Field("YCreValMdv", FieldType.Alphanumerical, 1, 1405, "Strategy creation type", "", "138", "");
            _ObsFields.Add(xField);

            xField = new Field("CIdAdfCreValMdv", FieldType.Alphanumerical, 8, 1406, "Identification of the UDS Member creator", "", "62", "");
            _ObsFields.Add(xField);

            xField = new Field("CIdNgCreValMdv", FieldType.Alphanumerical, 8, 1414, "Identification of the UDS Trader creator", "", "64", "");
            _ObsFields.Add(xField);

            xField = new Field("CIsinProdSja", FieldType.Alphanumerical, 12, 1422, "ISIN code for the underlying product", "", "65", "");
            _ObsFields.Add(xField);

            xField = new Field("YMarNSC", FieldType.Alphanumerical, 2, 1434, "NSC® market segment", "", "140", "");
            _ObsFields.Add(xField);

            xField = new Field("YExoFamProdYOpt", FieldType.Alphanumerical, 1, 1436, "Execution type for an option instrument", "", "140", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_19", FieldType.Alphanumerical, 1, 1437, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("IetaPcsOl", FieldType.Alphanumerical, 1, 1438, "Implied order processing flag", "", "83", "");
            _ObsFields.Add(xField);

            xField = new Field("CComVal", FieldType.Alphanumerical, 1, 1439, "Board Code", "", "57", "");
            _ObsFields.Add(xField);

            xField = new Field("CSecVal", FieldType.Alphanumerical, 3, 1440, "Sector Code", "", "68", "");
            _ObsFields.Add(xField);

            xField = new Field("CSoSecVal", FieldType.Alphanumerical, 4, 1443, "Sub-sector Code", "", "71", "");
            _ObsFields.Add(xField);

            xField = new Field("YDeComp", FieldType.Numerical, 1, 1447, "Settlement Delay Type", "", "139", "");
            _ObsFields.Add(xField);

            xField = new Field("IprodIsl", FieldType.Alphanumerical, 1, 1448, "Syariah Indicator", "", "87", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_20", FieldType.Alphanumerical, 3, 1449, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("IvtDec", FieldType.Alphanumerical, 1, 1452, "Short sell indicator", "", "91", "");
            _ObsFields.Add(xField);

            xField = new Field("LPra", FieldType.Alphanumerical, 10, 1453, "Practice Notes", "", "96", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_21", FieldType.Alphanumerical, 28, 1463, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("CIsinForeign", FieldType.Alphanumerical, 12, 1491, "ISIN foreign cash product", "", "65", "");
            _ObsFields.Add(xField);

            xField = new Field("LocForeignIndicator", FieldType.Numerical, 1, 1503, "Local Foreign Indicator", "", "96", "");
            _ObsFields.Add(xField);

            xField = new Field("CIndustryValICB", FieldType.Alphanumerical, 4, 1504, "Industry Code ICB", "", "64", "");
            _ObsFields.Add(xField);

            xField = new Field("CSuperSecValICB", FieldType.Alphanumerical, 4, 1508, "Super Sector Code ICB", "", "71", "");
            _ObsFields.Add(xField);

            xField = new Field("CSecValICB", FieldType.Alphanumerical, 4, 1512, "Sector Code ICB", "", "69", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_22", FieldType.Alphanumerical, 1, 1516, "", "", "", "");
            _ObsFields.Add(xField);

            //StSplitAgg ==> Stock Split Aggregate , Page = 122
            xField = new Field("QCurStSplit", FieldType.Numerical, 12, 1517, "Current Number of Shares for Stock Split", "", "112", "");
            _ObsFields.Add(xField);

            xField = new Field("QnewStSplit", FieldType.Numerical, 12, 1529, "New Number of Shares for Stock Split", "", "115", "");
            _ObsFields.Add(xField);

            //StDivAgg ==> Stock Dividend Aggregate , Paga = 122
            xField = new Field("QCurStDiv", FieldType.Numerical, 12, 1541, "Current Number of Shares for Stock Dividend", "", "112", "");
            _ObsFields.Add(xField);

            xField = new Field("QAddStDiv", FieldType.Numerical, 12, 1553, "Additional Number of Shares for Stock Dividend", "", "111", "");
            _ObsFields.Add(xField);

            xField = new Field("QTitMaxSaiOmBuy", FieldType.Numerical, 12, 1565, "Maximum quantity which can be entered for buy orders on the instrument", "", "117", "");
            _ObsFields.Add(xField);

            xField = new Field("QTitMaxSaiOmSell", FieldType.Numerical, 12, 1577, "Maximum quantity which can be entered for sell orders on the instrument", "", "118", "");
            _ObsFields.Add(xField);

            xField = new Field("PDrCotV", FieldType.QtmX, 14, 1589, "Closing price before adjustment.", "", "104", "");
            _ObsFields.Add(xField);

            xField = new Field("YTrading", FieldType.Alphanumerical, 1, 1603, "Instrument Trading Mode", "", "145", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_23", FieldType.Alphanumerical, 13, 1604, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("IAtdAcVtDec", FieldType.Alphanumerical, 1, 1617, "Pending Buy Indicator for Short Sell", "", "81", "");
            _ObsFields.Add(xField);

            xField = new Field("ICtlVtTran", FieldType.Alphanumerical, 1, 1618, "Selling Check Indicator on Trades", "", "82", "");
            _ObsFields.Add(xField);

            xField = new Field("CIsinProdSja", FieldType.Alphanumerical, 12, 1619, "ISIN code for the underlying product", "", "65", "");
            _ObsFields.Add(xField);

            xField = new Field("QMinConsCptePret", FieldType.Numerical, 12, 1631, "Minimum Quantity which can be Retained within a Client ID lendable account", "", "113", "");
            _ObsFields.Add(xField);

            xField = new Field("YDnRjTran", FieldType.Alphanumerical, 1, 1643, "Clearing Method of Failing Trades", "", "139", "");
            _ObsFields.Add(xField);

            xField = new Field("YDVP", FieldType.Alphanumerical, 1, 1644, "DVP Settlement Method", "", "140", "");
            _ObsFields.Add(xField);

            xField = new Field("IngDrUn", FieldType.Alphanumerical, 1, 1645, "Trading Once a Right Indicator", "", "86", "");
            _ObsFields.Add(xField);

            xField = new Field("YMethCaIntObl", FieldType.Alphanumerical, 2, 1646, "Type of Interest Calculation Formula for Bonds", "", "141", "");
            _ObsFields.Add(xField);

            xField = new Field("KfrsHyp", FieldType.QtmX, 14, 1648, "Coefficient for Pledging Fee", "", "94", "");
            _ObsFields.Add(xField);

            xField = new Field("KfrsEmp", FieldType.QtmX, 14, 1662, "Coefficient for Borrowing Fee", "", "94", "");
            _ObsFields.Add(xField);

            xField = new Field("KcompEmp", FieldType.QtmX, 14, 1676, "Coefficient for Borrowing Compensation", "94", "", "");
            _ObsFields.Add(xField);

            xField = new Field("KtranEchComp", FieldType.QtmX, 14, 1690, "Coefficient for Failed Trade Compensation", "", "95", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler", FieldType.Alphanumerical, 2, 1704, "", "", "", "");
            _ObsFields.Add(xField);
        }
    }
}
