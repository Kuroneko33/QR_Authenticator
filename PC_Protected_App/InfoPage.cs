using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_Protected_App
{
    public partial class InfoPage : Form
    {
        string basicPath = @"../../";
        string imgPath = @"Images/";
        string basicImgExt = ".png";
        public InfoPage(int page, string type)
        {
            InitializeComponent();
            if (type == "Досье")
            {
                if (page == 1)
                {
                    this.BackgroundImage = new Bitmap(basicPath + imgPath + "ДосьеСкай" + basicImgExt);
                    this.Text = "Дейзи Луиза Джонсон";
                }
                else if (page == 2)
                {
                    this.BackgroundImage = new Bitmap(basicPath + imgPath + "ДосьеФитц" + basicImgExt);
                    this.Text = "Леопольд Джеймс Фитц";
                }
                else if (page == 3)
                {
                    this.BackgroundImage = new Bitmap(basicPath + imgPath + "ДосьеМэй" + basicImgExt);
                    this.Text = "Мелинда Кьаолиан Мэй";
                }
                else if (page == 4)
                {
                    this.BackgroundImage = new Bitmap(basicPath + imgPath + "ДосьеКолсон" + basicImgExt);
                    this.Text = "Филлип Джей Колсон";
                }
            }
            else if (type == "Миссии")
            {
                if (page == 1)
                {
                    this.BackgroundImage = new Bitmap(basicPath + imgPath + "Мстители" + basicImgExt);
                    this.Text = "Мстители";
                }
                else if (page == 2)
                {
                    this.BackgroundImage = new Bitmap(basicPath + imgPath + "МстителиВБ" + basicImgExt);
                    this.Text = "Мстители Война бесконечности";
                }
                else if (page == 3)
                {
                    this.BackgroundImage = new Bitmap(basicPath + imgPath + "МстителиЭА" + basicImgExt);
                    this.Text = "Мстители Эра Альтрона";
                }
                else if (page == 4)
                {
                    this.BackgroundImage = new Bitmap(basicPath + imgPath + "МстителиФинал" + basicImgExt);
                    this.Text = "Мстители Финал";
                }
            }
            else if (type == "Артефакты")
            {
                if (page == 1)
                {
                    this.BackgroundImage = new Bitmap(basicPath + imgPath + "Мьёльнир" + basicImgExt);
                    this.Text = "Мьёльнир";
                }
                else if (page == 2)
                {
                    this.BackgroundImage = new Bitmap(basicPath + imgPath + "Секира" + basicImgExt);
                    this.Text = "Громсекира";
                }
                else if (page == 3)
                {
                    this.BackgroundImage = new Bitmap(basicPath + imgPath + "Глаз" + basicImgExt);
                    this.Text = "Глаз Агомотто";
                }
                else if (page == 4)
                {
                    this.BackgroundImage = new Bitmap(basicPath + imgPath + "Тессеракт" + basicImgExt);
                    this.Text = "Тессеракт";
                }
            }
            else if (type == "Разработки")
            {
                if (page == 1)
                {
                    this.BackgroundImage = new Bitmap(basicPath + imgPath + "Щит" + basicImgExt);
                    this.Text = "Щит Капитана Америки";
                }
                else if (page == 2)
                {
                    this.BackgroundImage = new Bitmap(basicPath + imgPath + "ПерчаткаЖЧ" + basicImgExt);
                    this.Text = "Перчатка Железного Человека";
                }
                else if (page == 3)
                {
                    this.BackgroundImage = new Bitmap(basicPath + imgPath + "Паук" + basicImgExt);
                    this.Text = "Веб шутеры";
                }
                else if (page == 4)
                {
                    this.BackgroundImage = new Bitmap(basicPath + imgPath + "Квант" + basicImgExt);
                    this.Text = "Квантовый туннель";
                }
            }



        }
        private void InfoPage_Load(object sender, EventArgs e)
        {

        }
    }
}
