namespace tuto.Models;

public class Reclamation
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int Name { get; set; }
    public string ReclamationType { get; set; }
    public bool ClientStatut { get; set; }
    public string Description { get; set; }
}