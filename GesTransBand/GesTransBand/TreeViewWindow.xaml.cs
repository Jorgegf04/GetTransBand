using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace GesTransBand
{
    public partial class TreeViewWindow : Window
    {
        public TreeViewWindow()
        {
            InitializeComponent();
            LoadTreeView();
        }

        private void LoadTreeView()
        {
            string connectionString = "Server=PCJorge\\PCJORGE4;Database=MiBaseDeDatos;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Load Zones
                    var zones = new List<TreeNode>();
                    string zoneQuery = "SELECT IdZone, DesZone FROM Zone";
                    SqlCommand zoneCommand = new SqlCommand(zoneQuery, connection);
                    SqlDataReader zoneReader = zoneCommand.ExecuteReader();
                    while (zoneReader.Read())
                    {
                        var zoneNode = new TreeNode
                        {
                            Name = zoneReader["DesZone"].ToString(),
                            Children = new List<TreeNode>()
                        };

                        // Load Production Lines for each Zone
                        string lineQuery = $"SELECT pl.IdLine, pl.DesLine FROM ProductionLine pl " +
                                           $"JOIN BeltAssignment ba ON pl.IdLine = ba.IdLine " +
                                           $"WHERE ba.IdZone = {zoneReader["IdZone"]}";
                        SqlCommand lineCommand = new SqlCommand(lineQuery, connection);
                        SqlDataReader lineReader = lineCommand.ExecuteReader();
                        while (lineReader.Read())
                        {
                            var lineNode = new TreeNode
                            {
                                Name = lineReader["DesLine"].ToString(),
                                Children = new List<TreeNode>()
                            };

                            // Load Actives for each Line
                            string activeQuery = $"SELECT IdActive, DesActive FROM Active WHERE IdLine = {lineReader["IdLine"]}";
                            SqlCommand activeCommand = new SqlCommand(activeQuery, connection);
                            SqlDataReader activeReader = activeCommand.ExecuteReader();
                            while (activeReader.Read())
                            {
                                var activeNode = new TreeNode
                                {
                                    Name = activeReader["DesActive"].ToString()
                                };
                                lineNode.Children.Add(activeNode);
                            }
                            activeReader.Close();
                            zoneNode.Children.Add(lineNode);
                        }
                        lineReader.Close();
                        zones.Add(zoneNode);
                    }
                    zoneReader.Close();

                    treeViewRelations.ItemsSource = zones;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }

    public class TreeNode
    {
        public string Name { get; set; }
        public List<TreeNode> Children { get; set; }
    }
}

