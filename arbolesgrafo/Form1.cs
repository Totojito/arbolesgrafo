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
        private Grafo mapaEdificios;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

            
            mapaEdificios = new Grafo();
      
            Nodo raiz = new Nodo("Rectoría");


            arbolJerarquia = new Arbol(raiz);

   
            arbolJerarquia.Insertar("Rectoría", "Vicerrectoría Académica");
            arbolJerarquia.Insertar("Rectoría", "Vicerrectoría Administrativa");

            arbolJerarquia.Insertar("Vicerrectoría Académica", "Facultad de Ingeniería");
            arbolJerarquia.Insertar("Vicerrectoría Académica", "Facultad de Derecho");

            arbolJerarquia.Insertar("Facultad de Ingeniería", "Departamento de Sistemas");
            arbolJerarquia.Insertar("Facultad de Ingeniería", "Departamento Civil");
  

            mapaEdificios = new Grafo();

            mapaEdificios.AgregarVertice("Biblioteca");
            mapaEdificios.AgregarVertice("Cafetería");
            mapaEdificios.AgregarVertice("Gimnasio");
            mapaEdificios.AgregarVertice("Laboratorios");
            mapaEdificios.AgregarVertice("Rectoría"); 

         
            mapaEdificios.AgregarArista("Biblioteca", "Cafetería", 50);
            mapaEdificios.AgregarArista("Biblioteca", "Laboratorios", 100);
            mapaEdificios.AgregarArista("Cafetería", "Laboratorios", 60);
            mapaEdificios.AgregarArista("Cafetería", "Gimnasio", 80);
            mapaEdificios.AgregarArista("Laboratorios", "Gimnasio", 120);
            mapaEdificios.AgregarArista("Gimnasio", "Rectoría", 70);

          
            if (mapaEdificios != null)
            {
                
                foreach (Vertice v in mapaEdificios.Vertices)
                {
                 
                    cmbOrigen.Items.Add(v.Valor);
                    cmbDestino.Items.Add(v.Valor);
                }

              
                if (cmbOrigen.Items.Count > 0)
                {
                    cmbOrigen.SelectedIndex = 0;
                    cmbDestino.SelectedIndex = 0;
                }
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

            MessageBox.Show($"El número total de nodos es: {totalNodos}");
        }

       

        private void btnCalcularRuta_Click(object sender, EventArgs e)
        {
         
            if (mapaEdificios == null)
            {
                MessageBox.Show("El mapa de edificios no ha sido inicializado.");
                return;
            }

            if (cmbOrigen.SelectedItem == null || cmbDestino.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un origen y un destino.");
                return;
            }


            string valorOrigen = cmbOrigen.SelectedItem.ToString();
            string valorDestino = cmbDestino.SelectedItem.ToString();

       
            mapaEdificios.CalcularRutaMasCorta(valorOrigen);

   
            string rutaResultado = mapaEdificios.ObtenerRutaMasCorta(valorDestino);


            txtArbolResultado.Text = rutaResultado;
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
        /// Busca un nodo en el árbol basado en su valor.
        /// Utiliza Búsqueda en Amplitud.
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
        /// Función privada recursiva que hace el trabajo de recorrer.
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
   
    public class Arista
    {
        public Vertice VerticeDestino { get; set; }
        public int Peso { get; set; } 

        public Arista(Vertice destino, int peso)
        {
            this.VerticeDestino = destino;
            this.Peso = peso;
        }
    }
   
    public class Vertice
    {
        public string Valor { get; set; } 

    
        public List<Arista> Aristas { get; set; }


        public int DistanciaMinima { get; set; }
        public Vertice VerticeAnterior { get; set; }
        public bool Visitado { get; set; }


        public Vertice(string valor)
        {
            this.Valor = valor;
            this.Aristas = new List<Arista>();


            this.DistanciaMinima = int.MaxValue; 
            this.VerticeAnterior = null;
            this.Visitado = false;
        }
    }

    public class Grafo
    {

        public List<Vertice> Vertices { get; set; }

        public Grafo()
        {
            this.Vertices = new List<Vertice>();
        }


        public void AgregarVertice(string valor)
        {

            if (BuscarVertice(valor) == null)
            {
                Vertices.Add(new Vertice(valor));
            }
        }

        /// <summary>
        /// Añade una Arista (camino) entre dos edificios.
        /// :)
        /// </summary>
        /// <param name="valorOrigen">Nombre del edificio A</param>
        /// <param name="valorDestino">Nombre del edificio B</param>
        /// <param name="peso">Distancia entre A y B</param>
        public void AgregarArista(string valorOrigen, string valorDestino, int peso)
        {
            Vertice origen = BuscarVertice(valorOrigen);
            Vertice destino = BuscarVertice(valorDestino);


            if (origen != null && destino != null)
            {
           
                origen.Aristas.Add(new Arista(destino, peso));

      
                destino.Aristas.Add(new Arista(origen, peso));
            }
        }

 
        public Vertice BuscarVertice(string valor)
        {
 
            foreach (Vertice v in Vertices)
            {
                if (v.Valor == valor)
                {
                    return v;
                }
            }
            return null; 
        }



        /// <summary>
        /// Implementación del Algoritmo de Dijkstra.
        /// Encuentra la ruta más corta desde un vértice de origen a todos los demás.
        /// </summary>
        /// <param name="valorOrigen">El nombre del edificio donde empezamos.</param>
        public void CalcularRutaMasCorta(string valorOrigen)
        {
  
            Vertice origen = BuscarVertice(valorOrigen);
            if (origen == null)
            {
                return;
            }

         
            foreach (Vertice v in Vertices)
            {
                v.DistanciaMinima = int.MaxValue; 
                v.VerticeAnterior = null;
                v.Visitado = false;
            }


            origen.DistanciaMinima = 0;

      
            List<Vertice> pendientes = new List<Vertice>(Vertices);

   
            while (pendientes.Count > 0)
            {
 
                Vertice verticeActual = null;
                int minimaDistancia = int.MaxValue;

                foreach (Vertice v in pendientes)
                {
                    if (v.DistanciaMinima < minimaDistancia)
                    {
                        minimaDistancia = v.DistanciaMinima;
                        verticeActual = v;
                    }
                }


                if (verticeActual == null)
                {
                    break;
                }

   
                verticeActual.Visitado = true;
                pendientes.Remove(verticeActual);

           
                foreach (Arista arista in verticeActual.Aristas)
                {
                    Vertice vecino = arista.VerticeDestino;

           
                    if (vecino.Visitado)
                    {
                        continue;
                    }

             
                    int nuevaDistancia = verticeActual.DistanciaMinima + arista.Peso;

        
                    if (nuevaDistancia < vecino.DistanciaMinima)
                    {
      
                        vecino.DistanciaMinima = nuevaDistancia;
                        vecino.VerticeAnterior = verticeActual;
                    }
                }
            }
        }

        /// <summary>
        /// Reconstruye la ruta más corta hacia un destino, DESPUÉS de ejecutar Dijkstra.
        /// </summary>
        /// <param name="valorDestino">El nombre del edificio al que queremos llegar.</param>
        /// <returns>Un string describiendo la ruta y la distancia total.</returns>
        public string ObtenerRutaMasCorta(string valorDestino)
        {
            Vertice destino = BuscarVertice(valorDestino);
            if (destino == null)
            {
                return "El edificio de destino no existe.";
            }

   
            if (destino.DistanciaMinima == int.MaxValue)
            {
                return $"No se encontró una ruta hacia {valorDestino}.";
            }

    
            List<string> ruta = new List<string>();
            Vertice actual = destino;

            while (actual != null)
            {
                ruta.Add(actual.Valor);
                actual = actual.VerticeAnterior;
            }

      
            ruta.Reverse();

      
            string resultado = $"Ruta más corta a {valorDestino} ({destino.DistanciaMinima}m): \n";
            resultado += string.Join(" -> ", ruta);

            return resultado;
        }

    }

}