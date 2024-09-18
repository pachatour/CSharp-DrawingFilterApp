using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizarra_de_dibujo_y_filtros
{
    public partial class Form1 : Form
    {
        //CONSTRUCTOR
        public Form1()
        {
            InitializeComponent(); //iniciamos todos los componentes del formulario

            this.Width = 900; //ancho formulario
            this.Height = 700; //alto formulario
            bm = new Bitmap(pic.Width,pic.Height); //nuevo mapa de bits, del mismo tamano PictureBox
            g = Graphics.FromImage(bm); //se crea un objeto Graphics a partir del mapa de bits para poder dibujar en el
            g.Clear(Color.White); //llena el mapa de bits con color blanco (un linzo blanco)
            pic.Image = bm; //asigna el mapa de bits como una imagen de PictureBox
        }

        //VARIABLES DE CLASE
        Bitmap bm; //almacena la imagen en la que se dibujara
        Graphics g; //objeto para realizar operaciones de dibujo en el mapa de bits
        bool paint = false; //indica si se esta dibujando actualmente
        Point px, py; //almacenan las cordenadas del mouse para dibujar
        Pen p = new Pen(Color.Black, 8); //crea un lapiz negro con grosor: 8 
        int index; //se usa para determinar que herramiento de dibujo esta seleccionada

        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            py = e.Location;
        }

        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint)
            {
                if (index == 1)
                {
                    px = e.Location;
                    g.DrawLine(p, px, py);
                    py = px;
                }
            }
            pic.Refresh();
        }

        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;
        }

        private void btn_pencil_Click(object sender, EventArgs e)
        {
            index = 1;
        }

        /*CREADAS POR ACCIDENTE*/
        private void pic_color_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pic_Click(object sender, EventArgs e)
        {

        }
    }
}
