using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_Authenticator
{
    class LFSR //linear feedback shift register
    {
        List<int> indexes1 = new List<int>(0);
        BitArray LFSR1;//стандартный рандомный ключ аллгоритма длиной в степень полинома, для генерации спектра
        Random rnd;
        BitArray Spectrum;//Спектр, накладываемый на текст
        public LFSR()
        {
            indexes1.Add(28);
            indexes1.Add(3);
            rnd = new Random();
            LFSR1 = new BitArray(indexes1[0]);
        }
        public string GenerateKey()
        {
            for (int i = 0; i < indexes1[0]; i++)
            {
                int value = rnd.Next(0, 2);//1 or 0
                if (value == 0)
                {
                    LFSR1[i] = false;
                }
                else
                {
                    LFSR1[i] = true;
                }
            }
            return BitArrToStr(LFSR1);//вернуть двоичный ключ в текстовом варианте
        }

        public void EnterKey(string key)
        {
            for (int i = 0; i < indexes1[0]; i++)
            {
                if (key[i] == '0')
                {
                    LFSR1[i] = false;
                }
                else
                {
                    LFSR1[i] = true;
                }
            }
        }

        private void GenerateSpectrum(string text)
        {
            byte[] textInBytes = Portable.Text.Encoding.GetEncoding(1251).GetBytes(text);
            int textBitLength = textInBytes.Length * 8;
            Spectrum = new BitArray(textBitLength);
            BitArray LFSR2 = new BitArray(LFSR1);
            for (int i = 0; i < textBitLength; i++)
            {
                bool[] val = new bool[indexes1.Count];//Значения, стоящие под индексами из массива индексов (сепеней икса)
                for (int j = 0; j < val.Length; j++)
                {
                    val[j] = LFSR2[indexes1[j] - 1];

                }

                //многоместная операция сложения «ИСКЛЮЧАЮЩЕЕ-ИЛИ»
                bool sumVal = val[0];
                for (int j = 0; j < indexes1.Count - 1; j++)
                {
                    if (sumVal == val[j + 1])
                    {
                        Spectrum[i] = true;
                    }
                    else
                    {
                        Spectrum[i] = false;
                    }
                    sumVal = Spectrum[i];
                }

                //Сдвиг
                for (int J = 0; J < LFSR2.Length - 1; J++)
                {
                    LFSR2[J] = LFSR2[J + 1];
                }
                LFSR2[LFSR2.Length - 1] = Spectrum[i];
            }
        }

        public string Encrypt(string text)
        {
            GenerateSpectrum(text);
            byte[] textInBytes = Portable.Text.Encoding.GetEncoding(1251).GetBytes(text);
            int textBitLength = textInBytes.Length * 8;
            BitArray textInBits = new BitArray(textInBytes);
            BitArray codedTextInBits = new BitArray(textBitLength);
            for (int i = 0; i < textInBits.Length; i++)
            {
                if (textInBits[i] == Spectrum[i])//XOR
                {
                    codedTextInBits[i] = true;
                }
                else
                {
                    codedTextInBits[i] = false;
                }
            }

            byte[] codedTextInByts = BitArrayToByteArray(codedTextInBits);
            string codedTextInStr = Portable.Text.Encoding.GetEncoding(1251).GetString(codedTextInByts, 0, codedTextInByts.Length);

            string decodedTextInStr = Portable.Text.Encoding.GetEncoding(1251).GetString(textInBytes);
            byte[] codedTextInByts1231 = Portable.Text.Encoding.GetEncoding(1251).GetBytes(BitArrToStr(codedTextInBits));
            byte[] textInBytes1 = BitArrayToByteArray(textInBits);

            return codedTextInStr;
        }
        public string Decrypt(string text)
        {
            GenerateSpectrum(text);
            byte[] codedTextInByts = Portable.Text.Encoding.GetEncoding(1251).GetBytes(text);
            BitArray newCodedTextInBits = new BitArray(codedTextInByts);
            BitArray decodedTextInBits = new BitArray(codedTextInByts);

            for (int i = 0; i < newCodedTextInBits.Length; i++)
            {
                if (newCodedTextInBits[i] == Spectrum[i])//XOR
                {
                    decodedTextInBits[i] = true;
                }
                else
                {
                    decodedTextInBits[i] = false;
                }
            }
            byte[] decodedTextInByts = BitArrayToByteArray(decodedTextInBits);
            string decodedTextInStr = Portable.Text.Encoding.GetEncoding(1251).GetString(decodedTextInByts, 0, decodedTextInByts.Length);
            return decodedTextInStr;
        }

        public string BitArrToStr(BitArray bitArr)
        {
            string data = "";
            for (int i = 0; i < bitArr.Length; i++)
            {
                if (bitArr[i])
                {
                    data += "1";
                }
                else
                {
                    data += "0";
                }
            }
            return data;
        }

        public static byte[] BitArrayToByteArray(BitArray bits)
        {
            byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(ret, 0);
            return ret;
        }
    }
}
