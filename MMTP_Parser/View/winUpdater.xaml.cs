using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using MMTP_Parser.Tools;
using System.IO;
using MMTP_Parser.Entity;
using System.Threading;
using MMTP_Parser.Entity.Custom;

namespace MMTP_Parser.View
{
    /// <summary>
    /// Interaction logic for winUpdater.xaml
    /// </summary>
    public partial class winUpdater : Window
    {
        private ObservableCollection<MMTP_Parser.Entity.MMTP.DIFF.Header> _ObsMessageDiff;
        private ObservableCollection<MMTP_Parser.Entity.MMTP.RLC.Header> _ObsMessageRlc;

        TcpClient _Sock = null;
        NetworkStream _NetStream = null;
        StreamReader _StreamReader = null;

        //*************************************************************
        public winUpdater()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;


            InitializeComponent();
            if (Config._ProtocoleMode.Nvl("").ToLower() == "diff")
            {
                Tool._ProtocoleMode = "diff";
                rdbDiff.IsChecked = true;
            }
            else if (Config._ProtocoleMode.Nvl("").ToLower() == "rlc")
            {
                Tool._ProtocoleMode = "rlc";
                rdbRlc.IsChecked = true;
            }
            if (Config._AutoRun.Nvl(0) == 1)
            {
                btnRun_Click(null, null);
            }
        }
        //*************************************************************
        private void rdbDiff_Checked(object sender, RoutedEventArgs e)
        {
            Tool._ProtocoleMode = "diff";
        }
        //*************************************************************
        private void rdbRlc_Checked(object sender, RoutedEventArgs e)
        {
            Tool._ProtocoleMode = "rlc";
        }
        //*************************************************************
        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            MybusyIndicator.BusyContent = "Parser is running";
            MybusyIndicator.IsBusy = true;
            _ObsMessageDiff = new ObservableCollection<MMTP_Parser.Entity.MMTP.DIFF.Header>();
            _ObsMessageRlc = new ObservableCollection<MMTP_Parser.Entity.MMTP.RLC.Header>();
            try
            {
                new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                if (Config._ReadFromMMTPLogMessage.Nvl(0) == 0)
                {
                    _Sock = new TcpClient(Config._FeederIp, Config._FeederPort.Nvl(0));
                    _NetStream = _Sock.GetStream();
                }
                else
                {
                    _StreamReader = new StreamReader(System.IO.Path.GetFullPath(Config._MMTPLogMessageName));
                }
                while (true)
                {
                    lock (this)
                    {
                        if (Tool._ProtocoleMode == "diff")
                        {
                            ReadDiff();
                        }
                        else if (Tool._ProtocoleMode == "rlc")
                        {
                            ReadRlc();
                        }
                    }
                }
            }).Start();
            }
            catch (Exception e1)
            {
                MessageBox.Show("btnRun_Click (" + Config._ProtocoleMode.ToUpper() + ") : " + e1.Message);
                using (FileStream fs = new FileStream(string.Format("Errors.log"), FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("btnRun_Click : " + DateTime.Now.ToString() + e1.Message + "\n");
                }
                MybusyIndicator.IsBusy = false;
                btnRun.Focus();
            }
            finally
            {
                if (_Sock != null)
                {
                    MybusyIndicator.IsBusy = false;
                    _Sock.GetStream().Close();
                    _Sock.Close();
                }
            }
        }
        //*************************************************************
        private void ReadDiff()
        {
            string xText = "";
            string[] xArr = null;
            MMTP_Parser.Entity.MMTP.DIFF.Header xHeader = new MMTP_Parser.Entity.MMTP.DIFF.Header();
            Byte[] xArrFirstSub = new Byte[95];
            if (Config._ReadFromMMTPLogMessage.Nvl(0) == 0)
            {
                _NetStream.Read(xArrFirstSub, 0, xArrFirstSub.Length);
            }
            else
            {
                xText = _StreamReader.ReadLine();
                if (xText == null)
                {

                }
                xArr = xText.Split(',');

                for (int i = 0; i < xArrFirstSub.Length; i++)
                {
                    xArrFirstSub[i] = Convert.ToByte(xArr[i]);
                }
            }
            xHeader.FillFirstSub(xArrFirstSub);
            if (xHeader._IsFirstSubFiled)
            {

                Byte[] xArrSecondSub = new Byte[xHeader._ObsFields.GetFieldFromObs("Business_Data_Length")._Numerical.Nvl(0) + 1];
                if (Config._ReadFromMMTPLogMessage.Nvl(0) == 0)
                {
                    _NetStream.Read(xArrSecondSub, 0, xArrSecondSub.Length);
                }
                else
                {
                    for (int i = 95; i < xArrSecondSub.Length; i++)
                    {
                        xArrSecondSub[i - 95] = Convert.ToByte(xArr[i]);
                    }
                }
                xHeader.FillSecondSub(xArrSecondSub);
                if (xHeader._BusinessDataHeader._IsValedMessage)
                {
                    if (Config._WriteMMTPLogMessageUnReadable.Nvl(0) == 1)
                    {
                        Tool.WriteToTxtMmtpUnReadable(xArrFirstSub, xArrSecondSub);
                    }
                    if (Config._WriteMMTPLogMessageReadable.Nvl(0) == 1)
                    {
                        Tool.WriteToTxtMmtpDiffReadable(xHeader);
                    }
                    _ObsMessageDiff.Add(xHeader);
                }
            }
        }
        //*************************************************************
        private void ReadRlc()
        {
            string xText = "";
            string[] xArr = null;
            MMTP_Parser.Entity.MMTP.RLC.Header xHeader = new MMTP_Parser.Entity.MMTP.RLC.Header();
            Byte[] xArrFirstSub = new Byte[84];
            if (Config._ReadFromMMTPLogMessage.Nvl(0) == 0)
            {
                _NetStream.Read(xArrFirstSub, 0, xArrFirstSub.Length);
            }
            else
            {
                xText = _StreamReader.ReadLine();
                if (xText == null)
                {

                }
                xArr = xText.Split(',');

                for (int i = 0; i < xArrFirstSub.Length; i++)
                {
                    xArrFirstSub[i] = Convert.ToByte(xArr[i]);
                }
            }
            //**Insert Byte To the Array
            byte[] xArrFirstSubTmp = new byte[xArrFirstSub.Length + 1];
            xArrFirstSub.CopyTo(xArrFirstSubTmp, 1);
            xArrFirstSubTmp[0] = 0;
            xArrFirstSub = xArrFirstSubTmp;
            //##Insert Byte To the Array
            xHeader.FillFirstSub(xArrFirstSub);
            if (xHeader._IsFirstSubFiled && !xHeader._ObsFields.GetFieldFromObs("YMsgRLC")._Alphanumerical.Contains(" ") && xHeader._ObsFields.GetFieldFromObs("CValMne")._Alphanumerical != "0000")
            {
                Byte[] xArrSecondSub = new Byte[xHeader._ObsFields.GetFieldFromObs("ZOctMsgRLC5")._Numerical.Nvl(0) - 84 + 1];
                if (Config._ReadFromMMTPLogMessage.Nvl(0) == 0)
                {
                    _NetStream.Read(xArrSecondSub, 0, xArrSecondSub.Length);
                }
                else
                {
                    for (int i = 84; i < xArrSecondSub.Length; i++)
                    {
                        xArrSecondSub[i - 84] = Convert.ToByte(xArr[i]);
                    }
                }
                //**Insert Byte To the Array
                byte[] xArrSecondSubTmp = new byte[xArrSecondSub.Length + 1];
                xArrSecondSub.CopyTo(xArrSecondSubTmp, 1);
                xArrSecondSubTmp[0] = 0;
                xArrSecondSub = xArrSecondSubTmp;
                //##Insert Byte To the Array
                xHeader.FillSecondSub(xArrSecondSub);
                if (xHeader._IsValedMessage)
                {
                    if (Config._WriteMMTPLogMessageUnReadable.Nvl(0) == 1)
                    {
                        Tool.WriteToTxtMmtpUnReadable(xArrFirstSub, xArrSecondSub);
                    }
                    if (Config._WriteMMTPLogMessageReadable.Nvl(0) == 1)
                    {
                        Tool.WriteToTxtMmtpRlcReadable(xHeader);
                    }
                    _ObsMessageRlc.Add(xHeader);
                }
            }
            else
            {

            }
        }
        //*************************************************************
    }
}
