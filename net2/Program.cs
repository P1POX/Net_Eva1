/* DOCUMENTACION
 * Requerimientos
    CRUD: producto
 */

// Referencias

// Definiciones de variables y configuraciones
using net2.DB;
using net2.Model;
using net2.PModel;

MenuUsuario menu;
MenuUsuario menuModificar;
Inventario data;
int idProducto;

InitComponent();
main();

// Ejecucion
void main()
{
    string opcion;
    bool run = true;

    do
    {
        Console.WriteLine(menu);
        Console.Write("Ingrese una opcion: ");
        opcion = Console.ReadLine();
        int opcionInt = int.Parse(opcion);

        Console.Clear();

        switch (opcionInt)
        {
            case 0:
                // Salir
                Console.WriteLine("Saliendo ....");
                run = false;
                break;
            case 1:
                // Agregar
                Producto producto = new Producto();
                Console.Write("Ingrese el nombre del producto: ");
                producto.Name = Console.ReadLine();

                Console.Write("Ingrese la descripción: ");
                producto.Description = Console.ReadLine();

                Console.Write("Ingrese el precio: ");
                producto.Price = int.Parse(Console.ReadLine());

                Console.Write("Ingrese la cantidad: ");
                int amount = int.Parse(Console.ReadLine());

                if (data.Data.Count != 0)
                {
                    producto.Id = data.Data.ElementAt(data.Data.Count - 1).Producto.Id + 1;
                }
                data.Data.Add(new Item(producto, amount));
                Console.Clear();
                Console.WriteLine("Producto agregado exitosamente!\n");
                break;
            case 2:
                // Ejercicio 4 - Listar Productos
                Console.WriteLine(data);
                break;
            case 3:
                // Ejercicio 1 - Modificar Producto
                Console.WriteLine(menuModificar);
                Console.Write("Ingrese una opcion: ");
                int op;
                try
                {
                    op = int.Parse(Console.ReadLine());
                } catch {
                    op = -1;
                }
                switch (op)
                {
                    case 1:
                        // Buscar Producto
                        Console.Write("Ingrese el nombre del producto: ");
                        string name = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine(data.SearchProducts(name));
                        if (data.ExistProductName(name))
                        {
                            ModifyProductById();
                        }
                        break;
                    case 2:
                        ModifyProductById();
                        break;
                    case 0:
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("La opcion ingresada no es valida!\n");
                        break;
                }
                break;
            case 4:
                // Ejercicio 2 - Eliminar
                Console.Write("Ingrese la ID del producto que desea eliminar: ");
                if (InputIdProduct())
                {
                    Item item = data.getItemWithId(idProducto);
                    Console.Write($"Se eliminará el siguiente producto\n| ID | Nombre | Precio | Stock disponible\n{item}\n¿Deseas eliminar este producto? (yes) ");
                    string confirmacion = Console.ReadLine();
                    if (confirmacion == "yes")
                    {
                        data.DeleteProduct(idProducto);
                        Console.Clear();
                        Console.WriteLine("Producto eliminado exitosamente!\n");
                    }
                }
                break;
            case 5:
                // Ejercicio 3 - Buscar Producto por Id
                Console.Write("Ingrese la ID del producto que desea visualizar: ");
                if (InputIdProduct())
                {
                    Item item = data.getItemWithId(idProducto);
                    Console.WriteLine($"| ID | Nombre | Descripcion | Precio | Stock disponible\n| {item.Producto} | {item.cantidad}\n");
                }
                break;

            default:
                Console.WriteLine("La opcion ingresada no es valida!");
                break;
        }


    }
    while (run);
}

void InitComponent()
{
    menu = new MenuUsuario();
    menu.Cabecera = "Menu de Productos";
    menu.Opciones.Add(new Opcion(1, "Agregar"));
    menu.Opciones.Add(new Opcion(2, "Listar"));
    menu.Opciones.Add(new Opcion(3, "Modificar"));
    menu.Opciones.Add(new Opcion(4, "Eliminar"));
    menu.Opciones.Add(new Opcion(5, "Buscar"));
    menu.Opciones.Add(new Opcion(0, "Salir"));

    menuModificar = new MenuUsuario();
    menuModificar.Cabecera = "Modificar productos";
    menuModificar.Opciones.Add(new Opcion(1, "Buscar productos por nombre"));
    menuModificar.Opciones.Add(new Opcion(2, "Ingresar Id de producto"));
    menuModificar.Opciones.Add(new Opcion(0, "Salir"));


    data = new Inventario();

}

bool InputIdProduct()
{
    try
    {
        idProducto = int.Parse(Console.ReadLine());
    }
    catch
    {
        idProducto = -1;
    }
    if (data.ExistProductId(idProducto))
    {
        return true;
    } else
    {
        Console.Clear();
        Console.WriteLine("No se encontró un producto con esa ID!\n");
        return false;
    }
}

void ModifyProductById()
{
    Console.Write("Ingrese la ID del producto que desea modificar: ");
    if (InputIdProduct())
    {
        Item item = data.getItemWithId(idProducto);
        Console.Write($"Ingrese el precio: ({item.Producto.Price}) ");
        int precio;
        int cantidad;
        try
        {
            precio = int.Parse(Console.ReadLine());
        }
        catch
        {
            precio = item.Producto.Price;
        }
        Console.Write($"Ingrese el stock: ({item.cantidad}) ");
        try
        {
            cantidad = int.Parse(Console.ReadLine());
        }
        catch
        {
            cantidad = item.cantidad;
        }
        Console.WriteLine($"Se modificará el producto '{item.Producto.Name}' con precio '{precio}' y stock '{cantidad}'");
        Console.Write("¿Deseas confirmar los cambios? (yes) ");
        string confirmacion = Console.ReadLine();
        if (confirmacion == "yes")
        {
            item.Producto.Price = precio;
            item.cantidad = cantidad;

            Console.Clear();
            Console.WriteLine("Producto modicado exitosamente!\n");
        } else
        {
            Console.Clear();
            Console.WriteLine("El producto no fue modificado!\n");
        }
    }
}