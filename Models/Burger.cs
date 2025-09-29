namespace FoodAPI2.Models;

public enum Tamano { Pequena, Mediana, Grande, Extra }

public class Burger
{
    public int Id { get; set; }
    public string Nombre { get; set; } = default!;
    public string Ingredientes { get; set; } = default!;
    public decimal Precio { get; set; }
    public Tamano Tamano { get; set; }
}