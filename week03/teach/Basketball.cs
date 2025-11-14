/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        // Creates a TextFieldParser object to read the "basketball.csv" file and assigns it to the reader variable. The using statement ensures the reader is properly disposed when done.
        using var reader = new TextFieldParser("basketball.csv");

        //  Configures the parser to treat the file as delimited text (like CSV) rather than fixed-width fields.
        reader.TextFieldType = FieldType.Delimited;

        //  Sets the comma character as the delimiter that separates fields in the CSV file.
        reader.SetDelimiters(",");

        // Reads the first row of the CSV file (the header row containing column names) but doesn't store it - this moves the reader to the next line so data processing starts from the second row.
        reader.ReadFields(); // ignore header row
        
        // Starts a loop that continues as long as there is more data to read in the file. The loop will run once for each data row.
        while (!reader.EndOfData) {
            // Reads the current row from the CSV file, splits it into an array of string values using the comma delimiter, and stores it in the fields variable. The ! tells the compiler the result won't be null.
            var fields = reader.ReadFields()!;
            // Extracts the first field (index 0) from the current row and stores it as the player ID.
            var playerId = fields[0];
            //  Extracts the ninth field (index 8) from the current row, converts it from a string to an integer, and stores it as the points value.
            var points = int.Parse(fields[8]);

            if (players.ContainsKey(playerId))
            {
                players[playerId] += points;

            }
            else
            {
                players.Add(playerId, points);                
            }       
            
        }

        // Console.WriteLine($"Players: {{{string.Join(", ", players)}}}");

        var topPlayers = players.ToArray();

        Array.Sort(topPlayers, (p1, p2) => p2.Value - p1.Value);

        Console.WriteLine();
        for (var i = 0; i < 10; i++)
        {
            Console.WriteLine(topPlayers[i]);
        }

        


    }
}