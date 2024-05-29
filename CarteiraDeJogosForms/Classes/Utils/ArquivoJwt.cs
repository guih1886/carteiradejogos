namespace CarteiraDeJogosForms.Classes.Utils;

public static class ArquivoJwt
{
    public static void GravarJwt(string jwt)
    {
        File.WriteAllText("C:\\Windows\\Temp\\jwt.txt", jwt);
    }
    public static void DeletarJwt()
    {
        if (File.Exists("C:\\Windows\\Temp\\jwt.txt"))
        {
            File.Delete("C:\\Windows\\Temp\\jwt.txt");
        }
    }
}
