using System;

// Definición de la clase Nodo, que representa un nodo en el árbol binario de búsqueda.
class Nodo
{
    // Valor entero almacenado en el nodo.
    public int Valor;
    // Punteros a los nodos hijos izquierdo y derecho.
    public Nodo Izquierdo, Derecho;

    // Constructor de la clase Nodo. Inicializa un nuevo nodo con el valor dado.
    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null; // Inicialmente, los nodos hijos son nulos.
    }
}

// Definición de la clase ArbolBinarioBusqueda, que representa el árbol binario de búsqueda.
class ArbolBinarioBusqueda
{
    // Nodo raíz del árbol.
    private Nodo raiz;

    // Método para insertar un nuevo nodo en el árbol.
    public void Insertar(int valor)
    {
        raiz = InsertarRec(raiz, valor); // Llama al método recursivo para realizar la inserción.
    }

    // Método recursivo para insertar un nuevo nodo en el árbol.
    private Nodo InsertarRec(Nodo nodo, int valor)
    {
        // Si el nodo actual es nulo, crea un nuevo nodo con el valor dado y lo retorna.
        if (nodo == null)
            return new Nodo(valor);

        // Si el valor a insertar es menor que el valor del nodo actual,
        // inserta el nuevo nodo en el subárbol izquierdo.
        if (valor < nodo.Valor)
            nodo.Izquierdo = InsertarRec(nodo.Izquierdo, valor);
        // Si el valor a insertar es mayor que el valor del nodo actual,
        // inserta el nuevo nodo en el subárbol derecho.
        else if (valor > nodo.Valor)
            nodo.Derecho = InsertarRec(nodo.Derecho, valor);

        // Retorna el nodo actual.
        return nodo;
    }

    // Método para buscar un nodo con el valor dado en el árbol.
    public bool Buscar(int valor)
    {
        return BuscarRec(raiz, valor); // Llama al método recursivo para realizar la búsqueda.
    }

    // Método recursivo para buscar un nodo con el valor dado en el árbol.
    private bool BuscarRec(Nodo nodo, int valor)
    {
        // Si el nodo actual es nulo, el valor no se encuentra en el árbol.
        if (nodo == null)
            return false;
        // Si el valor del nodo actual es igual al valor buscado, el valor se encuentra en el árbol.
        if (nodo.Valor == valor)
            return true;
        // Si el valor buscado es menor que el valor del nodo actual,
        // busca en el subárbol izquierdo.
        if (valor < nodo.Valor)
            return BuscarRec(nodo.Izquierdo, valor);
        // Si el valor buscado es mayor que el valor del nodo actual,
        // busca en el subárbol derecho.
        return BuscarRec(nodo.Derecho, valor);
    }

    // Método para realizar un recorrido inorden del árbol.
    public void Inorden() { InordenRec(raiz); Console.WriteLine(); }
    // Método recursivo para realizar un recorrido inorden del árbol.
    private void InordenRec(Nodo nodo)
    {
        // Si el nodo actual no es nulo, realiza el recorrido inorden.
        if (nodo != null)
        {
            InordenRec(nodo.Izquierdo); // Recorre el subárbol izquierdo.
            Console.Write(nodo.Valor + " "); // Imprime el valor del nodo actual.
            InordenRec(nodo.Derecho); // Recorre el subárbol derecho.
        }
    }

    // Método para realizar un recorrido preorden del árbol.
    public void Preorden() { PreordenRec(raiz); Console.WriteLine(); }
    // Método recursivo para realizar un recorrido preorden del árbol.
    private void PreordenRec(Nodo nodo)
    {
        // Si el nodo actual no es nulo, realiza el recorrido preorden.
        if (nodo != null)
        {
            Console.Write(nodo.Valor + " "); // Imprime el valor del nodo actual.
            PreordenRec(nodo.Izquierdo); // Recorre el subárbol izquierdo.
            PreordenRec(nodo.Derecho); // Recorre el subárbol derecho.
        }
    }

    // Método para realizar un recorrido postorden del árbol.
    public void Postorden() { PostordenRec(raiz); Console.WriteLine(); }
    // Método recursivo para realizar un recorrido postorden del árbol.
    private void PostordenRec(Nodo nodo)
    {
        // Si el nodo actual no es nulo, realiza el recorrido postorden.
        if (nodo != null)
        {
            PostordenRec(nodo.Izquierdo); // Recorre el subárbol izquierdo.
            PostordenRec(nodo.Derecho); // Recorre el subárbol derecho.
            Console.Write(nodo.Valor + " "); // Imprime el valor del nodo actual.
        }
    }

