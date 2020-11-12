using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CreateKeys
{
	class Program
	{
        private static byte[] C_Key;
        private static byte[] C_IV;

        static void Main(string[] args)
		{
            createKeys();
            createFirstUser();
        }

        public static void createFirstUser()
        {
            employee employee = new employee();
            employee.employeeId = 1;
            employee.employeeName = "admin";
            employee.phone = "0";
            employee.email = "N/A";
            employee.gender = "U";
            employee.registerDate = DateTime.Now;
            employee.isActive = true;

            user user = new user();
            user.userId = 1;
            user.employeeId = 1;
            user.userName = Encriptar("admin", C_Key, C_IV);
            user.userPassword = Encriptar("root", C_Key, C_IV);

            users_X_rols users_X_Rols = new users_X_rols();
            users_X_Rols.rolId = 1;
            users_X_Rols.userId = 1;

            using (DB_CRMEntities db = new DB_CRMEntities())
            {
                db.employees.Add(employee);
                db.users.Add(user);
                db.users_X_rols.Add(users_X_Rols);

                try
                {
                    db.SaveChanges();
                }
                catch(Exception ex)
				{

				}
            }
        }

        public static void createKeys()
		{
            using (Aes myAes = Aes.Create())
            {

                using (DB_CRMEntities db = new DB_CRMEntities())
                {
                    key keys = new key();
                    keys.id = 1;
                    keys.C_Key = myAes.Key;
                    keys.C_IV = myAes.IV;

                    C_Key = myAes.Key;
                    C_IV = myAes.IV;
                    try
                    {
                        db.keys.Add(keys);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
        }

        public static byte[] Encriptar(String original, byte[] Key, byte[] IV)
        {
            try
            {
                byte[] encrypted = EncryptStringToBytes_Aes(original,
                                                            Key,
                                                            IV);
                return encrypted;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            byte[] encrypted;

            // Create an Aes object with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key,
                                                                    aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt,
                                                                     encryptor,
                                                                     CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }

                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }
    }
}
