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
        string type = "";
        Dictionary<string, Bitmap> dossierMenuPicsForThisLevel = new Dictionary<string, Bitmap>();
        public Dossier(int accessLevel, string type)
        {
            InitializeComponent();
            AccessLevel = accessLevel;
            this.type = type;
            this.Text = type;
        }

        private void Dossier_Load(object sender, EventArgs e)
        {
            if (type == "Досье")
            {
                dossierMenuPicsNames[0] = "ДосьеМенюСкай";
                dossierMenuPicsNames[1] = "ДосьеМенюФитц";
                dossierMenuPicsNames[2] = "ДосьеМенюМэй";
                dossierMenuPicsNames[3] = "ДосьеМенюКолсон";
                dossierMenuPicsNames[4] = "ДосьеМенюНеизвестный2Уровень";
                dossierMenuPicsNames[5] = "ДосьеМенюНеизвестный3Уровень";
                dossierMenuPicsNames[6] = "ДосьеМенюНеизвестный4Уровень";
            }
            else if (type == "Миссии")
            {
                dossierMenuPicsNames[0] = "МстителиМеню";
                dossierMenuPicsNames[1] = "МстителиВБМеню";
                dossierMenuPicsNames[2] = "МстителиЭАМеню";
                dossierMenuPicsNames[3] = "МстителиФиналМеню";
                dossierMenuPicsNames[4] = "Требуется2Уровень";
                dossierMenuPicsNames[5] = "Требуется3Уровень";
                dossierMenuPicsNames[6] = "Требуется4Уровень";
            }
            else if (type == "Артефакты")
            {
                dossierMenuPicsNames[0] = "МьёльнирМеню";
                dossierMenuPicsNames[1] = "СекираМеню";
                dossierMenuPicsNames[2] = "ГлазМеню";
                dossierMenuPicsNames[3] = "ТессерактМеню";
                dossierMenuPicsNames[4] = "Требуется2Уровень";
                dossierMenuPicsNames[5] = "Требуется3Уровень";
                dossierMenuPicsNames[6] = "Требуется4Уровень";
            }
            else if (type == "Разработки")
            {
                dossierMenuPicsNames[0] = "ЩитМеню";
                dossierMenuPicsNames[1] = "ПерчаткаЖЧМеню";
                dossierMenuPicsNames[2] = "ПаукМеню";
                dossierMenuPicsNames[3] = "КвантМеню";
                dossierMenuPicsNames[4] = "Требуется2Уровень";
                dossierMenuPicsNames[5] = "Требуется3Уровень";
                dossierMenuPicsNames[6] = "Требуется4Уровень";
            }



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

            pictureBox1.BackgroundImage = dossierMenuPics[dossierMenuPicsNames[0]];
            if (AccessLevel>=2)
            {
                dossierMenuPicsForThisLevel.Add("2", dossierMenuPics[dossierMenuPicsNames[1]]);
                dossierMenuPicsForThisLevel.Add("2L", dossierMenuPics[dossierMenuPicsNames[1] + "Свеч"]);
            }
            else
            {
                dossierMenuPicsForThisLevel.Add("2", dossierMenuPics[dossierMenuPicsNames[4]]);
                dossierMenuPicsForThisLevel.Add("2L", dossierMenuPics[dossierMenuPicsNames[4] + "Свеч"]);
            }
            if (AccessLevel >= 3)
            {
                dossierMenuPicsForThisLevel.Add("3", dossierMenuPics[dossierMenuPicsNames[2]]);
                dossierMenuPicsForThisLevel.Add("3L", dossierMenuPics[dossierMenuPicsNames[2] + "Свеч"]);
            }
            else
            {
                dossierMenuPicsForThisLevel.Add("3", dossierMenuPics[dossierMenuPicsNames[5]]);
                dossierMenuPicsForThisLevel.Add("3L", dossierMenuPics[dossierMenuPicsNames[5] + "Свеч"]);
            }
            if (AccessLevel >= 4)
            {
                dossierMenuPicsForThisLevel.Add("4", dossierMenuPics[dossierMenuPicsNames[3]]);
                dossierMenuPicsForThisLevel.Add("4L", dossierMenuPics[dossierMenuPicsNames[3] + "Свеч"]);
            }
            else
            {
                dossierMenuPicsForThisLevel.Add("4", dossierMenuPics[dossierMenuPicsNames[6]]);
                dossierMenuPicsForThisLevel.Add("4L", dossierMenuPics[dossierMenuPicsNames[6] + "Свеч"]);
            }
            pictureBox2.BackgroundImage = dossierMenuPicsForThisLevel["2"];
            pictureBox3.BackgroundImage = dossierMenuPicsForThisLevel["3"];
            pictureBox4.BackgroundImage = dossierMenuPicsForThisLevel["4"];
        }

        private void PictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = dossierMenuPics[dossierMenuPicsNames[0] + "Свеч"];
        }
        private void PictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = dossierMenuPics[dossierMenuPicsNames[0]];
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
                    try
                    {
                        pictureBox5.Invoke(new Action<bool>((s) => pictureBox5.Visible = s), false);

                    }
                    catch (Exception)
                    {
                    }
                });
                DossierPage dossier = new DossierPage(page, type);
                dossier.Show();
            }
            else
            {
                pictureBox5.BackgroundImage = new Bitmap(basicPath + imgPath + "ДоступЗапрещён" + basicImgExt);
                pictureBox5.Visible = true;
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(SleepTime);
                    try
                    {
                        pictureBox5.Invoke(new Action<bool>((s) => pictureBox5.Visible = s), false);
                    }
                    catch (Exception)
                    {
                    }
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
