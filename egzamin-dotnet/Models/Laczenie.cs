using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

public class Laczenie{
    private readonly string? _connectonString;

    public Laczenie(IConfiguration configurator){
        _connectonString = configurator.GetConnectionString("MysqlConnection");
    }
    public List<Zdejcia> Skrypt1(){

        List<Zdejcia> zdjecia = new List<Zdejcia>();
        using var connection = new MySqlConnection(_connectonString);
        connection.Open();
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM zdjecia;";
        using var reader = command.ExecuteReader();
        while(reader.Read())
        {
            zdjecia.Add(
                new Zdejcia
                {
                    ID = reader.GetInt32("id"),
                    nazwaPliku = reader.GetString("nazwaPliku"),
                    podpis = reader.GetString("podpis")
                }
            );
        }
        connection.Close();
        return zdjecia;
    }
    public List<Wycieczki> Skrypt2(string sql){
        List<Wycieczki> wycieczka = new List<Wycieczki>();
        using var connection = new MySqlConnection(_connectonString);
        connection.Open();
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = sql;
        using var reader = command.ExecuteReader();
        while(reader.Read())
        {
            wycieczka.Add(
                new Wycieczki
                {
                    data = reader.GetDateTime("dataWyjazdu"),
                    cel = reader.GetString("cel")
                }
            );
        }
        connection.Close();
        return wycieczka;
    }
}