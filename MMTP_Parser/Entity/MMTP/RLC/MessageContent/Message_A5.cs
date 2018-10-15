using MMTP_Parser.Entity.Custom;
using System.Collections.ObjectModel;
namespace MMTP_Parser.Entity.MMTP.RLC.MessageContent
{
    /// <summary>
    ///Processing rules
    /// This message transmits all or part of the list of instruments making up an index:
    ///     * Instrument IDs (long ID and mnemonic)
    ///     * Percentage of each instrument in the index capitalization
    ///     * Adjustment coefficient for the capitalization of each instrument
    ///     * Total number of instruments making up the index
    /// This list can be broken down into several type-A5 messages, depending on the number of instruments in the index.
    ///Transmission Functions
    /// Each trading day, when the index platform is initialized, one or more type-A5 messages are sent by the platform for each index of type "stock index" that exists in its reference database (this rule excludes bond indexes, ETF - Index Estimate indices and ETF- Indicative NAV indices), with the following exceptions:
    ///     * PFI2 does not send a type-A5 message for indices whose sample contains no components.
    ///     * PFI2 does not send a type-A5 message for indices extracted from a third party data flow and rebroadcast.
    /// If two indices are linked in the PFI2 reference database by a relationship indicating that the two indices have the same sample (EPRA and NAREIT indices), PFI2 sends only one type-A5 message for this couple of indices, with the ISIN code common to the two indices.
    /// </summary>
    public class Message_A5 : MessageContents //Length ==> 915 , Short description ==> Composition of an Index
    {
        //********************************************************************************************
        public Message_A5()
        {
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            //**ACapValIdx ==> Aggregate of index component , Page ==> 79 , Occ. ==> 15
            xField = new Field("CIdLngCpsIdx_1", FieldType.Alphanumerical, 12, 1, "Long instrument ID of index component", "", "93", "15");
            _ObsFields.Add(xField);

            xField = new Field("CValMneCpsIdx_1", FieldType.Alphanumerical, 5, 13, "Mnemonic code of index component", "", "104", "15");
            _ObsFields.Add(xField);

            xField = new Field("XValCarRf_1", FieldType.Numerical, 7, 18, "Instrument's % in previous day's reference capitalization of the index", "", "166", "15");
            _ObsFields.Add(xField);

            xField = new Field("KajCapValCpsIdx_1", FieldType.QtmX, 13, 25, "Capitalization adjustment coefficient of an instrument within an index", "", "126", "15");
            _ObsFields.Add(xField);

            xField = new Field("ZTitValCaIdx_1", FieldType.QtmX, 16, 38, "Number of shares used for index calculation", "", "184", "15");
            _ObsFields.Add(xField);

            xField = new Field("Filler_1", FieldType.Alphanumerical, 3, 54, "", "", "", "15");
            _ObsFields.Add(xField);


            xField = new Field("CIdLngCpsIdx_2", FieldType.Alphanumerical, 12, 57, "Long instrument ID of index component", "", "93", "15");
            _ObsFields.Add(xField);

            xField = new Field("CValMneCpsIdx_2", FieldType.Alphanumerical, 5, 69, "Mnemonic code of index component", "", "104", "15");
            _ObsFields.Add(xField);

            xField = new Field("XValCarRf_2", FieldType.Numerical, 7, 74, "Instrument's % in previous day's reference capitalization of the index", "", "166", "15");
            _ObsFields.Add(xField);

            xField = new Field("KajCapValCpsIdx_2", FieldType.QtmX, 13, 81, "Capitalization adjustment coefficient of an instrument within an index", "", "126", "15");
            _ObsFields.Add(xField);

            xField = new Field("ZTitValCaIdx_2", FieldType.QtmX, 16, 94, "Number of shares used for index calculation", "", "184", "15");
            _ObsFields.Add(xField);

            xField = new Field("Filler_2", FieldType.Alphanumerical, 3, 110, "", "", "", "15");
            _ObsFields.Add(xField);


            xField = new Field("CIdLngCpsIdx_3", FieldType.Alphanumerical, 12, 113, "Long instrument ID of index component", "", "93", "15");
            _ObsFields.Add(xField);

            xField = new Field("CValMneCpsIdx_3", FieldType.Alphanumerical, 5, 125, "Mnemonic code of index component", "", "104", "15");
            _ObsFields.Add(xField);

            xField = new Field("XValCarRf_3", FieldType.Numerical, 7, 130, "Instrument's % in previous day's reference capitalization of the index", "", "166", "15");
            _ObsFields.Add(xField);

            xField = new Field("KajCapValCpsIdx_3", FieldType.QtmX, 13, 137, "Capitalization adjustment coefficient of an instrument within an index", "", "126", "15");
            _ObsFields.Add(xField);

            xField = new Field("ZTitValCaIdx_3", FieldType.QtmX, 16, 150, "Number of shares used for index calculation", "", "184", "15");
            _ObsFields.Add(xField);

            xField = new Field("Filler_3", FieldType.Alphanumerical, 3, 166, "", "", "", "15");
            _ObsFields.Add(xField);


            xField = new Field("CIdLngCpsIdx_4", FieldType.Alphanumerical, 12, 169, "Long instrument ID of index component", "", "93", "15");
            _ObsFields.Add(xField);

            xField = new Field("CValMneCpsIdx_4", FieldType.Alphanumerical, 5, 181, "Mnemonic code of index component", "", "104", "15");
            _ObsFields.Add(xField);

            xField = new Field("XValCarRf_4", FieldType.Numerical, 7, 186, "Instrument's % in previous day's reference capitalization of the index", "", "166", "15");
            _ObsFields.Add(xField);

            xField = new Field("KajCapValCpsIdx_4", FieldType.QtmX, 13, 193, "Capitalization adjustment coefficient of an instrument within an index", "", "126", "15");
            _ObsFields.Add(xField);

            xField = new Field("ZTitValCaIdx_4", FieldType.QtmX, 16, 206, "Number of shares used for index calculation", "", "184", "15");
            _ObsFields.Add(xField);

            xField = new Field("Filler_4", FieldType.Alphanumerical, 3, 222, "", "", "", "15");
            _ObsFields.Add(xField);


            xField = new Field("CIdLngCpsIdx_5", FieldType.Alphanumerical, 12, 225, "Long instrument ID of index component", "", "93", "15");
            _ObsFields.Add(xField);

            xField = new Field("CValMneCpsIdx_5", FieldType.Alphanumerical, 5, 237, "Mnemonic code of index component", "", "104", "15");
            _ObsFields.Add(xField);

            xField = new Field("XValCarRf_5", FieldType.Numerical, 7, 242, "Instrument's % in previous day's reference capitalization of the index", "", "166", "15");
            _ObsFields.Add(xField);

            xField = new Field("KajCapValCpsIdx_5", FieldType.QtmX, 13, 249, "Capitalization adjustment coefficient of an instrument within an index", "", "126", "15");
            _ObsFields.Add(xField);

            xField = new Field("ZTitValCaIdx_5", FieldType.QtmX, 16, 262, "Number of shares used for index calculation", "", "184", "15");
            _ObsFields.Add(xField);

            xField = new Field("Filler_5", FieldType.Alphanumerical, 3, 278, "", "", "", "15");
            _ObsFields.Add(xField);


            xField = new Field("CIdLngCpsIdx_6", FieldType.Alphanumerical, 12, 281, "Long instrument ID of index component", "", "93", "15");
            _ObsFields.Add(xField);

            xField = new Field("CValMneCpsIdx_6", FieldType.Alphanumerical, 5, 293, "Mnemonic code of index component", "", "104", "15");
            _ObsFields.Add(xField);

            xField = new Field("XValCarRf_6", FieldType.Numerical, 7, 298, "Instrument's % in previous day's reference capitalization of the index", "", "166", "15");
            _ObsFields.Add(xField);

            xField = new Field("KajCapValCpsIdx_6", FieldType.QtmX, 13, 305, "Capitalization adjustment coefficient of an instrument within an index", "", "126", "15");
            _ObsFields.Add(xField);

            xField = new Field("ZTitValCaIdx_6", FieldType.QtmX, 16, 318, "Number of shares used for index calculation", "", "184", "15");
            _ObsFields.Add(xField);

            xField = new Field("Filler_6", FieldType.Alphanumerical, 3, 334, "", "", "", "15");
            _ObsFields.Add(xField);


            xField = new Field("CIdLngCpsIdx_7", FieldType.Alphanumerical, 12, 337, "Long instrument ID of index component", "", "93", "15");
            _ObsFields.Add(xField);

            xField = new Field("CValMneCpsIdx_7", FieldType.Alphanumerical, 5, 349, "Mnemonic code of index component", "", "104", "15");
            _ObsFields.Add(xField);

            xField = new Field("XValCarRf_7", FieldType.Numerical, 7, 354, "Instrument's % in previous day's reference capitalization of the index", "", "166", "15");
            _ObsFields.Add(xField);

            xField = new Field("KajCapValCpsIdx_7", FieldType.QtmX, 13, 361, "Capitalization adjustment coefficient of an instrument within an index", "", "126", "15");
            _ObsFields.Add(xField);

            xField = new Field("ZTitValCaIdx_7", FieldType.QtmX, 16, 374, "Number of shares used for index calculation", "", "184", "15");
            _ObsFields.Add(xField);

            xField = new Field("Filler_7", FieldType.Alphanumerical, 3, 390, "", "", "", "15");
            _ObsFields.Add(xField);


            xField = new Field("CIdLngCpsIdx_8", FieldType.Alphanumerical, 12, 393, "Long instrument ID of index component", "", "93", "15");
            _ObsFields.Add(xField);

            xField = new Field("CValMneCpsIdx_8", FieldType.Alphanumerical, 5, 405, "Mnemonic code of index component", "", "104", "15");
            _ObsFields.Add(xField);

            xField = new Field("XValCarRf_8", FieldType.Numerical, 7, 410, "Instrument's % in previous day's reference capitalization of the index", "", "166", "15");
            _ObsFields.Add(xField);

            xField = new Field("KajCapValCpsIdx_8", FieldType.QtmX, 13, 417, "Capitalization adjustment coefficient of an instrument within an index", "", "126", "15");
            _ObsFields.Add(xField);

            xField = new Field("ZTitValCaIdx_8", FieldType.QtmX, 16, 430, "Number of shares used for index calculation", "", "184", "15");
            _ObsFields.Add(xField);

            xField = new Field("Filler_8", FieldType.Alphanumerical, 3, 446, "", "", "", "15");
            _ObsFields.Add(xField);


            xField = new Field("CIdLngCpsIdx_9", FieldType.Alphanumerical, 12, 449, "Long instrument ID of index component", "", "93", "15");
            _ObsFields.Add(xField);

            xField = new Field("CValMneCpsIdx_9", FieldType.Alphanumerical, 5, 461, "Mnemonic code of index component", "", "104", "15");
            _ObsFields.Add(xField);

            xField = new Field("XValCarRf_9", FieldType.Numerical, 7, 466, "Instrument's % in previous day's reference capitalization of the index", "", "166", "15");
            _ObsFields.Add(xField);

            xField = new Field("KajCapValCpsIdx_9", FieldType.QtmX, 13, 473, "Capitalization adjustment coefficient of an instrument within an index", "", "126", "15");
            _ObsFields.Add(xField);

            xField = new Field("ZTitValCaIdx_9", FieldType.QtmX, 16, 486, "Number of shares used for index calculation", "", "184", "15");
            _ObsFields.Add(xField);

            xField = new Field("Filler_9", FieldType.Alphanumerical, 3, 502, "", "", "", "15");
            _ObsFields.Add(xField);


            xField = new Field("CIdLngCpsIdx_10", FieldType.Alphanumerical, 12, 505, "Long instrument ID of index component", "", "93", "15");
            _ObsFields.Add(xField);

            xField = new Field("CValMneCpsIdx_10", FieldType.Alphanumerical, 5, 517, "Mnemonic code of index component", "", "104", "15");
            _ObsFields.Add(xField);

            xField = new Field("XValCarRf_10", FieldType.Numerical, 7, 522, "Instrument's % in previous day's reference capitalization of the index", "", "166", "15");
            _ObsFields.Add(xField);

            xField = new Field("KajCapValCpsIdx_10", FieldType.QtmX, 13, 529, "Capitalization adjustment coefficient of an instrument within an index", "", "126", "15");
            _ObsFields.Add(xField);

            xField = new Field("ZTitValCaIdx_10", FieldType.QtmX, 16, 542, "Number of shares used for index calculation", "", "184", "15");
            _ObsFields.Add(xField);

            xField = new Field("Filler_10", FieldType.Alphanumerical, 3, 558, "", "", "", "15");
            _ObsFields.Add(xField);


            xField = new Field("CIdLngCpsIdx_11", FieldType.Alphanumerical, 12, 561, "Long instrument ID of index component", "", "93", "15");
            _ObsFields.Add(xField);

            xField = new Field("CValMneCpsIdx_11", FieldType.Alphanumerical, 5, 573, "Mnemonic code of index component", "", "104", "15");
            _ObsFields.Add(xField);

            xField = new Field("XValCarRf_11", FieldType.Numerical, 7, 578, "Instrument's % in previous day's reference capitalization of the index", "", "166", "15");
            _ObsFields.Add(xField);

            xField = new Field("KajCapValCpsIdx_11", FieldType.QtmX, 13, 585, "Capitalization adjustment coefficient of an instrument within an index", "", "126", "15");
            _ObsFields.Add(xField);

            xField = new Field("ZTitValCaIdx_11", FieldType.QtmX, 16, 598, "Number of shares used for index calculation", "", "184", "15");
            _ObsFields.Add(xField);

            xField = new Field("Filler_11", FieldType.Alphanumerical, 3, 614, "", "", "", "15");
            _ObsFields.Add(xField);


            xField = new Field("CIdLngCpsIdx_12", FieldType.Alphanumerical, 12, 617, "Long instrument ID of index component", "", "93", "15");
            _ObsFields.Add(xField);

            xField = new Field("CValMneCpsIdx_12", FieldType.Alphanumerical, 5, 629, "Mnemonic code of index component", "", "104", "15");
            _ObsFields.Add(xField);

            xField = new Field("XValCarRf_12", FieldType.Numerical, 7, 634, "Instrument's % in previous day's reference capitalization of the index", "", "166", "15");
            _ObsFields.Add(xField);

            xField = new Field("KajCapValCpsIdx_12", FieldType.QtmX, 13, 641, "Capitalization adjustment coefficient of an instrument within an index", "", "126", "15");
            _ObsFields.Add(xField);

            xField = new Field("ZTitValCaIdx_12", FieldType.QtmX, 16, 654, "Number of shares used for index calculation", "", "184", "15");
            _ObsFields.Add(xField);

            xField = new Field("Filler_12", FieldType.Alphanumerical, 3, 670, "", "", "", "15");
            _ObsFields.Add(xField);


            xField = new Field("CIdLngCpsIdx_13", FieldType.Alphanumerical, 12, 673, "Long instrument ID of index component", "", "93", "15");
            _ObsFields.Add(xField);

            xField = new Field("CValMneCpsIdx_13", FieldType.Alphanumerical, 5, 685, "Mnemonic code of index component", "", "104", "15");
            _ObsFields.Add(xField);

            xField = new Field("XValCarRf_13", FieldType.Numerical, 7, 690, "Instrument's % in previous day's reference capitalization of the index", "", "166", "15");
            _ObsFields.Add(xField);

            xField = new Field("KajCapValCpsIdx_13", FieldType.QtmX, 13, 697, "Capitalization adjustment coefficient of an instrument within an index", "", "126", "15");
            _ObsFields.Add(xField);

            xField = new Field("ZTitValCaIdx_13", FieldType.QtmX, 16, 710, "Number of shares used for index calculation", "", "184", "15");
            _ObsFields.Add(xField);

            xField = new Field("Filler_13", FieldType.Alphanumerical, 3, 726, "", "", "", "15");
            _ObsFields.Add(xField);


            xField = new Field("CIdLngCpsIdx_14", FieldType.Alphanumerical, 12, 729, "Long instrument ID of index component", "", "93", "15");
            _ObsFields.Add(xField);

            xField = new Field("CValMneCpsIdx_14", FieldType.Alphanumerical, 5, 741, "Mnemonic code of index component", "", "104", "15");
            _ObsFields.Add(xField);

            xField = new Field("XValCarRf_14", FieldType.Numerical, 7, 746, "Instrument's % in previous day's reference capitalization of the index", "", "166", "15");
            _ObsFields.Add(xField);

            xField = new Field("KajCapValCpsIdx_14", FieldType.QtmX, 13, 753, "Capitalization adjustment coefficient of an instrument within an index", "", "126", "15");
            _ObsFields.Add(xField);

            xField = new Field("ZTitValCaIdx_14", FieldType.QtmX, 16, 766, "Number of shares used for index calculation", "", "184", "15");
            _ObsFields.Add(xField);

            xField = new Field("Filler_14", FieldType.Alphanumerical, 3, 782, "", "", "", "15");
            _ObsFields.Add(xField);


            xField = new Field("CIdLngCpsIdx_15", FieldType.Alphanumerical, 12, 785, "Long instrument ID of index component", "", "93", "15");
            _ObsFields.Add(xField);

            xField = new Field("CValMneCpsIdx_15", FieldType.Alphanumerical, 5, 797, "Mnemonic code of index component", "", "104", "15");
            _ObsFields.Add(xField);

            xField = new Field("XValCarRf_15", FieldType.Numerical, 7, 802, "Instrument's % in previous day's reference capitalization of the index", "", "166", "15");
            _ObsFields.Add(xField);

            xField = new Field("KajCapValCpsIdx_15", FieldType.QtmX, 13, 809, "Capitalization adjustment coefficient of an instrument within an index", "", "126", "15");
            _ObsFields.Add(xField);

            xField = new Field("ZTitValCaIdx_15", FieldType.QtmX, 16, 822, "Number of shares used for index calculation", "", "184", "15");
            _ObsFields.Add(xField);

            xField = new Field("Filler_15", FieldType.Alphanumerical, 3, 838, "", "", "", "15");
            _ObsFields.Add(xField);
            //##ACapValIdx ==> Aggregate of index component , Page ==> 79 , Occ. ==> 15

            xField = new Field("IdrMsgMMTPEchnIdx", FieldType.Alphanumerical, 1, 841, "Flag indicating the last MMTP message for an index", "", "115", "");
            _ObsFields.Add(xField);

            xField = new Field("ZTotValIdx", FieldType.Numerical, 3, 842, "Total number of instruments in an index", "", "185", "");
            _ObsFields.Add(xField);

            xField = new Field("XInuClMresVIdx", FieldType.QtmX, 10, 845, "Previous day's reference closing level for an index (daily summary)", "", "157", "");
            _ObsFields.Add(xField);

            xField = new Field("CFDifIdx", FieldType.Alphanumerical, 1, 855, "Frequency of index broadcast mode", "", "90", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_16", FieldType.Alphanumerical, 60, 856, "", "", "", "");
            _ObsFields.Add(xField);
        }
    }
}
