using MMTP_Parser.Entity.Custom;
using System.Collections.ObjectModel;
namespace MMTP_Parser.Entity.MMTP.DIFF.BusinessData.MessageContent
{
    /// <summary>
    ///Processing Rules
    /// For stock indices
    /// This message handles the real-time characteristics of an index: the level of the index or of the forerunner, variations in the index level, type of index level (first, real-time, forerunner,...), and various indicators for the instruments that make up the index.
    /// For ETF - Index Estimate indices and ETF- Indicative NAV (indicative Net Asset Value) indices
    /// This message handles in real-time the "intraday" (indicative) Net Asset Value of an ETF-type instrument (Exchange-Traded Fund).
    /// There are two formulas for calculating the "intraday" (indicative) Net Asset Value of an ETF:
    ///     * One formula is based on the real-time price of the instruments that make up the ETF fund; this formula is called the Indicative NAV index,
    ///     * The other formula is based on the real-time level of the stock index for which the ETF tries to duplicate the performance; this formula is called the Index Estimate.
    /// The Index Estimate formula is used as a backup so that an intraday NAV can continue to be broadcast when prices of instruments are not available.
    /// The PFI2 application uses the type-B1 message to broadcast the intraday indicative Net Asset Values of ETFs. In these messages, the ETF is identified by its ISIN code and its mnemonic code (the "intraday codes" of the ETF). These "intraday" codes are not the same as the ISIN code and mnemonic code of the ETF as a listed security in NSC® (an explicit link must be managed between these two instruments). It should also be noted that, in PFI2, two indices are configured for each ETF: one uses the Index Estimate calculation formula, the other uses the Indicative NAV formula. The index manager configures whether one or the other is broadcast (or the two simultaneously). The ISIN and mnemonic codes are identical for the two indices that are associated with the same ETF. Thus, viewed from the outside, it is not possible to distinguish between type-B1 messages that send Indicative NAVs from type-B1 messages that send Index Estimates.
    ///Transmission Functions
    ///     The sending conditions and the nature of type-B1 messages that are sent for each index are dependent on two factors: the broadcast mode of the index, and the current calculation phase of the index. These two factors are explained below.
    /// Broadcast mode
    ///     There are three broadcasting modes for type-B1 messages:
    ///         * CONTINUOUS: Calculated index levels are broadcast periodically, at a frequency that can be configured for each index. The frequency must be a multiple of the base calculation frequency (15 seconds).
    ///         * DISCONTINUOUS: a single broadcast during the day, occurring at a time (a "fixed time") that can be configured for each index.
    ///         * AT CLOSING only: no broadcast during the day.
    ///     The conditions for sending type-B1 messages for each of these three modes are described below.
    /// Calculation phases of an index
    ///     The type of index level (expressed in the data item CNivIdx) contained in a type-B1 message depends on the current calculation phase of the index. During the day, every index passes successively through the following phases:
    ///         * PRE-OPENING phase
    ///         The index enters the Pre-Opening phase as soon as one of three conditions occurs (for a given index, the three conditions are mutually exclusive):
    ///             o The weight (in the previous day's reference capitalization of the index) of the instruments for which PFI2 has received a theoretical opening price (an NSC® MMTP-30 – Theoretical Opening Price message) is greater than a threshold that has been configured,
    ///             o The number of instruments in the index for which PFI2 has received a theoretical opening price is greater than a threshold that has been configured,
    ///             o The time for passing into the Pre-Opening phase has arrived.
    ///         * OPENING phase
    ///         The index enters the Opening phase as soon as one of three conditions occurs (for a given index, the three conditions are mutually exclusive):
    ///             o The weight (in the previous day's reference capitalization of the index) of the instruments for which PFI2 has received an opening price (an NSC® MMTP-32 – Opening Summary message, Opening Summary) is greater than a threshold that has been configured.
    ///             o The number of instruments in the index for which PFI2 has received an opening price is greater than a threshold that has been configured.
    ///             o The time for passing into the Opening phase has arrived.
    ///         * CONTINUOUS TRADING phase
    ///         The index enters the Continuous Trading phase as soon as one of three conditions occurs (for a given index, the three conditions are mutually exclusive):
    ///             o The weight (in the previous day's reference capitalization of the index) of the instruments for which PFI2 has received a price (NSC® MMTP-32 – Opening Summary or MMTP-02 – Trade messages) is greater than a threshold that has been configured.
    ///             o The number of instruments in the index for which PFI2 has received a price is greater than a threshold that has been configured.
    ///             o The time for passing into the Continuous Trading phase has arrived.
    ///         * PROVISIONAL CLOSING phase
    ///         The index enters the Provisional Closing phase as soon as one of two mutually exclusive conditions occurs:
    ///             o PFI2 receives a group state message indicating the end of the Market Control Intervention phase for each instrument group that has an instrument in the index; that is, an NSC® MMTP-16 – Group State Change message with the group state code = F (End-of-Day Inquiries); this condition of course applies only to instruments traded on NSC®.
    ///             o The time for passing into the Provisional Closing phase has arrived.
    ///         * FINAL CLOSING phase
    ///         The index enters the Final Closing phase after being in the Provisional Closing phase for a configurable period of time, which depends on the index.
    /// Indices in CONTINUOUS broadcast mode
    ///     * In the morning, during the start-of-day batch processing (around 7:30 am): For each index, PFI2 sends a type-B1 message with CNivIdx=5 (reference closing index) and the value of the previous day's reference closing index. If an index is not treated (no trade from NSC®) and if the index has been declared with the parameter “broadcast not treated index” set to YES, the B1 messages will be generated with CNivIdx=‘Z’.
    ///     * While the index is in the Pre-Opening phase, if the Calculate Forerunner flag is set to Yes, every X seconds (X being a parameter of the index level): sending of a type-B1 message with CNivIdx = 8 (pre-opening forerunner).
    ///     * While the index is in Opening phase, if the Calculate Forerunner flag is set to Yes, every X seconds: sending of a type-B1 message with CNivIdx = 3 (real-time forerunner).
    ///     * When the index enters the Continuous Trading phase, and if the Calculate Opening Index Level Using Opening Prices flag is set to Yes:
    ///         o If PFI2 has not yet received opening prices for all instruments in the index (NSC® MMTP-32 – Opening Summary messages): sending of a type-B1 message with CNivIdx = A (partial, provisional opening index).
    ///         o If PFI2 has received opening prices for all instruments in the index (NSC® MMTP-32 – Opening Summary messages): sending of a type-B1 message with CNivIdx = B (complete, provisional opening index).
    ///     * During the Continuous Trading phase, when PFI2 receives an opening price for all instruments in the index (an NSC® 32 – Opening Summary message), and if the Calculate Opening Index Level Using Opening Prices flag is set to Yes: sending of a type-B1 message with CNivIdx = B (complete, provisional opening index).
    ///     * While the index is in Continuous Trading phase, every X seconds:
    ///         o Always: sending of a type-B1 message with CNivIdx = 1 (first real-time index of the day) for the first message, and CNivIdx = 2 (real-time index (except the first of the day)) for the subsequent messages.
    ///         o If, in addition, at this moment a time period for calculating the average of index levels is active, sending of a type-B1 message with CNivIdx = the value of CNivIdx set to the index level for this time period; in theory, the configured CNivIdx should have a value of 6 (daily settlement index level) or a value of 7 (at-expiration settlement index level).
    ///     * When the index passes into the Provisional Closing phase, and if the index is a "stock index" (which thus excludes ETF- Indicative NAV indices and ETF - Index Estimate indices):
    ///         o Always: sending of a type-B1 message with CNivIdx = 5 (reference closing index).
    ///         o If in addition the Calculate Opening Index Level Using Opening Prices flag is set to Yes: sending of a type-B1 message with CNivIdx = C (reference opening index).
    ///     * When the index enters the Final Closing phase:
    /// Indices in CONTINUOUS broadcast mode
    ///     * In the morning, during the start-of-day batch processing (around 7:30 am): For each index, PFI2 sends a type-B1 message with CNivIdx=5 (reference closing index) and the value of the previous day's reference closing index. If an index is not treated (no trade from NSC®) and if the index has been declared with the parameter “broadcast not treated index” set to YES, the B1 messages will be generated with CNivIdx=‘Z’.
    ///     * While the index is in the Pre-Opening phase, if the Calculate Forerunner flag is set to Yes, every X seconds (X being a parameter of the index level): sending of a type-B1 message with CNivIdx = 8 (pre-opening forerunner).
    ///     * While the index is in Opening phase, if the Calculate Forerunner flag is set to Yes, every X seconds: sending of a type-B1 message with CNivIdx = 3 (real-time forerunner).
    ///     * When the index enters the Continuous Trading phase, and if the Calculate Opening Index Level Using Opening Prices flag is set to Yes:
    ///         o If PFI2 has not yet received opening prices for all instruments in the index (NSC® MMTP-32 – Opening Summary messages): sending of a type-B1 message with CNivIdx = A (partial, provisional opening index).
    ///         o If PFI2 has received opening prices for all instruments in the index (NSC® MMTP-32 – Opening Summary messages): sending of a type-B1 message with CNivIdx = B (complete, provisional opening index).
    ///     * During the Continuous Trading phase, when PFI2 receives an opening price for all instruments in the index (an NSC® 32 – Opening Summary message), and if the Calculate Opening Index Level Using Opening Prices flag is set to Yes: sending of a type-B1 message with CNivIdx = B (complete, provisional opening index).
    ///     * While the index is in Continuous Trading phase, every X seconds:
    ///         o Always: sending of a type-B1 message with CNivIdx = 1 (first real-time index of the day) for the first message, and CNivIdx = 2 (real-time index (except the first of the day)) for the subsequent messages.
    ///         o If, in addition, at this moment a time period for calculating the average of index levels is active, sending of a type-B1 message with CNivIdx = the value of CNivIdx set to the index level for this time period; in theory, the configured CNivIdx should have a value of 6 (daily settlement index level) or a value of 7 (at-expiration settlement index level).
    ///     * When the index passes into the Provisional Closing phase, and if the index is a "stock index" (which thus excludes ETF- Indicative NAV indices and ETF - Index Estimate indices):
    ///         o Always: sending of a type-B1 message with CNivIdx = 5 (reference closing index).
    ///         o If in addition the Calculate Opening Index Level Using Opening Prices flag is set to Yes: sending of a type-B1 message with CNivIdx = C (reference opening index).
    ///     * When the index enters the Final Closing phase:
    ///         o Always: sending of a type-B1 message with CNivIdx = 5 (reference closing index).
    ///         o If in addition the Calculate Opening Index Level Using Opening Prices flag is set to Yes: sending of a type-B1 message with CNivIdx = C (reference opening index).
    /// SUSPENSION and RESUMPTION of BROADCASTING of an index
    ///     In certain circumstances, described below, the broadcasting of type-B1 messages with an index level of 2 (real-time index) for a given index (which is in the Continuous Trading phase) can be temporarily suspended, then resumed. When an index is in a suspended state, PFI2 broadcasts type-B1 messages with an index level of 3 (real-time forerunner), in place of messages with an index level of 2 (real-time index).
    ///     * The suspension of broadcasting for an index can be initiated:
    ///         o Either manually by the index manager (if the index is in the Continuous Trading phase),
    ///         o Or automatically by PFI2, when the conditions for maintaining the index in the Continuous Trading phase are no longer met (see the description above of the conditions for when an index passes into the Continuous Trading phase).
    ///     * The resumption of broadcasting for an index can be initiated:
    ///         o Either manually by the index manager (regardless of whether the origin of the suspension was manual or automatic),
    ///         o Or automatically by PFI2. Automatic resumption occurs at the moment T0 + P, where T0 is the moment when conditions permit the index to return to the Continuous Trading phase, and where P is a period of time that is configurable for each index, with the restriction that conditions for being in the Continuous Trading phase are still met at the moment T0 + P.
    /// </summary>
    public class Message_B1 : MessageContents //Length ==> 148 , Short description ==> Real-time Date for an Index
    {
        //********************************************************************************************
        public Message_B1()
        {
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            xField = new Field("CNivIdx", FieldType.Alphanumerical, 1, 1, "Index level code", "", "65", "");
            _ObsFields.Add(xField);

            xField = new Field("XDrNivJIdx", FieldType.Numerical, 6, 2, "Day's last index level", "", "123", "");
            _ObsFields.Add(xField);

            xField = new Field("XPhNivJIdx", FieldType.Numerical, 6, 8, "Day's highest index level", "", "132", "");
            _ObsFields.Add(xField);

            xField = new Field("HphJIdx", FieldType.Numerical, 6, 14, "Time of day's highest index level", "", "79", "");
            _ObsFields.Add(xField);

            xField = new Field("XPbNivJIdx", FieldType.Numerical, 6, 20, "Day's lowest index level", "", "131", "");
            _ObsFields.Add(xField);

            xField = new Field("HPbJIdx", FieldType.Numerical, 6, 26, "Time of day's lowest index level", "", "79", "");
            _ObsFields.Add(xField);

            xField = new Field("ZValIdxCot", FieldType.Numerical, 3, 32, "Number of traded instruments in the index", "", "152", "");
            _ObsFields.Add(xField);

            xField = new Field("XCapValAcfIdx", FieldType.Numerical, 5, 35, "Percentage of capitalization for the active instruments in the index", "", "123", "");
            _ObsFields.Add(xField);

            xField = new Field("IsensXVarIdxJ", FieldType.Alphanumerical, 1, 40, "Sign of Variation for Day's Index ('Forerunner”)", "", "88", "");
            _ObsFields.Add(xField);

            xField = new Field("XVarIdxJ", FieldType.Numerical, 5, 41, "Variation for Day's Index ('Forerunner”)", "", "134", "");
            _ObsFields.Add(xField);

            xField = new Field("IsensXVarIdxJRfV", FieldType.Alphanumerical, 1, 46, "Sign of Variation for Day's Index / Previous Day's Reference", "", "89", "");
            _ObsFields.Add(xField);

            xField = new Field("XVarIdxJRfV", FieldType.Numerical, 5, 47, "Variation for Day's Index / Previous Day's Reference", "", "135", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_1", FieldType.Alphanumerical, 6, 52, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("IsensXVarIdxJDrAnP", FieldType.Alphanumerical, 1, 58, "Sign of Variation for Day's / Last for Previous Year", "", "88", "");
            _ObsFields.Add(xField);

            xField = new Field("XVarIdxJDrAnP", FieldType.Numerical, 5, 59, "Variation for Day's Index / Last for Previous Year", "", "135", "");
            _ObsFields.Add(xField);

            xField = new Field("XNivIrteNetIbs", FieldType.QtmX, 7, 64, "Net Return Index Level", "", "131", "");
            _ObsFields.Add(xField);

            xField = new Field("XNivIrteGlIbs", FieldType.QtmX, 7, 71, "Gross Return Index Level", "", "129", "");
            _ObsFields.Add(xField);

            xField = new Field("ZValBaiIbs", FieldType.Numerical, 3, 78, "Number of declining instruments in the index", "", "151", "");
            _ObsFields.Add(xField);

            xField = new Field("ZValHauIbs", FieldType.Numerical, 3, 81, "Number of rising instruments in the index", "", "151", "");
            _ObsFields.Add(xField);

            xField = new Field("ZValIchgIbs", FieldType.Numerical, 3, 84, "Number of unchanged instruments in the index", "", "152", "");
            _ObsFields.Add(xField);

            xField = new Field("ZValNonCotIbs", FieldType.Numerical, 3, 87, "Number of non-traded instruments in the index", "", "152", "");
            _ObsFields.Add(xField);

            xField = new Field("ZValResIbs", FieldType.Numerical, 3, 90, "Number of reserved instruments in the index", "", "153", "");
            _ObsFields.Add(xField);

            xField = new Field("ZValSuIbs", FieldType.Numerical, 3, 93, "Number of suspended instruments in the index", "", "153", "");
            _ObsFields.Add(xField);

            xField = new Field("ZTotValIbs", FieldType.Numerical, 3, 96, "Total number of instruments in the index", "", "151", "");
            _ObsFields.Add(xField);

            xField = new Field("IsensXMoyVarValIbs", FieldType.Alphanumerical, 1, 99, "Sign of Average Variation for Instruments in the Index", "", "88", "");
            _ObsFields.Add(xField);

            xField = new Field("XMoyVarValIbs", FieldType.Numerical, 6, 100, "Average Variation for Instruments in the Index", "", "126", "");
            _ObsFields.Add(xField);

            xField = new Field("XMoyVarValBaiIbs", FieldType.Numerical, 6, 106, "Average Variation for Declining Instruments in the Index", "", "125", "");
            _ObsFields.Add(xField);

            xField = new Field("XMoyVarValHauIbs", FieldType.Numerical, 6, 112, "Average Variation for Rising Instruments in the Index", "", "126", "");
            _ObsFields.Add(xField);

            xField = new Field("IIBsAscNivIbs", FieldType.Alphanumerical, 1, 118, "Flag for Indicators Related to an Index Level", "", "85", "");
            _ObsFields.Add(xField);

            //ANivIdxJ ==> Aggregate of Index Levels for the Day (Ift/QMt Format) , Page ==> 56
            xField = new Field("XDrNivJIdx_IftQMt", FieldType.QtmX, 10, 119, "Day's last index level", "", "124", "");
            _ObsFields.Add(xField);

            xField = new Field("XPhNivJIdx_IftQMt", FieldType.QtmX, 10, 129, "Day's highest index level", "", "132", "");
            _ObsFields.Add(xField);

            xField = new Field("XPbNivJIdx_IftQMt", FieldType.QtmX, 10, 139, "Day's lowest index level", "", "132", "");
            _ObsFields.Add(xField);
        }
    }
}
