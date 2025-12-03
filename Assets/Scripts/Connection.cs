using MySql.Data.MySqlClient;
using UnityEngine;

public class Connection : MonoBehaviour
{
    void Start()
    {
        string connStr = "Server=172.16.39.38;Database=connect;User ID=admin;Password=P@ssw0rd;";

        try
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                Debug.Log("Conectado ao MySQL!");

                string query = "SELECT * FROM client;";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Acessa os campos por índice ou nome
                        string id = reader["id"].ToString();
                        string name = reader["name"].ToString();
                        string enterprise = reader["enterprise"].ToString();
                        string role = reader["role"].ToString();

                        Debug.Log($"ID: {id}, Nome: {name}, Email: {enterprise}, Role: {role}");
                    }
                }
            }
        }
        catch (MySqlException ex)
        {
            Debug.LogError("Erro MySQL: " + ex.Message);
        }
    }
}