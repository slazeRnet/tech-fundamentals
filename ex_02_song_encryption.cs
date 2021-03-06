```cs
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace ex_02_song_encryption
{
    class Program
    {
        static void Main()
        {
            Regex songPattern = new Regex(@"^([A-Z][a-z ,']+):([A-Z ]+)$");
            List<string> cryptedSongs = new List<string>();
            string input = "";
            while((input = Console.ReadLine()) != "end")
            {
                bool isOperationSuccesfull = true;
                char newLetter = ' ';
                string artist = "";
                string song = "";
                string cryptedArtist = "";
                string cryptedSong = "";
                Match match1 = songPattern.Match(input);
                if (match1.Success)
                {
                    artist = match1.Groups[1].Value;
                    song = match1.Groups[2].Value;
                    //  start crypting artist
                    int artistLength = artist.Length;
                    DoArtist(artist, artistLength, ref newLetter,
            ref isOperationSuccesfull, ref cryptedArtist, ref cryptedSong);
                    DoSong(song, artistLength, ref newLetter,
            ref isOperationSuccesfull, ref cryptedArtist, ref cryptedSong);
                        cryptedSongs.Add("Successful encryption: " + cryptedArtist + "@" + cryptedSong);

                }
                else
                {                   
                        cryptedSongs.Add("Invalid input!");                   
                }
            }
            // PRINT OUTPUT
            foreach (var item in cryptedSongs)
            {
                Console.WriteLine(item);
            }
        }

        static void DoSong(string song, int artistLength,ref char newLetter,
            ref bool isOperationSuccesfull, ref string cryptedArtist, ref string cryptedSong)
        {
            string type = "song";
            foreach (var letter in song)
            {
                if (Char.IsUpper(letter))
                {
                    int charNumbericalValue = Convert.ToInt32(letter);
                    if (charNumbericalValue + artistLength <= 90 && charNumbericalValue + artistLength >= 65)
                    {
                        newLetter = Convert.ToChar(charNumbericalValue + artistLength);
                        cryptedSong += newLetter;
                    }
                    else
                    {
                        UpperLetterOutOfRange(charNumbericalValue, ref newLetter,
            artistLength, ref cryptedArtist, ref cryptedSong, type);
                    }
                }
                else if(letter == ' ')
                {
                    newLetter = ' ';
                    cryptedSong += newLetter;
                }
                else
                {
                    isOperationSuccesfull = false;
                    break;
                }
            }
        }

        static void DoArtist(string artist, int artistLength,ref char newLetter,
            ref bool isOperationSuccesfull, ref string cryptedArtist, ref string cryptedSong)
        {
            string type = "artist";
            foreach (var letter in artist)
            {
                if (Char.IsUpper(letter))
                {
                    int charNumbericalValue = Convert.ToInt32(letter);
                    if (charNumbericalValue + artistLength <= 90 && charNumbericalValue + artistLength >= 65)
                    {
                        newLetter = Convert.ToChar(charNumbericalValue + artistLength);
                        cryptedArtist += newLetter;
                    }
                    else
                    {
                        UpperLetterOutOfRange(charNumbericalValue, ref newLetter,
            artistLength, ref cryptedArtist, ref cryptedSong, type);
                    }
                }
               else if (Char.IsLower(letter))
                {
                    int charNumbericalValue = Convert.ToInt32(letter);
                    if (charNumbericalValue + artistLength >= 97 && charNumbericalValue + artistLength <= 122)
                    {
                        newLetter = Convert.ToChar(charNumbericalValue + artistLength);
                        cryptedArtist += newLetter;
                    }
                    else
                    {
                        LowerLetterOutOfRange(charNumbericalValue,ref newLetter, artistLength,
                            ref cryptedArtist, ref cryptedSong, type);
                    }
                }
                else if(letter == ' ' || letter == '\'')
                {
                    newLetter = letter;
                    cryptedArtist += newLetter;
                }
                else
                {
                    isOperationSuccesfull = false;
                    break;
                }
            }
        }


        // FOR ARTIST
        static void UpperLetterOutOfRange(int charNumbericalValue,ref  char newLetter,
            int artistLength, ref string cryptedArtist, ref string cryptedSong, string type)
        {
            while(charNumbericalValue + artistLength > 90 )
            {
                charNumbericalValue += artistLength;
                charNumbericalValue -= 26;
            }
            newLetter = Convert.ToChar(charNumbericalValue);
            if (type == "artist")
            {
                cryptedArtist += newLetter;
            }
            else if (type == "song")
            {
                cryptedSong += newLetter;
            }
        }

        static void LowerLetterOutOfRange(int charNumbericalValue, ref char newLetter,
            int artistLength, ref string cryptedArtist, ref string cryptedSong, string type)
        {
            while (charNumbericalValue + artistLength > 122)
            {
                charNumbericalValue += artistLength;
                charNumbericalValue -= 26;
            }
            newLetter = Convert.ToChar(charNumbericalValue);
            cryptedArtist += newLetter;
        }
    }
}
```
