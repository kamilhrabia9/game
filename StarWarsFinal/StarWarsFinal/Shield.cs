namespace StarWarsFinal
{
    class Shield : Defensive
    {
        int shieldLevel;

        public Shield(string name, int price, int condition, int defence, int shieldLevel)
        {
            this.name = name;
            this.price = price;
            this.condition = condition;
            this.defence = defence;
            this.shieldLevel = shieldLevel;
        }

        public void Show()
        {
            ShowDefInfo("shield level", this.shieldLevel);
        }

        public Equipment Transmit()
        {
            Equipment item;
            return item = TransmitDef(this.shieldLevel);

        }
    }
}
