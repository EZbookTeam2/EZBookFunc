﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace Testing9.Utils
{
    public class Common
    {
        public static byte[] GetRandomSalt(int length)
        {
            var random = new RNGCryptoServiceProvider();
            byte[] salt = new byte[length];
            random.GetNonZeroBytes(salt);
            return salt;

        }
        public static byte[] SaltHashPassword(byte[] password, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] plainTextWithSaltBytes = new byte[password.Length + salt.Length];
            for (int i = 0; i < password.Length; i++)
                plainTextWithSaltBytes[i] = password[i];
            for (int i = 0; i < salt.Length; i++)
                plainTextWithSaltBytes[password.Length + i] = salt[i];
            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }
    }
}