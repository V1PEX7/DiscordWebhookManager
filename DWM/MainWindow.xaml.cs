using System;
using System.Collections.Generic;
using System.Linq;
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Collections.Specialized;
using System.Windows.Threading;
using Color = System.Windows.Media.Color;
using System.Diagnostics;
using ColorConverter = System.Windows.Media.ColorConverter;

namespace DWM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        List<string> Url = new List<string>();
        List<string> names1 = new List<string>();
        List<string> avatars = new List<string>();
        List<string> avatarnames = new List<string>();
        List<string> themenames = new List<string>();
        const string namepath = @"./names.txt";
        const string urlpath = @"./urls.txt";
        const string avatarspath = @"./avatars.txt";
        const string avatarnamespath = @"./avatarnames.txt";
        const string setpath = @"./settings.txt";
        const string foldpath = @"./Themes";
        string urls2;                                       // VARIABLE FOR CHECK IF THE ENTERED URL IS CORRECT
        bool delmode = false;                               // DELETE MODE
        bool slctd = false;                                 // FALSE WHEN SEND SCREEN OPENED
        bool avsel = true;                                  // AVATAR SELECTION
        int selth = 0;
        string cg1c1;
        string cg1c2;
        string cg2c1;
        string cg2c2;
        string cgbc1;
        string cgbc2;
        string cgsc1;
        string cgsc2;
        System.Windows.Media.Color mg1c1 = System.Windows.Media.Color.FromArgb(100, 97, 67, 133);
        System.Windows.Media.Color mg1c2 = System.Windows.Media.Color.FromArgb(100, 81, 99, 149);
        System.Windows.Media.Color mg2c1 = System.Windows.Media.Color.FromArgb(100, 43, 88, 118);
        System.Windows.Media.Color mg2c2 = System.Windows.Media.Color.FromArgb(100, 78, 67, 118);
        System.Windows.Media.Color mgbc1 = System.Windows.Media.Color.FromArgb(100, 35, 34, 32);
        System.Windows.Media.Color mgbc2;
        System.Windows.Media.Color mgsc1;
        System.Windows.Media.Color mgsc2;

        public MainWindow()
        {
            InitializeComponent();
            if ((File.Exists(urlpath)) && (File.Exists(namepath)) && (File.Exists(avatarspath)) && (File.Exists(avatarnamespath)) && (File.Exists(setpath)) && (Directory.Exists(foldpath)) && (File.Exists(@"./Themes/default.dwmtheme")))
            {
                Url.AddRange(File.ReadAllLines(urlpath));
                names1.AddRange(File.ReadAllLines(namepath));
                avatars.AddRange(File.ReadAllLines(avatarspath));
                avatarnames.AddRange(File.ReadAllLines(avatarnamespath));
                string[] tempset = File.ReadAllLines(setpath);
                if (tempset[0] == "False" || tempset[0] == "False" || tempset[0] == "0")
                {
                    avsel = false;
                }
                else
                {
                    avsel = true;
                }
                try
                {
                    selth = Convert.ToInt32(tempset[1]);
                }
                catch (Exception)
                {
                    FileStream file4 = File.Create(setpath);
                    byte[] f4 = Encoding.UTF8.GetBytes(avsel + "\r\n" + selth + "\r\n");
                    file4.Write(f4, 0, f4.Length);
                    file4.Close();
                }
                themenames.AddRange(Directory.GetFiles(foldpath));
                themeload();
                if (cg1c1 == "" || cg1c2 == "" || cg2c1 == "" || cg2c2 == "" || cgbc1 == "" || cgbc2 == "" || cg1c1 == null || cg1c2 == null || cg2c1 == null || cg2c2 == null || cgbc1 == null || cgbc2 == null)
                {
                    mg1c1 = (Color)ColorConverter.ConvertFromString("#FF516395");
                    mg1c2 = (Color)ColorConverter.ConvertFromString("#FF614385");
                    mg2c1 = (Color)ColorConverter.ConvertFromString("#FF2B5876");
                    mg2c2 = (Color)ColorConverter.ConvertFromString("#FF4E4376");
                    mgbc1 = (Color)ColorConverter.ConvertFromString("#FF04619F");
                    mgbc2 = (Color)ColorConverter.ConvertFromString("Black");
                    mgsc1 = (Color)ColorConverter.ConvertFromString("#FF232220");
                    mgsc2 = (Color)ColorConverter.ConvertFromString("#FF232220");
                    ThemeApply();
                }
                else
                {
                    mg1c1 = (Color)ColorConverter.ConvertFromString(cg1c1);
                    mg1c2 = (Color)ColorConverter.ConvertFromString(cg1c2);
                    mg2c1 = (Color)ColorConverter.ConvertFromString(cg2c1);
                    mg2c2 = (Color)ColorConverter.ConvertFromString(cg2c2);
                    mgbc1 = (Color)ColorConverter.ConvertFromString(cgbc1);
                    mgbc2 = (Color)ColorConverter.ConvertFromString(cgbc2);
                    mgsc1 = (Color)ColorConverter.ConvertFromString(cgsc1);
                    mgsc2 = (Color)ColorConverter.ConvertFromString(cgsc2);
                    ThemeApply();
                }
                listBox3.SelectedIndex = selth;
            }
            else
            {
                if ((!File.Exists(urlpath)))                                    //Creating Files
                {
                    FileStream names = File.Create(urlpath);
                    names.Close();
                }

                if ((!File.Exists(namepath)))
                {
                    FileStream names2 = File.Create(namepath);
                    names2.Close();
                }
                if ((!File.Exists(avatarspath)))
                {
                    FileStream names3 = File.Create(avatarspath);
                    names3.Close();
                }
                if ((!File.Exists(avatarnamespath)))
                {
                    FileStream names4 = File.Create(avatarnamespath);
                    names4.Close();
                }
                if ((!File.Exists(setpath)))
                {
                    FileStream names5 = File.Create(setpath);
                    names5.Close();
                }
                if (!Directory.Exists(foldpath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(foldpath);
                }
                if ((!File.Exists(@"./Themes/default.dwmtheme")))
                {
                    FileStream file5 = File.Create(@"./Themes/default.dwmtheme");
                    byte[] f4 = Encoding.UTF8.GetBytes("[Gradient 1 Color 1]\r\n#FF516395\r\n[Gradient 1 Color 2]\r\n#FF2B5876\r\n[Gradient 2 Color 1]\r\n#FF2B5876\r\n[Gradient 2 Color 2]\r\n#FF4E4376\r\n[Background Gradient Color 1]\r\n#FF04619F\r\n[Background Gradient Color 2]\r\n#000000\r\n[Sidebar Gradient Color 1]\r\n#FF232220\r\n[Sidebar Gradient Color 2]\r\n#FF232220\r\n");
                    file5.Write(f4, 0, f4.Length);
                    file5.Close();
                }

            }

            for (int i = 0; i < Math.Min(Url.Count, names1.Count); i++)                 //Listbox fill
            {
                listBox1.Items.Add(names1[i]);
            }
            for (int i = 0; i < Math.Min(avatars.Count, avatarnames.Count); i++)
            {
                listBox2.Items.Add(avatarnames[i]);
            }
            for (int i = 0; i < themenames.Count; i++)
            {
                listBox3.Items.Add(themenames[i].Remove(0,9));
            }
            if (avsel == false)
            {
                listBox2.Visibility = Visibility.Hidden;
                listBox1.Height = 368;
                avLabel.Visibility = Visibility.Hidden;
                AvSelSet.IsChecked = false;
            }
        }

        public void sendWebHook(string URL, string msg, string username, string avatarurl)
        {
            Http.Post(URL, new NameValueCollection()
            {
                {
                    "username",
                    username
                },

                {
                    "content",
                    msg
                },

                {
                    "avatar_url",
                    avatarurl
                }
            }
                     );
        }

        public void sendWebHook(string URL, string msg, string username)
        {
            Http.Post(URL, new NameValueCollection()
            {
                {
                    "username",
                    username
                },

                {
                    "content",
                    msg
                },
            }
                     );
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBox2.Text != "" && textBox1.Text != "")
                {
                    urls2 = Url[listBox1.SelectedIndex];
                    if (urls2.StartsWith("https://discordapp.com/api/webhooks/") || urls2.StartsWith("https://discord.com/api/webhooks/"))
                    {
                        if (listBox2.SelectedIndex != -1)
                        {
                            sendWebHook(Url[listBox1.SelectedIndex], textBox2.Text, textBox1.Text, avatars[listBox2.SelectedIndex]);
                            textBox2.Text = "";
                        }
                        else
                        {
                            sendWebHook(Url[listBox1.SelectedIndex], textBox2.Text, textBox1.Text);
                            textBox2.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("You saved invalid Discord Webhook URL in file!");
                    }
                }
                else
                {
                    MessageBox.Show("Error: Check input fields",
                        "Error");
                }
            }
            catch (Exception)
            {
                {
                    MessageBox.Show("Webhook/Avatar URL not specified or is incorrect!",
                        "Error");
                }
            }
        }

        private void SendCatBtn_Click(object sender, RoutedEventArgs e)
        {
            SendGrid.Visibility = Visibility.Visible;
            AddGrid.Visibility = Visibility.Hidden;
            SetGrid.Visibility = Visibility.Hidden;
            slctd = false;
        }

        private void AddcCatBtn_Click(object sender, RoutedEventArgs e)                  //Choosing Category
        {
            AddGrid.Visibility = Visibility.Visible;
            SendGrid.Visibility = Visibility.Hidden;
            SetGrid.Visibility = Visibility.Hidden;
            slctd = true;
        }

        private void DeleteCatBtn_Click(object sender, RoutedEventArgs e)
        {
            if (avsel == true)
            {

                if (slctd == false)
                {
                    if (delmode == false)
                    {

                        DelWHBtn.Visibility = Visibility.Visible;
                        DelChBtn.Visibility = Visibility.Visible;
                        delmode = true;
                    }
                    else
                    {
                        DelWHBtn.Visibility = Visibility.Hidden;
                        DelChBtn.Visibility = Visibility.Hidden;
                        delmode = false;
                    }
                }
                else
                {
                    SendGrid.Visibility = Visibility.Visible;
                    AddGrid.Visibility = Visibility.Hidden;
                    SetGrid.Visibility = Visibility.Hidden;
                    slctd = false;
                    if (delmode == false)
                    {

                        DelWHBtn.Visibility = Visibility.Visible;
                        DelChBtn.Visibility = Visibility.Visible;
                        delmode = true;
                    }
                    else
                    {
                        DelWHBtn.Visibility = Visibility.Hidden;
                        DelChBtn.Visibility = Visibility.Hidden;
                        delmode = false;
                    }
                }
            }
            else
            {
                DelWHBtn.Margin = new Thickness(632, 378, 0, 0);
                if (slctd == false)
                {
                    if (delmode == false)
                    {

                        DelWHBtn.Visibility = Visibility.Visible;
                        DelChBtn.Visibility = Visibility.Visible;
                        delmode = true;
                    }
                    else
                    {
                        DelWHBtn.Visibility = Visibility.Hidden;
                        DelChBtn.Visibility = Visibility.Hidden;
                        delmode = false;
                    }
                }
                else
                {
                    SendGrid.Visibility = Visibility.Visible;
                    AddGrid.Visibility = Visibility.Hidden;
                    SetGrid.Visibility = Visibility.Hidden;
                    slctd = false;
                    if (delmode == false)
                    {

                        DelWHBtn.Visibility = Visibility.Visible;
                        DelChBtn.Visibility = Visibility.Visible;
                        delmode = true;
                    }
                    else
                    {
                        DelWHBtn.Visibility = Visibility.Hidden;
                        DelChBtn.Visibility = Visibility.Hidden;
                        delmode = false;
                    }
                }
            }
        }

        private void AddChBtn_Click(object sender, RoutedEventArgs e)                   //Adding Avatar
        {
            if ((ChIDBox.Text != "") && (ChNameBox.Text != ""))
            {
                    listBox2.Items.Add(ChNameBox.Text);
                    avatars.Add(ChIDBox.Text);
                    avatarnames.Add(ChNameBox.Text);
                    ChIDBox.Text = "";
                    ChNameBox.Text = "";
            }
            else
            {
                MessageBox.Show("Error: Check input fields.",
                    "Error");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((textBox3.Text != "") && (textBox4.Text != ""))
            {
                urls2 = textBox3.Text;
                if (urls2.StartsWith("https://discordapp.com/api/webhooks/") || urls2.StartsWith("https://discord.com/api/webhooks/"))
                {
                    listBox1.Items.Add(textBox4.Text);
                    names1.Add(textBox4.Text);
                    Url.Add(textBox3.Text);
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                else
                {
                    MessageBox.Show("Invalid Discord Webhook URL entered!");
                }
            }
            else
            {
                MessageBox.Show("Error: Check input fields",
                    "Error");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            FileStream file = File.Create(urlpath);                             //Saving URLs
            foreach (string i in Url)
            {
                byte[] f = Encoding.UTF8.GetBytes(i + "\r\n");
                file.Write(f, 0, f.Length);
            }
            file.Close();

            FileStream file1 = File.Create(namepath);                           //Saving Names
            foreach (string i in names1)
            {
                byte[] f1 = Encoding.UTF8.GetBytes(i + "\r\n");
                file1.Write(f1, 0, f1.Length);
            }
            file1.Close();

            FileStream file2 = File.Create(avatarspath);                       //Saving Avatars ID
            foreach (string i in avatars)
            {
                byte[] f2 = Encoding.UTF8.GetBytes(i + "\r\n");
                file2.Write(f2, 0, f2.Length);
            }
            file2.Close();

            FileStream file3 = File.Create(avatarnamespath);                   //Saving Avatars Names
            foreach (string i in avatarnames)
            {
                byte[] f3 = Encoding.UTF8.GetBytes(i + "\r\n");
                file3.Write(f3, 0, f3.Length);
            }
            file3.Close();

            FileStream file4 = File.Create(setpath);
            byte[] f4 = Encoding.UTF8.GetBytes(avsel + "\r\n" + selth + "\r\n");
            file4.Write(f4, 0, f4.Length);
            file4.Close();
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                textBox1.Text = names1[listBox1.SelectedIndex];
            }
            catch (Exception)
            {

            }
        }

        private void DelWHBtn_Click(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                int i = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(i);
                names1.RemoveAt(i);
                Url.RemoveAt(i);
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("You can't delete nothing!",
                    "Error");
            }
        }

        private void DelChBtn_Click(object sender, RoutedEventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                int i = listBox2.SelectedIndex;
                listBox2.Items.RemoveAt(i);
                avatars.RemoveAt(i);
                avatarnames.RemoveAt(i);
            }
            else
            {
                MessageBox.Show("You can't delete nothing!",
                    "Error");
            }
        }

        private void SetCatBtn_Click(object sender, RoutedEventArgs e)
        {
            AddGrid.Visibility = Visibility.Hidden;
            SendGrid.Visibility = Visibility.Hidden;
            SetGrid.Visibility = Visibility.Visible;
            slctd = true;
        }

        private void AvSelSet_Checked(object sender, RoutedEventArgs e)
        {
            avsel = true;
            listBox2.Visibility = Visibility.Visible;
            listBox1.Height = 169;
            avLabel.Visibility = Visibility.Visible;
        }

        private void AvSelSet_Unchecked(object sender, RoutedEventArgs e)
        {
            avsel = false;
            listBox2.Visibility = Visibility.Hidden;
            listBox1.Height = 368;
            avLabel.Visibility = Visibility.Hidden;
            listBox2.SelectedIndex = -1;
        }

        private void listBox1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            listBox1.SelectedIndex = -1;
        }

        private void listBox2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            listBox2.SelectedIndex = -1;
        }

        private void ThemeApply()
        {                               //Gradient 1
            g1c1.Color = mg1c1;
            g1c2.Color = mg1c2;

            g2c1.Color = mg1c1;
            g2c2.Color = mg1c2;

            g3c1.Color = mg1c1;
            g3c2.Color = mg1c2;

            g4c1.Color = mg1c1;
            g4c2.Color = mg1c2;

            g5c1.Color = mg1c1;
            g5c2.Color = mg1c2;

            g6c1.Color = mg1c1;
            g6c2.Color = mg1c2;

            g7c1.Color = mg1c1;
            g7c2.Color = mg1c2;

            g8c1.Color = mg1c1;
            g8c2.Color = mg1c2;

            g9c1.Color = mg1c1;
            g9c2.Color = mg1c2;

            g10c1.Color = mg1c1;
            g10c2.Color = mg1c2;

            g11c1.Color = mg1c1;
            g11c2.Color = mg1c2;

            g12c1.Color = mg1c1;
            g12c2.Color = mg1c2;

            //Gradient 2

            g1c1v2.Color = mg2c1;
            g1c2v2.Color = mg2c2;

            g1c1v2.Color = mg2c1;
            g1c2v2.Color = mg2c2;

            g2c1v2.Color = mg2c1;
            g2c2v2.Color = mg2c2;

            g3c1v2.Color = mg2c1;
            g3c2v2.Color = mg2c2;

            g4c1v2.Color = mg2c1;
            g4c2v2.Color = mg2c2;

            g5c1v2.Color = mg2c1;
            g5c2v2.Color = mg2c2;
                                        //Background

            gbc1.Color = mgbc1;
            gbc2.Color = mgbc2;
                                        //Sidebar

            gsc1.Color = mgsc1;
            gsc2.Color = mgsc2;
        }

        private void ThemeOpenBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(Directory.GetCurrentDirectory() + @"\themes");
            }
            catch
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\themes");
                Process.Start(Directory.GetCurrentDirectory() + @"\themes");
            }
        }

        private void ThemeButton_Click(object sender, RoutedEventArgs e)
        {
            selth = Convert.ToInt32(listBox3.SelectedIndex);
            themeload();
            if (cg1c1 == "" || cg1c2 == "" || cg2c1 == "" || cg2c2 == "" || cgbc1 == "" || cgbc2 == "" || cg1c1 == null || cg1c2 == null || cg2c1 == null || cg2c2 == null || cgbc1 == null || cgbc2 == null)
            {
                mg1c1 = (Color)ColorConverter.ConvertFromString("#FF516395");
                mg1c2 = (Color)ColorConverter.ConvertFromString("#FF614385");
                mg2c1 = (Color)ColorConverter.ConvertFromString("#FF2B5876");
                mg2c2 = (Color)ColorConverter.ConvertFromString("#FF4E4376");
                mgbc1 = (Color)ColorConverter.ConvertFromString("#FF04619F");
                mgbc2 = (Color)ColorConverter.ConvertFromString("Black");
                mgsc1 = (Color)ColorConverter.ConvertFromString("#FF232220");
                mgsc2 = (Color)ColorConverter.ConvertFromString("#FF232220");
                themenames.Clear();
                themenames.AddRange(Directory.GetFiles(foldpath));
                listBox3.Items.Clear();
                for (int i = 0; i < themenames.Count; i++)
                {
                    listBox3.Items.Add(themenames[i].Remove(0, 9));
                }
                
                ThemeApply();
            }
            else
            {
                mg1c1 = (Color)ColorConverter.ConvertFromString(cg1c1);
                mg1c2 = (Color)ColorConverter.ConvertFromString(cg1c2);
                mg2c1 = (Color)ColorConverter.ConvertFromString(cg2c1);
                mg2c2 = (Color)ColorConverter.ConvertFromString(cg2c2);
                mgbc1 = (Color)ColorConverter.ConvertFromString(cgbc1);
                mgbc2 = (Color)ColorConverter.ConvertFromString(cgbc2);
                mgsc1 = (Color)ColorConverter.ConvertFromString(cgsc1);
                mgsc2 = (Color)ColorConverter.ConvertFromString(cgsc2);
                themenames.Clear();
                themenames.AddRange(Directory.GetFiles(foldpath));
                listBox3.Items.Clear();
                for (int i = 0; i < themenames.Count; i++)
                {
                    listBox3.Items.Add(themenames[i].Remove(0, 9));
                }
                ThemeApply();

            }
        }

        private void RefreshTheme_Click(object sender, RoutedEventArgs e)
        {
            themenames.Clear();
            themenames.AddRange(Directory.GetFiles(foldpath));
            listBox3.Items.Clear();
            for (int i = 0; i < themenames.Count; i++)
            {
                listBox3.Items.Add(themenames[i].Remove(0, 9));
            }
        }

        private void themeload()
        {
            if(selth < 0)
            {
                MessageBox.Show("You must select something!", "Error");
                return;
            }

            string[] temp = File.ReadAllLines(themenames[selth]);
            cg1c1 = temp[1];
            cg1c2 = temp[3];
            cg2c1 = temp[5];
            cg2c2 = temp[7];
            cgbc1 = temp[9];
            cgbc2 = temp[11];
            cgsc1 = temp[13];
            cgsc2 = temp[15];
        }
    }
}
