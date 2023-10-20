namespace Meliora.DataLayer.Model
{
    public class ProductMixinMap
    {
        public int MapId { get; set; }
        public int MixinId { get; set; }
        public virtual Mixins? Mixin { get; set; }
    }
}
