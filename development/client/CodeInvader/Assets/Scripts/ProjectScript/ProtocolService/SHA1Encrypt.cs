using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using UnityEngine;

public class SHA1Encrypt
{
    private static volatile SHA1Encrypt _instance;
    private static object _lock = new object();

    public static SHA1Encrypt Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new SHA1Encrypt();
                }
            }
            return _instance;
        }
    }

    private SHA1Encrypt()
    {
    }

    public string encrypt(string source)
    {
        var sourceBytes = Encoding.Default.GetBytes(source);
        HashAlgorithm ShaAlgorithm = new SHA1CryptoServiceProvider();
        sourceBytes = ShaAlgorithm.ComputeHash(sourceBytes);
        //return Convert.ToBase64String(sourceBytes);
        string encryptResult = "";
        foreach (byte _byte in sourceBytes)
        {
            encryptResult += $"{_byte:x2}";
        }
        return encryptResult;
    }
}
