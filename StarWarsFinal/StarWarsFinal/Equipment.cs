namespace StarWarsFinal
{
    class Equipment : Gun
    {
        protected int additionalFeature;
        public int attribute { get; set; }
        public string description;

        public Equipment(string name = "null", int price = 0, string type = "offensive", int condition = 100, int attribute = 0, int additionalFeature = 0)
        {
            this.name = name;
            this.price = price;
            this.type = type;
            this.condition = condition;
            this.attribute = attribute;
            this.additionalFeature = additionalFeature;
            this.description = " name: " + this.name + " price: " + this.price + " attribute: " + this.attribute + " condition: " + this.condition + " feature: " + additionalFeature;
        }

        public int getPrice()
        {
            return price;
        }

        public int Attack()
        {
            int x = 0;

            if (this.type != "Defensive")
            {
                x = (int)(this.attribute * (this.condition * 0.01));
                if (condition >= 5)
                {
                    this.condition -= 5;
                }
            }

            return x;
        }

        public int Defense()
        {
            int x = 0;

            if (this.type == "Defensive")
            {

                x = (int)(this.attribute * (this.condition * 0.01));
                if (condition >= 10)
                {
                    this.condition -= 10;
                }
            }

            return x;

        }


    }

}
