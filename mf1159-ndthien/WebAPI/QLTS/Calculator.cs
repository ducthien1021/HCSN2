namespace QLTS
{
    public class Calculator
    {
        public long Add(int x, int y)
        {
            return x + (long)y;
        }

        public long Add(string s)
        {
            long sum = 0;
            string[] numStr = s.Split(',');

            // Tìm kiếm số âm và ném Exception
            List<string> numberInvalid = new List<string>();
            List<string> numberInvalidNumberFormat = new List<string>();
            List<long> numberIsValid = new List<long>();

            foreach (var item in numStr)
            {
                if (item != "")
                {
                    bool isParseSuccess = Int64.TryParse(item, out long number);
                    if (isParseSuccess)
                    {
                        numberIsValid.Add(number);
                    }
                    else
                    {
                        numberInvalidNumberFormat.Add(item);
                    }

                    if (isParseSuccess && number < 0)
                    {
                        numberInvalid.Add(item);
                    }
                }
            }

            var result = String.Join(", ", numberInvalidNumberFormat.ToArray());
            if (result.Length > 0)
            {
                throw new Exception("Các chuỗi không phải là số: " + result);
            }

            result = String.Join(", ", numberInvalid.ToArray());
            if (result.Length > 0)
            {
                throw new Exception("Không chấp nhận toán tử âm: " + result);
            }

            // Thực hiện tính tổng
            foreach (var item in numberIsValid)
            {
                sum += item;
            }
            return sum;
        }

        public long Sub(int x, int y)
        {
            return x - (long)y;
        }

        public long Mul(int x, int y)
        {
            return x * (long)y;
        }

        public double Div(int x, int y)
        {
            if (y == 0)
            {
                throw new Exception("Không chia được cho 0");
            }
            return x / (double)y;
        }
    }
}
