namespace WSTube.Models.Request
{
    public class ClienteRequest
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Usuario { get; set; }

    }
}
