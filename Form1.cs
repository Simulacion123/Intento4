using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace simulacion_estacionamiento
{
    public partial class Formestacionamiento : Form
    {
		private int[] NumerosPares = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };

        public Formestacionamiento()
        {
            InitializeComponent();
        }
        clscaseta objcaseta = new clscaseta();
        clsauto objauto = new clsauto();
        clscajon caja = new clscajon();
        int contador = 0;

		private void DibujarPicture(PictureBox picture)
		{
			Invoke(new Action(() => pishurreal.Controls.Add(picture)));
		}

		private void Formestacionamiento_Load(object sender, EventArgs e)
		{
			Métodos.setDibujar(DibujarPicture);
			Métodos.setMover(Mover);
			Carrotes.Start();

		}

		private void Mover(string comandeishon, PictureBox picture, int velocidad, int coordenada)
		{
			switch (comandeishon)
			{
				case "arriba":

					for (int i = picture.Location.Y; i >= coordenada; i--)
					{
						Invoke(new Action(() => picture.Location = new Point(picture.Location.X, i)));
						Thread.Sleep(velocidad);
					}
					break;

				case "abajo":
					for (int i = picture.Location.Y; i <= coordenada; i++)
					{
						Invoke(new Action(() => picture.Location = new Point(picture.Location.X, i)));
						Thread.Sleep(velocidad);
					}
					break;

				case "izquierda":
					for (int i = picture.Location.X; i >= coordenada; i--)
					{
						Invoke(new Action(() => picture.Location = new Point( i, picture.Location.Y)));
						Thread.Sleep(velocidad);
					}
					break;

				case "derecha":
					for (int i = picture.Location.X; i <= coordenada; i++)
					{
						Invoke(new Action(() => picture.Location = new Point(i, picture.Location.Y)));
						Thread.Sleep(velocidad);
					}
					break;
			}
		}

		private void Carrotes_Tick(object sender, EventArgs e)
		{
			Random random = new Random();
			var tarea = Task.Factory.StartNew((x) =>
			{
				int numero = NumerosPares[(int)x];
				for (int i = 0; i < numero / 2; i++)
				{
					Thread hilo = new Thread(() => new Carritos());
					hilo.Start();
				}
			}, random.Next(1, 10));
			
		}

		private void pishurreal_MouseMove(object sender, MouseEventArgs e)
		{

		}

		private void pishurreal_Click(object sender, EventArgs e)
		{

		}
	}
}
