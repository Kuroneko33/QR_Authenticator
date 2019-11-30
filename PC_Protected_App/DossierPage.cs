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
    public partial class DossierPage : Form
    {
        string basicPath = @"../../";
        string imgPath = @"Images/";
        string basicImgExt = ".png";
        string page;
        public DossierPage(int page)
        {
            InitializeComponent();
            if (page == 1)
            {
                this.BackgroundImage = new Bitmap(basicPath + imgPath + "ДосьеСкай" + basicImgExt);
            }
            else if (page == 2)
            {
                this.BackgroundImage = new Bitmap(basicPath + imgPath + "ДосьеФитц" + basicImgExt);
            }
            else if (page == 3)
            {
                this.BackgroundImage = new Bitmap(basicPath + imgPath + "ДосьеМэй" + basicImgExt);
            }
            else if (page == 4)
            {
                this.BackgroundImage = new Bitmap(basicPath + imgPath + "ДосьеКолсон" + basicImgExt);
            }
        }
        private void DossierPage_Load(object sender, EventArgs e)
        {

        }
    }
}
