using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Cryptography
/// </summary>
public static class SubstitutionCipher
{
    static string key = string.Empty;

    public static string Encrypt(string plainText)
    {
        key = System.Configuration.ConfigurationManager.AppSettings["Substitute"].ToString();
        char[] chars = new char[plainText.Length];
        for (int i = 0; i < plainText.Length; i++)
        {
            if (plainText[i] == ' ')
            {
                chars[i] = ' ';
            }
            else
            {
                int j = plainText[i] - 97;
                chars[i] = key[j];
            }
        }
        return new string(chars);
    }

    public static string Decrypt(string cipherText)
    {
        key = System.Configuration.ConfigurationManager.AppSettings["Substitute"].ToString();
        char[] chars = new char[cipherText.Length];
        for (int i = 0; i < cipherText.Length; i++)
        {
            if (cipherText[i] == ' ')
            {
                chars[i] = ' ';
            }
            else
            {
                int j = key.IndexOf(cipherText[i]) - 97;
                chars[i] = (char)j;
            }
        }
        return new string(chars);
    }

}