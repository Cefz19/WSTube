using System;
using System.Collections.Generic;

namespace WSTube.Models;

public partial class RegistroUsuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Usuario { get; set; } = null!;
}
