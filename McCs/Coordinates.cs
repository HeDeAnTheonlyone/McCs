
namespace McCs;

public struct Coordinates
{
   public readonly double x;
   public readonly double y;
   public readonly double z;

   public Coordinates(double x, double y, double z)
   {
      this.x = x;
      this.y = y;
      this.z = z;
   }
   public Coordinates()
   {
      this.x = 0;
      this.y = 0;
      this.z = 0;
   }
}