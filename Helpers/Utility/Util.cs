namespace Helpers.Utility;

public static class Util
{
    private const Ambiente ambiente = Ambiente.NotFelipe;

    public static string ConectionString = StringsConnection(ambiente);

    public const string SecurityKey = "CLIENTLIST_2024_11_22_MUUNIZ_BARRETO_FELIPE_DEV_2022_HASKEY_14587444%";

    public const string KeyCryptography = "CLIENTLIST1495874201LIST98546320";

    public const string IvCryptography = "CLIENTLIST587412";

    private static string StringsConnection(Ambiente ambientes)
    {
        switch (ambientes)
        {
            case Ambiente.PCFelipe:
                return "Data Source=DESKTOP-HER7P6R;Initial Catalog=ClientList;Integrated Security=True;Pooling=False;Encrypt=False;TrustServerCertificate=False;";
            case Ambiente.NotFelipe:
                return "Data Source=DESKTOP-HH8094V;Initial Catalog=ClientList;Integrated Security=True;Pooling=False;Encrypt=False;TrustServerCertificate=False;";
            case Ambiente.Producao:
                return string.Empty;
            default: return string.Empty;

        }
    }

    public enum Ambiente
    {
        PCFelipe,
        NotFelipe,
        Producao
    }
}
