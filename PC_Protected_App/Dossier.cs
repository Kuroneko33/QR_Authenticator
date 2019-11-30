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

namespace PC_Protected_App
{
    public partial class Dossier : Form
    {
        int AccessLevel;
        string basicPath = @"../../";
        string imgPath = @"Images/";
        string basicImgExt = ".png";
        Dictionary<string, Bitmap> dossierMenuPics = new Dictionary<string, Bitmap>();
        List<string> dossierMenuPicsPath = new List<string>();
        string[] dossierMenuPicsNames = new string[7];
        string ДосьеМенюКолсон = "ДосьеМенюКолсон";
        string ДосьеМенюМэй = "ДосьеМенюМэй";
        string ДосьеМенюСкай = "ДосьеМенюСкай";
        string ДосьеМенюФитц = "ДосьеМенюФитц";
        string ДосьеМенюНеизвестный2Уровень = "ДосьеМенюНеизвестный2Уровень";
        string ДосьеМенюНеизвестный3Уровень = "ДосьеМенюНеизвестный3Уровень";
        string ДосьеМенюНеизвестный4Уровень = "ДосьеМенюНеизвестный4Уровень";
        Dictionary<string, Bitmap> dossierMenuPicsForThisLevel = new Dictionary<string, Bitmap>();
        public Dossier(int accessLevel)
        {
            InitializeComponent();
            AccessLevel = accessLevel;
        }

        private void Dossier_Load(object sender, EventArgs e)
        {
            dossierMenuPicsNames[0] = ДосьеМенюКолсон;
            dossierMenuPicsNames[1] = ДосьеМенюМэй;
            dossierMenuPicsNames[2] = ДосьеМенюСкай;
            dossierMenuPicsNames[3] = ДосьеМенюФитц;
            dossierMenuPicsNames[4] = ДосьеМенюНеизвестный2Уровень;
            dossierMenuPicsNames[5] = ДосьеМенюНеизвестный3Уровень;
            dossierMenuPicsNames[6] = ДосьеМенюНеизвестный4Уровень;
            for (int i = 0; i < dossierMenuPicsNames.Length; i++)
            {
                dossierMenuPicsPath.Add(basicPath + imgPath + dossierMenuPicsNames[i] + basicImgExt);
                dossierMenuPics.Add(dossierMenuPicsNames[i], new Bitmap(dossierMenuPicsPath[i]));
            }
            for (int i = 0; i < dossierMenuPicsNames.Length; i++)
            {
                dossierMenuPicsPath.Add(basicPath + imgPath + dossierMenuPicsNames[i] + "Свеч" + basicImgExt);
                dossierMenuPics.Add(dossierMenuPicsNames[i] + "Свеч", new Bitmap(dossierMenuPicsPath[i + dossierMenuPicsNames.Length]));
            }

            pictureBox1.BackgroundImage = dossierMenuPics[ДосьеМенюСкай];
            if (AccessLevel>=2)
            {
                dossierMenuPicsForThisLevel.Add("2", dossierMenuPics[ДосьеМенюФитц]);
                dossierMenuPicsForThisLevel.Add("2L", dossierMenuPics[ДосьеМенюФитц + "Свеч"]);
            }
            else
            {
                dossierMenuPicsForThisLevel.Add("2", dossierMenuPics[ДосьеМенюНеизвестный2Уровень]);
                dossierMenuPicsForThisLevel.Add("2L", dossierMenuPics[ДосьеМенюНеизвестный2Уровень + "Свеч"]);
            }
            if (AccessLevel >= 3)
            {
                dossierMenuPicsForThisLevel.Add("3", dossierMenuPics[ДосьеМенюМэй]);
                dossierMenuPicsForThisLevel.Add("3L", dossierMenuPics[ДосьеМенюМэй + "Свеч"]);
            }
            else
            {
                dossierMenuPicsForThisLevel.Add("3", dossierMenuPics[ДосьеМенюНеизвестный3Уровень]);
                dossierMenuPicsForThisLevel.Add("3L", dossierMenuPics[ДосьеМенюНеизвестный3Уровень + "Свеч"]);
            }
            if (AccessLevel >= 4)
            {
                dossierMenuPicsForThisLevel.Add("4", dossierMenuPics[ДосьеМенюКолсон]);
                dossierMenuPicsForThisLevel.Add("4L", dossierMenuPics[ДосьеМенюКолсон + "Свеч"]);
            }
            else
            {
                dossierMenuPicsForThisLevel.Add("4", dossierMenuPics[ДосьеМенюНеизвестный4Уровень]);
                dossierMenuPicsForThisLevel.Add("4L", dossierMenuPics[ДосьеМенюНеизвестный4Уровень + "Свеч"]);
            }
            pictureBox2.BackgroundImage = dossierMenuPicsForThisLevel["2"];
            pictureBox3.BackgroundImage = dossierMenuPicsForThisLevel["3"];
            pictureBox4.BackgroundImage = dossierMenuPicsForThisLevel["4"];
        }

        private void PictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = dossierMenuPics[ДосьеМенюСкай+"Свеч"];
        }
        private void PictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = dossierMenuPics[ДосьеМенюСкай];
        }
        private void PictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = dossierMenuPicsForThisLevel["2L"];
        }
        private void PictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = dossierMenuPicsForThisLevel["2"];
        }
        private void PictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = dossierMenuPicsForThisLevel["3L"];
        }
        private void PictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = dossierMenuPicsForThisLevel["3"];
        }
        private void PictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.BackgroundImage = dossierMenuPicsForThisLevel["4L"];
        }
        private void PictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackgroundImage = dossierMenuPicsForThisLevel["4"];
        }

        int SleepTime = 1500;

        private void PictureBox_Click(int accessLevel, int page)
        {
            if (AccessLevel >= accessLevel)
            {
                pictureBox5.BackgroundImage = new Bitmap(basicPath + imgPath + "ДоступРазрешён" + basicImgExt);
                pictureBox5.Visible = true;
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(SleepTime);
                    pictureBox5.Invoke(new Action<bool>((s) => pictureBox5.Visible = s), false);
                });
                DossierPage dossier = new DossierPage(page);
                dossier.Show();
            }
            else
            {
                pictureBox5.BackgroundImage = new Bitmap(basicPath + imgPath + "ДоступЗапрещён" + basicImgExt);
                pictureBox5.Visible = true;
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(SleepTime);
                    pictureBox5.Invoke(new Action<bool>((s) => pictureBox5.Visible = s), false);
                });
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox_Click(1, 1);
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            PictureBox_Click(2, 2);
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            PictureBox_Click(3, 3);
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            PictureBox_Click(4, 4);
        }
    }
}
