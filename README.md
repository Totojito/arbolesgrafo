#  Proyecto: Árboles y Grafos

La aplicación está desarrollada en C# (Windows Forms) usando Visual Studio 2022.

# Autor

* **Nombre:** Axel Yael Algaba Flores
  
* **CIF:** 25011383



##  Características Implementadas

El proyecto consta de dos módulos principales:

### Parte 1: Jerarquía Organizativa (Árbol General)
**Inserción:** Permite añadir nuevos nodos (puestos/departamentos) a la jerarquía.

**Búsqueda:** Implementa Búsqueda en Amplitud (**BFS**) para encontrar cualquier nodo.

**Recorrido:** Muestra la jerarquía completa usando un recorrido **PreOrden** recursivo con sangría.

**Conteo:** Función recursiva para contar el total de nodos en el árbol.


### Parte 2: Sistema de Rutas Grafo
**Representación:** Grafo No Dirigido y Ponderado, implementado con **Listas de Adyacencia** (Clases `Vertice`, `Arista` y `Grafo`).

**Cálculo de Ruta:** Implementación del **Algoritmo de Dijkstra** para encontrar la ruta más corta entre dos edificios.

**Interfaz:** Permite al usuario seleccionar un "Origen" y "Destino" de una lista y muestra la ruta y distancia total.



##  Cómo Ejecutar

1.  Clonar este repositorio.
2.  Abrir el archivo `arbolesgrafo.sln` con Visual Studio 2022.
