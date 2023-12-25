using System;
using otdelkadrov.Models;

namespace otdelkadrov
{
    class GettingData
    {
    

        public GettingData(Employee employee) => GetNewEmployeer(employee);

        private void GetNewEmployeer(Employee employee)
        {

        }

        

        private byte[] StringToByteArray(string str)
        {
            int numberChars = str.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(str.Substring(i, 2), 16);
            return bytes;
        }
    }
}
