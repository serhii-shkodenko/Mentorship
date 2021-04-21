namespace Lecture3.Oo
{
    public class SuperObject : IFlyable, ISwimable
    {
        public void SuperAction()
        {
            var newObject = new SuperObject();
            ((IFlyable)newObject).Action();
        }
    }
}