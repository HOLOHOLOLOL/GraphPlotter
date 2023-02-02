using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphPlotter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DrawGraph(Graphics g, int xmin, int xmax, Func<int, double> f) // Функция для рисования графика по входным данным.  
        {

            int width = panel1.Width; // Ширина панели.  

            Pen pen = new Pen(Color.Red); // Цвет линий.  

            for (int x = 0; x < width; ++x)  //Рисуем линию, соединяя точку (x, f(x)) c (x + 1, f(x + 1))  
            {

                int x1 = xmin + (xmax - xmin) * x / width; //Преобразуем X-координату   

                int y1 = panel1.Height - (int)(panel1.Height * f(x1) / 5); //Преобразуем Y-координату   

                int x2 = xmin + (xmax - xmin) * (x + 1) / width; //Преобразуем X-координату   

                int y2 = panel1.Height - (int)(panel1.Height * f(x2) / 5); //Преобразуем Y-координату   

                g.DrawLine(pen, x, y1, x + 1, y2); //Рисуем линь  
                

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)// Paint event handler  
        {

            DrawGraph(e.Graphics, 0, 10, t => Math.Sin(t));// Draw the graph of the function Sin() on the Panel control    

        }
    }
}