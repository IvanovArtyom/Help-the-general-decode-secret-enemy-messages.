using System.Text;
using System.Collections.Generic;

public static class Program
{
    public static void Main()
    {
        // Test
        var t = Decoder.Decode("atC5kcOuKAr!");
        // ...should return "Hello World!"
    }
}

public static class Decoder
{
    public static Dictionary<char, char> decryptionTable = new()
    {
        { 'a', 'H' }, { 'b', 'a' }, { 'c', 'I' }, { 'd', 'b' }, { 'e', 'J' }, { 'f', 'c' },
        { 'g', 'K' }, { 'h', 'd' }, { 'i', 'L' }, { 'j', 'e' }, { 'k', 'M' }, { 'l', 'f' },
        { 'm', 'N' }, { 'n', 'g' }, { 'o', 'O' }, { 'p', 'h' }, { 'q', 'P' }, { 'r', 'i' },
        { 's', 'Q' }, { 't', 'j' }, { 'u', 'R' }, { 'v', 'k' }, { 'w', 'S' }, { 'x', 'l' },
        { 'y', 'T' }, { 'z', 'm' }, { 'A', 'U' }, { 'B', 'n' }, { 'C', 'V' }, { 'D', 'o' },
        { 'E', 'W' }, { 'F', 'p' }, { 'G', 'X' }, { 'H', 'q' }, { 'I', 'Y' }, { 'J', 'r' },
        { 'K', 'Z' }, { 'L', 's' }, { 'M', '0' }, { 'N', 't' }, { 'O', '1' }, { 'P', 'u' },
        { 'Q', '2' }, { 'R', 'v' }, { 'S', '3' }, { 'T', 'w' }, { 'U', '4' }, { 'V', 'x' },
        { 'W', '5' }, { 'X', 'y' }, { 'Y', '6' }, { 'Z', 'z' }, { '0', '7' }, { '1', 'A' },
        { '2', '8' }, { '3', 'B' }, { '4', '9' }, { '5', 'C' }, { '6', '.' }, { '7', 'D' },
        { '8', ',' }, { '9', 'E' }, { ' ', 'G' }, { '.', '?' }, { ',', 'F' }, { '?', ' ' }
    };

    static readonly int cnt = decryptionTable.Count;

    public static string Decode(string p_what)
    {
        StringBuilder message = new(p_what.Length);

        for (int i = 0; i < p_what.Length; i++)
        {
            if (!decryptionTable.ContainsKey(p_what[i]))
            {
                message.Append(p_what[i]);
                continue;
            }

            char c = p_what[i];

            for (int j = 0; j <= i % cnt; j++)
                c = decryptionTable[c];

            message.Append(c);
        }

        return message.ToString();
    }
}