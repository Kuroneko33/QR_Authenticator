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
using System.Windows.Input;

namespace PC_Protected_App
{
    public partial class Form0 : Form
    {
        public Form0()
        {
            InitializeComponent();
        }
        Dictionary<string,Bitmap> mainMenuPics = new Dictionary<string,Bitmap>();
        static string basicPath = @"../../";
        static string imgPath = @"Images/";
        static string basicExt = ".png";
        static string[] mainMenuPicsNames = new string[6];
        string OS_UI_NoTarget = "OS_UI_NoTarget";
        string OS_UI_Досье = "OS_UI_Досье";
        string OS_UI_Миссии = "OS_UI_Миссии";
        string OS_UI_Артефакты = "OS_UI_Артефакты";
        string OS_UI_Разработки = "OS_UI_Разработки";
        string OS_UI_Управление_кораблём = "OS_UI_Управление кораблём";
        List<string> mainMenuPicsPath = new List<string>();
        private void Form0_Load(object sender, EventArgs e)
        {
            mainMenuPicsNames[0] = OS_UI_NoTarget;
            mainMenuPicsNames[1] = OS_UI_Досье;
            mainMenuPicsNames[2] = OS_UI_Миссии;
            mainMenuPicsNames[3] = OS_UI_Артефакты;
            mainMenuPicsNames[4] = OS_UI_Разработки;
            mainMenuPicsNames[5] = OS_UI_Управление_кораблём;
            for (int i = 0; i < mainMenuPicsNames.Length; i++)
            {
                mainMenuPicsPath.Add(basicPath + imgPath + mainMenuPicsNames[i] + basicExt);
                mainMenuPics.Add(mainMenuPicsNames[i], new Bitmap(mainMenuPicsPath[i]));
            }
        }

        Thread Receive;
        private void ReceiveThreadFunk()
        {
            ///////string mess = new Tcp_S_R.Tcp_S_R().ReceiveMessage();
            ///Тут еще вставку с загрузкой пользователя сделать
            ///
            if (pictureBox1.InvokeRequired) pictureBox1.Invoke(new Action<bool>((s) => pictureBox1.Visible = s), false);
            else pictureBox1.Visible = false;
            if (label1.InvokeRequired) label1.Invoke(new Action<bool>((s) => label1.Visible = s), false);
            else label1.Visible = false;
            if (label1.InvokeRequired) label1.Invoke(new Action<bool>((s) => label1.Visible = s), false);
            else label1.Visible = false;
            if (pictureBox2.InvokeRequired) pictureBox2.Invoke(new Action<bool>((s) => pictureBox2.Visible = s), true);
            else pictureBox2.Visible = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
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
            /////pictureBox1.Visible = true;
            /////label1.Visible = true;
            /////BarCodeGenerate(code);
            Receive = new Thread(new ThreadStart(ReceiveThreadFunk));
            Receive.Start();
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

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Point CursorLocation = PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
            int CursorX = CursorLocation.X;
            int CursorY = CursorLocation.Y;
            Console.WriteLine(CursorX + " " + CursorY);
            if (CursorX > 155 && CursorX < 260 && CursorY > 80 && CursorY < 235)
            {
                Console.WriteLine(CursorX + " ! " + CursorY);
            }
            else if (CursorX > 145 && CursorX < 265 && CursorY > 330 && CursorY < 495)
            {
                Console.WriteLine(CursorX + " ! " + CursorY);
            }
            else if ((CursorX > 745 && CursorX < 835 && CursorY > 90 && CursorY < 205) ||
                    (CursorX > 700 && CursorX < 880 && CursorY > 205 && CursorY < 240))
            {
                Console.WriteLine(CursorX + " ! " + CursorY);
            }
            else if ((CursorX > 745 && CursorX < 835 && CursorY > 340 && CursorY < 460) ||
                    (CursorX > 710 && CursorX < 890 && CursorY > 460 && CursorY < 500))
            {
                Console.WriteLine(CursorX + " ! " + CursorY);
            }
            else if ((CursorX > 455 && CursorX < 545 && CursorY > 215 && CursorY < 330) ||
                    (CursorX > 330 && CursorX < 680 && CursorY > 330 && CursorY < 370))
            {
                Console.WriteLine(CursorX + " ! " + CursorY);
            }
        }

        private void PictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            int CursorX = e.Location.X;
            int CursorY = e.Location.Y;
            //Console.WriteLine(CursorX + " " + CursorY);
            if (CursorX>155 && CursorX<260 && CursorY > 80 && CursorY < 235)
            {
                pictureBox2.Image = mainMenuPics[OS_UI_Досье];
            }
            else if (CursorX > 145 && CursorX < 265 && CursorY > 330 && CursorY < 495)
            {
                pictureBox2.Image = mainMenuPics[OS_UI_Миссии];
            }
            else if ((CursorX > 745 && CursorX < 835 && CursorY > 90 && CursorY < 205) || 
                    (CursorX > 700 && CursorX < 880 && CursorY > 205 && CursorY < 240))
            {
                pictureBox2.Image = mainMenuPics[OS_UI_Артефакты];
            }
            else if ((CursorX > 745 && CursorX < 835 && CursorY > 340 && CursorY < 460) ||
                    (CursorX > 710 && CursorX < 890 && CursorY > 460 && CursorY < 500))
            {
                pictureBox2.Image = mainMenuPics[OS_UI_Разработки];
            }
            else if ((CursorX > 455 && CursorX < 545 && CursorY > 215 && CursorY < 330) ||
                    (CursorX > 330 && CursorX < 680 && CursorY > 330 && CursorY < 370))
            {
                pictureBox2.Image = mainMenuPics[OS_UI_Управление_кораблём];
            }
            else
            {
                pictureBox2.Image = mainMenuPics[OS_UI_NoTarget];
            }
        }
    }
}
