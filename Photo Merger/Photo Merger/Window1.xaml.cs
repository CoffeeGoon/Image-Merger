using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Photo_Merger
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    /// 





    public partial class Window1 : Window
    {
        String savenm = "";
        Bitmap store;
        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }



        public Window1(Bitmap paint, String loc)
        {
            savenm = loc;
            if(paint != null)
            {
                Console.WriteLine("good");
            }
            InitializeComponent();
            //ImageSourceConverter foo = new ImageSourceConverter();



            BitmapImage exxy = BitmapToImageSource(paint);
           // output.Stretch = Stretch.Fill;
            output.Source = exxy;
            store = paint;

          

            
        }
        private void Button_Click(object sender, RoutedEventArgs e) {
            SaveFileDialog sef = new SaveFileDialog();
            if (sef.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                store.Save(sef.FileName, ImageFormat.Jpeg);
               MainWindow bac = new MainWindow();
                App.Current.MainWindow = bac;
                this.Close();
                bac.Show();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            MainWindow bac = new MainWindow();
            App.Current.MainWindow = bac;
            this.Close();
            bac.Show();
        }
    }
}
