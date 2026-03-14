//https://github.com/thanhdnh/DSA_HKD2026_CY001_B004
class Program
{
    static int SeqSearch(int[] arr, int value){
        int i = 0;
        while(arr[i]!=value)
            i++;
        return i;
    }
    static int SentSearch(int[] arr, int value){
        int temp = arr[arr.Length-1];
        arr[arr.Length-1] = value;
        int ind = SeqSearch(arr, value);
        arr[arr.Length-1] = temp;
        if(ind<arr.Length-1)
            return ind;
        else{
            if(arr[arr.Length-1]==value)
                return arr.Length-1;
            else
                return -1;
        }
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
        else{
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
    //Bài 1. Xây dựng RecuSearch3(Array, int)
    //Trong đó, mảng được chia thành 2 phần đều nhau
    
    static int BinSearch(int[] sarr, int left, int right, int value)
    {
        while(left<=right){
            int mid = (left+right)/2;
            if(value==sarr[mid])
                return mid;
            else if (value > sarr[mid])
                left = mid + 1; //Tìm bên phải
            else
                right = mid - 1; //Tìm bên trái
        }
        return -1;
    }
    static int BinSearchRecu(int[] sarr, int left, int right, int value)
    {
        if(left>right) return -1;
        int mid = (left+right)/2;
        if(value==sarr[mid])
            return mid;
        else if(value>sarr[mid])
            return BinSearchRecu(sarr, mid+1, right, value);
        else
            return BinSearchRecu(sarr, left, mid-1, value);
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

        int x = 11;
        int index4 = SentSearch(input, x);
        Console.WriteLine($"SentSearch: {index4}");

        int[] sorted = {2, 3, 6, 9, 11};
        v = 9;
        int index5 = BinSearch(sorted, 0, 
                                sorted.Length-1, v);
        Console.WriteLine($"BinSearch: {index5}");

        int index6 = BinSearchRecu(sorted, 0, sorted.Length-1, v);
        Console.Write($"BinSearchRecu: {index6}");
    }
}