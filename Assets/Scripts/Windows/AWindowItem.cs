using Factories;

namespace Windows
{
    public abstract class AWindowItem<T> : AObjectPoolItem where T : AWindowItemData
    {
        public abstract void Init(T data);
    }
}
