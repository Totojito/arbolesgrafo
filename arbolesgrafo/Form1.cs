using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using arbolesgrafo;

namespace arbolesgrafo
{
    public partial class Form1 : Form
    {
      
        private Arbol arbolJerarquia;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

           
            Nodo raiz = new Nodo("Rectoría");

           
            arbolJerarquia = new Arbol(raiz);

           
            arbolJerarquia.Insertar("Rectoría", "Vicerrectoría Académica");
            arbolJerarquia.Insertar("Rectoría", "Vicerrectoría Administrativa");

            arbolJerarquia.Insertar("Vicerrectoría Académica", "Facultad de Ingeniería");
            arbolJerarquia.Insertar("Vicerrectoría Académica", "Facultad de Derecho");

            arbolJerarquia.Insertar("Facultad de Ingeniería", "Departamento de Sistemas");
            arbolJerarquia.Insertar("Facultad de Ingeniería", "Departamento Civil");

           
            Nodo nodoBuscado = arbolJerarquia.Buscar("Facultad de Ingeniería");
            if (nodoBuscado != null)
            {
                
                Console.WriteLine("¡Nodo encontrado!");
            }
        }

        
        private void btnMostrarArbol_Click(object sender, EventArgs e)
        {
            
            if (arbolJerarquia == null)
            {
                MessageBox.Show("El árbol aún no ha sido inicializado.");
                return;
            }

            
            string textoDelArbol = arbolJerarquia.RecorrerPreOrden();

            
            txtArbolResultado.Text = textoDelArbol;
        }

        
        private void btnContar_Click(object sender, EventArgs e)
        {
            if (arbolJerarquia == null)
            {
                MessageBox.Show("El árbol aún no ha sido inicializado.");
                return;
            }

            
            int totalNodos = arbolJerarquia.ContarNodos();

            MessageBox.Show($"El número total de nodos (puestos/deptos) es: {totalNodos}");
        }
    }

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

        // --- Aquí pondremos las funciones principales ---

        /// <summary>
        /// Busca un nodo en el árbol basado en su valor (nombre).
        /// Utiliza Búsqueda en Amplitud (BFS).
        /// </summary>
        /// <param name="valorBuscado">El string (ej. "Rector") que queremos encontrar.</param>
        /// <returns>El Nodo si se encuentra, o null si no existe.</returns>
        public Nodo Buscar(string valorBuscado)
        {

            if (this.Raiz == null)
            {
                return null;
            }


            Queue<Nodo> cola = new Queue<Nodo>();


            cola.Enqueue(this.Raiz);


            while (cola.Count > 0)
            {

                Nodo nodoActual = cola.Dequeue();


                if (nodoActual.Valor == valorBuscado)
                {
                    return nodoActual;
                }


                foreach (Nodo hijo in nodoActual.Hijos)
                {
                    cola.Enqueue(hijo);
                }
            }


            return null;
        }


        /// <summary>
        /// Inserta un nuevo nodo en el árbol.
        /// </summary>
        /// <param name="valorPadre">El valor (nombre) del nodo al que queremos agregar el hijo.</param>
        /// <param name="valorNuevo">El valor (nombre) del nuevo nodo a crear.</param>
        /// <returns>True si se pudo insertar, False si el padre no existe.</returns>
        public bool Insertar(string valorPadre, string valorNuevo)
        {

            Nodo nodoPadre = this.Buscar(valorPadre);


            if (nodoPadre == null)
            {

                return false;
            }


            Nodo nuevoNodo = new Nodo(valorNuevo);


            nuevoNodo.Padre = nodoPadre;


            nodoPadre.Hijos.Add(nuevoNodo);

            return true;
        }

       
        public string RecorrerPreOrden()
        {
           
            StringBuilder sb = new StringBuilder();

            
            RecorrerPreOrden_Recursivo(this.Raiz, 0, sb);

            return sb.ToString();
        }

        /// <summary>
        /// Función PRIVADA recursiva que hace el trabajo de recorrer.
        /// </summary>
        /// <param name="nodo">El nodo que estamos visitando ahora.</param>
        /// <param name="nivel">La profundidad (para saber cuánta sangría poner).</param>
        /// <param name="sb">El StringBuilder donde vamos armando el texto.</param>
        private void RecorrerPreOrden_Recursivo(Nodo nodo, int nivel, StringBuilder sb)
        {
            
            if (nodo == null) return;

            
            sb.Append(new string(' ', nivel * 4)); 
            sb.AppendLine(nodo.Valor); 

            
            foreach (Nodo hijo in nodo.Hijos)
            {
               
                RecorrerPreOrden_Recursivo(hijo, nivel + 1, sb);
            }
        }
        // ... (Aquí están tus funciones de Recorrer) ...

        /// <summary>
        /// Función PÚBLICA que inicia el conteo de nodos.
        /// </summary>
        /// <returns>El número total de nodos en el árbol.</returns>
        public int ContarNodos()
        {
            
            return ContarNodos_Recursivo(this.Raiz);
        }

        
        private int ContarNodos_Recursivo(Nodo nodo)
        {
            
            if (nodo == null)
            {
                return 0;
            }

            
            int conteo = 1;

           
            foreach (Nodo hijo in nodo.Hijos)
            {
                conteo += ContarNodos_Recursivo(hijo);
            }

            return conteo;
        }
    }
}