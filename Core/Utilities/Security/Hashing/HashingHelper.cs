﻿using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        // Hash'in yaradilmasi
        public static void CreatePasswordHash
            (string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hcmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hcmac.Key;
                passwordHash = hcmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash
            (string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hcmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hcmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
