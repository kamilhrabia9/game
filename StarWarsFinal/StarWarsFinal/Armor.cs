namespace StarWarsFinal
{
    class Armor : Defensive
    {
        int armorLevel;

        public Armor(string name, int price, int condition, int defence, int armorLevel)
        {
            this.name = name;
            this.price = price;
            this.condition = condition;
            this.defence = defence;
            this.armorLevel = armorLevel;
        }

        public void Show()
        {
            ShowDefInfo("armor level", this.armorLevel);
        }


        public Equipment Transmit()
        {
            Equipment item;
            return item = TransmitDef(this.armorLevel);

        }
    }
}
