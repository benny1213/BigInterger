using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigInterger
{
    class BigInteger
    {
        private int[] number = new int[100];
        int length;
        bool ifnegative = false;//biginteger的负号标识初始值皆为false
        public BigInteger(string input)//输入大数字
        {
            length = input.Length;
            if (input.Length != 0)//输入值不为0才能进行记录符号操作
            {
                if (input[0] == '-') //记录负值并减去负号位
                {
                    this.ifnegative = true;
                    this.length--;
                }
                if (input[0] != '-')
                {
                    for (int i = 0; i < this.length; i++)
                    {
                        this.number[i] = Convert.ToInt32(input[this.length - 1 - i].ToString());
                    }
                }
                else
                {
                    for (int i = 0; i < this.length; i++)
                    {
                        this.number[i] = Convert.ToInt32(input[this.length - i].ToString());
                    }
                }
            }
        }
        public void show()//反向输出数字
        {
            if (this.ifnegative == true) Console.Write("-");//负数则先输出一个负号
            for (int i = length - 1; i >= 0; i--)
            {
                Console.Write(number[i]);
            }
            Console.WriteLine();
        }
        public static BigInteger operator +(BigInteger b1, BigInteger b2)//加法
        {
            if (b1.ifnegative == b2.ifnegative)//如果两个数字符号相同，则可进行加法运算，否则转到减法运算
            {
                BigInteger output = new BigInteger("");
                output.length = b1.length > b2.length ? b1.length : b2.length;//取两个数字长度间的较大值
                for (int i = 0; i < output.length; i++)
                {
                    if (b1.number[i] + b2.number[i] > 10) output.number[i + 1]++;
                    output.number[i] += (b1.number[i] + b2.number[i]) % 10;
                }
                if (b1.number[b1.length - 1] + b2.number[b2.length - 1] > 10) output.length++;//最高位数字相加大于10则长度加一
                if (b1.ifnegative == true) output.ifnegative = true;//如果两个负数相加则结果还是负数
                return output;
            }
            else
            {
                if (b1.ifnegative)//当b1为负数时
                {
                    b1.ifnegative = false;
                    BigInteger b3 = b2 - b1;
                    b1.ifnegative = true;
                    return b3;
                }
                else//当b2为负数时
                {
                    b2.ifnegative = false;
                    BigInteger b3 = b1 - b2;
                    b2.ifnegative = true;
                    return b3;
                }
            }

        }
        public static BigInteger operator -(BigInteger b1, BigInteger b2)//减法
        {
            BigInteger output = new BigInteger("");
            BigInteger b3 = b1;
            BigInteger b4 = b2;
            output.length = b3.length > b4.length ? b3.length : b4.length;//取两数字长度间较大值
            if ((b3.ifnegative == false) && (b4.ifnegative == false))
            {
                if (b3 > b4 || !(b1 > b2) && !(b1 < b2))
                {
                    for (int i = 0; i < output.length; i++)
                    {
                        if (b3.number[i] < b4.number[i])
                        {
                            b3.number[i] += 10;
                            b3.number[i + 1] -= 1;
                        }
                        output.number[i] = (b3.number[i] - b4.number[i]) % 10;
                    }
                }
                else //如果小减大则反过来减最后加'-'号
                {
                    output = b4 - b3;
                    output.ifnegative = true;//如果是b1<b2那么两数相减的结果为负
                }
                for (int i = output.length - 1; i > 0; i--)//检查差的高位是否为0，如果是0要将 output 的 length 减少    最高位是(output.length-1)
                {
                    if (output.number[i] == 0)
                    {
                        output.length--;
                        break;
                    }
                    break;
                }
                return output;
            }
            if ((b3.ifnegative == true) && (b4.ifnegative == true))
            {
                b3.ifnegative = !b3.ifnegative;
                b4.ifnegative = !b4.ifnegative;
                output = b3 - b4;
                return output;
            }
            else
            {
                b4.ifnegative = !b4.ifnegative;
                output = b3 + b4;
                b4.ifnegative = !b4.ifnegative;
                return output;
            }
        }
        public static bool operator >(BigInteger b1, BigInteger b2)//若b1比b2大则返回true，否则返回false(相等也返回false)
        {
            bool result = true; //假设 b1 比 b2 大
            if(b1.ifnegative == b2.ifnegative)//两数字符号相同的情况
            {
                if(b1.length == b2.length)//两符号相同的数字长度相同的情况
                {
                    for(int i = b1.length - 1; i > 0; i--)// 若检测到b1 第i位数字小于b2该位数字则返回false
                    {
                        if (b1.number[i] < b2.number[i])
                        {
                            result = false;
                            break;
                        }
                    }
                }
                if (b1.length > b2.length) result = true;
                else result = false;
                if (b1.ifnegative == true) result = !result; //如果为负数则反转符号
            }
            if (b1.ifnegative == false) result = true;
            else result = false;
            return result;
        }
        public static bool operator <(BigInteger b1, BigInteger b2)//若b1比b2小则返回true，否则返回false（相等也返回false）
        {
            if (b1 > b2 || b1 == b2) return false;
            else return true;

        }
        public static bool operator ==(BigInteger b1, BigInteger b2)
        {
            bool result = false;
            if (b1.length == b2.length)
            {
                result = true;
                for (int i = b1.length; i > 0; i--)
                {
                    if (b1.number[i] != b2.number[i])//检查每一位，如果有一位不相同则返回值位false
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }
        public static bool operator !=(BigInteger b1, BigInteger b2)
        {
            if (b1 == b2) return false;
            else return true;
        }
    }
}
