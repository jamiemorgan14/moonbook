namespace moonbook.Models
{
  class Moon : IDestination
  {
    public string Name { get; set; }
    public string Description { get; set; }

    Planet Planet { get; set; }

    public Planet Return()
    {
      return Planet;
    }

    public Moon(string name, string desc, Planet planet)
    {
      Name = name;
      Description = desc;
      Planet = planet;
    }
  }
}