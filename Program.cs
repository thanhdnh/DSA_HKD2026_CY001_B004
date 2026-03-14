class Program
{
    static int SeqSearch(int[] arr, int value){
        int i = 0;
        while(arr[i]!=value)
            i++;
        return i;
    }
    static int RecuSearch(int[] arr, int from, int value)
    {
        if(arr[from]==value)
            return from; 
        else
            return RecuSearch(arr, from+1, value);
    }
    static int RecuSearch2(Array arr, int value)
    {
        //first = Chỉ số Phần tử đầu tiên
        //Nếu arr[first]==value -> return first
        //Ngược lại:
        //      - newarr = arr loại bỏ phần tử đầu
        //      - Tìm kiếm trên newarr
        int first = arr.GetLowerBound(0);
        if((int)arr.GetValue(first)==value)
            return first;
        else
        {
            Array newarr = Array.CreateInstance(
                                typeof(int),
                                new int[]{arr.Length-1},
                                new int[]{first+1}
                           );
            for(int i=newarr.GetLowerBound(0);
                i<=newarr.GetUpperBound(0); i++)
                    newarr.SetValue(arr.GetValue(i), i);
            return RecuSearch2(newarr, value);
        }
    }
    static void Main(string[] args){
        int[] input = {3, 1, 9, 7}; int v = 9;
        int index1 = SeqSearch(input, v);
        Console.WriteLine($"SeqSearch: {index1}");

        int index2 = RecuSearch(input, 0, v);
        Console.WriteLine($"RecuSearch: {index2}");

        Array input2 = Array.CreateInstance(
            typeof(int), 4
        );
        input2.SetValue(3, 0); input2.SetValue(1, 1);
        input2.SetValue(9, 2); input2.SetValue(7, 3);
        int index3 = RecuSearch2(input2, v);
        Console.WriteLine($"RecuSearch2: {index3}");
    }
}