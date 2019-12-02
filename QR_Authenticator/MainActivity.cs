using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using ZXing.Mobile;

namespace QR_Authenticator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        string Agent = "Скай";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            MobileBarcodeScanner.Initialize(Application);

            Agent = "Скай";
            FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(Resource.Drawable.Sky);

            var button = FindViewById<ImageButton>(Resource.Id.fab);
            button.Click += async delegate
            {
                var scanner = new MobileBarcodeScanner();
                var result = await scanner.Scan();

                if (result == null) return;

                string ip = result.Text;

                string[] randStrs = {"fdytrtfv", "dcdsvsd", "sdasxcwfw", "jult,", "ascsdcr", "yujtytr", "ecl,", "i;remcd", "mkfwec", "sa;xlz,"};  
                string LastName = Agent;
                string mess = "";
                Random rnd = new Random();
                for (int i = 0; i < randStrs.Length; i++)
                {
                    if (i==7)
                    {
                        mess += LastName;
                    }
                    else
                    {
                        mess += randStrs[rnd.Next(randStrs.Length)];
                    }
                    mess += ":";
                }
                LFSR messProtection = new LFSR();
                string key = messProtection.GenerateKey();
                string enctyptedMess = messProtection.Encrypt(mess);

                messProtection.EnterKey(key);
                string dectyptedMess = messProtection.Decrypt(enctyptedMess);

                new Tcp_S_R.Tcp_S_R(ip).SendMessage(enctyptedMess);
                new Tcp_S_R.Tcp_S_R(ip).SendMessage(enctyptedMess.Length.ToString());
                new Tcp_S_R.Tcp_S_R(ip).SendMessage(key);
                new Tcp_S_R.Tcp_S_R(ip).SendMessage(key.Length.ToString());
            };
        }

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if(drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.nav_camera)
            {
                Agent = "Скай";
                FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(Resource.Drawable.Sky);
            }
            else if (id == Resource.Id.nav_gallery)
            {
                Agent = "Фитц";
                FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(Resource.Drawable.Fitz);
            }
            else if (id == Resource.Id.nav_slideshow)
            {
                Agent = "Мэй";
                FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(Resource.Drawable.May);
            }
            else if (id == Resource.Id.nav_manage)
            {
                Agent = "Колсон";
                FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(Resource.Drawable.Coulson);
            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

