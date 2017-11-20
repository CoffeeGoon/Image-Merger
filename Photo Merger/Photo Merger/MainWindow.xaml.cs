using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Photo_Merger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Drawing.Image layerA = null;
        System.Drawing.Image layerB = null;
        float opacA =(float) 0.7;
        float opacB = (float) 0.7;
        String outputpath = "";
        public MainWindow()
        {
          
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
           fd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if(fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var bar = System.Drawing.Image.FromFile(fd.FileName);
                
                layerA = new Bitmap(bar, 496, 303);
                    var myImage3 = new System.Windows.Controls.Image();
                    BitmapImage bi3 = new BitmapImage(new Uri(fd.FileName));
                  //  bi3.BeginInit();
                    //bi3.UriSource = new Uri(fd.FileName, UriKind.Relative);
                    //bi3.EndInit();
                    ImageA.Stretch = Stretch.Fill;
                    ImageA.Source = bi3;
                Console.WriteLine(fd.FileName);
              




            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var bar =  System.Drawing.Image.FromFile(fd.FileName);
                    layerB = new Bitmap(bar, new System.Drawing.Size(496, 303));
                    var myImage3 = new System.Windows.Controls.Image();
                    BitmapImage bi3 = new BitmapImage(new Uri(fd.FileName));
                   // bi3.BeginInit();
                    //bi3.UriSource = new Uri(fd.FileName, UriKind.Relative);
                    //bi3.EndInit();
                    ImgB.Stretch = Stretch.Fill;
                    ImgB.Source = bi3;
                Console.WriteLine(fd.FileName);




            }
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Send_Data(object sender, RoutedEventArgs e)
        {
            Boolean senti = false;
            if(layerA != null && layerB != null)
            {
                senti = true;
            }
            if (senti)
            {
                opacA = opacA - (float) metricA.Value;
                opacB = opacB - (float) metricB.Value;
                Console.WriteLine("slider a: " + metricA.Value + " Slider b: " + metricB.Value);
                Bitmap transfer = new Bitmap(496, 303);
                using (Graphics gwrite = Graphics.FromImage(transfer))
                {
                    ColorMatrix alterA = new ColorMatrix();
                    ColorMatrix alterB = new ColorMatrix();
                    alterA.Matrix33 = opacA;
                    alterB.Matrix33 = opacB;
                    ImageAttributes tempA = new ImageAttributes();
                    ImageAttributes tempB = new ImageAttributes();
                    tempA.SetColorMatrix(alterA, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    tempB.SetColorMatrix(alterB, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                  
                    gwrite.DrawImage(layerA, new System.Drawing.Rectangle(0, 0, layerA.Width, layerA.Height), 0, 0, layerA.Width, layerA.Height, GraphicsUnit.Pixel, tempA);
                     gwrite.DrawImage(layerB, new System.Drawing.Rectangle(0, 0, layerA.Width, layerA.Height), 0, 0, layerA.Width, layerA.Height, GraphicsUnit.Pixel, tempB);
                    gwrite.Dispose();
                }
                if (transfer != null)
                {
                    Window1 swit = new Window1(transfer, "deprecated");
                    App.Current.MainWindow = swit;
                    this.Close();
                    swit.Show();
                }
                else
                {
                    Console.WriteLine("bitmap empty");
                }

            }
        }
    }

}
