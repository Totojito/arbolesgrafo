using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arbolesgrafo
{

    public class Nodo
    {

        public string Valor { get; set; }


        public List<Nodo> Hijos { get; set; }


        public Nodo Padre { get; set; }


        public Nodo(string valor)
        {
            this.Valor = valor;

            this.Hijos = new List<Nodo>();
        }
    }


    public class Arbol
    {

        public Nodo Raiz { get; set; }


        public Arbol(Nodo raiz)
        {
            this.Raiz = raiz;
        }


    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
