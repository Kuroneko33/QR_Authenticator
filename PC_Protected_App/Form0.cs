using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;
using ZXing.Rendering;

namespace PC_Protected_App
{
    public partial class Form0 : Form
    {
        public Form0()
        {
            InitializeComponent();
        }

        private void Form0_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            label1.Visible = true;
            Button clickedButton = (Button)sender;
            clickedButton.Visible = false;
            string host = System.Net.Dns.GetHostName();
            System.Net.IPAddress ip = System.Net.Dns.GetHostByName(host).AddressList[1];
            string code = "";
            code += ip.ToString() + ";";
            int level = 1;
            code += level + ";";
            string key = "fdsfnmdsfk'mdofn44jn2535ljn";
            code += key + ";";
            BarCodeGenerate(code);
        }
        private void BarCodeGenerate(string msg)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            EncodingOptions encodingOptions = new EncodingOptions() { Width = pictureBox1.Width, Height = pictureBox1.Height, Margin = 0, PureBarcode = false };//Тут размеры qr кода, потом поменять
            encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
            barcodeWriter.Renderer = new BitmapRenderer();
            barcodeWriter.Options = encodingOptions;
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            Bitmap qrCode = barcodeWriter.Write(msg);
            pictureBox1.Image = qrCode;
        }
        private void StartForm1()
        {
            Form f1 = new Form1();
            f1.Show();
        }
    }
}
