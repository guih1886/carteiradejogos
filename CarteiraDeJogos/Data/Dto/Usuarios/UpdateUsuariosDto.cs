﻿namespace CarteiraDeJogos.Data.Dto.Usuarios;

public class UpdateUsuariosDto
{
    public string Nome { get; set; }

    public List<int> Jogos { get; set; }

    public List<int> JogosFavoritos { get; set; }
}
