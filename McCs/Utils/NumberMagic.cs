
namespace McCs.Utils;

public static class NumberMagic
{
   public static int[] GetNumberRange(int start, int end)
   {
      int[] range = new int[end - start + 1];

      for (int i = start; i <= end; i++)
         range[i - start] = i;

      return range;
   }
}