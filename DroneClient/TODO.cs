/*
ENCRYPTION:

EncryptionTest('stuff', Encoding.UTF8.GetBytes('hypn0sh1t'));

void EncryptionTest(string text, byte[] key){
 byte[] plain = Encoding.UTF8.GetBytes(text);
 BaseCrypto enc = new SimpleEncryptor(key), dec = new SimpleDecryptor(key);
 byte[] cipher = enc.TransformFinalBlock(plain, 0, plain.Length);
 byte[] plain2 = dec.TransformFinalBlock(cipher, 0, cipher.Length);
 // plain and plain2 should now be byte-for-byte equal
}
*/
