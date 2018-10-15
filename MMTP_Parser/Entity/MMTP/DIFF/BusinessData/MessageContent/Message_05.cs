using MMTP_Parser.Entity.Custom;
using System.Collections.ObjectModel;
namespace MMTP_Parser.Entity.MMTP.DIFF.BusinessData.MessageContent
{
    /// <summary>
    ///Processing rules
    /// This message is sent by NSC® to indicate a status change of an instrument:
    ///     * Trading suspension on instrument.
    ///     * Reservation.
    ///     * Resumption of trading.
    ///     * Etc.
    ///Transmission functions
    /// Preparing for the session
    ///     For each instrument that remains suspended, reserved or forbidden from the previous trading day, and for each instrument created in a forbidden state, an MMTP-05 – Instrument State Change message is sent, with an action code (CActModEtaVal) of N (State at initialization).
    /// Opening of an instrument with its group
    ///     For each instrument in the group,
    ///         * If the instrument is neither reserved nor suspended:
    ///             o If the Theoretical Opening Price cannot be determined and some Must-Be-Filled orders or At Opening orders or Market Orders remain unfilled, then an MMTP-05 – Instrument State Change message is sent with an instrument trading state indicator (IetaCotVal) at H (instrument reserved upward) or B (Instrument reserved downward), the indicator giving origin of instrument reservation (IOrgResVal) set to A (Automatic) and an action code (CActModEtaVal) of R (Reservation). Otherwise, an MMTP-05 – Instrument State Change message is sent with the action code of O (Changes to Open state).
    ///             o If the Theoretical Opening Price has been determined and falls within the price thresholds, an MMTP-05 – Instrument State Change message is sent with an action code (CActModEtaVal) of C (Trading), followed by an MMTP-05 – Instrument State Change message with an action code of O (Changes to Open state).
    ///             o If the Theoretical Opening Price has been determined and falls outside the price thresholds, an MMTP-05 – Instrument State Change message is sent with an instrument trading state indicator (IetaCotVal) of H (Instrument reserved upward) or B (Instrument reserved downward), the indicator giving origin of instrument reservation set to A (Automatic) and an action code (CActModEtaVal) of R (Reservation).
    ///         * If the instrument is already reserved or suspended: the conditions for sending this message are identical to those of the Opening of an instrument function (see below).
    /// Opening of an instrument (immediate or programmed)
    ///     * If the Theoretical Opening Price cannot be determined,
    ///         o If some Must-Be-Filled orders (In the strict sense: excluding Market Orders) or some Market On Opening orders are unfilled, the system sends an MMTP-05 – Instrument State Change message with an instrument trading state indicator (IetaCotVal) at H (Instrument reserved upward) or B (Instrument reserved downward), the indicator giving origin of instrument reservation (IOrgResVal) set to A (Automatic) and an action code (CActModEtaVal) of R (Reservation).
    ///         o Otherwise, the system sends an MMTP-05 – Instrument State Change message with an action code (CActModEtaVal) of O (Changes to Open state).
    ///     * If the Theoretical Opening Price has been determined and falls within the price thresholds, the system sends an MMTP-05 – Instrument State Change message with the action code (CActModEtaVal) set to C (Trading), followed by an MMTP-05 – Instrument State Change message with an action code of O (Changes to Open state).
    ///     * If the Theoretical Opening Price has been determined and falls outside the price thresholds, the system sends an MMTP-05 – Instrument State Change message with an instrument trading state indicator (IetaCotVal) of H (Instrument reserved upward) or B (Instrument reserved downward), the indicator giving origin of instrument reservation (IOrgResVal) set to A (Automatic) and an action code (CActModEtaVal) of R (Reservation).
    /// Instrument auction (immediate or programmed)
    ///     * If the Theoretical Opening Price cannot be determined,
    ///       o If (the instrument is neither suspended nor reserved before the auction, and some Must-Be-Filled orders or some Market Orders or some At Opening orders are unfilled) or (the instrument is suspended or reserved before the auction and some Must-Be-Filled orders or At Opening orders are unfilled), the system sends an MMTP- 05 – Instrument State Change message with an instrument trading state indicator (IetaCotVal) of H (Instrument reserved upward) or B (Instrument reserved downward), the indicator giving origin of instrument reservation (IOrgResVal) set to A (Automatic) and an action code (CActModEtaVal) of R (Reservation).
    ///       o Otherwise, if in addition the instrument was not open before the auction, the system sends an MMTP-05 – Instrument State Change message with the action code (CActModEtaVal) of O (Change to Open state).
    ///       o If the instrument was authorized for order entry, the system sends an MMTP-05 – Instrument State Change message with an action code (CActModEtaVal) set to I (Order entry forbidden).
    ///     * If the Theoretical Opening Price has been determined and falls within the price thresholds, the system sends an MMTP-05 – Instrument State Change message with an action code (CActModEtaVal) of C (Trading), followed by an MMTP-05 – Instrument State Change message with an action code of O (Change to Open state).
    ///     * If the Theoretical Opening Price has been determined and falls outside the price thresholds, the system sends an MMTP-05 – Instrument State Change message with an instrument trading state indicator of (IetaCotVal) H (Instrument reserved upward) or B (Instrument reserved downward), the indicator giving origin of instrument reservation (IOrgResVal) set to A (Automatic) and an action code (CActModEtaVal) of R (Reservation), followed by an MMTP-05 – Instrument State Change message with an action code of I (Order entry forbidden) if the instrument was authorized.
    /// Processing of an order during the Continuous Trading phase
    ///     If the instrument is frozen, the system sends an MMTP-05 – Instrument State Change message with an action code (CActModEtaVal) of G (Freeze of an instrument).
    /// Market Control commands
    ///     * Programming of a deferred opening for a reserved or suspended instrument: an MMTP-05 – Instrument State Change message is sent with an action code (CActModEtaVal) of P and a programmed opening time provided and a space for the instrument trading state indicator (IetaCotVal).
    ///     * Cancellation of a deferred opening: an MMTP-05 – Instrument State Change message is sent with an action code (CActModEtaVal) of D.
    ///     * Reservation of an instrument by a Market Control command: an MMTP-05 – Instrument State Change message is sent with an instrument trading state indicator (IetaCotVal) of H, B or P and an action code (CActModEtaVal) of M.
    ///     * Suspension of an instrument:
    ///         o If the suspension command relates to a reserved instrument with a programmed deferred opening, an MMTP-05 – Instrument State Change message is sent with a space for the instrument trading state indicator (IetaCotVal) and an action code (CActModEtaVal) of D.
    ///         o In all cases, an MMTP-05 – Instrument State Change message is sent with an instrument trading state indicator (IetaCotVal) of S and an action code (CActModEtaVal) of M.
    ///     * Forbidding or authorization of an instrument: an MMTP-05 – Instrument State Change message is sent with a space for the instrument trading state indicator (IetaCotVal) and an action code (CActModEtaVal) of I or A.
    ///     * Stopping of the broadcasting of the market sheet for an instrument (Change to a Fast Market): an MMTP-05 – Instrument State Change message is sent with a space for the instrument trading state indicator (IetaCotVal) and an action code (CActModEtaVal) of F.
    ///     * Resumption of the broadcasting of the market sheet for an instrument (Return to a Slow Market): an MMTP-05 – Instrument State Change message is sent with a space for the instrument trading state indicator (IetaCotVal) and an action code (CActModEtaVal) of S.
    ///     * Elimination of all orders in the book for an instrument: an MMTP-05 – Instrument State Change message is sent with an action code (CActModEtaVal) of E.
    ///     * If the instrument is thawed, the system sends an MMTP-05 – Instrument State Change message with an action code (CActModEtaVal) of G (Thaw of an instrument).
    /// </summary>
    public class Message_05 : MessageContents //Length ==>48 , Short description ==> Instrument State Change
    {
        //********************************************************************************************
        public Message_05()
        {
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            xField = new Field("IetaCotVal", FieldType.Alphanumerical, 1, 1, "Instrument trading state indicator", "", "82", "");
            _ObsFields.Add(xField);

            xField = new Field("IOrgResVal", FieldType.Alphanumerical, 1, 2, "Indicator giving origin of instrument reservation", "", "87", "");
            _ObsFields.Add(xField);

            xField = new Field("DDebSuVal", FieldType.Numerical, 8, 3, "Start date for suspension of instrument", "", "73", "");
            _ObsFields.Add(xField);

            xField = new Field("HdebSuVal", FieldType.Numerical, 6, 11, "Start time for suspension of instrument", "", "76", "");
            _ObsFields.Add(xField);

            xField = new Field("CEtaVal", FieldType.Alphanumerical, 2, 17, "Code indicating the state of the instrument in NSC®", "", "59", "");
            _ObsFields.Add(xField);

            xField = new Field("CActModEtaVal", FieldType.Alphanumerical, 1, 19, "Action code for the instrument state change", "", "57", "");
            _ObsFields.Add(xField);

            xField = new Field("HOvPgmVal", FieldType.Alphanumerical, 6, 20, "Programmed opening time for instrument", "", "79", "");
            _ObsFields.Add(xField);

            xField = new Field("CEtaValSysTCS", FieldType.Alphanumerical, 1, 26, "Instrument state code in TCS system", "", "60", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_1", FieldType.Alphanumerical, 22, 27, "", "", "", "");
            _ObsFields.Add(xField);
        }
    }
}
