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
        string basicPath = @"../../";
        string imgPath = @"Images/";
        string basicImgExt = ".png";

        Dictionary<string,Bitmap> mainMenuPics = new Dictionary<string,Bitmap>();
        List<string> mainMenuPicsPath = new List<string>();
        string[] mainMenuPicsNames = new string[6];
        string OS_UI_NoTarget = "OS_UI_NoTarget";
        string OS_UI_Досье = "OS_UI_Досье";
        string OS_UI_Миссии = "OS_UI_Миссии";
        string OS_UI_Артефакты = "OS_UI_Артефакты";
        string OS_UI_Разработки = "OS_UI_Разработки";
        string OS_UI_Управление_кораблём = "OS_UI_Управление кораблём";
        bool LoadingFinished = false;
        Dictionary<string,Bitmap> greetingAgentsPics = new Dictionary<string,Bitmap>();
        List<string> greetingAgentsPicsPath = new List<string>();
        string[] greetingAgentsPicsNames = new string[5];
        string ПриветствиеКолсон = "ПриветствиеКолсон";
        string ПриветствиеМэй = "ПриветствиеМэй";
        string ПриветствиеСкай = "ПриветствиеСкай";
        string ПриветствиеФитц = "ПриветствиеФитц";
        string ПриветствиеНеизвестно = "ПриветствиеНеизвестно";


        Agent agentSky = new Agent("Дейзи", "Луиза", "Джонсон", 1);
        Agent agentFitz = new Agent("Леопольд", "Джеймс", "Фитц", 2);
        Agent agentMay = new Agent("Мелинда", "Кьаолиан", "Мэй", 3);
        Agent agentCoulson = new Agent("Филлип", "Джей", "Колсон", 4);

        int AccessLevel = 1;
        public Form0()
        {
            InitializeComponent();
        }
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
                mainMenuPicsPath.Add(basicPath + imgPath + mainMenuPicsNames[i] + basicImgExt);
                mainMenuPics.Add(mainMenuPicsNames[i], new Bitmap(mainMenuPicsPath[i]));
            }
            greetingAgentsPicsNames[0] = ПриветствиеКолсон;
            greetingAgentsPicsNames[1] = ПриветствиеМэй;
            greetingAgentsPicsNames[2] = ПриветствиеСкай;
            greetingAgentsPicsNames[3] = ПриветствиеФитц;
            greetingAgentsPicsNames[4] = ПриветствиеНеизвестно;
            for (int i = 0; i < greetingAgentsPicsNames.Length; i++)
            {
                greetingAgentsPicsPath.Add(basicPath + imgPath + greetingAgentsPicsNames[i] + basicImgExt);
                greetingAgentsPics.Add(greetingAgentsPicsNames[i], new Bitmap(greetingAgentsPicsPath[i]));
            }
        }

        Thread Receive;
        private void ReceiveThreadFunk()
        {
            string mess = new Tcp_S_R.Tcp_S_R().ReceiveMessage();
            
            if (pictureBox1.InvokeRequired) pictureBox1.Invoke(new Action<bool>((s) => pictureBox1.Visible = s), false);
            else pictureBox1.Visible = false;
            if (label1.InvokeRequired) label1.Invoke(new Action<bool>((s) => label1.Visible = s), false);
            else label1.Visible = false;
            if (label1.InvokeRequired) label1.Invoke(new Action<bool>((s) => label1.Visible = s), false);
            else label1.Visible = false;

            //Разделение сообщения mess на части, вызов шифрования и т.д.
            Agent agent = agentMay;
            AccessLevel = agent.AccessLevel;
            string user = "";
            user = agent.FullName;
            UserLoad(user);
            Thread.Sleep(500/*2000*/);
            pictureBox3.Invoke(new Action<bool>((s) => pictureBox3.Visible = s), false);
            LoadingFinished = true;

            if (pictureBox2.InvokeRequired) pictureBox2.Invoke(new Action<bool>((s) => pictureBox2.Visible = s), true);
            else pictureBox2.Visible = true;
        }

        private void UserLoad(string user)
        {
            Bitmap localGreetingBmp = greetingAgentsPics[ПриветствиеНеизвестно]; ;
            if (user == agentSky.FullName)
            {
                localGreetingBmp = greetingAgentsPics[ПриветствиеСкай];
            }
            else if (user == agentFitz.FullName)
            {
                localGreetingBmp = greetingAgentsPics[ПриветствиеФитц];
            }
            else if (user == agentMay.FullName)
            {
                localGreetingBmp = greetingAgentsPics[ПриветствиеМэй];
            }
            else if (user == agentCoulson.FullName)
            {
                localGreetingBmp = greetingAgentsPics[ПриветствиеКолсон];
            }
            pictureBox3.BackgroundImage = localGreetingBmp;
            pictureBox3.Invoke(new Action<bool>((s) => pictureBox3.Visible = s), true);
        }

        private void Button1_Click(object sender, EventArgs e)//кнопка входа
        {
            Button clickedButton = (Button)sender;
            clickedButton.Visible = false;
            string host = System.Net.Dns.GetHostName();
            System.Net.IPAddress ip = System.Net.Dns.GetHostByName(host).AddressList[1];
            LFSR ipProtection = new LFSR();
            string key = ipProtection.GenerateKey();
            string ipStr = ip.ToString();
            string enctyptedIpStr = ipProtection.Encrypt(ipStr);
            ipProtection.EnterKey(key);
            string dectyptedIpStr = ipProtection.Decrypt(enctyptedIpStr);

            string code = "";
            code += enctyptedIpStr + ";";
            code += key;

            pictureBox1.Visible = true;
            label1.Visible = true;
            BarCodeGenerate(code);
            
            Receive = new Thread(new ThreadStart(ReceiveThreadFunk));
            Receive.Start();
        }
        private void BarCodeGenerate(string msg)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            EncodingOptions encodingOptions = new EncodingOptions() { Width = pictureBox1.Width, Height = pictureBox1.Height, Margin = 0, PureBarcode = false };
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
            if (!LoadingFinished) return;
            Point CursorLocation = PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
            int CursorX = CursorLocation.X;
            int CursorY = CursorLocation.Y;
            Console.WriteLine(CursorX + " " + CursorY);
            if (CursorX > 130 && CursorX < 220 && CursorY > 70 && CursorY < 200)
            {
                Console.WriteLine(CursorX + " ! " + CursorY);
                Dossier dossier = new Dossier(AccessLevel);
                dossier.Show();
            }
            else if (CursorX > 125 && CursorX < 224 && CursorY > 290 && CursorY < 425)
            {
                Console.WriteLine(CursorX + " ! " + CursorY);
            }
            else if ((CursorX > 625 && CursorX < 705 && CursorY > 80 && CursorY < 180) ||
                    (CursorX > 590 && CursorX < 740 && CursorY > 180 && CursorY < 205))
            {
                Console.WriteLine(CursorX + " ! " + CursorY);
            }
            else if ((CursorX > 625 && CursorX < 710 && CursorY > 295 && CursorY < 400) ||
                    (CursorX > 595 && CursorX < 750 && CursorY > 400 && CursorY < 425))
            {
                Console.WriteLine(CursorX + " ! " + CursorY);
            }
            else if ((CursorX > 385 && CursorX < 455 && CursorY > 190 && CursorY < 285) ||
                    (CursorX > 280 && CursorX < 570 && CursorY > 285 && CursorY < 315))
            {
                Console.WriteLine(CursorX + " ! " + CursorY);
            }
        }

        private void PictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (!LoadingFinished) return;
            int CursorX = e.Location.X;
            int CursorY = e.Location.Y;
            //Console.WriteLine(CursorX + " " + CursorY);
            if (CursorX>130 && CursorX<220 && CursorY > 70 && CursorY < 200)
            {
                pictureBox2.BackgroundImage = mainMenuPics[OS_UI_Досье];
            }
            else if (CursorX > 125 && CursorX < 224 && CursorY > 290 && CursorY < 425)
            {
                pictureBox2.BackgroundImage = mainMenuPics[OS_UI_Миссии];
            }
            else if ((CursorX > 625 && CursorX < 705 && CursorY > 80 && CursorY < 180) || 
                    (CursorX > 590 && CursorX < 740 && CursorY > 180 && CursorY < 205))
            {
                pictureBox2.BackgroundImage = mainMenuPics[OS_UI_Артефакты];
            }
            else if ((CursorX > 625 && CursorX < 710 && CursorY > 295 && CursorY < 400) ||
                    (CursorX > 595 && CursorX < 750 && CursorY > 400 && CursorY < 425))
            {
                pictureBox2.BackgroundImage = mainMenuPics[OS_UI_Разработки];
            }
            else if ((CursorX > 385 && CursorX < 455 && CursorY > 190 && CursorY < 285) ||
                    (CursorX > 280 && CursorX < 570 && CursorY > 285 && CursorY < 315))
            {
                pictureBox2.BackgroundImage = mainMenuPics[OS_UI_Управление_кораблём];
            }
            else
            {
                pictureBox2.BackgroundImage = mainMenuPics[OS_UI_NoTarget];
            }
        }
    }
}
