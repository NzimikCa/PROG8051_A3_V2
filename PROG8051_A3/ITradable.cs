namespace PROG8051_A3_ITradable
{
    public interface ITradable
    {
        // Methods
        // Buy Shares - string: sharename, decimal: quantity, string: percentage
        // Buy Goods - xstring: goodsname, decimal: goodsamount, string: goodsunit
        void Buy(string name, decimal quantity, string parameter);
        void Sell(string name, decimal quantity);
    }
}
