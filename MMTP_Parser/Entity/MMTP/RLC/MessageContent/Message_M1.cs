using MMTP_Parser.Entity.Custom;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTP_Parser.Entity.MMTP.RLC.MessageContent
{
    /// <summary>

    /// </summary>
    public class Message_M1 : MessageContents //Length ==> 592 , Short description ==> Trade For Clearing
    {
        //********************************************************************************************
        public Message_M1()
        {
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            xField = new Field("DSeaBsEven", FieldType.Alphanumerical, 8, 1, "Date of trading session for event", "", "109", "");
            _ObsFields.Add(xField);

            xField = new Field("NTranSeaBs", FieldType.Numerical, 10, 9, "Trade number", "", "134", "");
            _ObsFields.Add(xField);

            xField = new Field("QTitTran", FieldType.Numerical, 12, 19, "Traded quantity", "", "152", "");
            _ObsFields.Add(xField);

            xField = new Field("PTran", FieldType.QtmX, 14, 31, "Trade Price", "", "142", "");
            _ObsFields.Add(xField);

            xField = new Field("IAnuTran", FieldType.Numerical, 2, 45, "Trade cancellation flag", "", "113", "");
            _ObsFields.Add(xField);

            xField = new Field("ITranYApl", FieldType.Numerical, 1, 47, "Cross Trade Flag", "", "123", "");
            _ObsFields.Add(xField);

            xField = new Field("IDenTCSAcSaiSrv", FieldType.Alphanumerical, 1, 48, "Flag Indicating entry of TCS buy declaration by Market Control", "", "114", "");
            _ObsFields.Add(xField);

            xField = new Field("IDenTCSVtSaiSrv", FieldType.Alphanumerical, 1, 49, "Flag indicating entry of TCS sell declaration by Market Control", "", "114", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_1", FieldType.Alphanumerical, 3, 50, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("TDeAtypDnT", FieldType.Alphanumerical, 2, 53, "Non-standard settlement period for TCS trade", "", "154", "");
            _ObsFields.Add(xField);

            xField = new Field("IGarTranChc", FieldType.Alphanumerical, 1, 55, "Flag indicating whether trade is to be guaranteed by clearing house", "", "117", "");
            _ObsFields.Add(xField);

            xField = new Field("CMarFncEven", FieldType.Alphanumerical, 3, 56, "ID of financial market on which event occurred", "", "96", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_2", FieldType.Alphanumerical, 3, 59, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("NSesNgTran", FieldType.Numerical, 1, 62, "Indicator for sub-period of a trading day", "", "133", "");
            _ObsFields.Add(xField);

            xField = new Field("DHTran", FieldType.Alphanumerical, 14, 63, "Trade Date and Time", "", "108", "");
            _ObsFields.Add(xField);

            xField = new Field("CValStgAc", FieldType.Alphanumerical, 12, 77, "Strategy identification for the buy side", "", "104", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_3", FieldType.Alphanumerical, 8, 89, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("CValStgVt", FieldType.Alphanumerical, 12, 97, "Strategy identification for the sell side", "", "104", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_4", FieldType.Alphanumerical, 8, 109, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("CIdGrc", FieldType.Alphanumerical, 2, 117, "Instrument group identification", "", "93", "");
            _ObsFields.Add(xField);

            xField = new Field("IFinTran", FieldType.Alphanumerical, 1, 119, "Flag indicating end of trades at the same price", "", "116", "");
            _ObsFields.Add(xField);

            xField = new Field("ITranPrCotProdSea", FieldType.Alphanumerical, 1, 120, "Flag for first trade on instrument", "", "123", "");
            _ObsFields.Add(xField);

            xField = new Field("YOmOrgTran", FieldType.Alphanumerical, 1, 121, "Type of orders at the origin of a trade", "", "175", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_5", FieldType.Alphanumerical, 16, 122, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("TDeComp", FieldType.Numerical, 2, 138, "Settlement Delay", "", "155", "");
            _ObsFields.Add(xField);

            xField = new Field("NTranKL", FieldType.Numerical, 8, 140, "TRS Trade number bis", "", "133", "");
            _ObsFields.Add(xField);

            xField = new Field("IShortSell", FieldType.Alphanumerical, 1, 148, "Short Sell Indicator for a Sell Order", "", "122", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_6", FieldType.Alphanumerical, 19, 149, "", "", "", "");
            _ObsFields.Add(xField);

            //**ACarOmDenAcKL ==> Aggregate of data for buy order or buy declaration , Page ==> 79
            xField = new Field("CIdAdfEmetOm_B", FieldType.Alphanumerical, 8, 168, "ID of trading system member that issued the order", "", "92", "");
            _ObsFields.Add(xField);

            xField = new Field("DSaiOm_B", FieldType.Numerical, 8, 176, "Order entry date (in the Central Trading System)", "", "108", "");
            _ObsFields.Add(xField);

            xField = new Field("NSeqOm10_B", FieldType.Numerical, 10, 184, "Order sequence number", "", "132", "");
            _ObsFields.Add(xField);

            xField = new Field("CIdMbrNgOm_B", FieldType.Alphanumerical, 8, 194, "ID of clearing system member that performed the trade", "", "94", "");
            _ObsFields.Add(xField);

            xField = new Field("CidNgSaiOm_B", FieldType.Alphanumerical, 8, 202, "ID of the trader that entered the order", "", "195", "");
            _ObsFields.Add(xField);

            xField = new Field("YCpteOm_B", FieldType.Alphanumerical, 1, 210, "Type of Clearing Account for Member that owns the order", "", "169", "");
            _ObsFields.Add(xField);

            xField = new Field("YDplOmSysComp_B", FieldType.Alphanumerical, 1, 211, "Posting action for an order in the clearing system", "", "172", "");
            _ObsFields.Add(xField);

            xField = new Field("YPdplTranOm_B", FieldType.Alphanumerical, 1, 212, "Posting or give-up action for trade", "", "177", "");
            _ObsFields.Add(xField);

            xField = new Field("CIdMbrDestGupOm_B", FieldType.Alphanumerical, 8, 213, "ID of Clearing System Member that is the beneficiary of a give-up", "", "94", "");
            _ObsFields.Add(xField);

            xField = new Field("NcptePosIptOm_B", FieldType.Alphanumerical, 16, 221, "ID of position account to which the order is to be booked", "", "130", "");
            _ObsFields.Add(xField);

            xField = new Field("IFctOm_B", FieldType.Alphanumerical, 1, 237, "Flag for commission to be charged for order", "", "116", "");
            _ObsFields.Add(xField);

            //**ADonCtgMbrGup ==> Aggregate of brokerage commission for members for a give-up , Page ==> 82
            xField = new Field("ICtgPdfMbrGup_B", FieldType.Alphanumerical, 1, 238, "Flag indicating standard commission between members for a give-up", "", "114", "");
            _ObsFields.Add(xField);

            xField = new Field("YExpCtgMbrGup_B", FieldType.Alphanumerical, 1, 239, "Unit of expression for the commission between members for a give-up", "", "173", "");
            _ObsFields.Add(xField);

            xField = new Field("XQCtgMbrGup_B", FieldType.QtmX, 19, 240, "Rate and amount of commission between members for a give-up", "", "165", "");
            _ObsFields.Add(xField);
            //##ADonCtgMbrGup ==> Aggregate of brokerage commission for members for a give-up , Page ==> 82

            xField = new Field("CIdOmNg_B", FieldType.Alphanumerical, 16, 259, "Trader Order Number (TON)", "", "95", "");
            _ObsFields.Add(xField);

            xField = new Field("LSaiOm_B", FieldType.Alphanumerical, 18, 275, "Free text entered with order", "", "128", "");
            _ObsFields.Add(xField);

            xField = new Field("YOmTrtItf_B", FieldType.Alphanumerical, 1, 293, "Type of order to be processed at trading system member", "", "176", "");
            _ObsFields.Add(xField);

            xField = new Field("YCpteOmRgEua_B", FieldType.Alphanumerical, 1, 294, "Customer type indicator (CTI)", "", "170", "");
            _ObsFields.Add(xField);

            xField = new Field("ICaTVASysComp_B", FieldType.Alphanumerical, 1, 295, "Flag indicating whether the clearing system is to calculate VAT on fees", "", "113", "");
            _ObsFields.Add(xField);

            xField = new Field("YMbrOrgOmCme_B", FieldType.Alphanumerical, 2, 296, "Type of member that passed order", "", "174", "");
            _ObsFields.Add(xField);

            xField = new Field("DHSaiOmAdf_B", FieldType.Alphanumerical, 14, 298, "Order Entry Date and Time", "", "108", "");
            _ObsFields.Add(xField);

            xField = new Field("CAtvNgOrgOm_B", FieldType.Alphanumerical, 1, 312, "Activity code for order issuer", "", "86", "");
            _ObsFields.Add(xField);

            xField = new Field("YPLimSaiOm_B", FieldType.Alphanumerical, 1, 313, "Type of Limit for an Order", "", "177", "");
            _ObsFields.Add(xField);

            xField = new Field("YValiOmNSC_B", FieldType.Alphanumerical, 1, 314, "Validity Type of an Order", "", "180", "");
            _ObsFields.Add(xField);

            xField = new Field("YOm_B", FieldType.Alphanumerical, 1, 315, "Code for the Technical Origin of the Order", "", "175", "");
            _ObsFields.Add(xField);

            xField = new Field("IPrsQTitRestOm_B", FieldType.Alphanumerical, 1, 316, "Indicator for Remaining Quantity on an Order", "", "119", "");
            _ObsFields.Add(xField);

            xField = new Field("CIdItfOm_B", FieldType.Alphanumerical, 11, 317, "ID of the member's order entry server", "", "93", "");
            _ObsFields.Add(xField);

            xField = new Field("PLimSaiOm_B", FieldType.QtmX, 14, 328, "Original Order Price", "", "138", "");
            _ObsFields.Add(xField);

            xField = new Field("PDchOmStop_B", FieldType.QtmX, 14, 342, "Original Trigger Price", "", "135", "");
            _ObsFields.Add(xField);

            //**CBIC ==> BIC Code of the Member , Page 87
            xField = new Field("CBq_B", FieldType.Alphanumerical, 4, 356, "Bank code", "", "87", "");
            _ObsFields.Add(xField);

            xField = new Field("CPyMbr_B", FieldType.Alphanumerical, 2, 360, "Country Code", "", "100", "");
            _ObsFields.Add(xField);

            xField = new Field("CVilMbr_B", FieldType.Alphanumerical, 2, 362, "Town Code", "", "105", "");
            _ObsFields.Add(xField);

            xField = new Field("CSec_B", FieldType.Alphanumerical, 3, 364, "Branch Code", "", "100", "");
            _ObsFields.Add(xField);
            //##CBIC ==> BIC Code of the Member , Page 87
            //##ACarOmDenAcKL ==> Aggregate of data for buy order or buy declaration , Page ==> 79



            //**ACarOmDenAcKL ==> Aggregate of data for sell order or sell declaration , Page ==> 79
            xField = new Field("CIdAdfEmetOm_S", FieldType.Alphanumerical, 8, 367, "ID of trading system member that issued the order", "", "92", "");
            _ObsFields.Add(xField);

            xField = new Field("DSaiOm_S", FieldType.Numerical, 8, 375, "Order entry date (in the Central Trading System)", "", "108", "");
            _ObsFields.Add(xField);

            xField = new Field("NSeqOm10_S", FieldType.Numerical, 10, 383, "Order sequence number", "", "132", "");
            _ObsFields.Add(xField);

            xField = new Field("CIdMbrNgOm_S", FieldType.Alphanumerical, 8, 393, "ID of clearing system member that performed the trade", "", "94", "");
            _ObsFields.Add(xField);

            xField = new Field("CidNgSaiOm_S", FieldType.Alphanumerical, 8, 401, "ID of the trader that entered the order", "", "195", "");
            _ObsFields.Add(xField);

            xField = new Field("YCpteOm_S", FieldType.Alphanumerical, 1, 409, "Type of Clearing Account for Member that owns the order", "", "169", "");
            _ObsFields.Add(xField);

            xField = new Field("YDplOmSysComp_S", FieldType.Alphanumerical, 1, 410, "Posting action for an order in the clearing system", "", "172", "");
            _ObsFields.Add(xField);

            xField = new Field("YPdplTranOm_S", FieldType.Alphanumerical, 1, 411, "Posting or give-up action for trade", "", "177", "");
            _ObsFields.Add(xField);

            xField = new Field("CIdMbrDestGupOm_S", FieldType.Alphanumerical, 8, 412, "ID of Clearing System Member that is the beneficiary of a give-up", "", "94", "");
            _ObsFields.Add(xField);

            xField = new Field("NcptePosIptOm_S", FieldType.Alphanumerical, 16, 420, "ID of position account to which the order is to be booked", "", "130", "");
            _ObsFields.Add(xField);

            xField = new Field("IFctOm_S", FieldType.Alphanumerical, 1, 436, "Flag for commission to be charged for order", "", "116", "");
            _ObsFields.Add(xField);

            //**ADonCtgMbrGup ==> Aggregate of brokerage commission for members for a give-up , Page ==> 82
            xField = new Field("ICtgPdfMbrGup_S", FieldType.Alphanumerical, 1, 437, "Flag indicating standard commission between members for a give-up", "", "114", "");
            _ObsFields.Add(xField);

            xField = new Field("YExpCtgMbrGup_S", FieldType.Alphanumerical, 1, 438, "Unit of expression for the commission between members for a give-up", "", "173", "");
            _ObsFields.Add(xField);

            xField = new Field("XQCtgMbrGup_S", FieldType.QtmX, 19, 439, "Rate and amount of commission between members for a give-up", "", "165", "");
            _ObsFields.Add(xField);
            //##ADonCtgMbrGup ==> Aggregate of brokerage commission for members for a give-up , Page ==> 82

            xField = new Field("CIdOmNg_S", FieldType.Alphanumerical, 16, 458, "Trader Order Number (TON)", "", "95", "");
            _ObsFields.Add(xField);

            xField = new Field("LSaiOm_S", FieldType.Alphanumerical, 18, 474, "Free text entered with order", "", "128", "");
            _ObsFields.Add(xField);

            xField = new Field("YOmTrtItf_S", FieldType.Alphanumerical, 1, 492, "Type of order to be processed at trading system member", "", "176", "");
            _ObsFields.Add(xField);

            xField = new Field("YCpteOmRgEua_S", FieldType.Alphanumerical, 1, 493, "Customer type indicator (CTI)", "", "170", "");
            _ObsFields.Add(xField);

            xField = new Field("ICaTVASysComp_S", FieldType.Alphanumerical, 1, 494, "Flag indicating whether the clearing system is to calculate VAT on fees", "", "113", "");
            _ObsFields.Add(xField);

            xField = new Field("YMbrOrgOmCme_S", FieldType.Alphanumerical, 2, 495, "Type of member that passed order", "", "174", "");
            _ObsFields.Add(xField);

            xField = new Field("DHSaiOmAdf_S", FieldType.Alphanumerical, 14, 497, "Order Entry Date and Time", "", "108", "");
            _ObsFields.Add(xField);

            xField = new Field("CAtvNgOrgOm_S", FieldType.Alphanumerical, 1, 511, "Activity code for order issuer", "", "86", "");
            _ObsFields.Add(xField);

            xField = new Field("YPLimSaiOm_S", FieldType.Alphanumerical, 1, 512, "Type of Limit for an Order", "", "177", "");
            _ObsFields.Add(xField);

            xField = new Field("YValiOmNSC_S", FieldType.Alphanumerical, 1, 513, "Validity Type of an Order", "", "180", "");
            _ObsFields.Add(xField);

            xField = new Field("YOm_S", FieldType.Alphanumerical, 1, 514, "Code for the Technical Origin of the Order", "", "175", "");
            _ObsFields.Add(xField);

            xField = new Field("IPrsQTitRestOm_S", FieldType.Alphanumerical, 1, 515, "Indicator for Remaining Quantity on an Order", "", "119", "");
            _ObsFields.Add(xField);

            xField = new Field("CIdItfOm_S", FieldType.Alphanumerical, 11, 516, "ID of the member's order entry server", "", "93", "");
            _ObsFields.Add(xField);

            xField = new Field("PLimSaiOm_S", FieldType.QtmX, 14, 527, "Original Order Price", "", "138", "");
            _ObsFields.Add(xField);

            xField = new Field("PDchOmStop_S", FieldType.QtmX, 14, 541, "Original Trigger Price", "", "135", "");
            _ObsFields.Add(xField);

            //**CBIC ==> BIC Code of the Member , Page 87
            xField = new Field("CBq_S", FieldType.Alphanumerical, 4, 555, "Bank code", "", "87", "");
            _ObsFields.Add(xField);

            xField = new Field("CPyMbr_S", FieldType.Alphanumerical, 2, 559, "Country Code", "", "100", "");
            _ObsFields.Add(xField);

            xField = new Field("CVilMbr_S", FieldType.Alphanumerical, 2, 561, "Town Code", "", "105", "");
            _ObsFields.Add(xField);

            xField = new Field("CSec_S", FieldType.Alphanumerical, 3, 563, "Branch Code", "", "100", "");
            _ObsFields.Add(xField);
            //##CBIC ==> BIC Code of the Member , Page 87
            //##ACarOmDenAcKL ==> Aggregate of data for sell order or sell declaration , Page ==> 79

            xField = new Field("YTCSkP", FieldType.Alphanumerical, 1, 566, "Type of price determined by TCS for check", "", "180", "");
            _ObsFields.Add(xField);

            xField = new Field("TCSCkP", FieldType.QtmX, 14, 567, "Price determined by TCS for check", "", "154", "");
            _ObsFields.Add(xField);

            xField = new Field("VWAPTimStar", FieldType.Numerical, 6, 581, "Start of time for VWAP calculator", "", "155", "");
            _ObsFields.Add(xField);

            xField = new Field("VWAPTimStop", FieldType.Numerical, 6, 587, "Stop of time for VWAP calculator", "", "155", "");
            _ObsFields.Add(xField);
        }
    }
}
