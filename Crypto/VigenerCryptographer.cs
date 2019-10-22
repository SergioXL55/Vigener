using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    class VigenerCryptographer : Cryptographer
    {
        private readonly char[] alphabet = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И','Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                             'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ','Э', 'Ю', 'Я',
                                             'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и','й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с',
                                             'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ы', 'ъ','э', 'ю', 'я',
                                               ' ','1', '2', '3', '4', '5', '6', '7','8', '9', '0' };

        private String key;

        public string decode(string text)
        {
            return GetEncryptionResult(CryptoAction.DECODE, text);
        }

        public string encode(string text)
        {
            return GetEncryptionResult(CryptoAction.ENCODE, text);
        }

        public void setKey(string key)
        {
            this.key = key;
        }

        private int GetKeywordIndex(int currentIndex, int keyLenght)
        {
            currentIndex++;
            if ((currentIndex) == keyLenght)
            {
                currentIndex = 0;
            }

            return currentIndex;
        }

        private String GetEncryptionResult(CryptoAction action, String incomingText)
        {
            String result = "";
            int power = alphabet.Length;
            int keyword_index = 0;

            foreach (char symbol in incomingText)
            {
                int c = Array.IndexOf(alphabet, symbol);
                int k = Array.IndexOf(alphabet, key[keyword_index]);
                int p = 0;
                switch (action)
                {
                    case (CryptoAction.DECODE): { p = (c + power - k) % power; break; };
                    case (CryptoAction.ENCODE): { p = (c + k) % power; break; };
                }
                result += alphabet[p];
                keyword_index = GetKeywordIndex(keyword_index, key.Length);
            }
            return result;
        }

        bool IFieldValidator.ValidateInputData(string inputText, string key)
        {
            bool result = true;
            if (inputText.Length > 0 && key.Length > 0)
            {
                foreach (char symbol in inputText)
                {
                    int c = Array.IndexOf(alphabet, symbol);
                    if (c < 0) return false;
                }

                foreach (char symbol in key)
                {
                    int c = Array.IndexOf(alphabet, symbol);
                    if (c < 0) return false;
                }
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
