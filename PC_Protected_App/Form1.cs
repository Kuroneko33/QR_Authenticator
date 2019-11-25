using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;
using ZXing.Rendering;

namespace PC_Protected_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Thread Receive;
        private void ReceiveThreadFunk()
        {
            if (label1.InvokeRequired) label1.Invoke(new Action<string>((s) => label1.Text = s), new Tcp_S_R.Tcp_S_R().ReceiveMessage());
            else label1.Text = new Tcp_S_R.Tcp_S_R().ReceiveMessage();
        }
        private void BarCodeGenerate(string msg)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            EncodingOptions encodingOptions = new EncodingOptions() { Width = 150, Height = 150, Margin = 0, PureBarcode = false };//Тут размеры qr кода, потом поменять
            encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
            barcodeWriter.Renderer = new BitmapRenderer();
            barcodeWriter.Options = encodingOptions;
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            Bitmap qrCode = barcodeWriter.Write(msg);
            pictureBox1.Image = qrCode;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Receive = new Thread(new ThreadStart(ReceiveThreadFunk));
            Receive.Start();
            //label1.Text = new Tcp_S_R.Tcp_S_R().ReceiveMessage();
            BarCodeGenerate("Сюда пихать кодируемый текст с айпишником и уровнем допуска");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            new Tcp_S_R.Tcp_S_R("192.168.100.5").SendMessage(richTextBox1.Text);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
