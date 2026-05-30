using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // TODO Problem 1
                // Crear el nuevo nodo con el valor recibido
        Node newNode = new(value);
        // Si la lista está vacía, head y tail apuntan al nuevo nodo
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // Si ya hay elementos, solo se afecta el tail
        else
        {
            newNode.Prev = _tail; // El nuevo nodo apunta hacia atrás al tail actual
            _tail.Next = newNode; // El tail actual apunta hacia adelante al nuevo nodo
            _tail = newNode;      // Actualizamos tail para que sea el nuevo nodo
        }
    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // TODO Problem 2
        // Si la lista tiene un solo nodo (o está vacía), dejamos todo en null
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // Si hay más de un nodo, solo se afecta el tail
        else if (_tail is not null)
        {
            _tail.Prev!.Next = null; // El penúltimo nodo deja de apuntar al último
            _tail = _tail.Prev;      // Actualizamos tail para que sea el penúltimo
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        // TODO Problem 3
         // Empezamos la búsqueda desde el head
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // Si el nodo a eliminar es el head, reutilizamos RemoveHead
                if (curr == _head)
                {
                    RemoveHead();
                }
                // Si es el tail, reutilizamos RemoveTail
                else if (curr == _tail)
                {
                    RemoveTail();
                }
                // Si está en el medio, reconectamos los vecinos entre sí
                else
                {
                    curr.Prev!.Next = curr.Next; // El nodo anterior apunta al siguiente
                    curr.Next!.Prev = curr.Prev; // El nodo siguiente apunta al anterior
                }
                return; // Encontramos y eliminamos el primero, salimos
            }
            curr = curr.Next; // Avanzamos al siguiente nodo
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        // TODO Problem 4
        // Empezamos desde el head y recorremos TODA la lista (no hacemos return al encontrar)
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == oldValue)
            {
                curr.Data = newValue; // Reemplazamos el valor directamente en el nodo
            }
            curr = curr.Next; // Seguimos avanzando para reemplazar todas las ocurrencias
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        // TODO Problem 5
        // yield return 0; // replace this line with the correct yield return statement(s)
                // Empezamos desde el tail en lugar del head
        var curr = _tail;
        while (curr is not null)
        {
            yield return curr.Data; // Entregamos el valor actual al foreach
            curr = curr.Prev;       // Avanzamos hacia atrás usando Prev en lugar de Next
        }
   
   
    }


    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}