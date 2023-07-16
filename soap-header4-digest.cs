string _nonce = "nonce-value";
string _created = "2023-06-31T15:17:21Z";

System.Security.Cryptography.SHA1Managed shaPwd1 = new System.Security.Cryptography.SHA1Managed();
byte[] pwd = shaPwd1.ComputeHash(System.Text.Encoding.UTF8.GetBytes("your-password"));

byte[] nonceBytes = Convert.FromBase64String(_nonce);
byte[] createdBytes = System.Text.Encoding.UTF8.GetBytes(_created);
byte[] operand = new byte[nonceBytes.Length + createdBytes.Length + pwd.Length];

Array.Copy(nonceBytes, operand, nonceBytes.Length);
Array.Copy(createdBytes, 0, operand, nonceBytes.Length, createdBytes.Length);
Array.Copy(pwd, 0, operand, nonceBytes.Length + createdBytes.Length, pwd.Length);
System.Security.Cryptography.SHA1Managed sha1 = new System.Security.Cryptography.SHA1Managed();
string digest = Convert.ToBase64String(sha1.ComputeHash(operand));