    // Método para eliminar un nodo con el valor dado del árbol.
    public void Eliminar(int valor)
    {
        raiz = EliminarRec(raiz, valor); // Llama al método recursivo para realizar la eliminación.
    }

    // Método recursivo para eliminar un nodo con el valor dado del árbol.
    private Nodo EliminarRec(Nodo nodo, int valor)
    {
        // Si el nodo actual es nulo, retorna nulo.
        if (nodo == null)
            return nodo;

        // Si el valor a eliminar es menor que el valor del nodo actual,
        // elimina el nodo del subárbol izquierdo.
        if (valor < nodo.Valor)
            nodo.Izquierdo = EliminarRec(nodo.Izquierdo, valor);
        // Si el valor a eliminar es mayor que el valor del nodo actual,
        // elimina el nodo del subárbol derecho.
        else if (valor > nodo.Valor)
            nodo.Derecho = EliminarRec(nodo.Derecho, valor);
        // Si el valor a eliminar es igual al valor del nodo actual,
        // elimina el nodo actual.
        else
        {
            // Si el nodo actual no tiene hijo izquierdo, retorna el hijo derecho.
            if (nodo.Izquierdo == null)
                return nodo.Derecho;
            // Si el nodo actual no tiene hijo derecho, retorna el hijo izquierdo.
            else if (nodo.Derecho == null)
                return nodo.Izquierdo;

            // Si el nodo actual tiene ambos hijos, encuentra el valor mínimo en el subárbol derecho,
            // reemplaza el valor del nodo actual con el valor mínimo y elimina el nodo mínimo del subárbol derecho.
            nodo.Valor = MinValor(nodo.Derecho);
            nodo.Derecho = EliminarRec(nodo.Derecho, nodo.Valor);
        }
        // Retorna el nodo actual.
        return nodo;
    }

    // Método para encontrar el valor mínimo en un subárbol.
    private int MinValor(Nodo nodo)
    {
        int minValor = nodo.Valor;
        // Recorre el subárbol izquierdo hasta encontrar el nodo con el valor mínimo.
        while (nodo.Izquierdo != null)
        {
            minValor = nodo.Izquierdo.Valor;
            nodo = nodo.Izquierdo;
        }
        // Retorna el valor mínimo.
        return minValor;
    }
}

// Clase principal del programa.
class Program
{
    // Método principal del programa.
    static void Main()
    {
        // Crea una instancia de la clase ArbolBinarioBusqueda.
        ArbolBinarioBusqueda abb = new ArbolBinarioBusqueda();
        // Bucle principal del programa.
        while (true)
        {
            // Imprime el menú de opciones.
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Insertar nodo");
            Console.WriteLine("2. Buscar nodo");
            Console.WriteLine("3. Recorrido inorden");
            Console.WriteLine("4. Recorrido preorden");
            Console.WriteLine("5. Recorrido postorden");
            Console.WriteLine("6. Eliminar nodo");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");
            // Lee la opción seleccionada por el usuario.
            int opcion = int.Parse(Console.ReadLine());

            // Realiza la operación correspondiente según la opción seleccionada.
            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el valor a insertar: ");
                    int valor = int.Parse(Console.ReadLine());
                    abb.Insertar(valor);
                    break;
                case 2:
                    Console.Write("Ingrese el valor a buscar: ");
                    valor = int.Parse(Console.ReadLine());
                    Console.WriteLine(abb.Buscar(valor) ? "Valor encontrado." : "Valor no encontrado.");
                    break;
                case 3:
                    Console.WriteLine("Recorrido inorden:");
                    abb.Inorden();
                    break;
                case 4:
                    Console.WriteLine("Recorrido preorden:");
                    abb.Preorden();
                    break;
                case 5:
                    Console.WriteLine("Recorrido postorden:");
                    abb.Postorden();
                    break;
                case 6:
                    Console.Write("Ingrese el valor a eliminar: ");
                    valor = int.Parse(Console.ReadLine());
                    abb.Eliminar(valor);
                    break;
                case 7:
                    return; // Sale del programa.
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}
